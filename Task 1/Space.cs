using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Threading;

namespace Space
{
    public class SpaceObject
    {
        public double XPos { get; set; }
        public double YPos { get; set; }
        public string Name { get; set; }
        public double OrbitalRadius { get; set; }
        public double OrbitalPeriod { get; set; }
        public double OrbitalSpeed { get; set; }
        public double ObjectRadius { get; set; }
        public Color ObjectColor { get; set; }
        public SpaceObject(string name, double orbitalRadius, double orbitalPeriod, double objectRadius, Color objectColor)
        {
            XPos = 0.0;
            YPos = 0.0;
            Name = name;
            OrbitalRadius = orbitalRadius / 5000;
            OrbitalPeriod = orbitalPeriod / 5000;
            OrbitalSpeed = orbitalPeriod / OrbitalRadius / 5;
            ObjectRadius = objectRadius;
            ObjectColor = objectColor;
        }
    }
    public class Star : SpaceObject
    {
        public List<Planet> planets;
        public delegate void DT(int time, ref double speed);
        public DispatcherTimer t = new DispatcherTimer();
        public int time = 0;
        public event DT Move;
        public double Speed = 1;
        public Star(string name, double orbitalRadius, double orbitalPeriod, double objectRadius, Color objectColor) : base(name, orbitalRadius, orbitalPeriod, objectRadius, objectColor)
        {
            planets = new List<Planet>
            {
             new Planet(this, "Mercury", 57910 * 5, 87 * 5, 5, Colors.BlueViolet, 0),
             new Planet(this, "Venus", 108200 * 3.2, 224 * 3, 5, Colors.Yellow, 0),
             new Planet(this, "Terra", 149600 * 3, 365 * 3.5, 5, Colors.DeepSkyBlue, 1),
             new Planet(this, "Mars", 227940 * 2.5, 687 * 2.5, 5, Colors.OrangeRed, 0),
             new Planet(this, "Jupiter", 778330, 4333 / 2, 25, Colors.Beige, 0),
             new Planet(this, "Saturn", 1429400, 10760 / 4, 20, Colors.LightYellow, 0),
             new Planet(this, "Uranus", 2870990 / 1.6, 30685 / 8, 15, Colors.LightCyan, 0),
             new Planet(this, "Neptune", 4504300 / 2.2, 60190 / 10, 15, Colors.DarkBlue, 0),
             new Planet(this, "Pluto", 5913520 / 2.5, 90550 / 20, 5, Colors.Gray, 0)
            };
            t.Interval = new TimeSpan(200000);
            t.Tick += Tick;
            t.Start();
        }

        private void Tick(object sender, EventArgs e)
        {
            Move(time++, ref Speed);
        }
        public void HigherSpeed()
        {
            Speed += 0.5;
        }

        public void LowerSpeed()
        {
            if(Speed > 1)
            {
                Speed -= 0.5;
            }
          
        }

        public void Pause()
        {
            Speed = 0;
        }

        public void Resume()
        {
            Speed = 1;
        }
    }
    public class Planet : SpaceObject
    {
        public List<Moon> Moons = new List<Moon>();
        public Star Star;
        public Planet(Star star, string name, double orbitalRadius, double orbitalPeriod, double objectRadius, Color objectColor, int moons) : base(name, orbitalRadius, orbitalPeriod, objectRadius, objectColor)
        {
            Star = star;
            for(int i = 0; i<moons; i++)
            {
                Moons.Add(new Moon(this, "The Moon", OrbitalRadius * 500, 28 * 20, 2, Colors.LightGray));
            }
            star.Move += CalcPos;
        }

        public void CalcPos(int time, ref double speed)
        {
            XPos = OrbitalRadius + (int)(Math.Cos(speed * time * OrbitalSpeed * 3.1416 / 180) * OrbitalRadius);
            YPos = OrbitalRadius + (int)(Math.Sin(speed * time * OrbitalSpeed * 3.1416 / 180) * OrbitalRadius);
        }
    }



    public class Moon : SpaceObject
    {
        public Planet Planet; 
        public Moon(Planet planet, string name, double orbitalRadius, double orbitalPeriod, double objectRadius, Color objectColor) : base(name, orbitalRadius, orbitalPeriod, objectRadius, objectColor)
        {
            XPos = planet.XPos;
            YPos = 0.0;
            Planet = planet;
            planet.Star.Move += CalcPos;
        }

        public void CalcPos(int time, ref double speed)
        {
            XPos = OrbitalRadius + (int)(Math.Cos(speed * time * OrbitalSpeed * 3.1416 / 180) * OrbitalRadius);
            YPos = OrbitalRadius + (int)(Math.Sin(speed * time * OrbitalSpeed * 3.1416 / 180) * OrbitalRadius);
        }
    }

    public class Comet : SpaceObject
    {
        public Comet(string name, double orbitalRadius, double orbitalPeriod, double objectRadius, Color objectColor) : base(name, orbitalRadius, orbitalPeriod, objectRadius, objectColor)
        {
            YPos = 0.0;
        }
    }

    public class Asteriod : SpaceObject
    {
        public Asteriod(string name, double orbitalRadius, double orbitalPeriod, double objectRadius, Color objectColor) : base(name, orbitalRadius, orbitalPeriod, objectRadius, objectColor)
        {
            YPos = 0.0;
        }
    }

    public class DwarfPlanet : SpaceObject
    {
        public DwarfPlanet(string name, double orbitalRadius, double orbitalPeriod, double objectRadius, Color objectColor) : base(name, orbitalRadius, orbitalPeriod, objectRadius, objectColor)
        {
            YPos = 0.0;
        }
    }
}
