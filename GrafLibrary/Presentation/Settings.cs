using System;
using System.Collections.Generic;
using System.Drawing;

namespace GrafLibrary.Presentation
{
    public static class Settings
    {
        public static PartState Simple = new PartState("Simple", Color.Black);
        public static PartState OnDelete = new PartState("On delete", Color.Red);
        public static PartState Active = new PartState("On setting", Color.Green);
        public static PartState OnWay = new PartState("On way", Color.Orange);

        public static Dictionary<Type, GrafPartSize> Sizes { get; set; } = new Dictionary<Type, GrafPartSize>
        {
            [typeof(DrawingVertex)] = new GrafPartSize(20, 25),
            [typeof(DrawingEdge)] = new GrafPartSize(5, 7),
            [typeof(DrawingLoop)] = new GrafPartSize(70, 80)
        };
    }
    public struct GrafPartSize
    {
        public int simple;
        public int big;
        public GrafPartSize(int simple, int big)
        {
            this.simple = simple;
            this.big = big;
        }
    }
}
