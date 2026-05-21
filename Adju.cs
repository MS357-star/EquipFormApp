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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace EquipFormApp
{
    public partial class Adju : Form
    {

        private readonly string connectionString = "Data Source=192.168.3.19;Initial Catalog=Times26;User ID=JouhouGiken;Password=System26;TrustServerCertificate=True";
        public string SelectedEquipmentId { get; set; }
        public string SelectedEquipmentName { get; set; }
        public string SelectedQuantity { get; set; }

        public Adju()
        {
            InitializeComponent();
        }

        private void Adju_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("備品ID");
            dt.Columns.Add("備品名");
            dt.Columns.Add("現在の在庫数");

            dt.Rows.Add(SelectedEquipmentId, SelectedEquipmentName, SelectedQuantity);

            dgvStock.DataSource = dt;

            dgvStock.ReadOnly = true;
            dgvStock.AllowUserToAddRows = false;
            dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            cmbAdjuUnder.Items.Clear();
            cmbAdjuUnder.Items.Add("払い出し");
            cmbAdjuUnder.Items.Add("補充");
            cmbAdjuUnder.Items.Add("棚卸調整");
            cmbAdjuUnder.Items.Add("紛失・破損");

            cmbAdjuUnder.SelectedIndex = 0;

            cmbAdjuUnder.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // 「閉じる」ボタンが押された時の処理
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            txtAdjuSum.Text = txtAdjuSum.Text.Trim();

            //  必須入力チェック
            if (string.IsNullOrWhiteSpace(txtAdjuSum.Text))
            {
                MessageBox.Show("調整数を入力してください。", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdjuSum.Focus();
                return; 
            }

            if (!int.TryParse(txtAdjuSum.Text, out int adjustNum))
            {
                MessageBox.Show("調整数には半角数字（整数）を入力してください。\n払い出しの場合はマイナス（-）を付けて入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdjuSum.Focus();
                return;
            }

            // 在庫割れチェック
            int currentStock = int.Parse(SelectedQuantity);
            int afterStock = currentStock + adjustNum;

            if (afterStock < 0)
            {
                MessageBox.Show($"在庫不足です。\n現在の在庫数（{currentStock}）に対して、調整数（{adjustNum}）を適用すると0未満になってしまうため、処理を中断します。", "在庫エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdjuSum.Focus();
                return;
            }

            if (MessageBox.Show("在庫調整を確定してもよろしいですか？", "確定確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return; 
            }

            // 全てのチェックをクリアした後の処理
            try
            { 
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        string safeEquipId = SelectedEquipmentId.Replace("'", "''");

                        // M_Equipmentの在庫数を更新するSQL
                        string updateSql = $@"
                                UPDATE M_Equipment 
                                SET Quantity = {afterStock}, 
                                    UpdatedAt = GETDATE() 
                                WHERE EquipmentId = '{safeEquipId}'
                            ";

                        using (SqlCommand cmd = new SqlCommand(updateSql, conn, tx))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();

                        MessageBox.Show($"在庫調整が完了しました。\n新しい在庫数は {afterStock} です。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK; 
                        this.Close(); 
                    }
                    catch (Exception innerEx)
                    {
                        tx.Rollback();

                        throw new Exception("データベースの更新中にエラーが発生したため、処理を取り消しました。\n" + innerEx.Message);
                    }
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラーが発生しました：\n" + ex.Message, "システムエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}

