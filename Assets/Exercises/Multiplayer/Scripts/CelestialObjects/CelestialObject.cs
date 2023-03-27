using UnityEngine;

namespace Exercises.Multiplayer.Scripts.CelestialObjects
{
    public abstract class CelestialObject
    {
        protected CelestialObject(string name, float distanceFromParentToObject, int size)
        {
            Name = name;
            Size = size;
            _distance = distanceFromParentToObject;
        }

        public string Name { get; }
        public int Size { get; }

        private readonly float _distance;
        public Vector3 DistanceFromParentToObject(GameObject parentObject)
        {
            return parentObject.transform.position - new Vector3(_distance,0,0);
        }
    }
}