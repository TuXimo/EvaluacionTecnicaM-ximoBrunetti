using UnityEngine;

namespace Exercises.Unity_y_C_.Scripts.CelestialObjects
{
    public class Moon : CelestialObject
    {
        public Moon(string name, float distanceFromParentCelestialObject, int size, Planet parentPlanet) : base(name,distanceFromParentCelestialObject,size)
        {
            ParentPlanet = parentPlanet;
        }

        public Planet ParentPlanet { get; }
    }
}