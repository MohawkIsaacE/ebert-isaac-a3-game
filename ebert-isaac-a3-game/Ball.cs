using System;
using System.Numerics;

namespace Game10003;

public class Ball
{
    public float radius;
    public Vector2 position;
    public int speed;

    bool isLeftOfWindow, isRightOfWindow, isAboveWindow, isBelowWindow;

    public void Render()
    {
        Draw.FillColor = Color.Red;
        Draw.Circle(position, radius);
    }

    public void Move()
    {
        // Window collision detection
        isLeftOfWindow = radius <= 0;
        isRightOfWindow = radius >= Window.Width;
        isAboveWindow = radius <= 0;
        isBelowWindow = radius >= Window.Height;

        // Ricochet the ball if it hits the sides or the top of the window
        if (isLeftOfWindow || isRightOfWindow)
        {
            position.X = -position.X;
        }

        if (isAboveWindow)
        {
            position.Y = -position.Y;
        }

    }
}
