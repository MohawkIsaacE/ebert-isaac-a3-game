using System;
using System.Numerics;

namespace Game10003;

public class Ball
{
    public float radius;
    public Vector2 position;
    public int speed;
    public Vector2 direction;

    bool isLeftOfWindow, isRightOfWindow, isAboveWindow, isBelowWindow;

    public void Render()
    {
        Draw.FillColor = Color.Green;
        Draw.Circle(position, radius);
    }

    public void Move()
    {
        // Window collision detection
        isLeftOfWindow = position.X - radius <= 0;
        isRightOfWindow = position.X + radius >= Window.Width;
        isAboveWindow = position.Y - radius <= 0;
        isBelowWindow = position.Y + radius >= Window.Height;

        // Ricochet the ball if it hits the sides or the top of the window
        if (isLeftOfWindow || isRightOfWindow)
        {
            direction.X = -direction.X;
        }

        if (isAboveWindow)
        {
            direction.Y = -direction.Y;
        }

        position.X += direction.X * speed * Time.DeltaTime;
        position.Y += direction.Y * speed * Time.DeltaTime;
    }
}
