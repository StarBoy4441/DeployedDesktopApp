using System;
using System.IO;
using System.Windows.Forms;
using WindowsFormsApp;

static class Program
{
    [STAThread]
    static void Main()
    {
        // Handle UI thread exceptions
        Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

        // Handle non-UI thread exceptions
        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }

    private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
    {
        LogException(e.Exception);
        MessageBox.Show("An error occurred. Check exception.log for details.");
    }

    private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        LogException(e.ExceptionObject as Exception);
        MessageBox.Show("A critical error occurred. Check exception.log for details.");
    }

    private static void LogException(Exception ex)
    {
        try
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "exception.log");
            File.AppendAllText(path, DateTime.Now.ToString() + Environment.NewLine);
            File.AppendAllText(path, ex.ToString() + Environment.NewLine + Environment.NewLine);
        }
        catch { /* ignore logging errors */ }
    }
}
