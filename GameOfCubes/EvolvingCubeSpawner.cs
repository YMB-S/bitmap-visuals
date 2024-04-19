using System.Collections.Generic;
using System.Windows.Input;
using System.Drawing;
using BitmapLib;
using System.Linq;
using System.Windows.Documents;
using System;
using System.Diagnostics;

namespace GameOfCubes
{
    public class EvolvingCubeSpawner : SimulationObject, IClickEventReceiver
    {
        private readonly int AMOUNT_COLORS_TO_GENERATE = 1000;
        private readonly int CUBE_EDGE_LENGTH = 10;

        List<Color> colors;

        List<Cube> cubes;

        public EvolvingCubeSpawner()
        {
            colors = ColorUtils.GetRainbowColors(AMOUNT_COLORS_TO_GENERATE);
            cubes = new()
            {
                new Cube(
                    new IntVector2(250, 250),
                    new IntVector2(0, 0),
                    CUBE_EDGE_LENGTH,
                    colors.First()
                    )
            };
        }

        public void ReceiveClick(IntVector2 clickPosition, MouseEventArgs e)
        {
            cubes.Add(new(
                new IntVector2(clickPosition.X, clickPosition.Y),
                new IntVector2(0, 0),
                CUBE_EDGE_LENGTH,
                colors.First()
                ));
        }

        public override void Update()
        {
            base.Update();
            Cube newCube = null;

            foreach(Cube cube in cubes)
            {
                List<Color?> neighbors = GetNeighboringColors(cube);
                Color? majority = GetMajorityColorFrom(neighbors);
                var grouping = neighbors.GroupBy(i => i);
                if (grouping.Where(x => x.Key == majority).Count() == 0) { newCube = AddNewNeighbor(cube); }
                else { cube.Color = (Color)majority; }
                Debug.WriteLine(majority);
            }

            if(newCube != null) { cubes.Add(newCube); }
        }

        private List<Color?> GetNeighboringColors(Cube cube)
        {
            List<Color?> neighborColors = new()
            {
                // Upper-Left Neighbor
                cubes.FirstOrDefault(x => x.Position.X == cube.Position.X - CUBE_EDGE_LENGTH && x.Position.Y == cube.Position.Y - CUBE_EDGE_LENGTH)?.Color,

                // Upper Neighbor
                cubes.FirstOrDefault(x => x.Position.X == cube.Position.X && x.Position.Y == cube.Position.Y - CUBE_EDGE_LENGTH)?.Color,
    
                // Upper-Right Neighbor
                cubes.FirstOrDefault(x => x.Position.X == cube.Position.X + CUBE_EDGE_LENGTH && x.Position.Y == cube.Position.Y - CUBE_EDGE_LENGTH)?.Color,
    
                // Middle-Left Neighbor
                cubes.FirstOrDefault(x => x.Position.X == cube.Position.X - CUBE_EDGE_LENGTH && x.Position.Y == cube.Position.Y)?.Color,
    
                // Middle-Right Neighbor
                cubes.FirstOrDefault(x => x.Position.X == cube.Position.X + CUBE_EDGE_LENGTH && x.Position.Y == cube.Position.Y)?.Color,
    
                // Bottom-Left Neighbor
                cubes.FirstOrDefault(x => x.Position.X == cube.Position.X - CUBE_EDGE_LENGTH && x.Position.Y == cube.Position.Y + CUBE_EDGE_LENGTH)?.Color,
    
                // Bottom-Middle Neighbor
                cubes.FirstOrDefault(x => x.Position.X == cube.Position.X && x.Position.Y == cube.Position.Y + CUBE_EDGE_LENGTH)?.Color,
    
                // Bottom-Right Neighbor
                cubes.FirstOrDefault(x => x.Position.X == cube.Position.X + CUBE_EDGE_LENGTH && x.Position.Y == cube.Position.Y + CUBE_EDGE_LENGTH)?.Color
            };

            return neighborColors!;
        }

        private Color? GetMajorityColorFrom(List<Color?> cubes)
        {
            var majorityColor = (from i in cubes
                        group i by i into grp
                        orderby grp.Count() descending
                        select grp.Key).First();
            if (majorityColor == null) { return Color.White; }
            return majorityColor;
        }

        private Cube AddNewNeighbor(Cube cube)
        {
            Color nextColor = colors.ElementAt((colors.IndexOf(cube.Color) + 1) % colors.Count);
            Cube newCube = new(
                Position = cube.Position,
                Velocity = cube.Velocity,
                CUBE_EDGE_LENGTH,
                nextColor
            );
            //cubes.Remove(cube);
            //SimulationManager.RemoveFromSimulation(cube);
            
            SimulationManager.AddToSimulation(newCube);
            return newCube;
        }
    }
}
