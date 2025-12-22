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
        // ОРИГИНАЛЬНЫЙ КОНСТРУКТОР (не меняем!)
        public LaboratoryForm()
        {
            InitializeComponent();
        }

        // ===== ДОБАВЛЯЕМ ДЛЯ ТЕСТОВ =====

        // 1. Делаем методы открытия форм публичными
        public Form OpenOilLotForm()
        {
            OilLotForm form = new OilLotForm();
            form.Show();
            return form;
        }

        public Form OpenOilProductForm()
        {
            OilProductForm form = new OilProductForm();
            form.Show();
            return form;
        }

        public Form OpenLaboratoryAnalysisForm()
        {
            LaboratoryAnalysisForm form = new LaboratoryAnalysisForm();
            form.Show();
            return form;
        }

        // 2. Метод для получения формы авторизации
        public Form GetAuthorizationForm()
        {
            return new AuthorizationForm();
        }

        // ===== ОРИГИНАЛЬНЫЕ ОБРАБОТЧИКИ (не меняем!) =====

        private void btnOil_Click(object sender, EventArgs e)
        {
            OpenOilLotForm();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            OpenOilProductForm();
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            OpenLaboratoryAnalysisForm();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var authForm = new AuthorizationForm();
            authForm.Show();
            this.Hide(); // если нужно скрыть текущую форму
        }
    }
}