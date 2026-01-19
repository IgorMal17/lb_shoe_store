namespace lb_shoe_store
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool exitProgram = false;

            while (!exitProgram)
            {
                using (var formLogin = new FormLogin())
                {
                    if (formLogin.ShowDialog() == DialogResult.OK)
                    {
                        // Открываем промежуточную форму выбора
                        using (var formChoice = new FormProductsOrOrders(formLogin.CurrentUser, formLogin.IsGuest))
                        {
                            if (formChoice.ShowDialog() == DialogResult.Cancel)
                            {
                                continue;
                            }
                        }
                    }
                    else
                    {
                        exitProgram = true;
                    }
                }
            }
        }
    }
}