using lb_shoe_store.Models;
using Microsoft.EntityFrameworkCore;

namespace lb_shoe_store
{
    public partial class FormOrders : System.Windows.Forms.Form
    {
        private User currentUser;
        private bool isGuest;

        public User CurrentUser
        {
            get => currentUser;
            private set => currentUser = value;
        }

        public bool IsGuest
        {
            get => isGuest;
            private set => isGuest = value;
        }

        public FormOrders(User user = null, bool guest = true)
        {
            InitializeComponent();
            SetupDataGridViewColumns();
            CurrentUser = user;
            IsGuest = guest;
            lbUserName.Text = IsGuest ? "Гость" : CurrentUser.FullName ?? "Пользователь";
            LoadData();
        }

        private void SetupDataGridViewColumns()
        {
            dgvOrders.Columns.Clear();
            var colInfo = new DataGridViewTextBoxColumn
            {
                Name = "colInfo",
                HeaderText = "Информация",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = { WrapMode = DataGridViewTriState.True }
            };
            var colStatus = new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "Статус",
                FillWeight = 15,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };
            dgvOrders.Columns.AddRange(new DataGridViewColumn[] { colInfo, colStatus });
        }

        private void LoadData()
        {
            try
            {
                using var db = new ShoeStoreContext();
                dgvOrders.SuspendLayout();
                dgvOrders.Rows.Clear();
                LoadAllOrders(db);
                dgvOrders.ResumeLayout();
                dgvOrders.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllOrders(ShoeStoreContext db)
        {
            var orders = db.Orders
                .Include(o => o.DeliveryPoint)
                .Include(o => o.Status)
                .Include(o => o.ProductsOrders)
                .ThenInclude(po => po.Product)
                .OrderByDescending(o => o.OrderDate)
                .Take(20)
                .ToList();
            foreach (var order in orders)
            {
                int rowIndex = dgvOrders.Rows.Add();
                var row = dgvOrders.Rows[rowIndex];
                var firstProduct = order.ProductsOrders.FirstOrDefault()?.Product;
                row.Cells["colInfo"].Value = FormatOrderInfo(order);
                row.Cells["colStatus"].Value = $"Дата доставки: {order.DeliveryDate:dd.MM.yyyy}";
                ApplyOrderRowStyles(row, order);
            }
        }

        private void ApplyOrderRowStyles(DataGridViewRow row, Order order)
        {
            switch (order.IdStatuses)
            {
                case 1:
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                    break;
                case 2:
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF2CC");
                    break;
                case 3:
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    break;
                case 4:
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D5E8D4");
                    break;
                case 5:
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                    break;
            }
        }

        private string FormatOrderInfo(Order order)
        {
            decimal totalSum = 0;
            string productsList = "Нет товаров";

            if (order.ProductsOrders != null && order.ProductsOrders.Any())
            {
                totalSum = order.ProductsOrders.Sum(po =>
                    po.Product.Price * po.Quantity * (100m - po.Product.Discount) / 100m);
                productsList = string.Join(", ",
                    order.ProductsOrders.Take(3).Select(po =>
                        $"{po.Product.Art} x{po.Quantity}"));

                if (order.ProductsOrders.Count > 3)
                    productsList += "...";
            }

            string deliveryAddress = "Неизвестно";
            if (order.DeliveryPoint != null)
                deliveryAddress = order.DeliveryPoint.DeliveryAddress;
            return $"Заказ №{order.Code}" + Environment.NewLine +
                   $"Дата заказа: {order.OrderDate:dd.MM.yyyy}" + Environment.NewLine +
                   $"Адрес пункта выдачи: {deliveryAddress}" + Environment.NewLine +
                   $"Статус заказа: {order.Status.StatusName ?? "Неизвестно"}" + Environment.NewLine +
                   $"Товары: {productsList}" + Environment.NewLine +
                   $"Сумма: {totalSum:C}";
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
