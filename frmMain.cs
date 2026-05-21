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
                    e.Note          AS [備考]
                FROM 
                    M_Equipment e
                INNER JOIN 
                    M_Category c ON e.CategoryCode = c.CategoryCode";

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
            // 1. 画面の入力値（検索条件）を取得する
            // コンボボックスの ValueMember（CategoryCode）を取得
            string selectedCategory = cmbCategory.SelectedValue?.ToString();

            // テキストボックスの文字を取得（前後の余計な空白を消す）
            string searchName = txtEquip.Text.Trim();

            // 2. ベースとなるSQL文（全件表示の形）
            string sql = @"
                SELECT 
                    e.EquipmentId   AS [備品ID],
                    e.EquipmentName AS [備品名],
                    c.CategoryName  AS [カテゴリ名],
                    e.Quantity      AS [在庫数],
                    e.Location      AS [保管場所],
                    e.Note          AS [備考]
                FROM 
                    M_Equipment e
                INNER JOIN 
                    M_Category c ON e.CategoryCode = c.CategoryCode
                WHERE 1 = 1"; // 条件を後ろに繋げやすくするためのテクニック

            // 3. 条件に応じてSQL文を後ろに付け足していく
            // カテゴリが「（すべて）」の時は選択値が空文字になるよう仕込んであるので、空じゃない時だけ絞り込む
            if (!string.IsNullOrEmpty(selectedCategory))
            {
                sql += " AND e.CategoryCode = @CategoryCode";
            }

            // 備品名が入力されている時だけ、部分一致（LIKE）の条件を追加
            if (!string.IsNullOrEmpty(searchName))
            {
                sql += " AND e.EquipmentName LIKE @EquipmentName";
            }

            // 4. データベースに接続して実行
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // 5. パラメータの値をセットする（SQLインジェクションという脆弱性を防ぐ安全な書き方）
                        if (!string.IsNullOrEmpty(selectedCategory))
                        {
                            cmd.Parameters.AddWithValue("@CategoryCode", selectedCategory);
                        }

                        if (!string.IsNullOrEmpty(searchName))
                        {
                            // 入力された文字の前後に % をくっつけて「部分一致」にする
                            cmd.Parameters.AddWithValue("@EquipmentName", "%" + searchName + "%");
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // データグリッド（dgvEquipment）の表示を新しい結果で上書きする
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

                // 第2画面を開く
                editForm.ShowDialog();
            }

            LoadEquipmentData();
        }
    }
}
