using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RibbonMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel ViewModel
        {
            get { return (ViewModel)DataContext; }
            set
            {
                DataContext = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }

        public void UpdateSvg()
        {
            ViewModel.UpdateSvg();
            SvgDisplay.Refresh();
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            //TODO: Save file dialog thing
            string filePath = "";
            ViewModel.Save(filePath);
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            //TODO: load file dialog thing
            string filePath = "";
            ViewModel = ViewModel.Load(filePath);
        }

        private void OnExport(object sender, RoutedEventArgs e)
        {
            //TODO: save file dialog thing
            string exportPath = "";
            ViewModel.Export(exportPath);
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            ControlCircle viewModel = (ControlCircle)((FrameworkElement)sender).DataContext;
            viewModel.OnMouseDown(e.GetPosition(ConstructionCanvas));
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            ControlCircle viewModel = (ControlCircle)((FrameworkElement)sender).DataContext;
            viewModel.OnMouseMove(e.LeftButton, e.GetPosition(ConstructionCanvas));
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            ControlCircle viewModel = (ControlCircle)((FrameworkElement)sender).DataContext;
            viewModel.OnMouseLeave();
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            ControlCircle viewModel = (ControlCircle)((FrameworkElement)sender).DataContext;
            viewModel.OnMouseUp();
            UpdateSvg();
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            ControlCircle viewModel = (ControlCircle)((FrameworkElement)sender).DataContext;
            viewModel.OnMouseEnter();
        }
    }
}
