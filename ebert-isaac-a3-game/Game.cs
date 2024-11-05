﻿// Include code libraries you need below (use the namespace).
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
        Brick[] bricks = new Brick[100];

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(600, 700);
            Window.SetTitle("Brick Breaker");

            // Initialize paddle size and location
            player.width = 40;
            player.height = 15;
            player.x = Window.Width / 2 - player.width / 2;
            player.y = 650;

            // Initialize ball
            ball.radius = 5;
            ball.position = new Vector2(Window.Width / 2, Window.Height / 2);

            // Initialize bricks
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            // Display everything to the screen
            player.Render();
            ball.Render();
            foreach (Brick b in bricks)
            {
                b.Render();
            }
        }
    }
}
