using System;
using System.Numerics;

namespace Game10003;

public class Ball
{
    public int radius;
    public Vector2 position;

    public void Render()
    {
        Draw.FillColor = Color.Red;
        Draw.Circle(position, radius);
    }
}
