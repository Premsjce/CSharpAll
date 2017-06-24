using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MultiThreading
{
    public class BacgroundWorkerDemo
    {
        #region Constructor(s)
        
        public BacgroundWorkerDemo()
        {
            InitializeBackgroudWorker();
        }
        #endregion

        #region Public Method(s)
        /// <summary>
        /// Delegate the work that does the time consuming operaiton to this method
        /// </summary>
        public void TakesCareOfTimeConsumingWork()
        {
            ScientificCalculator sciFiCalc = new ScientificCalculator();
            sciFiCalc.NumberOne = 1;
            sciFiCalc.NumberTwo = 2;

            bgWorker.RunWorkerAsync(sciFiCalc);
        }
        #endregion

        #region Private Method(s)

        private void InitializeBackgroudWorker()
        {
            bgWorker = new BackgroundWorker()
            {
                WorkerSupportsCancellation = true,
                WorkerReportsProgress = true
            };

            bgWorker.DoWork += BgWorker_DoWork;
            bgWorker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;

        }


        /// <summary>
        /// Handles the DoWork event of the BgWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Control comes here when RunWorkerAsync is called;
            ScientificCalculator scificalc = e.Argument as ScientificCalculator;
            e.Result = scificalc.Add();
                           
        }
        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Control comes here when the Worker completes its time consuming opetaion
            MessageBox.Show("The result is " + (int)e.Result);
        }
        #endregion

        #region Private Member(s)
        private BackgroundWorker bgWorker;
        #endregion
    }
}
