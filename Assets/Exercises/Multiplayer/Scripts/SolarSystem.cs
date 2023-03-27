using System.Collections.Generic;
using Exercises.Multiplayer.Scripts.CelestialObjects;
using UnityEngine;

namespace Exercises.Multiplayer.Scripts
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
