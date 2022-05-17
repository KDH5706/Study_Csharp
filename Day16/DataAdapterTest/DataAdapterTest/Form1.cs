using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DataAdapterTest
{
    public partial class Form1 : Form
    {
        private SqlConnection Con;
        private SqlDataAdapter Adpt;
        DataTable tblPeople;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Con = new SqlConnection();
            Con.ConnectionString = "Server=(local);database=ADOTest DB;" +
                "Integrated Security=true";
            //Con.Open() 불필요
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Adpt = new SqlDataAdapter("SELECT * FROM tblPeople", Con);
            tblPeople = new DataTable("tblPeople");

            tblPeople.ColumnChanged +=
                new DataColumnChangeEventHandler(tblPeople_ColumnChanging);

            /*
            SqlCommand cmd;
            cmd = new SqlCommand("INSERT INTO tblPeople VALUES (@Name, @Age, @Male)",
                Con);
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 10, "Name");
            cmd.Parameters.Add("@Age", SqlDbType.Int, 0, "Age");
            cmd.Parameters.Add("@Male", SqlDbType.Bit, 0, "Male");
            Adpt.InsertCommand = cmd;

            cmd = new SqlCommand("UPDATE tblPeople SET Name=@Name,Age=@Age," +
                "Male=@Male WHERE Name = @OldName", Con);
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 10, "Name");
            cmd.Parameters.Add("@Age", SqlDbType.Int, 0, "Age");
            cmd.Parameters.Add("@Male", SqlDbType.Bit, 0, "Male");
            cmd.Parameters.Add("@OldName", SqlDbType.NVarChar, 10, "Name");
            cmd.Parameters["@OldName"].SourceVersion = DataRowVersion.Original;
            Adpt.UpdateCommand = cmd;

            cmd = new SqlCommand("DELETE FROM tblPeople WHERE Name = @Name", Con);
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 10, "Name");
            Adpt.DeleteCommand = cmd;
            */

            //*
            /*
             * 1. 하나의 테이블을 대상으로 해야 함. JOIN 쿼리문은 사용할 수 없음.
             * 2. select 문의 컬럼 리스트에 반드시 기본키의 컬럼이 있어야 함.
             */
            SqlCommandBuilder Builder = new SqlCommandBuilder(Adpt);
            //*

            Adpt.Fill(tblPeople);
            dataGridView1.DataSource = tblPeople;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Adpt.Update(tblPeople);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnOpen_Click(sender, e);
            }
        }

        void tblPeople_ColumnChanging(object sender, DataColumnChangeEventArgs e)
        {
            if(e.Column.ColumnName == "Age")
            {
                if ((int)e.ProposedValue < 0 || (int)e.ProposedValue > 100)
                    e.Row.SetColumnError("Age", "나이는 0 ~ 100 사이만 가능합니다.");
                else
                    e.Row.SetColumnError("Age", "");            
            }
        }
    }
}
