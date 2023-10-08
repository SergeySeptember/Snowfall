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
            MessageBox.Show("���� ������ ��� ����, ������ ����� � ����� ����-�������\n" + e.Exception.ToString());
        }
    }
}