using ModelManager.Engine;
using ModelManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ModelManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum Models
        {
            PreProcess,
            Run,
            Process,
            PostProcess
        }
        // preProcessing model
        List<BaseViewModel> preProcessingModel = new List<BaseViewModel>();
        // run model
        List<BaseViewModel> runModel = new List<BaseViewModel>();
        // postProcssing model
        List<BaseViewModel> postProcessingModel = new List<BaseViewModel>();
        // Procss model
        List<BaseViewModel> ProcessModel = new List<BaseViewModel>();
        // selected Index for preProcessing model
        int selected_Index_preProcessingModel = -1;
        // selected Index for run model
        int selected_Index_runModel = -1;
        // selected Index for Post Processing model
        int selected_Index_postProcessingModel = -1;
        // selected Index for Process model
        int selected_Index_ProcessModel = -1;
        // output file Name
        string outputFileName = string.Empty;
        //Process Name selected
        string processName = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
            InitializeDGs();
            RegisterUpdateDGs();

        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(ModelNameTxt.Text))
            {
                MessageBox.Show("The model name cannot be empty!");
                return;
            }

            if(ModelCreator.IsModelValid(preProcessingModel)&& ModelCreator.IsModelValid(runModel)&& ModelCreator.IsModelValid(ProcessModel)&& ModelCreator.IsModelValid(postProcessingModel)&&!string.IsNullOrEmpty(ProcessNameTxt.Text))
            {
                ModelCreator.CreateOrUpdateModel(preProcessingModel, runModel, ProcessModel, postProcessingModel, ModelNameTxt.Text,ProcessNameTxt.Text);
                MessageBox.Show($"{ModelNameTxt.Text} is saved");
                return;
            }
            else
            {
                MessageBox.Show("The model is not valid. Check the names and positions, all should have values.");
                return;
            }
        }

        private void RunModel_SelectedCellsChanged(object sender, System.Windows.Controls.SelectedCellsChangedEventArgs e)
        {
            UpdateSelectedCell(sender, Models.Run);
        }

        private void PreProcessingDG_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            UpdateSelectedCell(sender, Models.PreProcess);
        }

        private void PostProcessingDG_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            UpdateSelectedCell(sender, Models.PostProcess);

        }

        private void ProcessDG_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            UpdateSelectedCell(sender, Models.Process);
        }
        private void UpdateSelectedCell(object sender,Models models)
        {
            var DG = sender as DataGrid;
            var temp = DG.SelectedIndex;
            selected_Index_preProcessingModel = -1;
            selected_Index_runModel = -1;
            selected_Index_ProcessModel = -1;
            selected_Index_postProcessingModel = -1;
            switch (models)
            {
                case Models.PreProcess:
                    selected_Index_preProcessingModel = temp;
                    break;
                case Models.Run:
                    selected_Index_runModel = temp;
                    break;
                case Models.Process:
                    selected_Index_ProcessModel = temp;
                    break;
                case Models.PostProcess:
                    selected_Index_postProcessingModel = temp;
                    break;
            }
        }
        private void InitializeDGs()
        {
            RunModelDG.ItemsSource = runModel;
            PreProcessingDG.ItemsSource = preProcessingModel;
            ProcessDG.ItemsSource = ProcessModel;
            PostProcessingDG.ItemsSource = postProcessingModel;
        }
        private void RegisterUpdateDGs()
        {
            this.Deactivated += (sender, args) => {
                ModelCreator.UpdateModel(runModel, selected_Index_runModel);
                ModelCreator.UpdateModel(preProcessingModel, selected_Index_preProcessingModel);
                ModelCreator.UpdateModel(ProcessModel, selected_Index_ProcessModel);
                ModelCreator.UpdateModel(postProcessingModel, selected_Index_postProcessingModel);
                RefreshModels();
            };
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog()
                {
                    // Set filter for file extension and default file extension 
                    DefaultExt = ".json",
                    Title = "Select the Model",
                    Filter = "Model Files (*.json)|*.json"
                };

                // Display OpenFileDialog by calling ShowDialog method 
                var result = dlg.ShowDialog();
                if (result.HasValue && result == true)
                {
                    var fileName = dlg.FileName;
                    // Get BaseModel
                    var (success, baseModel) = FileUtility.GetBaseModel(fileName);
                    if(success)
                    {
                        // Extract PreProcess, Run, Process, PostProcessing Models
                        (preProcessingModel, runModel, ProcessModel, postProcessingModel,processName) = (baseModel.PreProcessModel,baseModel.RunModel,baseModel.ProcessModel,baseModel.PostProcessModel,baseModel.ProcessName);
                        RefreshModels();
                        ModelNameTxt.Text = Path.GetFileName(fileName);
                    }
                    else
                    {
                        MessageBox.Show($"The model is not a proper model for automation");
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"There is a problem :{exception.Message}");
            }
        }

        private void RefreshModels()
        {
            RunModelDG.ItemsSource = null;
            RunModelDG.ItemsSource = runModel;
            PreProcessingDG.ItemsSource = null;
            PreProcessingDG.ItemsSource = preProcessingModel;
            ProcessDG.ItemsSource = null;
            ProcessDG.ItemsSource = ProcessModel;
            PostProcessingDG.ItemsSource = null;
            PostProcessingDG.ItemsSource = postProcessingModel;
            ProcessNameTxt.Text = processName;
        }
    }
}
