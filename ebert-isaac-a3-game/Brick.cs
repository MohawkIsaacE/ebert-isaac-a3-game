using System;
using System.Numerics;

namespace Game10003;
public class Brick
{
	public Vector2 position;
	int width = 50;
	int height = 20;
	public Color color;

	public float leftSide, rightSide, top, bottom;

	public Brick()
	{
		leftSide = position.X;
		rightSide = position.X + width;
		top = position.Y;
		bottom = position.Y + height;
		Console.WriteLine(leftSide);
	}

	public void Render()
	{
        Draw.FillColor = Color.Red;
        Draw.Rectangle(position.X, position.Y, width, height);
    }

	public void IsHit(Ball ball)
	{

	}
}
