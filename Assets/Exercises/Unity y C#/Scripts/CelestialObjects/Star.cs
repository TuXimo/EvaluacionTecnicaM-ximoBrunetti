using UnityEngine;

namespace Exercises.Unity_y_C_.Scripts.CelestialObjects
{
    public class Star : CelestialObject
    {
        public Star(string name, float distanceFromParentToObject, int size) : base(name,distanceFromParentToObject,size)
        {
            
        }
    }
}