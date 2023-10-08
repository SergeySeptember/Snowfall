namespace Snowfall
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.ThreadException += new ThreadExceptionEventHandler(Exception);
            Application.Run(new MainForm());
        }

        private static void Exception(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show("Если видишь это окно, сделай скрин и скниь горе-разрабу\n" + e.Exception.ToString());
        }
    }
}