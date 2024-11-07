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

        // Ricochet the ball if it hits the sides or the top of the window or the paddle
        if (isLeftOfWindow || isRightOfWindow || (isWithinPaddleX && position.Y > paddle.playerTopEdge && position.Y < paddle.playerBottomEdge))
        {
            InvertX();
        }

        if (isAboveWindow || (isWithinPaddle && !isWithinPaddleX) || (isWithinPaddleY && isWithinPaddle))
        {
            InvertY();
        }

        // Update position
        position.X += direction.X * speed * Time.DeltaTime;
        position.Y += direction.Y * speed * Time.DeltaTime;
        
    }

    private void InvertY()
    {
        direction.Y = -direction.Y;
        if (direction.Y > 0) position.Y += 1;
        if (direction.Y < 0) position.Y -= 1;
    }

    private void InvertX()
    {
        direction.X = -direction.X;
        if (direction.X > 0) position.X += 2;
        if (direction.X < 0) position.X -= 2;
    }

    /// <summary>
    ///     Ricochets the ball when it hits a brick
    /// </summary>
    public void BrickCollide(Brick brick)
    {
        // Detect if the ball is in the brick
        bool isWithinBrickX = position.X + radius > brick.leftSide && position.X - radius < brick.rightSide;
        bool isWithinBrickY = position.Y + radius > brick.top && position.Y - radius < brick.bottom;
        bool isWithinBrick = isWithinBrickX && isWithinBrickY;

        // Ricochet if ball hits brick on left or right side
        if (isWithinBrickX && isWithinBrick)
        {
            InvertX();
        }

        // Ricochet if ball hits brick on top or bottom
        if (isWithinBrickY && isWithinBrick)
        {
            InvertY();
        }
    }
}
