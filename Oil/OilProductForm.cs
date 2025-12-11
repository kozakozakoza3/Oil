using Oil.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Oil
{
    public partial class OilProductForm : Form
    {
        public OilProduct OilProduct { get; set; }

        public OilProductForm()
        {
            InitializeComponent();
        }

        private void OilProductForm_Load(object sender, EventArgs e)
        {
            if (OilProduct != null && OilProduct.Id > 0)
            {
                txtName.Text = OilProduct.Name;
                txtMark.Text = OilProduct.Mark;
                txtApplication.Text = OilProduct.Application;
                txtDangerClass.Text = OilProduct.DangerClass;
                txtFraction.Text = OilProduct.Fraction;
                dtpManufactureDate.Value = OilProduct.ManufactureDate;
                dtpExpirationDate.Value = OilProduct.ExpirationDate;
                Text = "Редактировать нефтепродукт";
            }
            else
            {
                OilProduct = new OilProduct();
                Text = "Добавить нефтепродукт";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                OilProduct.Name = txtName.Text;
                OilProduct.Mark = txtMark.Text;
                OilProduct.Application = txtApplication.Text;
                OilProduct.DangerClass = txtDangerClass.Text;
                OilProduct.Fraction = txtFraction.Text;
                OilProduct.ManufactureDate = dtpManufactureDate.Value;
                OilProduct.ExpirationDate = dtpExpirationDate.Value;

                string query;
                if (OilProduct.Id > 0)
                {
                    query = $"UPDATE oil_products SET " +
                           $"name = '{OilProduct.Name}', " +
                           $"mark = '{OilProduct.Mark}', " +
                           $"application = '{OilProduct.Application}', " +
                           $"danger_class = '{OilProduct.DangerClass}', " +
                           $"fraction = '{OilProduct.Fraction}', " +
                           $"manufacture_date = '{OilProduct.ManufactureDate:yyyy-MM-dd}', " +
                           $"expiration_date = '{OilProduct.ExpirationDate:yyyy-MM-dd}' " +
                           $"WHERE oil_product_id = {OilProduct.Id}";
                }
                else
                {
                    query = $"INSERT INTO oil_products (name, mark, application, danger_class, fraction, manufacture_date, expiration_date) " +
                           $"VALUES ('{OilProduct.Name}', '{OilProduct.Mark}', '{OilProduct.Application}', '{OilProduct.DangerClass}', " +
                           $"'{OilProduct.Fraction}', '{OilProduct.ManufactureDate:yyyy-MM-dd}', '{OilProduct.ExpirationDate:yyyy-MM-dd}')";
                }

                if (Oil.Helpers.DbMethods.Execute(query))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            return true;
        }
    }
}