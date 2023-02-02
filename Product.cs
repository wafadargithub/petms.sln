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
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
            DisplayProduct();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

        }

        private void PassWord_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Billing Obj = new Billing();
            Obj.Show();
            this.Hide();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Documents\PetShopdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void DisplayProduct()
        {
            con.Open();
            String Query = "SELECT * FROM Producttbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProductDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void clear()
        {
            PrNametb.Text = "";
            Cattb.SelectedIndex = 0;
            Qtytb.Text = "";
            Pricetb.Text = "";
        }
        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (PrNametb.Text == "" || Cattb.SelectedIndex == -1 || Qtytb.Text == "" || Pricetb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ProductTbl(PrName,PrCat,PrQty,PrPrice) values(@PN,@PC,@PQ,@PP)", con);
                    cmd.Parameters.AddWithValue("@PN", PrNametb.Text);
                    cmd.Parameters.AddWithValue("@PC", Cattb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PQ", Qtytb.Text);
                    cmd.Parameters.AddWithValue("@PP", Pricetb.Text);
                  
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Added");
                    con.Close();
                    DisplayProduct();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int key = 0;
        private void ProductDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PrNametb.Text = ProductDGV.SelectedRows[0].Cells[1].Value.ToString();
            Cattb.Text = ProductDGV.SelectedRows[0].Cells[2].Value.ToString();
            Qtytb.Text = ProductDGV.SelectedRows[0].Cells[3].Value.ToString();
            Pricetb.Text = ProductDGV.SelectedRows[0].Cells[4].Value.ToString();
            if (PrNametb.Text == "")
            {
                key = 0;
            }
            else
            {
                int Key = Convert.ToInt32(ProductDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select A Product");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from Producttbl Where Prid=@Pkey", con);
                    cmd.Parameters.AddWithValue("@PKey", key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Deleted|||");
                    con.Close();
                    DisplayProduct();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Editbtn_Click(object sender, EventArgs e)
        {
            if (PrNametb.Text =="" || Cattb.SelectedIndex == -1 || Qtytb.Text == "" || Pricetb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update ProductTbl set PrName=@PN,PrCat=@PC,PrQty=@PQ,PrPrice=@PP where Prid=@PKey", con);
                    cmd.Parameters.AddWithValue("@PN", PrNametb.Text);
                    cmd.Parameters.AddWithValue("@PC", Cattb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PQ", Qtytb.Text);
                    cmd.Parameters.AddWithValue("@PP", Pricetb.Text);
                    cmd.Parameters.AddWithValue("@PKey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Edited");
                    con.Close();
                    DisplayProduct();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Homes Obj = new Homes();
            Obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            login Obj = new login();
            Obj.Show();
            this.Hide();
        }
    }
}
