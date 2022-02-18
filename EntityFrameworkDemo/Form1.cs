using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();

        }

        private void LoadProducts()
        {
            dgwProducts.DataSource = productDal.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            productDal.Add(new Product
            {
                Name = txtName.Text,
                UnitPrice=Convert.ToDecimal(txtUnitPrice.Text),
                StockAmount = Convert.ToInt32(txtStockAmount.Text)
            });
            LoadProducts();
            MessageBox.Show("Added");

        }

        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            productDal.Update(new Product 
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = txtNameUpdate.Text,
                UnitPrice = Convert.ToDecimal(txtUnitPriceUpdate.Text),
                StockAmount = Convert.ToInt32(txtStockAmountUpdate.Text)

            });
            LoadProducts();
            MessageBox.Show("Updated");

        }

        private void dgwProducts_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            txtUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            txtStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            productDal.Delete(new Product
            {

                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
            });

            LoadProducts();
            MessageBox.Show("Deleted");
        }
    }
}
