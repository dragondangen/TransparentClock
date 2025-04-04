using System.Windows;

namespace TransparentClock
{
    public partial class MainWindow : Window
    {
        private OverlayWindow _overlay;
        private bool _isOverlayVisible = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToggleOverlayBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_isOverlayVisible)
            {
                _overlay?.Close();
                ToggleOverlayBtn.Content = "Показать часы";
            }
            else
            {
                _overlay = new OverlayWindow();
                _overlay.Show();
                ToggleOverlayBtn.Content = "Скрыть часы";
            }

            _isOverlayVisible = !_isOverlayVisible;
        }
    }
}
