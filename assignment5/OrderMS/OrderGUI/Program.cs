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
            User.Users.Add(new User(1, "Tester", true));
            User.Users.Add(new User(2, "Bob", false));
        }
    }
}