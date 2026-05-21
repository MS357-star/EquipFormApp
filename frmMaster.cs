using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.CompilerServices.RuntimeHelpers;


namespace EquipFormApp
{
    public partial class frmMaster : Form
    {
        string connectionString = "Data Source=192.168.3.19;Initial Catalog=Times26;User ID=JouhouGiken;Password=System26;TrustServerCertificate=True;";

        public frmMaster()
        {
            InitializeComponent();
        }

        // 3桁の数字かどうか
        bool IsThreeDigit(string v)
        {
            return v != null && v.Length == 3 && v.All(char.IsDigit);
        }

        // カテゴリコードの重複チェック
        private bool IsDuplicateCode(string code)
        {
            string esc(string v) => v?.Replace("'", "''") ?? "";

            string sql = $"SELECT COUNT(*) FROM M_Category WHERE CategoryCode = '{esc(code)}'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    int count = (int)command.ExecuteScalar();
                    return count > 0;   // 1件以上あれば重複
                }
            }
        }

        private bool IsCategoryUsed(string code)
        {
            string esc(string v) => v?.Replace("'", "''") ?? "";

            string sql = $"SELECT COUNT(*) FROM M_Equipment WHERE CategoryCode = '{esc(code)}'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    int count = (int)command.ExecuteScalar();
                    return count > 0; // 1件でも使われていれば true
                }
            }
        }


        private bool ExistsCode(string code)
        {
            string esc(string v) => v?.Replace("'", "''") ?? "";

            string sql = $"SELECT COUNT(*) FROM M_Category WHERE CategoryCode = '{esc(code)}'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // 入力チェック
        private bool IsInvalid(TextBox tb, string msg)
        {
            if (tb.Text.Trim() == String.Empty)
            {
                MessageBox.Show($"{msg}を入力してください", $"{msg}未入力");
                tb.Focus();
                return true;
            }
            return false;
        }

        private void frmMaster_Load(object sender, EventArgs e)
        {
            // カラム数を指定
            dgvCategory.ColumnCount = 3;

            // カラム名を指定
            dgvCategory.Columns[0].HeaderText = "Id";
            dgvCategory.Columns[1].HeaderText = "カテゴリコード";
            dgvCategory.Columns[2].HeaderText = "カテゴリ名";

            dgvCategory.Columns[0].Width = 50;
            dgvCategory.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCategory.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvCategory.Rows.Clear();
            // 接続成功時の処理
            try
            {
                // 3 SqlConnectionのインスタンスを作成
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    int intCount = 1;
                    // 4 接続
                    connection.Open();

                    string sql = "SELECT CategoryCode, CategoryName FROM M_Category";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int intId = intCount;
                                string strCode = reader["CategoryCode"].ToString();
                                string strName = reader["CategoryName"].ToString();

                                dgvCategory.Rows.Add(intId, strCode, strName);

                                //lblTable.Text += $"ID: {intId}, CODE: {strCode}, 名前: {strName}, 略: {strRyaku}" + "\n";
                                //Console.WriteLine($"ID: {id}, 名前: {name}, 年齢: {age}");
                                intCount++;
                            }
                        }
                    }

                }
            }
            catch (SqlException ex) // Exception を SqlException にすると詳細が取れる
            {
                //MSGで表示
                MessageBox.Show($"エラー番号: {ex.Number} / メッセージ: {ex.Message}");
            }
        }

        // 行選択時にテキストボックスへ反映
        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCateCode.Text = dgvCategory.Rows[e.RowIndex].Cells[1].Value?.ToString();
                txtCateName.Text = dgvCategory.Rows[e.RowIndex].Cells[2].Value?.ToString();
            }
        }

        // エスケープ関数（シングルクォートを二重化）
        string esc(string v) => v?.Replace("'", "''") ?? "";

        // 追加処理
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (IsInvalid(txtCateCode, "カテゴリコード")) return;
            if (IsInvalid(txtCateName, "カテゴリ名")) return;


            // 3桁チェック
            if (!IsThreeDigit(txtCateCode.Text))
            {
                MessageBox.Show("コードは3桁の数字で入力してください。");
                return;
            }

            // 重複チェック
            if (IsDuplicateCode(txtCateCode.Text))
            {
                MessageBox.Show("このカテゴリコードは既に登録されています。");
                return;
            }

            string sql = $@"INSERT INTO M_Category (CategoryCode, CategoryName) VALUES ('{esc(txtCateCode.Text)}', '{esc(txtCateName.Text)}')";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            MessageBox.Show("追加しました。");
            frmMaster_Load(null, null);
        }

        // 更新処理
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            string CateCode = txtCateCode.Text;

            // ★ ここで存在チェック
            if (!ExistsCode(CateCode))
            {
                MessageBox.Show("このカテゴリコードは登録されていません。");
                return;
            }

            if (IsInvalid(txtCateCode, "カテゴリコード")) return;
            if (IsInvalid(txtCateName, "カテゴリ名")) return;
            // 3桁チェック
            if (!IsThreeDigit(CateCode))
            {
                MessageBox.Show("コードは3桁の数字で入力してください。");
                return;
            }






            if (dgvCategory.CurrentRow == null) return;
            string code = dgvCategory.CurrentRow.Cells[1].Value.ToString();

            string sql = $"UPDATE M_Category SET CategoryName = '{esc(txtCateName.Text)}' WHERE CategoryCode = '{esc(code)}'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            MessageBox.Show("更新しました。");
            frmMaster_Load(null, null);
        }

        // 削除処理
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategory.CurrentRow == null) return;

            if (IsInvalid(txtCateCode, "カテゴリコード")) return;

            if (!ExistsCode(txtCateCode.Text))
            {
                MessageBox.Show("このカテゴリコードは登録されていません。");
                return;
            }

            if (IsCategoryUsed(txtCateCode.Text))
            {
                MessageBox.Show("このカテゴリは備品に紐づいているため削除できません。");
                return;
            }

            var result = MessageBox.Show("削除しますか？", "確認", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string sql = $"DELETE FROM M_Category WHERE CategoryCode = '{esc(txtCateCode.Text)}'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("削除しました。");
                frmMaster_Load(null, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtCateCode_Leave(object sender, EventArgs e)
        {
            // 空欄なら何もしない
            if (string.IsNullOrWhiteSpace(txtCateCode.Text)) return;

            // 3桁ゼロ埋め
            txtCateCode.Text = txtCateCode.Text.PadLeft(3, '0');
        }

        private void txtCateCode_KeyDown(object sender, KeyEventArgs e)
        {
            //数字のみ入力可能にする
            if (!char.IsControl((char)e.KeyCode) && !char.IsDigit((char)e.KeyCode))
            {
                e.SuppressKeyPress = true; // 入力を無効にする
            }
        }
    }
}
