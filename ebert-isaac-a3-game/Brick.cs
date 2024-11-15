using System;
using System.Numerics;
using System.Security.AccessControl;

namespace Game10003;
public class Brick
{
	public Vector2 position;
	int width = 50;
	int height = 20;
	public Color color;

	public float leftSide, rightSide, top, bottom;

	/// <summary>
	///		Sets the position of the brick
	///		Also sets the side locations
	/// </summary>
	public void SetPosition(float x, float y)
	{
		position = new Vector2(x, y);

		leftSide = position.X;
		rightSide = position.X + width;
		top = position.Y;
		bottom = position.Y + height;
	}

	public void Render()
	{
        Draw.FillColor = color;
        Draw.Rectangle(position.X, position.Y, width, height);
    }
	
	/// <summary>
	///		Detects if the ball hits a brick. Move the brick off screen if so.
	/// </summary>
	public bool IsHit(Ball ball)
	{
		bool isWithinBrickX = ball.position.X + ball.radius > leftSide && ball.position.X - ball.radius < rightSide;
		bool isWithinBrickY = ball.position.Y + ball.radius > top && ball.position.Y - ball.radius < bottom;
		bool isWithinBrick = isWithinBrickX && isWithinBrickY;

		if (isWithinBrick)
		{
			return true;
		}
		return false;
	}

	/// <summary>
	///		Updates the position of the brick
	/// </summary>
	public void UpdatePosition()
	{
        position.Y -= 1000;
        top = position.Y;
        bottom = position.Y + height;
    }
}
