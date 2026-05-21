using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

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

        // 画面が開いた時の処理（Loadイベント）
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

                // 1. 備品IDは入力不可（グレーアウト）にする
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
                            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList; // 手入力を禁止
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"カテゴリの読み込みに失敗しました。\n{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}