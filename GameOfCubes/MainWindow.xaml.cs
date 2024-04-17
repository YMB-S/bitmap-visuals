using System.Windows;
using System.Drawing;
using System.Numerics;
using BitmapLib;


namespace GameOfCubes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SimulationManager.GetInstance().AddObject(new CubeManager());

            BitmapLib.MainWindow window = BitmapLib.MainWindow.Start(this);
            window.Resize(100, 500, 500);
        }
    }
}
