using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace TransparentClock
{
    public partial class OverlayWindow : Window
    {
        private DispatcherTimer _timer;
        private Point _offset;

        public OverlayWindow()
        {
            InitializeComponent();
            InitializeTimer();
            UpdateClock();

            // Начальная позиция в правом нижнем углу
            SetPositionToBottomRight();
        }
        private void Window_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            double newOpacity = Opacity + (e.Delta > 0 ? 0.1 : -0.1);

            // Вместо Math.Clamp используем обычные проверки
            if (newOpacity < 0.2) newOpacity = 0.2;
            if (newOpacity > 0.9) newOpacity = 0.9;

            Opacity = newOpacity;
        }
        private void SetPositionToBottomRight()
        {
            Left = SystemParameters.WorkArea.Width - Width - 10;
            Top = SystemParameters.WorkArea.Height - Height - 10;
        }

        private void InitializeTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (s, e) => UpdateClock();
            _timer.Start();
        }

        private void UpdateClock()
        {
            TimeText.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                _offset = e.GetPosition(this);
                DragMove();
            }
        }
    }
}