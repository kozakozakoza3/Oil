using Oil.Models;
using Oil.Helpers;
using System;
using System.Data;
using System.Windows.Forms;
using Oil.Forms;

namespace Oil
{
    public partial class LaboratoryForm : Form
    {
        public LaboratoryForm()
        {
            InitializeComponent();
        }

        private void btnOil_Click(object sender, EventArgs e)
        {
            OilLotForm form = new OilLotForm();
            form.Show();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            OilProductForm form = new OilProductForm();
            form.Show();
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            LaboratoryAnalysisForm form = new LaboratoryAnalysisForm();
            form.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var authForm = new AuthorizationForm();
            authForm.Show();
        }
    }
}