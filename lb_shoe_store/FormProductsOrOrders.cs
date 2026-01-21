using lb_shoe_store.Models;
namespace lb_shoe_store
{
    public partial class FormProductsOrOrders : Form
    {
        private User currentUser;
        private bool isGuest;

        public User CurrentUser => currentUser;
        public bool IsGuest => isGuest;

        public FormProductsOrOrders(User user = null, bool guest = true)
        {
            InitializeComponent();
            currentUser = user;
            isGuest = guest;

            currentUser = user;
            isGuest = guest;

            lbUserName.Text = IsGuest ? "Гость" : CurrentUser.FullName;
        }


        private void ProductsBtn_Click(object sender, EventArgs e)
        {
            using (var formProducts = new FormProducts(CurrentUser, IsGuest))
            {
                formProducts.ShowDialog();
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OrdersBtn_Click(object sender, EventArgs e)
        {
            using (var formOrders = new FormOrders(CurrentUser, IsGuest))
            {
                formOrders.ShowDialog();
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
