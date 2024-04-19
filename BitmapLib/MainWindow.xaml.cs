using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace BitmapLib
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly int TARGET_FRAMES_PER_SECOND = 60;

        SimulationManager manager;
        SimulationDisplay display;
        DispatcherTimer timer;

        public MainWindow()
        {
            display = SimulationDisplay.GetInstance();
            manager = SimulationManager.GetInstance();

            SetupSimulationTimer(TARGET_FRAMES_PER_SECOND);

            InitializeComponent();
        }

        private void SetupSimulationTimer(int targetFramesPerSecond)
        {
            int milliseconds = 1000 / targetFramesPerSecond;
            timer = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 0, 0, milliseconds)
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            manager.Update();

            var image = display.GetImageFrom(manager.SimulationObjects);
            ImageDisplay.Source = image;
        }

        private void ImageDisplay_OnClick(object sender, MouseEventArgs e)
        {
            InputManager.GetInstance().NotifyClickReceiversOf(e);
        }

        public void Resize(int UserInterfaceMargin, int DISPLAY_WIDTH, int DISPLAY_HEIGHT)
        {
            SimulationDisplay.DISPLAY_WIDTH = DISPLAY_WIDTH;
            SimulationDisplay.DISPLAY_HEIGHT = DISPLAY_HEIGHT;
            ImageDisplay.Width = DISPLAY_WIDTH;
            ImageDisplay.Height = DISPLAY_HEIGHT;
            base.Width = UserInterfaceMargin + DISPLAY_WIDTH + (UserInterfaceMargin/10);
            base.Height = DISPLAY_HEIGHT + (UserInterfaceMargin/10);
            display.Resize(DISPLAY_WIDTH, DISPLAY_HEIGHT);
        }

        public void SetLightMode()
        {
            SetResourceReference(BackgroundProperty, SystemColors.ControlBrushKey);
        }

        public void SetSimulationLightMode()
        {
            display.BackgroundColor = System.Drawing.Color.White;

        }

        public void SetDarkMode()
        {
            SetResourceReference(BackgroundProperty, SystemColors.ControlDarkBrushKey);
        }

        public void SetSimulationDarkMode()
        {
            display.BackgroundColor = System.Drawing.Color.Black;
        }

        public static MainWindow Start(Window applicationWindow)
        {
            var mainWindow = new MainWindow();
            applicationWindow.Visibility = Visibility.Hidden;
            mainWindow.Show();
            return mainWindow;
        }
    }
}
