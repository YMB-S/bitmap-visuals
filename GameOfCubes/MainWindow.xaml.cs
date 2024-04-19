using System.Windows;
using System.Drawing;
using System.Numerics;
using System.Diagnostics;
using BitmapLib;
using System;


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

            SimulationManager.AddToSimulation(new EvolvingCubeSpawner());
            BitmapLib.MainWindow window = BitmapLib.MainWindow.Start(this);
            window.Resize(100, 500, 500);
        }
    }
}
