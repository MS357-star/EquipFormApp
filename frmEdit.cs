using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace EquipFormApp
{
    public partial class frmEdit : Form
    {

        private readonly string connectionString = "Data Source=192.168.3.19;Initial Catalog=Times26;User ID=JouhouGiken;Password=System26;TrustServerCertificate=True";

        // ★変更点1：メイン画面から全部のデータを受け取るための「ポケット」を増やす
        public string SelectedEquipmentId { get; set; }
        public string SelectedEquipmentName { get; set; }
        public string SelectedCategoryName { get; set; }
        public string SelectedQuantity { get; set; }
        public string SelectedLocation { get; set; }
        public string SelectedNote { get; set; }

        public frmEdit()
        {
            InitializeComponent();
        }

        private void frmEdit_Load(object sender, EventArgs e)
        {
            LoadCategoryCombo();

            if (string.IsNullOrEmpty(SelectedEquipmentId))
            {
                if (cmbCategory.Items.Count > 0)
                {
                    cmbCategory.SelectedIndex = 0;
                }
            }
            else
            {

                txtEquipId.Text = SelectedEquipmentId;
                txtEquipId.Enabled = false;

                txtEquipName.Text = SelectedEquipmentName;
                cmbCategory.Text = SelectedCategoryName;
                txtEquipSum.Text = SelectedQuantity;
                txtEquipFrom.Text = SelectedLocation;
                txtRem.Text = SelectedNote;
            }

        }

        private void LoadCategoryCombo()
        {
            string sql = "SELECT CategoryCode, CategoryName FROM M_Category ORDER BY CategoryCode";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            cmbCategory.DataSource = dt;
                            cmbCategory.DisplayMember = "CategoryName";
                            cmbCategory.ValueMember = "CategoryCode";
                            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"カテゴリの読み込みに失敗しました。\n{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            txtEquipId.Text = txtEquipId.Text.Trim();
            txtEquipName.Text = txtEquipName.Text.Trim();
            cmbCategory.Text = cmbCategory.Text.Trim();
            txtEquipSum.Text = txtEquipSum.Text.Trim();


            // 備品IDのチェック
            if (string.IsNullOrWhiteSpace(txtEquipId.Text))
            {
                MessageBox.Show("備品IDを入力してください。", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEquipId.Focus();
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEquipId.Text, @"^[a-zA-Z0-9]{6}$"))
            {
                MessageBox.Show("備品IDは半角英数字6桁で入力してください。（例：EQ0001）", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEquipId.Focus();
                return;
            }

            // 備品名のチェック
            if (string.IsNullOrWhiteSpace(txtEquipName.Text))
            {
                MessageBox.Show("備品名を入力してください。", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEquipName.Focus();
                return;
            }

            // カテゴリのチェック
            if (string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                MessageBox.Show("カテゴリを入力（選択）してください。", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return;
            }

            // 在庫数のチェック
            if (string.IsNullOrWhiteSpace(txtEquipSum.Text))
            {
                MessageBox.Show("在庫数を入力してください。", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEquipSum.Focus();
                return;
            }
            if (!int.TryParse(txtEquipSum.Text.Replace(",", ""), out int parsedQuantity) || parsedQuantity < 0)
            {
                MessageBox.Show("在庫数には 0 以上の半角数字を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEquipSum.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string executeSql = "";
                    string successMessage = "";


                    string categoryCode = cmbCategory.SelectedValue?.ToString() ?? "";

                    string safeEquipId = txtEquipId.Text.Replace("'", "''");
                    string safeEquipName = txtEquipName.Text.Replace("'", "''");
                    string safeCategoryCode = categoryCode.Replace("'", "''");
                    string safeLocation = txtEquipFrom.Text.Replace("'", "''");
                    string safeNote = txtRem.Text.Replace("'", "''");

                    // ポケットが空っぽなら「新規モード」
                    if (string.IsNullOrEmpty(SelectedEquipmentId))
                    {
                        // 重複チェックも直接埋め込み
                        string checkSql = $"SELECT COUNT(1) FROM M_Equipment WHERE EquipmentId = '{safeEquipId}'";
                        int count = 0;

                        using (SqlCommand checkCmd = new SqlCommand(checkSql, conn))
                        {
                            count = (int)checkCmd.ExecuteScalar();
                        }

                        if (count > 0)
                        {
                            MessageBox.Show("入力された備品IDは既に登録されています。\n別のIDを入力してください。", "重複エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtEquipId.Focus();
                            return;
                        }

                        if (MessageBox.Show("登録してもよろしいですか？", "登録確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        {
                            return;
                        }

                        executeSql = $@"
                        INSERT INTO M_Equipment (EquipmentId, EquipmentName, CategoryCode, Quantity, Location, Note, UpdatedAt) 
                        VALUES (
                        '{safeEquipId}', 
                        N'{safeEquipName}', 
                        '{safeCategoryCode}', 
                        {parsedQuantity}, 
                        N'{safeLocation}', 
                        N'{safeNote}', 
                        GETDATE()
                        )";

                        successMessage = "登録しました。";
                    }
                    else // 「更新（編集）モード」
                    {
                        if (MessageBox.Show("更新してよろしいですか？", "更新確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                        {
                            return;
                        }

                        executeSql = $@"
                        UPDATE M_Equipment SET 
                        EquipmentName = N'{safeEquipName}', 
                        CategoryCode = '{safeCategoryCode}', 
                        Quantity = {parsedQuantity}, 
                        Location = N'{safeLocation}', 
                        Note = N'{safeNote}', 
                        UpdatedAt = GETDATE() 
                        WHERE EquipmentId = '{safeEquipId}'
                        ";

                        successMessage = "更新しました。";
                    }

                    using (SqlCommand cmd = new SqlCommand(executeSql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show(successMessage, "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラーが発生しました：\n" + ex.Message, "システムエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //カンマ
        private void txtEquipSum_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEquipSum.Text))
            {
                string rawSum = txtEquipSum.Text.Replace(",", "");
                if (int.TryParse(rawSum, out int m))
                {
                    txtEquipSum.Text = m.ToString("#,##0");
                }
            }
        }

        private void txtEquipSum_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 0～9の数字以外の入力を無視する
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtEquipSum_TextChanged(object objSender, EventArgs e)
        {
            TextBox tb = (TextBox)objSender;

            string rawText = Microsoft.VisualBasic.Strings.StrConv(tb.Text, Microsoft.VisualBasic.VbStrConv.Narrow, 0);

            string raw = rawText.Replace(",", "");

            if (long.TryParse(raw, out long value))
            {
                int sel = tb.SelectionStart;
                int oldLength = tb.Text.Length;

                tb.Text = value.ToString("#,0");

                int newLength = tb.Text.Length;
                int diff = newLength - oldLength;

                tb.SelectionStart = Math.Max(0, sel + diff);
            }
            else if (string.IsNullOrEmpty(raw))
            {
                tb.Text = "";
            }
        }

        private void txtEquipId_Enter(object sender, EventArgs e)
        {
            txtEquipId.PromptChar = ' ';
            // 非同期（BeginInvoke）を使って、フォーカス移動が完全に終わった後にカーソル位置を動かす
            this.BeginInvoke(new Action(() =>
            {
                string currentText = txtEquipId.Text.Replace(" ", "").Trim();

                if (currentText == "EQ")
                {
                    txtEquipId.SelectionStart = 2;
                }
                {
                    txtEquipId.SelectionStart = txtEquipId.Text.Trim().Length;
                }
            }));

            txtEquipId.BeginInvoke(new Action(() => txtEquipId.Select(2, 6)));
        }

        private void txtEquipId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '０' && e.KeyChar <= '９')
            {
                e.Handled = true;
                return;
            }
            // 0～9の数字以外の入力を無視する
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtEquipId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.F1) btnSave.PerformClick();
            if (e.KeyCode == Keys.F10)
            {
                btnClose.PerformClick();
                SendKeys.Send("");
                e.Handled = true;
            }
        }

        private void frmEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) btnSave.PerformClick();
            if (e.KeyCode == Keys.F10)
            {
                btnClose.PerformClick();
                SendKeys.Send("");
                e.Handled = true;
            }
        }

        /*
        private void txtEquipId_TextChanged(object objSender, EventArgs e)
        {
            Regex regex = new Regex("^[EQ0-9]*$"); // 半角数字の正規表現
            if (!regex.IsMatch(txtEquipId.Text)) // 入力が正規表現にマッチしない場合
            {
                MessageBox.Show("半角数字のみを入力してください。"); // エラーメッセージを表示
                txtEquipId.Text = ""; // 入力をクリア
            }
        }
        */

        private void txtEquipId_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Regex regex = new Regex("^[EQ0-9]*$");

            if (!regex.IsMatch(txtEquipId.Text))
            {
                MessageBox.Show("半角英数字(EQ + 数字)のみを入力してください。");
                txtEquipId.Text = ""; // 入力をクリア
                e.Cancel = true; // フォーカス移動をキャンセル
            }
        }

        private void frmEdit_Activated(object sender, EventArgs e)
        {
            cmbCategory.Focus();
        }
    }
}
