using System;
using System.Drawing;

namespace GrafLibrary
{
    internal class Vector
    {
        PointF _start;
        PointF _radius;

        public Vector(PointF start, PointF end)
        {
            Start = start;
            Radius = new PointF(end.X - start.X, end.Y - Start.Y);
        }
        public Vector(PointF radius)
        {
            Start = new PointF(0, 0);
            Radius = radius;
        }
        public Vector(PointF start, PointF radius, int prostoTak)
        {
            Radius = radius;
            Start = start;
        }
        public Vector(Vector v, float lenght)
        {
            _start = new PointF(v.Start.X, v.Start.Y);
            _radius = new PointF((v.Radius.X * lenght) / v.Lenght, (v.Radius.Y * lenght) / v.Lenght);
        }

        public float Lenght
        {
            get
            {
                return (float)Math.Sqrt(Radius.X * Radius.X + Radius.Y * Radius.Y);
            }
        }
        public Vector Normal
        {
            get
            {
                return new Vector(new PointF(Start.Y - End.Y, End.X - Start.X));
            }
        }
        public Vector Unit
        {
            get
            {
                return new Vector(new PointF(
                    Radius.X / Lenght,
                    Radius.Y / Lenght
                    ));
            }
        }
        public PointF MidlePoint
        {
            get
            {
                return new PointF(_start.X + _radius.X / 2, Start.Y + _radius.Y / 2);
            }
        }
        public PointF Start
        {
            get
            {
                return _start;
            }
            set
            {
                _start = value;
            }
        }
        public PointF Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }

        }
        public PointF End
        {
            get
            {
                return new PointF(_start.X + _radius.X, _start.Y + _radius.Y);
            }
        }
        public static Vector operator *(Vector v, float f)
        {
            Vector result = new Vector(new PointF(v.Radius.X * f, v.Radius.Y * f));
            result.Start = v.Start;
            return result;
        }
        public static Vector operator -(Vector v1, Vector v2)
        {
            Vector result = new Vector(new PointF(v1.Radius.X - v2.Radius.X, v1.Radius.Y - v2.Radius.Y));
            result.Start = v1.Start;
            return result;
        }
        public static Vector operator -(Vector v1)
        {
            return new Vector(v1.Start, new PointF(-v1.Radius.X, -v1.Radius.Y), 0);
        }
        public static Vector operator /(Vector v, float value)
        {
            return new Vector(new PointF(v.Start.X, v.Start.Y), new PointF(v.Radius.X / value, v.Radius.Y / value), 0);
        }
    }
}
