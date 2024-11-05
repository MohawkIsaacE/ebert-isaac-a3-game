using Game10003;
using System;
using System.Numerics;

namespace Game10003;
public class Paddle
{
	public float x, y;
	public int width, height;
	public int speed;

	/// <summary>
	///		Renders the paddle to the screen
	/// </summary>
	public void Render()
	{
		Draw.FillColor = Color.Blue;
		Draw.Rectangle(x, y, width, height);
	}

	/// <summary>
	///		Move the paddle to the left
	/// </summary>
	public void moveLeft()
	{
		if (x > 0)
		{
            x -= 1 * speed * Time.DeltaTime;
        }
	}

	/// <summary>
	///		Move the paddle to the right
	/// </summary>
    public void moveRight()
    {
        if (x < Window.Width)
        {
            x += 1 * speed * Time.DeltaTime;
        }
    }
}
