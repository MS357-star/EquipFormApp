using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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
            dgvEquipCate.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvEquipCate.RowTemplate.Height = 42; 
            dgvEquipCate.DefaultCellStyle.DataSourceNullValue = null;
            dgvEquipCate.ShowCellToolTips = true;

            dgvEquipCate.EnableHeadersVisualStyles = false;
            dgvEquipCate.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvEquipCate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvEquipCate.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSkyBlue;
            dgvEquipCate.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEquipCate.RowHeadersDefaultCellStyle.BackColor = Color.LightSkyBlue;

            // 各列の幅（比率）の調整
            if (dgvEquipCate.Columns.Contains("備品ID"))
            {
                dgvEquipCate.Columns["備品ID"].FillWeight = 70;
                dgvEquipCate.Columns["備品名"].FillWeight = 150;
                dgvEquipCate.Columns["カテゴリ名"].FillWeight = 90;
                dgvEquipCate.Columns["在庫数"].FillWeight = 70;
                dgvEquipCate.Columns["保管場所"].FillWeight = 100;
                dgvEquipCate.Columns["備考"].FillWeight = 150;
                dgvEquipCate.Columns["最終更新日時"].FillWeight = 120;
            }

            string[] leftCols = { "備品名", "カテゴリ名", "保管場所", "備考" };
            foreach (string colName in leftCols)
            {
                if (dgvEquipCate.Columns.Contains(colName))
                {
                    dgvEquipCate.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }

            //中央揃えにする列
            string[] centerCols = { "備品ID", "最終更新日時" };
            foreach (string colName in centerCols)
            {
                if (dgvEquipCate.Columns.Contains(colName))
                {
                    dgvEquipCate.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

            //右揃えにする列（在庫数）
            if (dgvEquipCate.Columns.Contains("在庫数"))
            {
                dgvEquipCate.Columns["在庫数"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvEquipCate.Columns["在庫数"].DefaultCellStyle.Format = "#,##0";
            }
            if (dgvEquipCate.Columns.Contains("最終更新日時"))
            {
                dgvEquipCate.Columns["最終更新日時"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";
            }

            dgvEquipCate.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            foreach (DataGridViewColumn col in dgvEquipCate.Columns)
            {
                col.HeaderText = col.HeaderText.Trim();
                col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }


            dgvEquipCate.ColumnHeadersDefaultCellStyle.Padding = new Padding(18, 0, 0, 0);
            foreach (DataGridViewRow row in dgvEquipCate.Rows)
            {
                row.Height = 42;
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

                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("該当するものはありませんでした。", "検索結果", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (!string.IsNullOrEmpty(searchName))
                                {
                                    txtEquip.Clear();
                                    btnSearch.PerformClick();
                                    txtEquip.Focus();
                                }
                                else
                                {
                                    LoadEquipmentData();
                                    txtEquip.Focus();
                                }
                            }
                        }
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"検索中にエラーが発生しました。\nエラー内容: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("在庫調整する備品を選択してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            txtEquip.Focus();
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) btnInsert.PerformClick();
            if (e.KeyCode == Keys.F3) btnEdit.PerformClick();
            if (e.KeyCode == Keys.F5) btnAdju.PerformClick();
            if (e.KeyCode == Keys.F7) btnMaster.PerformClick();
            if (e.KeyCode == Keys.F9) btnSearch.PerformClick();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F10)
            {
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgvEquipCate_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.Value == null) return;

            string[] targetColumns = { "備品名", "カテゴリ名", "保管場所", "備考" };

            if (dgvEquipCate.Columns[e.ColumnIndex] == null) return;
            string columnName = dgvEquipCate.Columns[e.ColumnIndex].Name;
            if (!targetColumns.Contains(columnName)) return;

            e.Paint(e.ClipBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

            StringFormat sf = new StringFormat(StringFormatFlags.LineLimit);
            sf.Alignment = StringAlignment.Near;          
            sf.LineAlignment = StringAlignment.Center;    
            sf.Trimming = StringTrimming.EllipsisCharacter; 
            Brush brush = (e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected
                ? new SolidBrush(e.CellStyle.SelectionForeColor)
                : new SolidBrush(e.CellStyle.ForeColor);

            RectangleF textRect = new RectangleF(e.CellBounds.X + 3, e.CellBounds.Y, e.CellBounds.Width - 6, e.CellBounds.Height);

            e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, brush, textRect, sf);

            brush.Dispose();
            sf.Dispose();
            e.Handled = true;
        }
    }
}
