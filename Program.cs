namespace BT5_2_StudentRegistration
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new RegistrationForm());
        }
    }
}