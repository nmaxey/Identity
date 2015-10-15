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

    public class StartScreen
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern uint MessageBox(IntPtr hWnd, String text, String caption, uint type);
        private Texture2D texture, select, binary;
        public Game1 game;
        int timer = 0;
        int binarytimer;
        Vector2 binarypos = new Vector2(0, -1200);
        Vector2 texturepos = Vector2.Zero;
        float time;
        private KeyboardState lastState;
        int one = 0;
        int keypress;
        int key;
        Vector2 position = Vector2.Zero;
        

        public StartScreen(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("images/Code Lords");
            select = game.Content.Load<Texture2D>("images/select");
            binary = game.Content.Load<Texture2D>("images/binary");
            lastState = Keyboard.GetState();
        }
        public void Update(GameTime Gametime)
        {
            if (game.start == 2)
            {
                //Code Lords Timer
                time += 0.0166666666666f;
                //Main Menu
                if (binarypos.Y >= 480)
                    game.start = 0;
            }
            if (time >= 2)
            {
                //Scrolling Binary
                binarytimer += 1;
                if (binarytimer == 4)
                {
                    binarypos.Y += 25;
                    binarytimer = 0;
                }
            }
            if (time >= 5 && one == 0)
            {
                texture = game.Content.Load<Texture2D>("images/Identity");
                texturepos.X = -20;
            }

            if (game.start == 0)
            {
                timer++;
                KeyboardState keyboardState = Keyboard.GetState();
                lastState = keyboardState;
                if (timer > 15)
                { //Arrow movement on splash screen menu
                    if (texture == game.Content.Load<Texture2D>("images/Identity"))
                    {
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


                        if (one == 0) { position.X = 460; position.Y = 360; }
                        if (one == 1) { position.X = 310; position.Y = 480; }
                        if (one == 2) { position.X = 460; position.Y = 610; }
                    }
                }

                //Pressing Enter
                if (lastState.IsKeyDown(Keys.Enter))
                {
                    keypress += 1;
                    if (one == 0)
                    {
                        game.start = 1;
                    }
                    if (one == 1)
                    {
                        //MESSAGE BOXES DO NOT WORK IN FULL SCREEN
                        texture = game.Content.Load<Texture2D>("images/Identity Controls");
                        position = new Vector2(945, 640);
                        if (keypress == 1)
                            key += 1;
                        if (key == 2) { game.start = 1; }
                    }
                    if (one == 2)
                    {
                        texture = game.Content.Load<Texture2D>("images/Credits");
                        position = new Vector2(460, 800);
                        if (keypress == 1)
                            key += 1;
                        if (key == 2) { game.Exit(); }
                    }
                }
                if (lastState.IsKeyUp(Keys.Enter))
                {
                    keypress = 0;
                }
            }
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            //Scrolling Binary
            if (time >= 2)
                spritebatch.Draw(binary, binarypos * game.scale, null, Color.White, 0, Vector2.Zero, game.scale, SpriteEffects.None, 0);
            //Main Menu
            if (game.start == 0)
            {
                spritebatch.Draw(select, position, null, Color.White, 0, new Vector2(25,25), game.scale, SpriteEffects.None, 0);
                spritebatch.Draw(texture, texturepos, null, Color.White, 0, Vector2.Zero, game.scale, SpriteEffects.None, 0);
            }
            //Code Lords
            if (game.start == 2)
                spritebatch.Draw(texture, texturepos, null, Color.White, 0, Vector2.Zero, game.scale, SpriteEffects.None, 0);
            spritebatch.End();
        }

    }


}


