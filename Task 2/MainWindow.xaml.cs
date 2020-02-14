using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Space;

namespace Task_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Star star;
        public string CurrentName = "";
        public MainWindow()
        {
            InitializeComponent();
            
            Width = SystemParameters.PrimaryScreenWidth;
            Height = SystemParameters.PrimaryScreenHeight;

            star = new Star("Sun", 5000, 5000, 50, Colors.DarkRed);

            Ellipse Sun = new Ellipse();
            SolidColorBrush scb = new SolidColorBrush();
            scb.Color = star.ObjectColor;
            Sun.Fill = scb;
            Sun.Width = star.ObjectRadius * 2;
            Sun.Height = star.ObjectRadius * 2;
            double nullW = star.XPos + (Width / 2) - star.ObjectRadius;
            double nullH = star.YPos + (Height / 2) - star.ObjectRadius;

            Sun.MouseEnter += AddName;

            Canvas.SetLeft(Sun, nullW - star.ObjectRadius);
            Canvas.SetTop(Sun, nullH - star.ObjectRadius);

            star.t.Tick += (object sender, EventArgs e) =>
            {
                Solarsystem.Children.Clear();
                Solarsystem.Children.Add(GetTextBox());
                Solarsystem.Children.Add(Sun);

                foreach (Planet p in star.planets)
                {
                    Ellipse s = new Ellipse();
                    scb = new SolidColorBrush();
                    scb.Color = p.ObjectColor;
                    s.Fill = scb;
                    s.Width = p.ObjectRadius * 2;
                    s.Height = p.ObjectRadius * 2;

                    double nullWP = nullW + p.XPos - p.ObjectRadius - p.OrbitalRadius;
                    double nullHP = nullH + p.YPos - p.ObjectRadius - p.OrbitalRadius;

                    Canvas.SetLeft(s, nullWP);
                    Canvas.SetTop(s, nullHP);

                    s.MouseEnter += AddName;

                    Solarsystem.Children.Add(s);

                    foreach (Moon m in p.Moons)
                    {
                        Ellipse sm = new Ellipse();
                        scb = new SolidColorBrush();
                        scb.Color = m.ObjectColor;
                        sm.Fill = scb;
                        sm.Width = m.ObjectRadius * 2;
                        sm.Height = m.ObjectRadius * 2;

                        Canvas.SetLeft(sm, nullWP + m.XPos + m.ObjectRadius - m.OrbitalRadius);
                        Canvas.SetTop(sm, nullHP + m.YPos + m.ObjectRadius - m.OrbitalRadius);

                        sm.MouseEnter += AddName;

                        Solarsystem.Children.Add(sm);
                    }
                }
            };
        }

        private void AddName(object sender, MouseEventArgs e)
        {
            Point mouse = e.GetPosition(Application.Current.MainWindow);
            mouse.X -= (Width / 2) - star.ObjectRadius;
            mouse.Y -= (Height / 2) - star.ObjectRadius;
            if ((mouse.X < 50 && mouse.Y < 50) && (mouse.X > -50 && mouse.Y > -50))
            {
                CurrentName = star.Name;
            }
            else
            {
                mouse.X += (star.ObjectRadius / 2) - 10;
                foreach (Planet p in star.planets)
                {
                    if(mouse.X > p.OrbitalRadius)
                    {
                        CurrentName = p.Name;
                    } else
                    {
                        foreach (Moon m in p.Moons)
                        {
                            if (mouse.X < m.XPos + m.ObjectRadius && mouse.Y < m.YPos + m.ObjectRadius)
                            {
                               // CurrentName = m.Name;
                            }
                        }
                    }
                }
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.Left:
                    star.LowerSpeed();
                    break;
                case Key.Right:
                    star.HigherSpeed();
                    break;
                case Key.Down:
                    star.Pause();
                    break;
                case Key.Up:
                    star.Resume();
                    break;
                default:
                    return;
            }
        }

        private TextBox GetTextBox()
        {
            TextBox tb = new TextBox();
            tb.Background = Brushes.Black;
            tb.Foreground = Brushes.White;
            tb.BorderThickness = new Thickness(0);
            tb.Text = CurrentName;
            tb.FontSize = 30;
            return tb;
        }
    }
}
