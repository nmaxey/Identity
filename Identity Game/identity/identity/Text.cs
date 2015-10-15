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

    public class Text
    {
        public Game1 game;
        Texture2D textbox, z;
        Vector2 textpos = new Vector2(0, 720);
        public static int textinitiate;
        public static int textpause;
        public static int event1;
        float timer;
        string words;
        int keypress;
        public static int textkey;
        private KeyboardState newState;
        SpriteFont Font;

        public Text(Game1 game)
        {
            this.game = game;
            textbox = game.Content.Load<Texture2D>("images/Text Box");
            z = game.Content.Load<Texture2D>("images/Z");
            Font = game.Content.Load<SpriteFont>(@"font");
        }
        public void Update(GameTime Gametime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            newState = keyboardState;

            if (textinitiate >= 1)
            {
                if (textpos.Y >= 600) { textpos.Y -= 10; }

                if (newState.IsKeyDown(Keys.Z))
                {
                    keypress += 1;
                }
                if (keypress == 1)
                {
                    textkey += 1;
                }
                if (newState.IsKeyUp(Keys.Z))
                {
                    keypress = 0;
                }
            }

            if (textinitiate == 0)
            {
                words = "";
                if (textpos.Y <= 720) { textpos.Y += 10; }
                textkey = 0;
            }
            if (textinitiate == 1)
                words = "Better check my email.";
            if (textinitiate == 2)
            {
                if (textkey == 0)
                    words = "Kurt: What is this?";
                if (textkey == 1)
                    words = "Kurt: I didn't order a bomb.";
                if (textkey == 2)
                    words = "Kurt: Who is doing this?";
                if (textkey == 3)
                    words = "Kurt: Was my iden...";
                if (textkey == 4)
                {
                    words = "Cop: Stop! You are under arrest.";
                }
                if (textkey >= 4 && textkey <= 6)
                {
                    if (Chapter1.coppos1.Y >= 300)
                    {
                        Chapter1.coppos1.Y -= 5;
                        Chapter1.coppos1.X -= 2;
                        Chapter1.coppos2.Y -= 5;
                        Chapter1.coppos3.Y -= 5;
                        Chapter1.coppos3.X += 3;
                    }
                }
                if (textkey == 5)
                {
                    words = "Kurt: What did I do.";
                }
                if (textkey == 6)
                {
                    words = "Cop: You're coming with us";
                }
                if (textkey >= 7)
                {
                    Chapter1.coppos1.Y += 5;
                    Chapter1.coppos1.X += 2;
                    Chapter1.coppos2.Y += 5;
                    Chapter1.coppos3.Y += 5;
                    Chapter1.coppos3.X -= 3;
                    textpause = 1;
                    Gameplay.KurtPos.X -= 1;
                    Gameplay.KurtPos.Y += 5;
                    if (Chapter1.coppos1.Y >= 750)
                    {
                        game.level1 = 2;
                        Gameplay.KurtPos = new Vector2(1000, 1000);
                        textinitiate = 0;
                        textkey = 1;
                    }
                }
            }
            if (textinitiate == 3)
            {
                if (textkey == 1)
                    words = "Kurt: Why am I in here?";
                if (textkey == 2)
                    words = "Cop: You are in here because you commited fraud, burglary, hacking, and identity theft.";
                if (textkey == 3)
                    words = "Kurt: I didn't do any of that. I must have been framed. My idenity must have been stolen.";
                if (textkey == 4)
                    words = "Cop: Yea right. You will be rotting in here for the next 20 years.";
                if (textkey == 5)
                {
                    words = "Nooooo........";
                    event1 = 1;
                }
            }
            if (textinitiate == 4)
            {
                if (textkey == 0)
                    words = "You got a lantern! Might come in handy later.";

            }
            if (textinitiate == 5)
            {
                words = "Hmmm... What does this do?";
                if (textkey == 1)
                    textinitiate = 0;
            }
            if (textinitiate == 6)
            {
                words = "I have to get my identity back.";
                if (textkey == 1)
                    textinitiate = 0;
            }
            if (textinitiate == 7)
                words = "";
            if (textinitiate == 8)
                words = "";
            if (textinitiate == 9)
                words = "";
            if (textinitiate == 10)
                words = "";
            if (textinitiate == 11)
                words = "";
            if (textinitiate == 12)
                words = "";
            if (textinitiate == 13)
                words = "";
            if (textinitiate == 14)
                words = "";
            if (textinitiate == 15)
                words = "";
            if (textinitiate == 16)
                words = "";
            if (textinitiate == 17)
                words = "";

                
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Begin();
            spritebatch.Draw(textbox, textpos, null, Color.White * 0.5f, 0, Vector2.Zero, game.scale, SpriteEffects.None, 0);
            if (keypress == 0) { spritebatch.Draw(z, new Vector2(textpos.X + 1000, textpos.Y + 75), null, Color.White * 0.5f, 0, Vector2.Zero, 1, SpriteEffects.None, 0); }
            spritebatch.DrawString(Font, words, new Vector2(150, textpos.Y + 50), Color.White);
            spritebatch.End();

        }
    }
}
