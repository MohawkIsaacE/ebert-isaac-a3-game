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
    bool isWithinPaddleX, isWithinPaddleY, isWithinPaddle;

    public void Render()
    {
        Draw.FillColor = Color.Green;
        Draw.Circle(position, radius);
    }

    public void Move(Paddle paddle, Brick[] bricks)
    {
        // Window collision detection
        isLeftOfWindow = position.X - radius <= 0;
        isRightOfWindow = position.X + radius >= Window.Width;
        isAboveWindow = position.Y - radius <= 0;
        isBelowWindow = position.Y + radius >= Window.Height;

        // Paddle collision detection
        isWithinPaddleX = position.X + radius > paddle.playerLeftEdge && position.X - radius < paddle.playerRightEdge;
        isWithinPaddleY = position.Y + radius > paddle.playerTopEdge && position.Y - radius < paddle.playerBottomEdge;
        isWithinPaddle = isWithinPaddleX && isWithinPaddleY;

        // Brick collision detection

        // Ricochet the ball if it hits the sides or the top of the window, the paddle, or a brick
        if (isLeftOfWindow || isRightOfWindow || (isWithinPaddleX && position.Y > paddle.playerTopEdge && position.Y < paddle.playerBottomEdge))
        {
            direction.X = -direction.X;
            if (direction.X > 0) position.X += 1;
            if (direction.X < 0) position.X -= 1;
        }

        if (isAboveWindow || (isWithinPaddle && !isWithinPaddleX) || (isWithinPaddleY && isWithinPaddle))
        {
            direction.Y = -direction.Y;
        }

        position.X += direction.X * speed * Time.DeltaTime;
        position.Y += direction.Y * speed * Time.DeltaTime;
        
    }
}
