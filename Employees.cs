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
namespace PETMS
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
            DisplayEmployees();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void PassWord_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void gunaElipsePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (EmpName.Text == "" || EmpAddress.Text == "" || EmpPhone.Text == "" || EmpPassword.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update EmployeeTbl set EmpName=@EN,EmpAdd=@EA,EmpDOB=@ED,EmpPhone=@EP,EmpPass=@Epa Where EmpNum=@Ekey",con);
                    cmd.Parameters.AddWithValue("@EN", EmpName.Text);
                    cmd.Parameters.AddWithValue("@EA", EmpAddress.Text);
                    cmd.Parameters.AddWithValue("@ED", EmpDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@EP", EmpPhone.Text);
                    cmd.Parameters.AddWithValue("@EPa", EmpPassword.Text);
                    cmd.Parameters.AddWithValue("@Ekey", key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Updated |||");
                    con.Close();
                    DisplayEmployees();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

    private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpName.Text = EmployeesDGV.SelectedRows[0].Cells[1].Value.ToString();
            EmpAddress.Text = EmployeesDGV.SelectedRows[0].Cells[2].Value.ToString();
            EmpDOB.Text = EmployeesDGV.SelectedRows[0].Cells[3].Value.ToString();
            EmpPhone.Text = EmployeesDGV.SelectedRows[0].Cells[4].Value.ToString();
            EmpPassword.Text = EmployeesDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (EmpName.Text =="")
            {
                key = 0;
            }
            else 
            {
               int Key = Convert.ToInt32(EmployeesDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Billing Obj = new Billing();
            Obj.Show();
            this.Hide();
        } 

        private void label4_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Product Obj = new Product();
            Obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Homes Obj = new Homes();
            Obj.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            login Obj = new login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select An Employee");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from Employeetbl Where EmpNum = @Empkey", con);
                    cmd.Parameters.AddWithValue("@EmpKey",key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Deleted|||");
                    con.Close();
                    DisplayEmployees();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Documents\PetShopdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void DisplayEmployees()
        {
            con.Open();
            String Query = "SELECT * FROM Employeetbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmployeesDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void clear()
        {
            EmpName.Text = "";
            EmpAddress.Text = "";
            EmpPhone.Text = "";
            EmpPassword.Text = "";
        }
        int key = 0;
        private void bunifuThinButton21_Click_2(object sender, EventArgs e)
        {
            if (EmpName.Text == "" || EmpAddress.Text == "" || EmpPhone.Text == "" || EmpPassword.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into EmployeeTbl(EmpName,EmpAdd,EmpDOB,EmpPhone,EmpPass) values(@EN,@EA,@ED,@EP,@Epa)", con);
                    cmd.Parameters.AddWithValue("@EN", EmpName.Text);
                    cmd.Parameters.AddWithValue("@EA", EmpAddress.Text);
                    cmd.Parameters.AddWithValue("@ED", EmpDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@EP", EmpPhone.Text);
                    cmd.Parameters.AddWithValue("@EPa", EmpPassword.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Added");
                    con.Close();
                    DisplayEmployees();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
    

