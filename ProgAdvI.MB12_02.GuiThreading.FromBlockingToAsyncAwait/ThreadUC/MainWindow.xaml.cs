using System.Windows;

namespace ThreadUC
{
    public partial class MainWindow : Window {
        public MainWindow() {
            this.InitializeComponent();
        }

        private readonly DemoMode _mode = DemoMode.NoThread;
        // private readonly DemoMode _mode = DemoMode.Thread;
        // private readonly DemoMode _mode = DemoMode.TaskContinueWith;
        // private readonly DemoMode _mode = DemoMode.AsyncAwait;

        private void StartImport_Click(object sender, RoutedEventArgs e) {
            this.SetRunning(true);

            this.Log($"--- Start ({this._mode}) ---");

            switch (this._mode) {
                case DemoMode.NoThread:
                    this.RunImport_NoThread();
                    break;

                case DemoMode.Thread:
                    this.RunImport_Thread();
                    break;

                case DemoMode.TaskContinueWith:
                    this.RunImport_TaskContinueWith();
                    break;

                case DemoMode.AsyncAwait:
                    _ = this.RunImport_AsyncAwait();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SetRunning(bool running) {
            this.StartButton.IsEnabled = !running;
            this.ClearButton.IsEnabled = !running;
        }

        private void Clear_Click(object sender, RoutedEventArgs e) {
            this.LogListBox.Items.Clear();
            this.StatusTextBlock.Text = "Bereit";
        }

        // ------------------------------------------------------------
        // 1) Kein Thread
        // ------------------------------------------------------------
        private void RunImport_NoThread() {
            this.SetStatus("Lade Daten...");
            this.Log("Lade 5 Datensätze...");
            var rawData = this.LoadData_Blocking();

            this.SetStatus("Verarbeite Daten...");
            this.Log("Verarbeite Datensätze...");
            var result = this.ProcessData_Blocking(rawData);

            this.SetStatus("Import abgeschlossen");
            this.Log($"Resultat: {result}");
            this.SetRunning(false);
        }

        // ------------------------------------------------------------
        // 2) Thread
        // ------------------------------------------------------------
        private void RunImport_Thread() {

        }

        // ------------------------------------------------------------
        // 3) Task + ContinueWith
        // ------------------------------------------------------------
        private void RunImport_TaskContinueWith() {

        }

        // ------------------------------------------------------------
        // 4) Task + async/await
        // ------------------------------------------------------------
        private async Task RunImport_AsyncAwait() {

        }

        #region BusinessLogic

        // ------------------------------------------------------------
        // Blocking-Methoden
        // ------------------------------------------------------------
        private List<string> LoadData_Blocking() {
            Thread.Sleep(2000);

            return new List<string> {
                "Kunde A",
                "Kunde B",
                "Kunde C",
                "Kunde D",
                "Kunde E"
            };
        }

        private string ProcessData_Blocking(List<string> rawData) {
            Thread.Sleep(2000);
            return $"{rawData.Count} Datensätze importiert";
        }

        // ------------------------------------------------------------
        // Async-Methoden
        // ------------------------------------------------------------
        private async Task<List<string>> LoadDataAsync() {
            await Task.Delay(2000);

            return new List<string> {
                "Kunde A",
                "Kunde B",
                "Kunde C",
                "Kunde D",
                "Kunde E"
            };
        }

        private async Task<string> ProcessDataAsync(List<string> rawData) {
            await Task.Delay(2000);
            return $"{rawData.Count} Datensätze importiert";
        }

        // ------------------------------------------------------------
        // UI-Helfer
        // ------------------------------------------------------------
        private void SetStatus(string text) {
            this.StatusTextBlock.Text = text;
            this.Log($"Status => {text}");
        }

        private void Log(string text) {
            this.LogListBox.Items.Add($"{DateTime.Now:HH:mm:ss}  {text}");
        }
#endregion
    }

    public enum DemoMode {
        NoThread,
        Thread,
        TaskContinueWith,
        AsyncAwait
    }
}