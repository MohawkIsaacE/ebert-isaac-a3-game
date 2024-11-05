using Game10003;
using System;
using System.Numerics;

namespace Game10003;
public class Paddle
{
	public float x, y;
	public int width, height;

	/// <summary>
	///		Renders the paddle to the screen
	/// </summary>
	public void Render()
	{
		Draw.FillColor = Color.Blue;
		Draw.Rectangle(x, y, width, height);
	}
}
