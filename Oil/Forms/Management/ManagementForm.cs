using Oil.Forms;
using Oil.Forms.Management;
using Oil.Helpers;
using Oil.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace Oil.Management
{
    public partial class ManagementForm : Form
    {
        public ManagementForm(string login)
        {
            InitializeComponent();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            EmployeeForm form = new EmployeeForm();
            form.Show();
        }

        private void btnCounterparties_Click(object sender, EventArgs e)
        {
            CounterpartyForm form = new CounterpartyForm();
            form.Show();
        }

        private void btnLabReports_Click(object sender, EventArgs e)
        {
            LaboratoryAnalysisForm form = new LaboratoryAnalysisForm();
            form.Show();
        }

        private void btnInvoices_Click(object sender, EventArgs e)
        {
            InvoiceReportManagementForm form = new InvoiceReportManagementForm();
            form.Show();
        }

        private void btnStorage_Click(object sender, EventArgs e)
        {
            StorageForm form = new StorageForm();
            form.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var authForm = new AuthorizationForm();
            authForm.Show();
            this.Close();
        }
    }
}