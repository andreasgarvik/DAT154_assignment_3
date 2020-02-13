using System;
using System.Drawing;
//using System.Windows.Shapes;

namespace SpaceSim
{
    public class SpaceObject
    {
        public double XPos { get; set; }
        public double YPos { get; set; }
        public string Name { get; set; }
        public int OrbitalRadius { get; set; }
        public int OrbitalPeriod { get; set; }
        public int OrbitalSpeed { get; set; }
        public int ObjectRadius { get; set; }
        public int RotationalPeriod { get; set; }
        public Color ObjectColor { get; set; }
 //       public Ellipse Shape { get; set; }
        public SpaceObject(string name, int orbitalRadius, int orbitalPeriod, int orbitalSpeed,int objectRadius, int rotationalPeriod, Color objectColor)
        {
            Name = name;
            OrbitalRadius = orbitalRadius;
            OrbitalPeriod = orbitalPeriod;
            OrbitalSpeed = orbitalSpeed;
            ObjectRadius = objectRadius;
            RotationalPeriod = rotationalPeriod;
            ObjectColor = objectColor;
        }
        public virtual void CalcPos(int time)
        {
            XPos = OrbitalRadius + (Math.Cos(time * OrbitalSpeed * 3.1416 / 180) * OrbitalRadius);
            YPos = OrbitalRadius + (Math.Sin(time * OrbitalSpeed * 3.1416 / 180) * OrbitalRadius);
        }

    }
    public class Star : SpaceObject
    {
        
        public Star(string name, int orbitalRadius, int orbitalPeriod, int orbitalSpeed, int objectRadius, int rotationalPeriod, Color objectColor) : base(name, objectRadius, orbitalPeriod, orbitalSpeed, objectRadius, rotationalPeriod, objectColor) 
        {
            XPos = 0.0;
            YPos = 0.0;
        }
        public override void CalcPos(int time)
        {
            return;
        }
    }
    public class Planet : SpaceObject
    {
        public Planet(double xPos, string name, int orbitalRadius, int orbitalPeriod, int orbitalSpeed, int objectRadius, int rotationalPeriod, Color objectColor) : base(name, objectRadius, orbitalPeriod, orbitalSpeed, objectRadius, rotationalPeriod, objectColor) 
        {
            XPos = xPos;
            YPos = 0.0;
        }
    }
    public class Moon : SpaceObject
    {
        public Planet Planet { get; set; }
        public Moon(double xPos, string name, int orbitalRadius, int orbitalPeriod, int orbitalSpeed, int objectRadius, int rotationalPeriod, Color objectColor, Planet planet) : base(name, objectRadius, orbitalPeriod, orbitalSpeed, objectRadius, rotationalPeriod, objectColor) 
        {
            XPos = xPos;
            YPos = 0.0;
            Planet = planet;
        }
    }

    public class Comet : SpaceObject
    {
        public Comet(string name, int orbitalRadius, int orbitalPeriod, int orbitalSpeed, int objectRadius, int rotationalPeriod, Color objectColor) : base(name, objectRadius, orbitalPeriod, orbitalSpeed, objectRadius, rotationalPeriod, objectColor) 
        {
            YPos = 0.0;
        }
    }

    public class Asteriod : SpaceObject
    {
        public Asteriod(string name, int orbitalRadius, int orbitalPeriod, int orbitalSpeed, int objectRadius, int rotationalPeriod, Color objectColor) : base(name, objectRadius, orbitalPeriod, orbitalSpeed, objectRadius, rotationalPeriod, objectColor)
        {
            YPos = 0.0;
        }
    }

    public class DwarfPlanet : SpaceObject
    {
        public DwarfPlanet(string name, int orbitalRadius, int orbitalPeriod, int orbitalSpeed, int objectRadius, int rotationalPeriod, Color objectColor) : base(name, objectRadius, orbitalPeriod, orbitalSpeed, objectRadius, rotationalPeriod, objectColor) 
        {
            YPos = 0.0;
        }
    }
}
