namespace MainWindowTitle_test
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("MainWindowTitle test (.Net Core 3.1)");
            System.Console.WriteLine("Press ESC to stop.");

            string oldMainWindowTitle = null;
            var process = System.Diagnostics.Process.Start("notepad");
            try
            {
                do
                {
                    process?.Refresh();
                    string mainWindowTitle = process?.MainWindowTitle;
                    if (mainWindowTitle != oldMainWindowTitle)
                    {
                        oldMainWindowTitle = mainWindowTitle;
                        System.Console.WriteLine($"{mainWindowTitle} == {mainWindowTitle == string.Empty}");
                    }
                    System.Threading.Thread.Sleep(1000);
                } while (!(System.Console.KeyAvailable && System.Console.ReadKey(true).Key == System.ConsoleKey.Escape));
            }
            finally
            {
                process?.Kill();
            }
        }
    }
}
