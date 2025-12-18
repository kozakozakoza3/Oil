using Oil.Models;
using Oil.Helpers;
using System;
using System.Data;
using System.Windows.Forms;
using Oil.Forms;

namespace Oil
{
    public partial class StorageForm : Form
    {
        // Конструктор по умолчанию (без параметров)
        public StorageForm()
        {
            InitializeComponent();
        }

        private void btnTanks_Click(object sender, EventArgs e)
        {
            // Форма для работы с резервуарами
            TankForm form = new TankForm();
            form.Show();
        }

        private void btnOilLots_Click(object sender, EventArgs e)
        {
            // Форма для партий нефти на складе
            OilLotInStorageForm form = new OilLotInStorageForm();
            form.Show();
        }

        private void btnProductLots_Click(object sender, EventArgs e)
        {
            // Форма для партий нефтепродуктов на складе
            OilProductInStorageForm form = new OilProductInStorageForm();
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