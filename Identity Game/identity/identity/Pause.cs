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

    public class Pause
    {
        Texture2D PauseScreen, select;
        public Game1 game;
        int timer;
        int one;
        Vector2 position;
        private KeyboardState lastState;

        public Pause(Game1 game)
        {
            this.game = game;
            PauseScreen = game.Content.Load<Texture2D>("images/identity Pause");
            select = game.Content.Load<Texture2D>("images/select");
        }
        public void Update(GameTime Gametime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            lastState = keyboardState;
            if (game.pausegame == 1)
            {
                timer++;
                if (timer > 15)
                { //Arrow movement on splash screen menu
                    if (lastState.IsKeyDown(Keys.Up))
                    {
                        timer = 0;
                        one -= 1;
                        if (one <= -1)
                        {
                            one = 2;
                        }
                    }

                    if (lastState.IsKeyDown(Keys.Down))
                    {
                        timer = 0;
                        one += 1;
                        if (one >= 3) { one = 0; }
                    }
                }
                if (one == 0) { position.X = 390; position.Y = 292; }
                if (one == 1) { position.X = 300; position.Y = 430; }
                if (one == 2) { position.X = 380; position.Y = 572; }

                //Pressing Enter
                if (lastState.IsKeyDown(Keys.Enter))
                {
                    if (one == 0)
                    {
                        game.pausegame = 0;
                    }
                    if (one == 1)
                    {
                        //MESSAGE BOXES DO NOT WORK IN FULL SCREEN
                    }
                    if (one == 2)
                    {
                        game.Exit();
                    }
                }
            }
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Begin();
            spritebatch.Draw(PauseScreen, Vector2.Zero, null, Color.White, 0, Vector2.Zero, 1.56f, SpriteEffects.None, 0);
            spritebatch.Draw(select, position, null, Color.White, 0, new Vector2(25, 25), game.scale, SpriteEffects.None, 0);
            spritebatch.End();
        }
    }
}
