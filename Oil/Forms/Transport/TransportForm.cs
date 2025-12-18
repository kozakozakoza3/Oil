using Oil.Helpers;
using System;
using System.Data;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;
using Oil.Forms;
using Oil.Forms.Transport;

namespace Oil
{
    public partial class TransportForm : Form
    {
        public TransportForm()
        {
            InitializeComponent();
        }

        // 1. Управление поездами
        private void btnTrains_Click(object sender, EventArgs e)
        {
            TrainForm form = new TrainForm();
            form.Show();
        }

        // 4. Управление маршрутами
        private void btnRoutes_Click(object sender, EventArgs e)
        {
            RouteForm form = new RouteForm();
            form.Show();
        }

        // 5. Управление накладными
        private void btnInvoices_Click(object sender, EventArgs e)
        {
            InvoiceForm form = new InvoiceForm();
            form.Show();
        }

        // 6. Выход
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}