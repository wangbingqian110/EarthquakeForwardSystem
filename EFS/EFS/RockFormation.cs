using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ZedGraph;

namespace EFS
{
    class RockFormation
    {
        public string Name { get; set; }
        public string Speed { get; set; }
        public string Density { get; set; }
        public Color Color { get; set; }

        public RockFormation(string name,string speed, string density, Color color)
        {
            Name = name;
            Speed = speed;
            Density = density;
            Color = color;
        }
    }
}
