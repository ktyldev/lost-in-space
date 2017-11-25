using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public static Point operator +(Point a, Point b)
    {
        return new Point
        {
            X = a.X + b.X,
            Y = a.Y + b.Y
        };
    }

    public override bool Equals(object obj)
    {
        var point = (Point)obj;
        if (point == null)
            return false;

        return point.X == X && point.Y == Y;
    }
}
