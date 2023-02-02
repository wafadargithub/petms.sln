using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PETMS
{
    public partial class Homes : Form
    {
        public Homes()
        {
            InitializeComponent();
            CountDogs();
            CountBirds();
            CountCats();
            Finance();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Homes Obj = new Homes();
            Obj.Show();
            this.Hide();
        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void gunaCircleProgressBar1_Click(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Documents\PetShopdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void CountDogs()
        {
            String Cat = "Dog";
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From ProductTbl where PrCat='" + Cat + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DogsLbl.Text = dt.Rows[0][0].ToString();
            con.Close();
        }
        private void Finance()
        { 
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select sum(Amt) From BillTbl", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            FinanceLbl.Text = dt.Rows[0][0].ToString();
            con.Close();
        }
        private void CountBirds()
        {
            String Cat = "Birds";
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From ProductTbl where PrCat='" + Cat + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BirdsLbl.Text = dt.Rows[0][0].ToString();
            con.Close();
        }
        private void CountCats()
        {
            String Cat = "Cat";
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From ProductTbl where PrCat='" + Cat + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CatsLbl.Text = dt.Rows[0][0].ToString();
            con.Close();
        }
        private void label6_Click(object sender, EventArgs e)
        {
            login Obj = new login();
            Obj.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DogsLbl_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Product Obj = new Product();
            Obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Billing Obj = new Billing();
            Obj.Show();
            this.Hide();
        }
    }
}
