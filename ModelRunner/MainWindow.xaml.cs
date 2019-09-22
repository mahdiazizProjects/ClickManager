using ModelManager.Engine;
using ModelRunner.Engine;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using ClickEngine.Engine;
using ClickEngine.Engine.Positions;

namespace ModelRunner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string fileName = string.Empty;
        private int numIterations = -1;
        private FillType fillType = FillType.None;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void RunBtn_Click(object sender, RoutedEventArgs e)
        {
            // Get BaseModel
            var (success,baseModel) = FileUtility.GetBaseModel(fileName);
            if (success)
            {
                //hide window
                this.Hide();
                Thread.Sleep(500);
                // num of iterations 
                numIterations = Convert.ToInt32(NumIterationTxt.Text);
                // get fill type
                fillType = GetFillType(RunningTypeCB.SelectedIndex);
                // Extract PreProcess, Run, Process, PostProcessing Models
                var (PreProcess, Run, Process, PostProcessing,processName) = ModelUtility.ConvertBaseModelToActionModels(baseModel);
                RunReport runReport = new RunReport(new GenericRunner(PreProcess, Run, Process, PostProcessing,processName), fillType);
                runReport.Run(ClickEngine.Engine.SeedWork.FileUtility.GetUniqueTxtFileName(nameof(GenericRunner)), numIterations);
                this.Show();
                MessageBox.Show("The process is successfully finished.");
            }
            else
            {
                this.Show();
                MessageBox.Show($"Cannot read the model {fileName}");
            }
            SystemInteractions.ShowHideWindow(SystemInteractions.WindowHideShow.SHOW);
        }
        private FillType GetFillType(int fillTypeCBIndex)
        {
            FillType fillType = FillType.None;
            switch(fillTypeCBIndex)
            {
                case 0:
                    fillType = FillType.All;
                    break;
                case 1:
                    fillType = FillType.Random;
                    break;
                case 2:
                    fillType = FillType.None;
                    break;

            }
            return fillType;
        }

        private void BrowseBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog()
            {
                DefaultExt = ".json",
                Title = "Select the Model",
                Filter = "Model Files (*.json)|*.json"
            };

            var result = dlg.ShowDialog();
            if (result.HasValue && result == true)
            {
                fileName = dlg.FileName;
            }
        }
    }
}
