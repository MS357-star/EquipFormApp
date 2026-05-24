using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

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
            // DataGridViewの処理を削除し、テキストボックスに値をセットする処理に変更
            txtEquipId.Text = SelectedEquipmentId;
            txtEquipId.ReadOnly = true;
            txtEquipId.BackColor = Color.WhiteSmoke;

            txtEquipName.Text = SelectedEquipmentName;
            txtEquipName.ReadOnly = true;
            txtEquipName.BackColor = Color.WhiteSmoke;

            // 在庫数を見やすくカンマ区切りにして表示（元のデータにカンマが無い場合を考慮）
            if (int.TryParse(SelectedQuantity.Replace(",", ""), out int currentQty))
            {
                txtCurrentStock.Text = currentQty.ToString("#,##0");
            }
            else
            {
                txtCurrentStock.Text = SelectedQuantity;
            }
            txtCurrentStock.ReadOnly = true;
            txtCurrentStock.BackColor = Color.WhiteSmoke;

            // コンボボックスの初期設定
            cmbAdjuUnder.Items.Clear();
            cmbAdjuUnder.Items.Add("払い出し");
            cmbAdjuUnder.Items.Add("補充");
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

            // 必須入力チェック
            if (string.IsNullOrWhiteSpace(txtAdjuSum.Text))
            {
                MessageBox.Show("調整数を入力してください。", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdjuSum.Focus();
                return;
            }

            // 入力された文字が数字かチェック
            if (!int.TryParse(txtAdjuSum.Text.Replace(",", ""), out int adjustNum))
            {
                MessageBox.Show("調整数には半角数字（整数）を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdjuSum.Focus();
                return;
            }

            // 入力された数字を「絶対値（プラス）」にする
            int absAdjustNum = Math.Abs(adjustNum);

            int currentStock = int.Parse(SelectedQuantity.Replace(",", ""));
            int afterStock = 0;

            string mode = cmbAdjuUnder.SelectedItem?.ToString() ?? "";

            if (mode == "払い出し")
            {
                afterStock = currentStock - absAdjustNum;
            }
            else if (mode == "補充")
            {
                afterStock = currentStock + absAdjustNum;
            }
            else
            {
                MessageBox.Show("払い出し、または補充を選択してください。", "選択エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 在庫割れチェック
            if (afterStock < 0)
            {
                MessageBox.Show($"在庫不足です。\n現在の在庫数（{currentStock}）に対して、払い出し数（{absAdjustNum}）が多すぎるため、処理を中断します。", "在庫エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdjuSum.Focus();
                return;
            }

            // 上限オーバーチェック
            if (afterStock > 99999)
            {
                MessageBox.Show($"在庫数の上限オーバーです。\n補充後の合計が5桁（99,999）を超えることはできません。\n（現在の在庫数：{currentStock}）", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdjuSum.Focus();
                return;
            }

            // 最終確認
            if (MessageBox.Show($"{mode}処理を確定してもよろしいですか？\n（調整後の在庫数：{afterStock}）", "確定確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

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

        private void txtAdjuSum_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 1. スペースは弾く
            if (e.KeyChar == ' ' || e.KeyChar == ' ')
            {
                e.Handled = true;
                return;
            }

            // 2. コンボボックスが「払い出し」の時だけ、マイナス記号の入力を許可する
            string mode = cmbAdjuUnder.SelectedItem?.ToString() ?? "";
            if (mode == "払い出し")
            {
                // 半角マイナス '-' と、全角マイナス '－' の入力を許可（スルーさせる）
                if (e.KeyChar == '-' || e.KeyChar == '－')
                {
                    return;
                }
            }

            // 3. 数字と制御文字（BackSpace等）以外は弾く
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAdjuSum_Leave(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(txtAdjuSum.Text))
            {
                string inputText = txtAdjuSum.Text;

                // ★全角マイナス「－」や長音「ー」も半角マイナス「-」に変換できるように配列に追加
                string[] zenkaku = { "０", "１", "２", "３", "４", "５", "６", "７", "８", "９", "－", "ー" };
                string[] hankaku = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "-", "-" };

                for (int i = 0; i < zenkaku.Length; i++)
                {
                    inputText = inputText.Replace(zenkaku[i], hankaku[i]);
                }

                string rawSum = inputText.Replace(",", "").Replace(" ", "").Replace(" ", "");

                // ★【追加】もし「補充」モードなのにコピペ等でマイナスが入っていたら、強制的に消し去る
                string mode = cmbAdjuUnder.SelectedItem?.ToString() ?? "";
                if (mode == "払い出し")
                {
                    // ★払い出しの時：文字が空じゃなくて、マイナスが先頭についていなければ付ける
                    // （ユーザーが最初から「-150」と打ってくれていた場合はそのまま）
                    if (rawSum.Length > 0 && !rawSum.StartsWith("-"))
                    {
                        rawSum = "-" + rawSum;
                    }
                }
                else
                {
                    // ★補充の時：マイナスが入ってしまっていたら強制的に消す
                    rawSum = rawSum.Replace("-", "");
                }

                if (int.TryParse(rawSum, out int m))
                {
                    txtAdjuSum.Text = m.ToString("#,##0");
                }
            }
        }

        private void Adju_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btnEnter.PerformClick();
            }

            if (e.KeyCode == Keys.F10)
            {
                btnClose.PerformClick();
                SendKeys.Send("Tab");
                e.Handled = true;
            }
        }
    }
}
