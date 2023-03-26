using System;
using System.Linq;
using Exercises.Unity_y_C_.Scripts.CelestialObjects;
using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;

namespace Exercises.Unity_y_C_.Scripts
{
    public class SolarSystemManager : NetworkBehaviour
    {
        private MockupSystem _mockupSystem;
        [SerializeField] private GameObject[] celestialGameObjects;

        public override void OnNetworkSpawn()
        {
            if(!IsHost)
                return;;
            InstantiateUrinarySystem();
            print($"{_mockupSystem.SystemName} initiated");
        }

        private void InstantiateUrinarySystem()
        {
            _mockupSystem = new MockupSystem();
            transform.position = _mockupSystem.Location;

            //Find sun to set default parent in a urinary system and instantiate the sun
            Star star = _mockupSystem.CelestialObjectsList.OfType<Star>().FirstOrDefault();
            //Instead using prefabs, I used primitives created with code
            GameObject starGameObject = Instantiate(celestialGameObjects[0], transform.position, celestialGameObjects[0].transform.rotation);
            SetCelestialObjectProperties(starGameObject, star);

            //Iterate through the list to of planet to instantiate them and check if they have moons
            foreach (Planet planet in _mockupSystem.CelestialObjectsList.OfType<Planet>())
            {
                if (planet.ParentStar != star)
                {
                    throw new Exception("A planet was detected that is not part of this urinary system");
                }

                GameObject planetGameObject = Instantiate(celestialGameObjects[1], planet.DistanceFromParentToObject(starGameObject),
                    celestialGameObjects[1].transform.rotation);
                
                SetCelestialObjectProperties(planetGameObject, planet);
                //planetGameObject.transform.SetParent(starGameObject.transform);

                //Checks if the planet has moons and then iterates through
                //the list of moons to see if it belongs to that planet
                if (planet.QuantityOfMoons > 1)
                {
                    foreach (Moon moon in _mockupSystem.CelestialObjectsList.OfType<Moon>())
                    {
                        if (moon.ParentPlanet == planet)
                        {
                            GameObject moonObject = Instantiate(celestialGameObjects[2],
                                moon.DistanceFromParentToObject(planetGameObject),
                                celestialGameObjects[2].transform.rotation);
                            
                            //moonObject.transform.SetParent(planetGameObject.transform);
                            SetCelestialObjectProperties(moonObject, moon);
                        }
                    }
                }
            }

            void SetCelestialObjectProperties(GameObject celestialGameObject, CelestialObject celestialObject, int resize = 10)
            {
                //Set all features of the gameobject
                celestialGameObject.transform.localScale = Vector3.one * celestialObject.Size / resize;
                celestialGameObject.name = celestialObject.Name;
                celestialGameObject.GetComponent<MeshRenderer>().material.color = celestialObject.CelestialColor;
                celestialGameObject.GetComponent<NetworkObject>().Spawn();
            }
        }
    }
}

