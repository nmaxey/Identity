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
    public class Prologue
    {


        private Texture2D texture, flash, cursor, binary;
        public Game1 game;
        public float time;
        int timer;
        Vector2 texturepos = new Vector2(0, -1000);


        public Prologue(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("images/Kurt Weaver IV ID");
            binary = game.Content.Load<Texture2D>("images/Binary");
            flash = game.Content.Load<Texture2D>("images/Flash");
            cursor = game.Content.Load<Texture2D>("images/Cursor");
        }
        public void Update(GameTime Gametime)
        {
            //Prologue story 
            if (time <= 16)
            {
                if (game.start == 1)
                {
                    //timer for scrolling info
                    time += 0.016666666666f;
                }
                if (time >= 10 && time <= 15)
                {
                    //Scrolling binary
                    timer += 1;
                    if (timer == 4)
                    {
                        texturepos.Y += 25;
                        timer = 0;
                    }
                }
                if (time >= 12)
                {
                    texture = game.Content.Load<Texture2D>("images/Chapter 1");
                }
                if (time >= 15.8)
                {
                    game.level1 = 1;
                }
            }
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            //Flash
            if (time <= 0.25)
                spritebatch.Draw(flash, new Vector2 (720, 450), null, Color.White, 0, new Vector2 (400, 240), time * 100, SpriteEffects.None, 0);
            //Scrolling Info on Card
            if (time >= 0.25 && time <= 10)
            {
                spritebatch.Draw(cursor, new Vector2(330, time * 50 * game.scale), null, Color.White, 0, Vector2.Zero, game.scale, SpriteEffects.None, 0);
                spritebatch.Draw(cursor, new Vector2(510, time * 50 * game.scale), null, Color.White, 0, Vector2.Zero, game.scale, SpriteEffects.None, 0);
                spritebatch.Draw(texture, Vector2.Zero, null, Color.White, 0, Vector2.Zero, game.scale, SpriteEffects.None, 0);
            }
            //More Scrolling Binary
            if (time >= 10 && time <= 16)
            {
                spritebatch.Draw(binary, texturepos * game.scale, null, Color.White, 0, Vector2.Zero, game.scale, SpriteEffects.None, 0);
                spritebatch.Draw(texture, Vector2.Zero, null, Color.White, 0, Vector2.Zero, game.scale, SpriteEffects.None, 0);
            }
            spritebatch.End();
        }
    }
}
