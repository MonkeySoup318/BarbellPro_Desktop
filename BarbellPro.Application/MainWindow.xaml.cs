using System.Windows;
using System.Windows.Input;

namespace BarbellPro.Application
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

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();

            if (e.ClickCount == 2)
            {
                if (System.Windows.Application.Current.MainWindow.WindowState != WindowState.Normal)
                    System.Windows.Application.Current.MainWindow.WindowState = WindowState.Normal;
                else
                    System.Windows.Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
        }

        private void Button_Click_Minimize(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void Button_Click_Maximize(object sender, RoutedEventArgs e)
        {
            if (System.Windows.Application.Current.MainWindow.WindowState != WindowState.Maximized)
                System.Windows.Application.Current.MainWindow.WindowState = WindowState.Maximized;
            else
                System.Windows.Application.Current.MainWindow.WindowState = WindowState.Normal;
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.BorderThickness = new Thickness(7);
            else
                this.BorderThickness = new Thickness(0);
        }
    }
}
