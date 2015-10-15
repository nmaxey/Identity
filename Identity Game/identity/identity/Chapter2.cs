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

    public class Chapter2
    {
        public Game1 game;
        private Texture2D background, Cop1;
        private Rectangle Leftside = new Rectangle(797, 37, 0, 481);
        private Rectangle Downside = new Rectangle(509, 550, 0, 164);
        private Rectangle a = new Rectangle(353, 380, 0, 154);
        private Rectangle b = new Rectangle(0, 19, 750, 0);
        private Rectangle c = new Rectangle(353, 518, 156, 0);
        private Rectangle d = new Rectangle(664, 536, 1150, 0);
        private Rectangle d2 = new Rectangle(664, 525, 1150, 0);
        private Rectangle e = new Rectangle(26, 22, 0, 500);
        private Rectangle f = new Rectangle(35, 358, 300, 0);
        private Rectangle g = new Rectangle(507, 682, 644, 0);
        private Rectangle h = new Rectangle(355, 38, 0, 132);
        private Rectangle i = new Rectangle(26, 168, 327, 0);
        private Rectangle Rightside = new Rectangle(207, 363, 150,  0);
        private Rectangle Talk = new Rectangle(19, 461, 307, 56);
        float chapter2;
        int moveright;
        int moveup;
        private Vector2 backpos = new Vector2(0, 0);
        private KeyboardState newState;

        float opacity = 1;

        public Chapter2(Game1 game)
        {
            this.game = game;
            background = game.Content.Load<Texture2D>("images/Chapter 2");
            Cop1 = game.Content.Load<Texture2D>("images/Cop Back Sprite Brown Hair");
        }
        public void Update(GameTime Gametime)
        {
            
            KeyboardState keyboardState = Keyboard.GetState();
            newState = keyboardState;

            //Chapter 2 splash screen and opacity of cell hallway
            chapter2 += 0.0166666f;
            if (chapter2 <= 3)
            {
                opacity -= 0.006f;
            }
            if (chapter2 >= 3 && chapter2 <= 10)
            {
                background = game.Content.Load<Texture2D>("images/cell hallway");
                if (opacity <= 1)
                {
                    opacity += 0.01f;
                    Gameplay.KurtPos = new Vector2(238, 269);
                    Gameplay.KurtOpaque = 1;
                }
            }
            if (chapter2 >= 10 && Text.textinitiate != 3 && chapter2 <= 22)
            {
                chapter2 -= 0.0166666f;
            }
            if (background == game.Content.Load<Texture2D>("images/cell hallway"))
            {
                if (Gameplay.KurtPos.Y <= 18)
                    Gameplay.KurtPos.Y = 18;
                if (Gameplay.KurtPos.Y >= 415)
                    Gameplay.KurtPos.Y = 415;
                if (Gameplay.KurtPos.X <= 18)
                    Gameplay.KurtPos.X = 18;
                if (Gameplay.KurtPos.X >= 241)
                    Gameplay.KurtPos.X = 241;
            }

            if (Gameplay.KurtRect.Intersects(Talk))
            {
                Text.textinitiate = 3;
                Text.textpause = 1;
            }
            else
            {
                Text.textinitiate = 0;
                Text.textpause = 0;
            }
            if (Text.event1 == 1)
            {
                if (backpos.X == -20)
                    moveright = 1;
                if (moveright == 1)
                    backpos.X += 10;
                if (backpos.X == 20)
                    moveright = 0;
                if (moveright == 0)
                    backpos.X -= 10;
                if (backpos.Y == -30)
                    moveup = 1;
                if (moveup == 1)
                    backpos.Y += 10;
                if (backpos.Y == 30)
                    moveup = 0;
                if (moveup == 0)
                    backpos.Y -= 10;
            }
            if (chapter2 >= 22 && chapter2 <= 27)
            {
                Talk = new Rectangle(0, 0, 0, 0);
                Text.textkey = 0;
                if (opacity >= 0)
                {
                    opacity -= 0.01f;
                    Gameplay.KurtOpaque -= 0.01f;
                }
            }
            if (chapter2 >= 30)
            {
                Text.event1 = 0;
                backpos = new Vector2(0, 0);
                if (opacity <= 1)
                {
                    opacity += 0.01f;
                    Gameplay.KurtOpaque += 0.01f;
                }
                background = game.Content.Load<Texture2D>("images/brooken cell");
            }
            //private Rectangle Leftside = new Rectangle(797, 37, 0, 481);
            //private Rectangle Downside = new Rectangle(509, 520, 0, 164);
            //private Rectangle a = new Rectangle(353, 364, 0, 154);
            //private Rectangle b = new Rectangle(147, 19, 649, 0);
            //private Rectangle c = new Rectangle(353, 518, 156, 0);
            //private Rectangle d = new Rectangle(664, 536, 1150, 0);
            //private Rectangle e = new Rectangle(353, 364, 0, 154);
            //private Rectangle f = new Rectangle(35, 358, 300, 0);
            //private Rectangle g = new Rectangle(507, 682, 644, 0);
            //private Rectangle Rightside = new Rectangle(207, 363, 150,  0);
            //private Rectangle h = new Rectangle(355, 38, 0, 132);
            //private Rectangle i = new Rectangle(26, 168, 327, 0);
            if (background == game.Content.Load<Texture2D>("images/brooken cell"))
            {
                if (Gameplay.KurtRect.Intersects(Leftside))
                {
                    Gameplay.KurtPos.X = Leftside.X - 84;
                }
                if (Gameplay.KurtRect.Intersects(Downside))
                {
                    Gameplay.KurtPos.X = Downside.X;
                }
                if (Gameplay.KurtRect.Intersects(a))
                {
                    Gameplay.KurtPos.X = a.X;
                }
                if (Gameplay.KurtRect.Intersects(b))
                {
                    Gameplay.KurtPos.Y = b.Y;
                }
                if (Gameplay.KurtRect.Intersects(c))
                {
                    Gameplay.KurtPos.Y = c.Y - 104;
                }
                if (Gameplay.KurtRect.Intersects(d))
                {
                    Gameplay.KurtPos.Y = d.Y;
                }
                if (Gameplay.KurtRect.Intersects(d2))
                {
                    Gameplay.KurtPos.Y = d2.Y - 104;
                }
                if (Gameplay.KurtRect.Intersects(e))
                {
                    Gameplay.KurtPos.X = e.X;
                }
                if (Gameplay.KurtRect.Intersects(f))
                {
                    Gameplay.KurtPos.Y = f.Y - 104;
                }
                if (Gameplay.KurtRect.Intersects(g))
                {
                    Gameplay.KurtPos.Y = g.Y - 104;
                }
                if (Gameplay.KurtRect.Intersects(h))
                {
                    Gameplay.KurtPos.X = h.X;
                }
                if (Gameplay.KurtRect.Intersects(i))
                {
                    Gameplay.KurtPos.Y = i.Y;
                }
            }
            if (Gameplay.KurtPos.X >= 1100)
            {
                Gameplay.KurtPos.X = 0;
                Gameplay.KurtPos.Y = 290;
                game.level1 = 3;
            }

        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            if (background == game.Content.Load<Texture2D>("images/cell hallway"))
            {
                spritebatch.Draw(Cop1, new Vector2(84, 538), null, Color.White * opacity, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            }
            spritebatch.Draw(background, backpos, null, Color.White * opacity, 0, Vector2.Zero, game.scale, SpriteEffects.None, 1);
            spritebatch.End();
        }
    }
}
