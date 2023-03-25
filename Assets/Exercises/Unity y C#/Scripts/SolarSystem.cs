using System.Collections.Generic;
using Exercises.Unity_y_C_.Scripts.CelestialObjects;
using UnityEngine;

namespace Exercises.Unity_y_C_.Scripts
{
    public class SolarSystem
    {
        protected SolarSystem(string systemName, Vector3 location, List<CelestialObject> celestialObjectsList)
        {
            SystemName = systemName;
            Location = location;
            CelestialObjectsList = celestialObjectsList;
        }

        public string SystemName { get; }
        public Vector3 Location { get; }
        public List<CelestialObject> CelestialObjectsList { get; }
    }
}
