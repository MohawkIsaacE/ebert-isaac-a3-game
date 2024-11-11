using System;
using System.Numerics;

namespace Game10003;

public class Ball
{
    public float radius;
    public Vector2 position;
    public int speed;
    public Vector2 direction;
    public int lives;
    public bool isActive;

    bool isLeftOfWindow, isRightOfWindow, isAboveWindow, isBelowWindow;
    bool isWithinPaddleX, isWithinPaddleY, isWithinPaddle;

    /// <summary>
    ///     Displays the ball to the screen
    /// </summary>
    public void Render()
    {
        Draw.FillColor = Color.Green;
        Draw.Circle(position, radius);
    }

    /// <summary>
    ///     Handles the movement of the ball and wall and paddle collision
    /// </summary>
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

        // Ricochet the ball if it hits the sides of the window or paddle
        if (isLeftOfWindow || isRightOfWindow || (isWithinPaddleX && position.Y > paddle.playerTopEdge && position.Y < paddle.playerBottomEdge))
        {
            InvertX();
        }

        // Randomize the direction of the ball when it hits the paddle
        if ((isWithinPaddle && !isWithinPaddleX) || (isWithinPaddleY && isWithinPaddle))
        {
            direction = Random.Direction();
            direction.Y = -1;
            position.Y -= radius + 1;
        }

        // Ricochets the ball when it hits the top of the window
        if (isAboveWindow)
        {
            InvertY();
        }

        // Starts the game when the player presses the spacebar
        if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
        {
            isActive = true;
            direction.Y = 1;
        }

        // If ball goes off screen, reset the postion and take away a life
        if (isBelowWindow)
        {
            isActive = false;
            lives--;
        }

        // Update position
        // Detect if the player has started playing yet
        if (isActive)
        {
            // Moves the ball
            position.X += direction.X * speed * Time.DeltaTime;
            position.Y += direction.Y * speed * Time.DeltaTime;
        }
        else
        {
            // Keeps the ball on top of the paddle
            position.X = paddle.playerLeftEdge + paddle.width / 2;
            position.Y = paddle.playerTopEdge - (radius + 1); // Slightly above the paddle
        }
        
    }

    /// <summary>
    ///     Inverts the Y direction of the ball and offsets the ball so it doesn't get stuck in something
    /// </summary>
    private void InvertY()
    {
        direction.Y = -direction.Y;
        if (direction.Y > 0) position.Y += 1;
        if (direction.Y < 0) position.Y -= 1;
    }

    /// <summary>
    ///     Inverts the X direction of the ball and offsets the ball so it doesn't get stuck in something
    /// </summary>
    private void InvertX()
    {
        direction.X = -direction.X;
        if (direction.X > 0) position.X += 1;
        if (direction.X < 0) position.X -= 1;
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
        if (isWithinBrick && position.Y + radius < brick.bottom && position.Y + radius > brick.top)
        {
            InvertX();
        }

        // Ricochet if ball hits brick on top or bottom
        if (isWithinBrick && position.X + radius < brick.rightSide && position.X + radius > brick.leftSide)
        {
            InvertY();
        }
    }
}
