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

    public class Chapter2b
    {
        public Game1 game;
        public Texture2D background, lantern;
        public Rectangle border = new Rectangle(0, 183, 1200, 354);
        public Rectangle border2 = new Rectangle(659, 47, 451, 628);
        public Rectangle border3;
        public Rectangle border4;
        public Rectangle border5;
        public Rectangle border6;
        public Rectangle border7;
        public Rectangle jumpscare;
        public Rectangle lanpos = new Rectangle(900, 330, 80, 108);
        public float lantscale = 1;
        public static int langet;
        private KeyboardState newState;
        public SoundEffect getout;
        int music = 0;
        int exit;
        int startexit;
        int back;
        float opacity = 1;

        public Chapter2b(Game1 game)
        {
            this.game = game;
            background = game.Content.Load<Texture2D>("images/broken hallway light");
            lantern = game.Content.Load<Texture2D>("images/lantern");
            //getout = game.Content.Load<SoundEffect>("Sounds/Get Out Sound");
        }
        public void Update(GameTime Gametime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            newState = keyboardState;

            if (background == game.Content.Load<Texture2D>("images/broken hallway light"))
            {
                //y=-1/276x+48/23
                Gameplay.KurtOpaque = (float)Math.Abs((-0.00362318840579 * Gameplay.KurtPos.X) + 2.0869);
                if (newState.IsKeyDown(Keys.Z))
                {
                    Text.textinitiate = 0;
                    back = 1;
                }
                if (back == 0)
                {
                    Text.textinitiate = 6;
                }
                if (Gameplay.KurtPos.X <= border.X)
                {
                    Gameplay.KurtPos.X = border.X;
                }
                if (Gameplay.KurtPos.X + 84 >= border.Width)
                {
                    if (back == 1)
                    {
                        Gameplay.KurtPos.X = 0;
                        background = game.Content.Load<Texture2D>("images/light room");
                    }
                    else
                    {
                        Gameplay.KurtPos.X = border.Width - 84;
                    }
                }
                if (Gameplay.KurtPos.Y <= border.Y)
                {
                    Gameplay.KurtPos.Y = border.Y;
                }
                if (Gameplay.KurtPos.Y + 108 >= border.Y + border.Height)
                {
                    Gameplay.KurtPos.Y = border.Height + border.Y - 108;
                }
            }
            if (background == game.Content.Load<Texture2D>("images/light room"))
            {
                if (music == 0)
                {
                    //getout.Play();
                    music = 1;
                }
                border.Width = 650;
                if (Gameplay.KurtPos.X <= border.X)
                {
                    Gameplay.KurtPos.X = border.X;
                }
                if (Gameplay.KurtPos.Y <= border.Y && Gameplay.KurtPos.X <= border.Width)
                {
                    Gameplay.KurtPos.Y = border.Y;
                }
                if (Gameplay.KurtPos.Y + 108 >= border.Y + border.Height && Gameplay.KurtPos.X <= border.Width)
                {
                    Gameplay.KurtPos.Y = border.Height + border.Y - 108;
                }
                if (Gameplay.KurtPos.Y <= border2.Y)
                {
                    Gameplay.KurtPos.Y = border2.Y;
                }
                if (Gameplay.KurtPos.Y + 108 >= border2.Y + border2.Height)
                {
                    Gameplay.KurtPos.Y = border2.Height + border2.Y - 108;
                }
                if (Gameplay.KurtPos.X + 84 >= border2.Width + border2.X)
                {
                    Gameplay.KurtPos.X = border2.Width + border2.X - 84;
                }
                if (Gameplay.KurtPos.X <= border2.X && Gameplay.KurtPos.Y <= border.Y && Gameplay.KurtPos.X >= border.Width + border.X)
                {
                    Gameplay.KurtPos.X = border2.X;
                }
                if (Gameplay.KurtPos.X <= border2.X && Gameplay.KurtPos.Y + 108 >= border.Y + border.Height && Gameplay.KurtPos.X >= border.Width + border.X)
                {
                    Gameplay.KurtPos.X = border2.X;
                }
                if (Gameplay.KurtRect.Intersects(lanpos))
                {
                    Text.textinitiate = 4;
                    lantscale = 0.3f;
                    langet = 1;
                    lanpos.X = Gameplay.KurtRect.X + 40;
                    lanpos.Y = Gameplay.KurtRect.Y + 40;
                    opacity -= 0.01f;
                    if (Text.textkey == 1)
                    {
                        Text.textinitiate = 0;
                        background = game.Content.Load<Texture2D>("images/right side loop room");
                    }
                }
            }
            if (background == game.Content.Load<Texture2D>("images/right side loop room"))
            {
                opacity += 0.01f;
                border = new Rectangle(-100, 45, 1109, 630);
                border2 = new Rectangle(0, 309, 848, 0);
                border3 = new Rectangle(853, 309, 0, 112);
                border4 = new Rectangle(0, 423, 848, 0);
                if (Gameplay.KurtPos.X <= border.X)
                {
                    Gameplay.KurtPos.X = border.Width;
                    background = game.Content.Load<Texture2D>("images/left side loop room");
                }
                if (Gameplay.KurtPos.X + 84 >= border.Width)
                {
                    Gameplay.KurtPos.X = border.Width - 84;
                }
                if (Gameplay.KurtPos.Y <= border.Y)
                {
                    Gameplay.KurtPos.Y = border.Y;
                }
                if (Gameplay.KurtPos.Y + 108 >= border.Y + border.Height)
                {
                    Gameplay.KurtPos.Y = border.Height + border.Y - 108;
                }
                if (Gameplay.KurtRect.Intersects(border2))
                {
                    Gameplay.KurtPos.Y = border2.Y - 108;
                }
                if (Gameplay.KurtRect.Intersects(border3))
                {
                    Gameplay.KurtPos.X = border3.X;
                }
                if (Gameplay.KurtRect.Intersects(border4))
                {
                    Gameplay.KurtPos.Y = border4.Y;
                }

            }
            if (background == game.Content.Load<Texture2D>("images/left side loop room") || (background == game.Content.Load<Texture2D>("images/left side loop room open")))
            {
                exit = 630 + startexit;
                border = new Rectangle(45, 45, 1209, exit);
                border2 = new Rectangle(305, 309, 853, 0);
                border3 = new Rectangle(300, 309, 0, 112);
                border4 = new Rectangle(305, 423, 853, 0);
                border5 = new Rectangle(45, 631, 75, 102);
                border6 = new Rectangle(145, 690, 1209, 0);
                border7 = new Rectangle(150, 680, 0, 400);
                jumpscare = new Rectangle(45, 45, 50, 50);
                if (Gameplay.KurtPos.X <= border.X)
                {
                    Gameplay.KurtPos.X = border.X;
                }
                if (Gameplay.KurtPos.X + 84 >= border.Width)
                {
                    Gameplay.KurtPos.X = border.X;
                    background = game.Content.Load<Texture2D>("images/right side loop room");
                }
                if (Gameplay.KurtPos.Y <= border.Y)
                {
                    Gameplay.KurtPos.Y = border.Y;
                }
                if (Gameplay.KurtPos.Y + 108 >= border.Y + border.Height)
                {
                    Gameplay.KurtPos.Y = border.Height + border.Y - 108;
                }
                //
                if (Gameplay.KurtRect.Intersects(border2))
                {
                    Gameplay.KurtPos.Y = border2.Y - 108;
                }
                if (Gameplay.KurtRect.Intersects(border3))
                {
                    Gameplay.KurtPos.X = border3.X - 84;
                }
                if (Gameplay.KurtRect.Intersects(border4))
                {
                    Gameplay.KurtPos.Y = border4.Y;
                }
                if (Gameplay.KurtRect.Intersects(border5))
                {
                    if (startexit != 300) { Text.textinitiate = 5; }
                    if (newState.IsKeyDown(Keys.Z))
                    {
                        startexit = 300;
                        background = game.Content.Load<Texture2D>("images/left side loop room open");
                    }
                }
                else
                {
                    Text.textinitiate = 0;
                }
                if (Gameplay.KurtRect.Intersects(border6))
                {
                    Gameplay.KurtPos.X = border6.X - 84;
                }
                if (Gameplay.KurtRect.Intersects(border7))
                {
                    Gameplay.KurtPos.Y = border7.Y - 108;
                }
                if (Gameplay.KurtRect.Intersects(jumpscare))
                {
                    JumpScare.shock = 1;
                }
                else
                {
                    JumpScare.shock = 0;
                }
                //Starts random room
                if (Gameplay.KurtPos.Y >= 700)
                {
                    game.level1 += 1;
                    JumpScare.time = 0;
                }
            }
        }
        
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            if (background == game.Content.Load<Texture2D>("images/light room"))
            { spritebatch.Draw(lantern, new Vector2(lanpos.X, lanpos.Y), null, Color.White, 0, Vector2.Zero, lantscale, SpriteEffects.None, 1); }
            spritebatch.Draw(background, Vector2.Zero, null, Color.White * opacity, 0, Vector2.Zero, game.scale, SpriteEffects.None, 1);
            spritebatch.End();
        }
    }
}


