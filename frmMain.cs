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

        private void SetGridDesign()
        {
            if (dgvEquipCate.Columns.Count == 0) return;
            dgvEquipCate.EnableHeadersVisualStyles = false;
            dgvEquipCate.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSkyBlue;
            dgvEquipCate.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEquipCate.RowHeadersDefaultCellStyle.BackColor = Color.LightSkyBlue;
            dgvEquipCate.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvEquipCate.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;


            dgvEquipCate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvEquipCate.Columns.Contains("備品ID"))
            {
                dgvEquipCate.Columns["備品ID"].FillWeight = 70;       // かなり狭め
                dgvEquipCate.Columns["備品名"].FillWeight = 150;      // 広く
                dgvEquipCate.Columns["カテゴリ名"].FillWeight = 90;   // やや狭め
                dgvEquipCate.Columns["在庫数"].FillWeight = 70;       // かなり狭め
                dgvEquipCate.Columns["保管場所"].FillWeight = 100;    // 標準
                dgvEquipCate.Columns["備考"].FillWeight = 150;        // 広く
                dgvEquipCate.Columns["最終更新日時"].FillWeight = 100; // 日付が入るピッタリサイズ
            }

            if (dgvEquipCate.Columns.Contains("備品ID"))
            {
                dgvEquipCate.Columns["備品ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvEquipCate.Columns.Contains("在庫数"))
            {
                dgvEquipCate.Columns["在庫数"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvEquipCate.Columns["在庫数"].DefaultCellStyle.Format = "#,##0";
            }

            //最終更新日のフォーマット中央に寄せる
            if (dgvEquipCate.Columns.Contains("最終更新日時"))
            {
                dgvEquipCate.Columns["最終更新日時"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvEquipCate.Columns["最終更新日時"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";
            }

            foreach (DataGridViewColumn col in dgvEquipCate.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                string originalName = col.HeaderText.TrimStart();

                // 列ごとにスペースの量を調整
                switch (originalName)
                {
                    case "備品ID":
                        col.HeaderText = "      " + originalName;
                        break;
                    case "備品名":
                    case "在庫数":
                    case "備考":
                        col.HeaderText = "     " + originalName;
                        break;
                    case "カテゴリ名":
                    case "保管場所":
                        col.HeaderText = "   " + originalName;
                        break;
                    case "最終更新日時":
                        col.HeaderText = "   " + originalName;
                        break;
                    default:
                        col.HeaderText = "    " + originalName;
                        break;
                }
            }
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

                        SetGridDesign();
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

                            DataRow row = dt.NewRow();
                            row["CategoryCode"] = "";
                            row["CategoryName"] = "（すべて）";
                            dt.Rows.InsertAt(row, 0);

                            cmbCategory.DataSource = dt;

                            cmbCategory.DisplayMember = "CategoryName";

                            cmbCategory.ValueMember = "CategoryCode";

                            cmbCategory.SelectedIndex = 0;

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
                    e.UpdatedAt     AS [最終更新日時] 
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
                            SetGridDesign();
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
            if (dgvEquipCate.CurrentRow == null)
            {
                MessageBox.Show("変更する備品を選択してください。", "エラー");
                return;
            }

            DataGridViewRow row = dgvEquipCate.CurrentRow;

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
            if (dgvEquipCate.CurrentRow == null)
            {
                MessageBox.Show("在庫調整する備品を選択してください。", "エラー",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvEquipCate.CurrentRow;

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
        private void dgvList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();

            Rectangle rect = new Rectangle(
                e.RowBounds.Left,
                e.RowBounds.Top,
                dgvEquipCate.RowHeadersWidth,
                e.RowBounds.Height);

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString(strRowNumber, dgvEquipCate.Font, Brushes.Black, rect, format);
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            btnInsert.Focus();
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btnInsert.PerformClick();
            }

            if (e.KeyCode == Keys.F3)
            {
                btnEdit.PerformClick();
            }

            if (e.KeyCode == Keys.F5)
            {
                btnAdju.PerformClick();
            }

            if (e.KeyCode == Keys.F7)
            {
                btnMaster.PerformClick();
            }

            if (e.KeyCode == Keys.F9)
            {
                btnSearch.PerformClick();
            }
        }
    }
}
