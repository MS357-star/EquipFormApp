using Microsoft.Data.SqlClient;
using System.Data;

namespace EquipFormApp
{
    public partial class frmMain : Form
    {
        private readonly string connectionString = "Data Source=192.168.3.19;Initial Catalog=Times26;User ID=JouhouGiken;Password=System26;TrustServerCertificate=True";
        private int rightClickedRowIndex = -1;

        public frmMain()
        {
            InitializeComponent();
        }

        // 画面が開いたときに呼ばれるイベント
        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadCategoryCombo();

            LoadEquipmentData();
        }

        // データベースから一覧を取ってくる処理
        private void LoadEquipmentData()
        {
            string sql = @"
                SELECT 
                    e.EquipmentId   AS [備品ID],
                    e.EquipmentName AS [備品名],
                    c.CategoryName  AS [カテゴリ名],
                    e.Quantity      AS [在庫数],
                    e.Location      AS [保管場所],
                    e.Note          AS [備考],
                    e.UpdatedAt     AS [最終更新日時]
                FROM 
                    M_Equipment e
                INNER JOIN 
                    M_Category c ON e.CategoryCode = c.CategoryCode
                WHERE 1 = 1";

            // DBに接続してデータを取得
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        adapter.Fill(dt);

                        dgvEquipCate.DataSource = dt;
                    }
                }
            }
        }
        private void LoadCategoryCombo()
        {
            // カテゴリコードとカテゴリ名を取得するSQL（コード順に並び替え）
            string sql = "SELECT CategoryCode, CategoryName FROM M_Category ORDER BY CategoryCode";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            // データを格納する箱を用意
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // ★超重要ポイント：検索解除用の「すべて」という行を先頭に手作りで追加する
                            DataRow row = dt.NewRow();
                            row["CategoryCode"] = "";          // 裏側で持つ値は「空文字」
                            row["CategoryName"] = "（すべて）";  // 画面に表示する文字
                            dt.Rows.InsertAt(row, 0);          // 0番目（一番上）に差し込む

                            // コンボボックスにデータを紐付ける
                            cmbCategory.DataSource = dt;

                            // 画面に表示する列（ユーザーが見る文字）
                            cmbCategory.DisplayMember = "CategoryName";

                            // 裏側で保持する値（後で検索する時にプログラムが使うコード）
                            cmbCategory.ValueMember = "CategoryCode";

                            // 初期状態を一番上の「（すべて）」にしておく
                            cmbCategory.SelectedIndex = 0;

                            // （おまけ）ユーザーがキーボードで勝手な文字を入力できないようにする
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



        private void btnSearch_Click(object sender, EventArgs e)
        {
            string selectedCategory = cmbCategory.SelectedValue?.ToString();

            string searchName = txtEquip.Text.Trim();

            string sql = @"
                SELECT 
                    e.EquipmentId   AS [備品ID],
                    e.EquipmentName AS [備品名],
                    c.CategoryName  AS [カテゴリ名],
                    e.Quantity      AS [在庫数],
                    e.Location      AS [保管場所],
                    e.Note          AS [備考],
                    e.UpdatedAt     AS [最終更新日時] -- ★ここを足しました！
                FROM 
                    M_Equipment e
                INNER JOIN 
                    M_Category c ON e.CategoryCode = c.CategoryCode
                WHERE 1 = 1";

            if (!string.IsNullOrEmpty(selectedCategory))
            {
                sql += " AND e.CategoryCode = @CategoryCode";
            }

            if (!string.IsNullOrEmpty(searchName))
            {
                sql += " AND e.EquipmentName LIKE @EquipmentName";
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (!string.IsNullOrEmpty(selectedCategory))
                        {
                            cmd.Parameters.AddWithValue("@CategoryCode", selectedCategory);
                        }

                        if (!string.IsNullOrEmpty(searchName))
                        {
                            cmd.Parameters.AddWithValue("@EquipmentName", "%" + searchName + "%");
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);


                            dgvEquipCate.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"検索中にエラーが発生しました。\nエラー内容: {ex.Message}",
                                "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //登録ボタン
        private void btnInsert_Click(object sender, EventArgs e)
        {
            using (frmEdit form = new frmEdit())
            {
                form.ShowDialog();
            }
            LoadEquipmentData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvEquipCate.SelectedRows.Count == 0)
            {
                MessageBox.Show("変更する備品を選択してください。", "エラー");
                return;
            }

            DataGridViewRow row = dgvEquipCate.SelectedRows[0];

            using (frmEdit editForm = new frmEdit())
            {
                editForm.SelectedEquipmentId = row.Cells["備品ID"].Value?.ToString();
                editForm.SelectedEquipmentName = row.Cells["備品名"].Value?.ToString();
                editForm.SelectedCategoryName = row.Cells["カテゴリ名"].Value?.ToString();
                editForm.SelectedQuantity = row.Cells["在庫数"].Value?.ToString();
                editForm.SelectedLocation = row.Cells["保管場所"].Value?.ToString();
                editForm.SelectedNote = row.Cells["備考"].Value?.ToString();

                editForm.ShowDialog();
            }

            LoadEquipmentData();
        }

        private void btnAdju_Click(object sender, EventArgs e)
        {
            if (dgvEquipCate.SelectedRows.Count == 0)
            {
                MessageBox.Show("在庫調整する備品を選択してください。", "エラー",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvEquipCate.SelectedRows[0];

            using (Adju adjuForm = new Adju())
            {
                adjuForm.SelectedEquipmentId = row.Cells["備品ID"].Value?.ToString();
                adjuForm.SelectedEquipmentName = row.Cells["備品名"].Value?.ToString();
                adjuForm.SelectedQuantity = row.Cells["在庫数"].Value?.ToString();

                adjuForm.ShowDialog();
            }

            LoadEquipmentData();
        }

        private void btnMaster_Click(object sender, EventArgs e)
        {
            using (frmMaster masterForm = new frmMaster())
            {

                masterForm.ShowDialog();
            }


            LoadCategoryCombo();
            LoadEquipmentData();
        }

    }
}
