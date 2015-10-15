using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Runtime.InteropServices;

namespace identity
{

    public class JumpScare
    {
        public Game1 game;
        public static int shock;
        public Texture2D picture;
        public static float time;
        int face;
        Random rint = new Random();

        public JumpScare(Game1 game)
        {
            this.game = game;
            picture = game.Content.Load<Texture2D>("images/JumpScare1");
        }
        public void Update(GameTime Gametime)
        {
            if (shock == 1) { face = rint.Next(1, 10); }
            if (face <= 1) { time += 0.016666f; }
            if (face == 1) { picture = game.Content.Load<Texture2D>("images/JumpScare1"); }
            if (face == 2) { }
            if (face == 3) { }
            if (face == 4) { }
            if (face == 5) { }
            if (face == 6) { }
            if (face == 7) { }
            if (face == 8) { }
            if (face == 9) { }
            if (face == 10) { }
        }
        public void Draw(SpriteBatch spritebatch)
        {
            if (time <= 0.1f)
            {
                spritebatch.Begin();
                spritebatch.Draw(picture,Vector2.Zero, null, Color.White, 0, Vector2.Zero, game.scale,SpriteEffects.None, 0);
                spritebatch.End();
            }
        }
    }
}
