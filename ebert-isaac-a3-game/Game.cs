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
        string scoreText = "Score: ", livesText = "Lives: ";

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
            ball.lives = 3;
            ball.isActive = false;
            //ball.direction = Random.Direction();

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
                
                // Display how to start playing if the ball is not in motion
                if (!ball.isActive)
                {
                    Text.Size = 50;
                    Text.Draw("Press Space to play", 50, Window.Height / 2 - 50);
                }

                // Display everything to the screen
                player.Render();

                for (int i = 0; i < bricks.Length; i++)
                {
                    // Ball on brick collision detection
                    if (bricks[i].IsHit(ball))
                    {
                        ball.BrickCollide(bricks[i]);
                        bricks[i].UpdatePosition();
                        score += 50;
                    }
                    bricks[i].Render();
                }

                ball.Render();

                // Display score
                Text.Size = 25;
                Text.Draw(scoreText + score, 0, Window.Height - 25);
                // Display lives
                Text.Draw(livesText + ball.lives, Window.Width - 110, Window.Height - 25);
            }
            else // When the lives run out (game ends)
            {
                // Display final score
                Text.Size = 60;
                Text.Draw($"Final Score: {score:00000}", 10, Window.Height / 2 - 60);

                // Say how to restart
                Text.Size = 35;
                Text.Draw("Press Space to Play Again", 65, Window.Height / 2 + 50);
            }
        }
    }
}
