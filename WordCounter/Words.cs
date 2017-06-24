using System;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace WordCounter
{
    public class Words
    {
        public string SourceFile;
        public string CompareString;
        private int WordsCount;
        private int LinesCounted;

        /// <summary>
        /// Counts the words.
        /// </summary>
        /// <param name="bgWorker">The bg worker.</param>
        /// <param name="args">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.Exception">Compare string cannot be empty</exception>
        public void CountWords(BackgroundWorker bgWorker, DoWorkEventArgs args)
        {
            if (string.IsNullOrEmpty(CompareString))
                throw new Exception("Compare string cannot be empty");
            CurrentState currentState = new CurrentState();
            string currentLine = "";
            DateTime lastReportedTime = DateTime.Now;
            int elapsedTime = 20;

            //Open a new Stream
            using (StreamReader reader = new StreamReader(SourceFile))
            {
                while(!reader.EndOfStream)
                {
                    if (bgWorker.CancellationPending)
                    {
                        args.Cancel = true;
                        break;
                    }

                    currentLine = reader.ReadLine();
                    WordsCount += CountWordsInCurrentLine(currentLine);
                    LinesCounted += 1;

                    //Raise the event so the UI can monitor the progress
                    int compare = DateTime.Compare(DateTime.Now, lastReportedTime.AddMilliseconds(elapsedTime));

                    if(compare > 0)
                    {
                        currentState.LinesCounted = LinesCounted;
                        currentState.WordsMatched = WordsCount;
                        bgWorker.ReportProgress(0, currentState);
                        lastReportedTime = DateTime.Now;
                    }

                    Thread.Sleep(1);
                }

                //report the final count
                currentState.LinesCounted = LinesCounted;
                currentState.WordsMatched = WordsCount;
                bgWorker.ReportProgress(0, currentState);
            }

        }

        /// <summary>
        /// Counts the words in current line.
        /// </summary>
        /// <param name="currentLine">The current line.</param>
        /// <returns></returns>
        private int CountWordsInCurrentLine(string currentLine)
        {
            if (string.IsNullOrEmpty(currentLine))
                return 0;
            string escapedCompareString = Regex.Escape(CompareString);
            Regex regex = new Regex(@"\b" + escapedCompareString + @"\b",RegexOptions.IgnoreCase);
            MatchCollection regexMatches = regex.Matches(currentLine);
            return regexMatches.Count;
        }
    }
}
