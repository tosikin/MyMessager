using MyMessager;
namespace WindowsFormsClient
{
    internal static class Program
    {
        static int MessageId;
        static string UserName;
        static MessangerClientAPI API = new MessangerClientAPI();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}