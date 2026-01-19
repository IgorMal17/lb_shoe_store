using lb_shoe_store.Models;
using lb_shoe_store.Properties;
using Microsoft.EntityFrameworkCore;
namespace lb_shoe_store
{
    public partial class FormProducts : System.Windows.Forms.Form
    {

        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }

        public FormProducts(User user, bool guest)
        {
            InitializeComponent();

            var colPhoto = new DataGridViewImageColumn();
            colPhoto.Name = "Фото";
            colPhoto.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colPhoto.Width = 200;
            colPhoto.FillWeight = 30;

            var colInfo = new DataGridViewTextBoxColumn();
            colInfo.Name = "Информация";
            colInfo.FillWeight = 60;
            colInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;


            var colDiscount = new DataGridViewTextBoxColumn();
            colDiscount.Name = "Скидка";
            colDiscount.FillWeight = 10;
            colDiscount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvProducts.Columns.AddRange(
            [
                colPhoto, colInfo, colDiscount
            ]);

            CurrentUser = user;
            IsGuest = guest;

            lbUserName.Text = IsGuest ? "Гость" : CurrentUser.FullName;

            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                using (var db = new ShoeStoreContext())
                {
                    var products = db.Products
                        .Include(i => i.Category)
                        .Include(i => i.Manufacturer)
                        .Include(i => i.Supplier)
                        .Include(i => i.Measure)
                        .Include(i => i.ProductType)
                        .ToList();

                    dgvProducts.SuspendLayout();
                    dgvProducts.Rows.Clear();

                    foreach (var product in products)
                    {
                        int rowIndex = dgvProducts.Rows.Add();
                        var row = dgvProducts.Rows[rowIndex];

                        row.Cells["Фото"].Value = LoadProductImage(product.PhotoUrl);

                        row.Cells["Информация"].Value = FormatProductInfo(product);

                        row.Cells["Скидка"].Value = $"{product.Discount}%";
                        row.Cells["Скидка"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        ApplyRowStyles(row, product);
                    }

                    dgvProducts.ResumeLayout();
                    dgvProducts.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyRowStyles(DataGridViewRow row, Product product)
        {
            if (product.Discount > 15)
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2E8B57");
                row.DefaultCellStyle.ForeColor = Color.White;
            }

            if (product.CointInStock <= 0)
            {
                row.DefaultCellStyle.BackColor = Color.LightBlue;
                if (product.Discount <= 15)
                {
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }

            if (product.Discount > 0)
            {
                row.Cells["Скидка"].Style.ForeColor = Color.Red;
                row.Cells["Скидка"].Style.Font = new Font(
                    "Times New Roman",
                    12,
                    FontStyle.Bold);
            }
        }

        private string FormatProductInfo(Product product)
        {
            string priceText;

            if (product.Discount > 0)
            {
                decimal finalPrice = product.Price * (100 - product.Discount) / 100;
                priceText = $"Цена: {product.Price:C} -> {finalPrice:C}";
            }
            else
            {
                priceText = $"Цена: {product.Price:C}";
            }

            return $"{product.Category.CategoryName} | {product.ProductType.ProdType} " + Environment.NewLine +
                $"Описание товара: {product.Description}" + Environment.NewLine +
                $"Производитель: {product.Manufacturer.ManufacturerName}" + Environment.NewLine +
                $"Поставщик: {product.Supplier.SupplierName}" + Environment.NewLine +
                $"{priceText}" + Environment.NewLine +
                $"Единица измерения: {product.Measure.MeasureName}" + Environment.NewLine +
                $"Количество на складе: {product.CointInStock}";
        }

        private Image LoadProductImage(string photoUrl)
        {
            if (!String.IsNullOrEmpty(photoUrl) && System.IO.File.Exists(photoUrl))
            {
                return Image.FromFile(photoUrl);
            }

            return Resources.picture;
        }

        private void BtnLogut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }
    }
}


