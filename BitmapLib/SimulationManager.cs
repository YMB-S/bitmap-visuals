using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitmapLib
{
    public class SimulationManager
    {
        private static SimulationManager instance;
        public static SimulationManager GetInstance()
        {
            if (instance == null)
            {
                instance = new SimulationManager();
            }
            return instance;
        }

        private List<SimulationObject> simulationObjects;
        public List<SimulationObject> SimulationObjects { get { return simulationObjects; } }

        public SimulationManager()
        {
            simulationObjects = new();
        }

        public void Update()
        {
            simulationObjects.ForEach(obj => { obj.Update(); });
        }

        public void AddObject(SimulationObject toAdd)
        {
            simulationObjects.Add(toAdd);
        }
    }
}
