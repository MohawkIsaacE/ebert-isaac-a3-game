using Game10003;
using System;
using System.Drawing;
using System.Numerics;

namespace Game10003;
public class Paddle
{
	public float x, y;
	public int width, height;
	public int speed;

    float playerLeftEdge, playerRightEdge, playerTopEdge, playerBottomEdge;
    bool isLeftOfWindow, isRightOfWindow, isAboveWindow, isBelowWindow;

    /// <summary>
    ///		Renders the paddle to the screen
    /// </summary>
    public void Render()
	{
		Draw.FillColor = new Color(100, 100, 100);
		Draw.Rectangle(x, y, width, height);
    }

    /// <summary>
    ///     Calc
    /// </summary>
	public void Move()
	{
        // Compute each side of the player
        playerLeftEdge = x;
        playerRightEdge = x + width;
        playerTopEdge = y;
        playerBottomEdge = y + height;

        // Check each side and see if player is out-of-bounds
        isLeftOfWindow = playerLeftEdge <= 0;             // left check
        isRightOfWindow = playerRightEdge >= Window.Width;  // right check
        isAboveWindow = playerTopEdge <= 0;             // top check
        isBelowWindow = playerBottomEdge >= Window.Height; // bottom check

        // Get movement
        if (Input.IsKeyboardKeyDown(KeyboardInput.A) || Input.IsKeyboardKeyDown(KeyboardInput.Left))
        {
            moveLeft();
        }

        if (Input.IsKeyboardKeyDown(KeyboardInput.D) || Input.IsKeyboardKeyDown(KeyboardInput.Right))
        {
            moveRight();
        }
    }

	/// <summary>
	///		Move the paddle to the left
	/// </summary>
	public void moveLeft()
	{
		if (!isLeftOfWindow)
		{
            x -= 1 * speed * Time.DeltaTime;
        }
	}

	/// <summary>
	///		Move the paddle to the right
	/// </summary>
    public void moveRight()
    {
        if (!isRightOfWindow)
        {
            x += 1 * speed * Time.DeltaTime;
        }
    }
}
