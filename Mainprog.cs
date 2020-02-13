using System;
using System.Collections.Generic;
using SpaceSim;
using System.Drawing;
using System.Windows.Threading;

class Astronomy
{
    public delegate void TG(int time);
    private DispatcherTimer t;
    private static int time = 0;
    public static event TG move;

    public static void Main()
    {
        
         List<SpaceObject> solarSystem = new List<SpaceObject>
         {
             new Star("Sun", 0, 0, 1, 0, 0, Color.DarkRed),
             new Planet(1.0, "Mercury", 0, 0, 1, 0, 0, Color.BlueViolet),
             new Planet(2.0, "Venus", 0, 0, 1, 0, 0, Color.Yellow),
             new Planet(3.0, "Terra", 0, 0, 1, 0, 0, Color.DeepSkyBlue),
             new Planet(4.0, "Mars", 0, 0, 1, 0, 0, Color.OrangeRed),
             new Planet(5.0, "Jupiter", 0, 0, 1, 0, 0, Color.Beige),
             new Planet(6.0, "Saturn", 0, 0, 1, 0, 0, Color.LightYellow),
             new Planet(7.0, "Uranus", 0, 0, 1, 0, 0, Color.LightCyan),
             new Planet(8.0, "Neptune", 0, 0, 1, 0, 0, Color.DarkBlue),

         };
        foreach(SpaceObject so in solarSystem)
        {
            move += so.CalcPos;
            Console.WriteLine(so.XPos);
        }
    }

    private static void t_Tick(object sender, EventArgs e)
    {
        move(time++);
    }
}

