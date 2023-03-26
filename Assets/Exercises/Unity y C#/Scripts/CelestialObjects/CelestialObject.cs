using UnityEngine;

namespace Exercises.Unity_y_C_.Scripts.CelestialObjects
{
    public abstract class CelestialObject
    {
        protected CelestialObject(string name, float distanceFromParentToObject, int size)
        {
            Name = name;
            Size = size;
            distance = distanceFromParentToObject;
        }

        public string Name { get; }
        public int Size { get; }

        private float distance;
        public Vector3 DistanceFromParentToObject(GameObject parentObject)
        {
            return parentObject.transform.position - new Vector3(distance,0,0);
        }
        public Color CelestialColor { get; protected set; } = Color.white;
    }
}