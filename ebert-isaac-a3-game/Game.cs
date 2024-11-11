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
        Brick[] bricks = new Brick[60];
        int score;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(600, 700);
            Window.SetTitle("Brick Breaker");

            // Reset score
            score = 0;

            // Initialize paddle size, location, and move speed
            player.width = 62;
            player.height = 18;
            player.x = Window.Width / 2 - player.width / 2;
            player.y = 650;
            player.speed = 200;

            // Initialize ball
            ball.radius = 7;
            ball.speed = 200;
            ball.isActive = false;
            ball.direction = Random.Direction();
            Console.WriteLine($"{ball.direction.X}x {ball.direction.Y}y");

            int brickX = 50;
            int brickY = 10;
            // Initialize bricks
            for (int i = 0; i < bricks.Length; i++)
            {
                // Initialization so there's no null error
                bricks[i] = new Brick();
                // Move to the next row
                if (i % 10 == 0)
                {
                    brickY += 20;
                    brickX = 50;
                }
                // Give the bricks their own position
                bricks[i].SetPosition(brickX, brickY);
                // Move to the next column
                brickX += 50;
            }
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            // Check if the game should continue playing
            if (ball.lives > 0)
            {
                // Player movement
                player.Move();
                ball.Move(player, bricks);

                // Display everything to the screen
                player.Render();

                for (int i = 0; i < bricks.Length; i++)
                {
                    // Ball on brick collision detection
                    if (bricks[i].IsHit(ball))
                    {
                        ball.BrickCollide(bricks[i]);
                        bricks[i].UpdatePosition();
                        score += 100;
                    }
                    bricks[i].Render();
                }

                ball.Render();
            }
        }
    }
}
