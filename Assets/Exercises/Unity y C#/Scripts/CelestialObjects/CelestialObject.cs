using UnityEngine;

namespace Exercises.Unity_y_C_.Scripts.CelestialObjects
{
    public abstract class CelestialObject
    {
        protected CelestialObject(string name, float distanceFromParentToObject, int size)
        {
            Name = name;
            DistanceFromParentToObject = distanceFromParentToObject;
            Size = size;
        }

        public string Name { get; }
        public int Size { get; }
        public float DistanceFromParentToObject { get; }
        public Color CelestialColor { get; protected set; } = Color.white;
    }
}