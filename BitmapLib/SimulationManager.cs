using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BitmapLib
{
    public class SimulationManager
    {
        private static SimulationManager instance;
        private List<SimulationObject> objectsToAdd;
        private List<SimulationObject> objectsToRemove;
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
            objectsToAdd = new();
            objectsToRemove = new();
        }

        public void Update()
        {
            simulationObjects.ForEach(obj => { obj.Update(); });
            AddQueuedObjects();
            RemoveQueuedObjects();
        }

        private void AddQueuedObjects()
        {
            simulationObjects.AddRange(objectsToAdd);
            objectsToAdd.Clear();
        }

        private void RemoveQueuedObjects()
        {
            simulationObjects.RemoveAll(x => objectsToRemove.Contains(x));
            objectsToRemove.Clear();
        }

        public static void AddToSimulation(SimulationObject obj)
        {
            GetInstance().objectsToAdd.Add(obj);
        }

        public static void RemoveFromSimulation(SimulationObject obj)
        {
            GetInstance().objectsToRemove.Add(obj);
        }
    }
}
