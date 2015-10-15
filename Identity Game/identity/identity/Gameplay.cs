using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Runtime.InteropServices;

namespace identity
{

    public class Gameplay
    {
        public Game1 game;
        Texture2D Kurt, Stam, Heal, lantern;
        public static Vector2 KurtPos;
        public static int Health;
        public static double Stamina;
        Vector2 StamPos = new Vector2(50, 60);
        Vector2 HealthPos = new Vector2(50, 30);
        Vector2 MovePos;
        public static Rectangle KurtRect;
        float walktime;
        int step;
        int stampowerup = 1;
        float stamtimer;
        float healthtimer;
        private KeyboardState newState;
        public static float KurtOpaque = 1;
        public Rectangle lanpos = new Rectangle(1050, 20, 80, 108);
        public float lantscale = 0.3f;

        Point frameSize = new Point(94, 108);
        public static Point currentFrame = new Point(0, 0);
        Point sheetSize = new Point(3, 0);

        int timeSinceLastFrame = 0;
        int millisecondsPerFrame = 100;

        public Gameplay(Game1 game)
        {
            this.game = game;
            Kurt = game.Content.Load<Texture2D>("images/KURT SPREEDSHEET 2");
            Stam = game.Content.Load<Texture2D>("images/Stamina");
            Heal = game.Content.Load<Texture2D>("images/Health");
            lantern = game.Content.Load<Texture2D>("images/lantern");
            Health = 1000;
            Stamina = 1000;
        }
        public void Update(GameTime Gametime)
        {
            //Movement
            KeyboardState keyboardState = Keyboard.GetState();
            newState = keyboardState;
        
            if (walktime == 0)
            {
                if (Text.textpause == 0)
                {
                    if (newState.IsKeyDown(Keys.Up))
                    {
                        step = 1;
                        currentFrame.Y = 1;
                    }
                    if (newState.IsKeyDown(Keys.Down))
                    {
                        step = 2;
                        currentFrame.Y = 0;
                    }
                    if (newState.IsKeyDown(Keys.Left))
                    {
                        step = 3;
                        currentFrame.Y = 2;
                    }
                    if (newState.IsKeyDown(Keys.Right))
                    {
                        step = 4; 
                        currentFrame.Y = 3;
                    }
                }
                if (newState.IsKeyUp(Keys.Right) && newState.IsKeyUp(Keys.Left) && newState.IsKeyUp(Keys.Up) && newState.IsKeyUp(Keys.Down))
                {
                    currentFrame.X = 0;
                }
            }
            if (step == 1)
            {
                walktime += 1;
                KurtPos.Y -= MovePos.Y;
            }
            if (step == 2)
            {
                walktime += 1;
                KurtPos.Y += MovePos.Y;
            }
            if (step == 3)
            {
                walktime += 1;
                KurtPos.X -= MovePos.X;
            }
            if (step == 4)
            {
                walktime += 1;
                KurtPos.X += MovePos.X;
            }
            if (step == 1 || step == 2)
            {
                if (walktime >= 18)
                {
                    step = 0;
                    walktime = 0;
                }
            }
            if (step == 3 || step == 4)
            {
                if (walktime >= 17)
                {
                    step = 0;
                    walktime = 0;
                }
            }
            
            if (walktime >= 1)
            {
                if (newState.IsKeyDown(Keys.LeftShift))
                {
                    if (Stamina > 0) { MovePos = new Vector2(10, 12); }
                    else { MovePos = new Vector2(5, 6); }
                    Stamina -= 5;
                    stamtimer = 0;
                }
                else if (newState.IsKeyDown(Keys.RightShift))
                {
                    MovePos = new Vector2(2, 2);
                }
                else
                {
                    MovePos = new Vector2(5, 6);
                }
            }

            //Sprite Movement
            if (step != 0)
            {
                timeSinceLastFrame += Gametime.ElapsedGameTime.Milliseconds;
                if (timeSinceLastFrame > millisecondsPerFrame)
                {
                    timeSinceLastFrame -= millisecondsPerFrame;
                    ++currentFrame.X;

                    if (currentFrame.X > sheetSize.X)
                    {
                        currentFrame.X = 0;
                    }
                }
            }

            KurtRect = new Rectangle((int)KurtPos.X, (int)KurtPos.Y, 84, 108);

            //Stamina and Health Regen
            if (Stamina <= 0)
            {
                Stamina = 0;
            }
            if (Stamina >= 1000)
            {
                Stamina = 1000;
            }

            if (newState.IsKeyUp(Keys.LeftShift))
            {
                stamtimer += 0.016666f;
                if (stamtimer >= 3)
                    Stamina += 0.4f * stampowerup;
            }
            
            if (newState.IsKeyDown(Keys.P))
            {
                game.pausegame = 1;
            }
            if (Health <= 0)
            {
                Health = 0;
            }
            if (Health >= 1000)
            {
                Health = 1000;
            }


        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            spritebatch.Draw(Kurt, KurtPos, new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y), Color.White * KurtOpaque, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            spritebatch.Draw(Stam, StamPos, new Rectangle(0, 0, (int)((0.255 * Stamina) + 5), 23), Color.White * 0.6f, 0, Vector2.Zero, game.scale, SpriteEffects.None, 0);
            spritebatch.Draw(Heal, HealthPos, new Rectangle(0, 0, (int)((0.255 * Health) + 5), 23), Color.White * 0.6f, 0, Vector2.Zero, game.scale, SpriteEffects.None, 0);
            if (Chapter2b.langet == 1)
            { spritebatch.Draw(lantern, new Vector2(lanpos.X, lanpos.Y), null, Color.White, 0, Vector2.Zero, lantscale, SpriteEffects.None, 1); }
            spritebatch.End();
        }

    }
}
