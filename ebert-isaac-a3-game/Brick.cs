using System;
using System.Numerics;

namespace Game10003;
public class Brick
{
	public Vector2 position;
	public Color color;

	/*public Brick()
	{
		Draw.FillColor = Color.White;
		Draw.Rectangle(position.X, position.Y, 50, 20);
	} */
	public void Render()
	{
        Draw.FillColor = Color.White;
        Draw.Rectangle(position.X, position.Y, 50, 20);
    }
}
