using System.Windows;

namespace ClickManagerMain
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ModelManagerBtn_Click(object sender, RoutedEventArgs e)
        {
            ModelManager.MainWindow mainWindow = new ModelManager.MainWindow();
            mainWindow.Show();
        }

        private void ModelRunnerBtn_Click(object sender, RoutedEventArgs e)
        {
            ModelRunner.MainWindow mainWindow = new ModelRunner.MainWindow();
            mainWindow.Show();
        }
    }
}
