using System;
using System.Numerics;

namespace Game10003;

public class Ball
{
    public float radius;
    public Vector2 position;

    bool isLeftOfWindow, isRightOfWindow, isAboveWindow, isBelowWindow;

    public void Render()
    {
        Draw.FillColor = Color.Red;
        Draw.Circle(position, radius);
    }

    public void Move()
    {
        isLeftOfWindow = radius <= 0;
        isRightOfWindow = radius >= Window.Width;
        isAboveWindow = radius <= 0;
        isBelowWindow = radius >= Window.Height;
    }
}
