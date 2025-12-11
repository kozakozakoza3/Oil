using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oil
{
    public partial class OilLotForm : Form
    {
        public OilLot OilLot { get; set; }

        public OilLotForm()
        {
            InitializeComponent();
        }

        private void OilLotForm_Load(object sender, EventArgs e)
        {
            if (OilLot != null && OilLot.Id > 0) // Режим редактирования
            {
                txtLotNumber.Text = OilLot.LotNumber;
                dtpExtractionDate.Value = OilLot.ExtractionDate;
                txtColor.Text = OilLot.Color;
                txtFraction.Text = OilLot.Fraction;
                txtDensity.Text = OilLot.Density;
                txtViscosity.Text = OilLot.Viscosity;
                txtSulfurContent.Text = OilLot.SulfurContent;
                txtOilfield.Text = OilLot.Oilfield;
                txtRegion.Text = OilLot.Region;
                Text = "Редактировать партию нефти";
            }
            else // Режим добавления
            {
                OilLot = new OilLot();
                Text = "Добавить партию нефти";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                OilLot.LotNumber = txtLotNumber.Text;
                OilLot.ExtractionDate = dtpExtractionDate.Value;
                OilLot.Color = txtColor.Text;
                OilLot.Fraction = txtFraction.Text;
                OilLot.Density = txtDensity.Text;
                OilLot.Viscosity = txtViscosity.Text;
                OilLot.SulfurContent = txtSulfurContent.Text;
                OilLot.Oilfield = txtOilfield.Text;
                OilLot.Region = txtRegion.Text;

                // Сохраняем в БД
                string query;
                if (OilLot.Id > 0)
                {
                    // UPDATE
                    query = $"UPDATE oil_lot SET " +
                           $"lot_number = '{OilLot.LotNumber}', " +
                           $"extraction_date = '{OilLot.ExtractionDate:yyyy-MM-dd}', " +
                           $"color = '{OilLot.Color}', " +
                           $"fraction = '{OilLot.Fraction}', " +
                           $"density = '{OilLot.Density}', " +
                           $"viscosity = '{OilLot.Viscosity}', " +
                           $"sulfur_content = '{OilLot.SulfurContent}', " +
                           $"oilfield = '{OilLot.Oilfield}', " +
                           $"region = '{OilLot.Region}' " +
                           $"WHERE oil_lot_id = {OilLot.Id}";
                }
                else
                {
                    // INSERT
                    query = $"INSERT INTO oil_lot (lot_number, extraction_date, color, fraction, density, viscosity, sulfur_content, oilfield, region) " +
                           $"VALUES ('{OilLot.LotNumber}', '{OilLot.ExtractionDate:yyyy-MM-dd}', '{OilLot.Color}', '{OilLot.Fraction}', " +
                           $"'{OilLot.Density}', '{OilLot.Viscosity}', '{OilLot.SulfurContent}', '{OilLot.Oilfield}', '{OilLot.Region}')";
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
            if (string.IsNullOrWhiteSpace(txtLotNumber.Text))
            {
                MessageBox.Show("Введите номер партии", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLotNumber.Focus();
                return false;
            }
            return true;
        }
    }
}
