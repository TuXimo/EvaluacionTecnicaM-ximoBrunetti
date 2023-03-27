namespace Exercises.Multiplayer.Scripts.CelestialObjects
{
    public class Planet : CelestialObject
    {
        public Planet(string name, float distanceFromParentCelestialObject, int size, Star parentStar, bool hasMoons = false) : base(name,distanceFromParentCelestialObject,size)
        {
            ParentStar = parentStar;
            HasMoons = hasMoons;
        }

        public bool HasMoons { get; }
        public Star ParentStar { get; }
    }
}