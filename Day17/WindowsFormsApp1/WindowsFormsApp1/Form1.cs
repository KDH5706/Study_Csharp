using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string Constr = "Server=(local);database=ADOTest;" +
                "Integrated Security=true";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text == "" | this.txtYear.Text == "" | this.txtPrice.Text == "" | this.txtDoor.Text == "")
            {
                MessageBox.Show("입력되지 않은 정보가 있습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string Data = "(";
            Data += "'" + this.txtName.Text + "', ";
            Data += "'" + this.txtYear.Text + "', ";
            Data += this.txtPrice.Text + ", ";
            Data += this.txtDoor.Text + ")";

            SqlConnection Conn = new SqlConnection(Constr);
            Conn.Open();
            SqlCommand Command = new SqlCommand("INSERT INTO TB_CAR_INFO VALUES " + Data, Conn);
            Command.ExecuteNonQuery();
            Conn.Close();

            MessageBox.Show("정상적으로 데이터가 저장되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadAllData();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("수정할 데이터를 선택하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.txtName.Text == "" | this.txtYear.Text == "" | this.txtPrice.Text == "" | this.txtDoor.Text == "")
            {
                MessageBox.Show("입력되지 않은 정보가 있습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int SelectRow = listView1.SelectedItems[0].Index;

            string Set_Value = "";
            Set_Value += "carName = '" + txtName.Text + "', ";
            Set_Value += "carYear = '" + txtYear.Text + "', ";
            Set_Value += "carPrice = '" + txtPrice.Text + "', ";
            Set_Value += "carDoor = '" + txtDoor.Text + "'";

            string Conditional = listView1.Items[SelectRow].SubItems[0].Text;

            SqlConnection Conn = new SqlConnection(Constr);
            Conn.Open();
            SqlCommand Command = new SqlCommand("UPDATE TB_CAR_INFO SET " + Set_Value +
                " WHERE id = " + Conditional, Conn);
            Command.ExecuteNonQuery();
            Conn.Close();

            listView1.Items[SelectRow].SubItems[1].Text = txtName.Text;
            listView1.Items[SelectRow].SubItems[2].Text = txtYear.Text;
            listView1.Items[SelectRow].SubItems[3].Text = txtPrice.Text;
            listView1.Items[SelectRow].SubItems[4].Text = txtDoor.Text;

            listView1.Update();

            MessageBox.Show("정상적으로 데이터가 수정되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnConSearch_Click(object sender, EventArgs e)
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();
            ListViewItem Data;
            string Conditional = "";

            if (this.txtName.Text != "")
                Conditional += " or carName = '" + this.txtName.Text + "'";
            if (this.txtYear.Text != "")
                Conditional += " or carYear = '" + this.txtYear.Text + "'";
            if (this.txtPrice.Text != "")
                Conditional += " or carPrice = '" + this.txtPrice.Text + "'";
            if (this.txtDoor.Text != "")
                Conditional += " or carDoor = '" + this.txtDoor.Text + "'";

            SqlConnection Conn = new SqlConnection(Constr);
            Conn.Open();

            SqlCommand Command = new SqlCommand("SELECT * FROM TB_CAR_INFO WHERE 1=0" + Conditional, Conn);

            var Colums = Command.ExecuteReader();
            while (Colums.Read())
            {
                Data = new ListViewItem(Colums[0].ToString());
                Data.SubItems.Add(Colums[1].ToString());
                Data.SubItems.Add(Colums[2].ToString());
                Data.SubItems.Add(Colums[3].ToString());
                Data.SubItems.Add(Colums[4].ToString());

                listView1.Items.Add(Data);
            }
            listView1.EndUpdate();
            Conn.Close();
        }

        private void btnTotalSearch_Click(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int SelectRow = listView1.SelectedItems[0].Index;

                string Name = listView1.Items[SelectRow].SubItems[1].Text;
                string Year = listView1.Items[SelectRow].SubItems[2].Text;
                string Price = listView1.Items[SelectRow].SubItems[3].Text;
                string Door = listView1.Items[SelectRow].SubItems[4].Text;

                this.txtName.Text = Name;
                this.txtYear.Text = Year;
                this.txtPrice.Text = Price;
                this.txtDoor.Text = Door;
            }
        }

        private void 삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("데이터를 삭제할까요?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                int SelectRow = listView1.SelectedItems[0].Index;

                string Name = listView1.Items[SelectRow].SubItems[1].Text;
                string Year = listView1.Items[SelectRow].SubItems[2].Text;
                string Price = listView1.Items[SelectRow].SubItems[3].Text;
                string Door = listView1.Items[SelectRow].SubItems[4].Text;

                string Conditional = "";
                Conditional += " AND carName = '" + Name + "'";
                Conditional += " AND carYear = '" + Year + "'";
                Conditional += " AND carPrice = '" + Price + "'";
                Conditional += " AND carDoor = '" + Door + "'";

                SqlConnection Conn = new SqlConnection(Constr);
                Conn.Open();

                SqlCommand Command = new SqlCommand("DELETE TB_CAR_INFO WHERE 1=1" + Conditional, Conn);
                Command.ExecuteNonQuery();
                Conn.Close();

                listView1.SelectedItems[0].Remove();
                listView1.Update();
                txt_reset();

                MessageBox.Show("데이터가 정상적으로 삭제되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadAllData()
        {
            txt_reset();
            listView1.BeginUpdate();
            listView1.Items.Clear();
            ListViewItem Data;

            SqlConnection Conn = new SqlConnection(Constr);
            Conn.Open();

            SqlCommand Command = new SqlCommand("SELECT * FROM TB_CAR_INFO", Conn);

            var Colums = Command.ExecuteReader();
            while (Colums.Read())
            {
                Data = new ListViewItem(Colums[0].ToString());
                Data.SubItems.Add(Colums[1].ToString());
                Data.SubItems.Add(Colums[2].ToString());
                Data.SubItems.Add(Colums[3].ToString());
                Data.SubItems.Add(Colums[4].ToString());

                listView1.Items.Add(Data);
            }
            listView1.EndUpdate();
            Conn.Close();
        }

        private void txt_reset()
        {
            this.txtName.Text = "";
            this.txtYear.Text = "";
            this.txtPrice.Text = "";
            this.txtDoor.Text = "";
        }
    }
}
