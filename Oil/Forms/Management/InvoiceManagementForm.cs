using Oil.Helpers;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Oil.Models;

namespace Oil.Forms.Management
{
    public partial class InvoiceManagementForm : Form
    {
        public InvoiceManagementForm()
        {
            InitializeComponent();
        }

        private void LoadInvoices()
        {
            string query = @"
                SELECT 
                    i.invoice_id,
                    no.organization_name as counterparty_name,
                    e.last_name || ' ' || e.name || ' ' || COALESCE(e.middle_name, '') as employee_name,
                    t.train_name,
                    fp.final_point_name as destination,
                    CONCAT(i.distance, ' ', i.unit_of_measure) as distance_info,
                    CONCAT(opl.lot_size, ' ', opl.unit_of_measure) as lot_size_info,
                    i.date_time_compliation_invoice as invoice_date,
                    COALESCE(rs.status_name, 'Не назначен') as route_status,
                    COALESCE(r.date_time_sending::date::text, 'Не отправлено') as sending_date,
                    COALESCE(r.date_time_arrival::date::text, 'Не прибыло') as arrival_date
                FROM invoice i
                LEFT JOIN counterparty cp ON i.counterparty_id = cp.counterparty_id
                LEFT JOIN name_organization no ON cp.name_organization_id = no.name_organization_id
                LEFT JOIN employee e ON i.employee_id = e.employee_id
                LEFT JOIN train t ON i.train_id = t.train_id
                LEFT JOIN final_point fp ON i.final_point_id = fp.final_point_id
                LEFT JOIN oil_product_lot opl ON i.oil_product_lot_id = opl.oil_product_lot_id
                LEFT JOIN invoice_route ir ON i.invoice_id = ir.invoice_id
                LEFT JOIN route r ON ir.route_id = r.route_id
                LEFT JOIN route_status rs ON r.route_status_id = rs.route_status_id
                ORDER BY i.date_time_compliation_invoice DESC";

            DataTable dt = DbMethods.GetData(query);
            dgvInvoices.DataSource = dt;

            if (dgvInvoices.Columns.Count > 0)
            {
                dgvInvoices.Columns["invoice_id"].Visible = false;
                dgvInvoices.Columns["counterparty_name"].HeaderText = "Контрагент";
                dgvInvoices.Columns["employee_name"].HeaderText = "Ответственный сотрудник";
                dgvInvoices.Columns["train_name"].HeaderText = "Поезд";
                dgvInvoices.Columns["destination"].HeaderText = "Пункт назначения";
                dgvInvoices.Columns["distance_info"].HeaderText = "Расстояние";
                dgvInvoices.Columns["lot_size_info"].HeaderText = "Объем партии";
                dgvInvoices.Columns["invoice_date"].HeaderText = "Дата создания накладной";
                dgvInvoices.Columns["route_status"].HeaderText = "Статус маршрута";
                dgvInvoices.Columns["sending_date"].HeaderText = "Дата отправки";
                dgvInvoices.Columns["arrival_date"].HeaderText = "Дата прибытия";

                // Форматирование даты
                if (dgvInvoices.Columns.Contains("invoice_date"))
                {
                    dgvInvoices.Columns["invoice_date"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                }
            }
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            LoadInvoices();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvInvoices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите накладную для печати");
                return;
            }

            DataGridViewRow row = dgvInvoices.SelectedRows[0];
            int invoiceId = Convert.ToInt32(row.Cells["invoice_id"].Value);

            // Получаем полные данные для накладной
            string query = $@"
                SELECT 
                    i.invoice_id,
                    no.organization_name as counterparty_name,
                    e.last_name || ' ' || e.name || ' ' || COALESCE(e.middle_name, '') as employee_full_name,
                    p.post_name as employee_position,
                    t.train_name,
                    fp.final_point_name as destination,
                    i.starting_point as starting_point,
                    CONCAT(i.distance, ' ', i.unit_of_measure) as distance,
                    opn.product_name,
                    m.mark_name,
                    CONCAT(opl.lot_size, ' ', opl.unit_of_measure) as lot_size,
                    i.date_time_compliation_invoice as invoice_date,
                    COALESCE(r.date_time_sending, i.date_time_compliation_invoice) as sending_date,
                    COALESCE(r.date_time_arrival, i.date_time_compliation_invoice) as arrival_date,
                    COALESCE(rs.status_name, 'Не отправлено') as route_status
                FROM invoice i
                LEFT JOIN counterparty cp ON i.counterparty_id = cp.counterparty_id
                LEFT JOIN name_organization no ON cp.name_organization_id = no.name_organization_id
                LEFT JOIN employee e ON i.employee_id = e.employee_id
                LEFT JOIN post p ON e.post_id = p.post_id
                LEFT JOIN train t ON i.train_id = t.train_id
                LEFT JOIN final_point fp ON i.final_point_id = fp.final_point_id
                LEFT JOIN oil_product_lot opl ON i.oil_product_lot_id = opl.oil_product_lot_id
                LEFT JOIN oil_product op ON opl.oil_product_id = op.oil_product_id
                LEFT JOIN oil_product_name opn ON op.oil_product_name_id = opn.oil_product_name_id
                LEFT JOIN mark m ON op.mark_id = m.mark_id
                LEFT JOIN invoice_route ir ON i.invoice_id = ir.invoice_id
                LEFT JOIN route r ON ir.route_id = r.route_id
                LEFT JOIN route_status rs ON r.route_status_id = rs.route_status_id
                WHERE i.invoice_id = {invoiceId}";

            DataTable dt = DbMethods.GetData(query);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Не найдены данные для печати");
                return;
            }

            DataRow data = dt.Rows[0];

            // Создаем объект с данными для печати
            InvoicePrintData printData = new InvoicePrintData
            {
                InvoiceId = invoiceId,
                InvoiceNumber = $"ИНВ-{invoiceId.ToString().PadLeft(6, '0')}",
                CounterpartyName = data["counterparty_name"].ToString(),
                EmployeeName = data["employee_full_name"].ToString(),
                EmployeePosition = data["employee_position"].ToString(),
                TrainName = data["train_name"].ToString(),
                StartingPoint = data["starting_point"].ToString(),
                Destination = data["destination"].ToString(),
                Distance = data["distance"].ToString(),
                ProductName = data["product_name"].ToString(),
                ProductMark = data["mark_name"].ToString(),
                LotSize = data["lot_size"].ToString(),
                InvoiceDate = Convert.ToDateTime(data["invoice_date"]),
                SendingDate = SafeConverter.ToNullableDateTime(data["sending_date"]),
                ArrivalDate = SafeConverter.ToNullableDateTime(data["arrival_date"]),
                RouteStatus = data["route_status"].ToString(),
                PrintDateTime = DateTime.Now
            };

            // Создаем принтер и печатаем
            InvoicePrinter printer = new InvoicePrinter();
            printer.ShowPrintDialog(printData);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadInvoices();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}