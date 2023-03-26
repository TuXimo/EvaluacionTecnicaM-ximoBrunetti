using System;
using System.Collections.Generic;
using Exercises.Unity_y_C_.Scripts.CelestialObjects;
using UnityEngine;

namespace Exercises.Unity_y_C_.Scripts
{
    public class MockupSystem : SolarSystem
    {
        public MockupSystem(Vector3 location = default) : base("MockUp Urinary Solar System", location, new List<CelestialObject>())
        {
            Star mockupStar = new Star("MockStar", 0, 250);
            CelestialObjectsList.Add(mockupStar);

            Planet mockupEarth = new Planet("Earth", 50, 10, mockupStar);
            Planet mockupVenus = new Planet("Venus", -150, 8, mockupStar);
            Planet mockupJupiter = new Planet("Jupiter", 100, 30, mockupStar, 2);
            CelestialObjectsList.AddRange(new []{mockupEarth,mockupJupiter,mockupVenus});

            Moon mockupAtlas = new Moon("Atlas", -5, 2, mockupJupiter);
            Moon mockupTitan = new Moon("Titan", 10, 3, mockupJupiter);
            CelestialObjectsList.AddRange(new []{mockupAtlas,mockupTitan});

            CheckIfUrinary();
        }
        
        private void CheckIfUrinary()
        {
            int numberOfStars = 0;
            foreach (var celestialObject in CelestialObjectsList)
            {
                if (celestialObject.GetType() == typeof(Star))
                    numberOfStars++;

                if (numberOfStars > 1)
                    throw new Exception("Not urinary system");
            }
        }
    }
}
