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

    public class Chapter1
    {
        
        public Game1 game;
        private Texture2D background, cop1, cop2, cop3;
        public static Vector2 coppos1, coppos2, coppos3;
        private Rectangle DoorText;
        private Rectangle EmailText;
    
        float opacity;

        public Chapter1(Game1 game)
        {
            this.game = game;
            background = game.Content.Load<Texture2D>("images/GOD ROOM");
            cop1 = game.Content.Load<Texture2D>("images/Cop1");
            cop2 = game.Content.Load<Texture2D>("images/Cop2");
            cop3 = game.Content.Load<Texture2D>("images/Cop3");
            coppos1 = new Vector2(600, 900);
            coppos2 = new Vector2(500, 1000);
            coppos3 = new Vector2(500, 800);
            DoorText = new Rectangle(441, 580, 268, 39);
            EmailText = new Rectangle(653, 182, 121, 96);
           
        }
        public void Update(GameTime Gametime)
        {
            if (opacity <= 1)
            {
                opacity += 0.01f;
                Gameplay.KurtOpaque += 0.01f;
            }

            if (Gameplay.KurtPos.Y <= 90)
                Gameplay.KurtPos.Y = 90;
            if (Gameplay.KurtPos.Y >= 530)
                Gameplay.KurtPos.Y = 530;
            if (Gameplay.KurtPos.X <= 70)
                Gameplay.KurtPos.X = 70;
            if (Gameplay.KurtPos.X >= 1000)
                Gameplay.KurtPos.X = 1000;
            //441 689 520
            if (Gameplay.KurtRect.Intersects(DoorText) && Text.textkey <= 6)
            {
                Text.textinitiate = 1;
            }
            if (Gameplay.KurtRect.Intersects(EmailText))
            {
                Text.textinitiate = 2;
                if (Text.textkey <= 6) { Gameplay.KurtPos = new Vector2(655, 155); }
                Gameplay.currentFrame.Y = 1;
            }
            if (Gameplay.KurtRect.Intersects(DoorText) != true && Gameplay.KurtRect.Intersects(EmailText) != true && Text.textkey >= 20)
            {
                Text.textinitiate = 0;
            }

        }
        public void Draw(SpriteBatch spritebatch)
        {
            /*Draws top line first then next line in second layer etc.*/
            spritebatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            spritebatch.Draw(cop1, coppos1, Color.White);
            spritebatch.Draw(cop2, coppos2, Color.White);
            spritebatch.Draw(cop3, coppos3, Color.White);
            spritebatch.Draw(cop3, coppos3, Color.White);
            spritebatch.Draw(background, Vector2.Zero, null, Color.White * opacity, 0, Vector2.Zero, game.scale, SpriteEffects.None, 0);
            spritebatch.End();
        }
    }
}
