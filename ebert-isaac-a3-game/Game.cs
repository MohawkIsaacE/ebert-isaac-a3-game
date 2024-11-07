// Include code libraries you need below (use the namespace).
using System;
using System.Numerics;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        Paddle player = new Paddle();
        Ball ball = new Ball();
        Brick[] bricks = new Brick[10];
        int brickX = 50;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(600, 700);
            Window.SetTitle("Brick Breaker");

            // Initialize paddle size, location, and move speed
            player.width = 40;
            player.height = 15;
            player.x = Window.Width / 2 - player.width / 2;
            player.y = 650;
            player.speed = 100;

            // Initialize ball
            ball.radius = 5;
            ball.speed = 200;
            ball.position = new Vector2(Window.Width / 2, Window.Height / 2);
            ball.direction = Random.Direction();
            Console.WriteLine($"{ball.direction.X}x {ball.direction.Y}y");

            // Initialize bricks
            for(int i = 0; i < bricks.Length; i++)
            {
                // Initialization so there's no null error
                bricks[i] = new Brick();
                // Give the bricks their own position
                bricks[i].position = new Vector2(brickX, 200);
                brickX += 50;
            }
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            // Player movement
            player.Move();
            ball.Move(player, bricks);

            // Display everything to the screen
            player.Render();
            
            for(int i = 0; i < bricks.Length; i++)
            {
                bricks[i].Render();
            }

            ball.Render();
        }
    }
}
