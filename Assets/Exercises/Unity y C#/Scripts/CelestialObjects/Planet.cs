using UnityEngine;

namespace Exercises.Unity_y_C_.Scripts.CelestialObjects
{
    public class Planet : CelestialObject
    {
        public Planet(string name, float distanceFromParentCelestialObject, int size, Star parentStar, int quantityOfMoons = 0) : base(name,distanceFromParentCelestialObject,size)
        {
            ParentStar = parentStar;
            QuantityOfMoons = quantityOfMoons;
            CelestialColor = Color.blue;
        }

        public int QuantityOfMoons { get; }
        public Star ParentStar { get; }
    }
}