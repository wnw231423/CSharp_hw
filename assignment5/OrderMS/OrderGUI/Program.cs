namespace OrderGUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Init();
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }

        static void Init() {
            User tester = new User(1, "Tester", true);
            User bob = new User(2, "Bob", false);
            User.Users.Add(tester);
            User.Users.Add(bob);

            Good apple = new Good("Æ»¹û", 1.99);
            OrderDetails orderDetails = new OrderDetails();
            orderDetails.AddGood(apple, 2);
            Order order = new Order(tester, DateTime.Now, orderDetails);
            OrderService.TotalOrders.Add(order);
        }
    }
}