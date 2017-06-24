using Microsoft.Win32;
using System.ComponentModel;
using System.Windows;

namespace WordCounter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorker worker;
        public MainWindow()
        {
            InitializeComponent();
            worker = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.ProgressChanged += Worker_ProgressChanged;
        }

        private void StartThread()
        {
            // This method runs on the main thread.
            this.matchingWordsTextBox.Text = "0";

            //initialize the objects
            Words wc = new Words();
            wc.CompareString = compareStringTextBox.Text;
            wc.SourceFile = sourceFileTextBox.Text;

            //start the asynchronous operation
            worker.RunWorkerAsync(wc);
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // This event handler is where the actual work is done.
            // This method runs on the background thread

            // Get the BackgroundWorker object that raised this event
            BackgroundWorker bgWorker = sender as BackgroundWorker;
            Words words = e.Argument as Words;
            words.CountWords(bgWorker, e);

        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // This event handler is called when the background thread finishes.
            // This method runs on the main thread.
            if (e.Error != null)
                MessageBox.Show("Error: " + e.Error.Message);
            else if (e.Cancelled)
                MessageBox.Show("Word counting canceled.");
            else
                MessageBox.Show("Finished counting words.");
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            CurrentState state = e.UserState as CurrentState;
            this.linesCountedTextBox.Text = state.LinesCounted.ToString();
            this.matchingWordsTextBox.Text = state.WordsMatched.ToString();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            StartThread();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            worker.CancelAsync();
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Select a txt file";
            openDialog.Filter = "Text files (*.txt)|*.txt";
            openDialog.ShowDialog();
            this.sourceFileTextBox.Text =  openDialog.FileName;
        }
    }
}
