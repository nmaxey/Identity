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
    enum Screen
    {
        StartScreen,
        Prologue,
        Gameplay,
        Pause,
        Text,
        Music,
        RandomRoom,
        JumpScare,
        Chapter1,
        Chapter2,
        Chapter2b
    }
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont Font;

        //Classes
        Screen currentScreen;
        Screen introScreen;
        Screen RandomRoom;
        Screen Jump;
        Screen chapter1;
        Screen chapter2;
        Screen chapter2b;
        Screen gameplayscreen;
        Screen gamepause;
        Screen text;
        Screen sounds;
        

        StartScreen startscreen;
        Prologue intro;
        RandomRoom room;
        JumpScare scare;
        Chapter1 startgame;
        Chapter2 startgame2;
        Chapter2b startgame2b;
        Gameplay gameplay;
        Pause pause;
        Text textbox;
        Music music;
       

        //Integers
        int mousex;
        int mousey;
        private KeyboardState newState;
        public int start = 2;
        public int pausegame = 0;
        public int level1 = 0;
        public float scale;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            newState = Keyboard.GetState();
            
            //graphics.IsFullScreen = true;

            graphics.PreferredBackBufferWidth = (int)(1150);
            graphics.PreferredBackBufferHeight = (int)(720);
            scale = 1.4444f;
        }
        //1440w // 900h
        //center = 720w //450h

        protected override void Initialize()
        {
            base.Initialize();
            IsMouseVisible = true;
        }


        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);

            startscreen = new StartScreen(this);
            currentScreen = Screen.StartScreen;

            intro = new Prologue(this);
            introScreen = Screen.Prologue;

            room = new RandomRoom(this);
            RandomRoom = Screen.RandomRoom;

            scare = new JumpScare(this);
            Jump = Screen.JumpScare;

            startgame = new Chapter1(this);
            chapter1 = Screen.Chapter1;

            startgame2 = new Chapter2(this);
            chapter2 = Screen.Chapter2;

            startgame2b = new Chapter2b(this);
            chapter2b = Screen.Chapter2b;

            gameplay = new Gameplay(this);
            gameplayscreen = Screen.Gameplay;

            pause = new Pause(this);
            gamepause = Screen.Pause;

            textbox = new Text(this);
            text = Screen.Text;

            music = new Music(this);
            sounds = Screen.Music;

            Font = Content.Load<SpriteFont>(@"font");
            base.LoadContent();
            

            this.Window.Title = "Identity...";

        }


        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            

            //Mouse X and Y
            MouseState mouseState = Mouse.GetState();
            mousex = mouseState.X;
            mousey = mouseState.Y;
                //Main Menu
            if (start == 0 || start == 2)
            {
                switch (currentScreen)
                {
                    case Screen.StartScreen:
                        if (startscreen != null)
                            startscreen.Update(gameTime);
                        break;
                }
            }
            if (JumpScare.shock >= 1)
            {
                switch (Jump)
                {
                    case Screen.JumpScare:
                        if (scare != null)
                            scare.Update(gameTime);
                        break;
                }
            }

            if (pausegame == 0)
            {
                //Character Movement
                if (level1 >= 1)
                {
                    switch (gameplayscreen)
                    {
                        case Screen.Gameplay:
                            if (gameplay != null)
                                gameplay.Update(gameTime);
                            break;
                    }
                }

                //Prologue
                if (intro.time <= 20)
                {
                    switch (introScreen)
                    {
                        case Screen.Prologue:
                            if (intro != null)
                                intro.Update(gameTime);
                            break;
                    }
                }


                //Chapter 1
                if (level1 == 1)
                {
                    switch (chapter1)
                    {
                        case Screen.Chapter1:
                            if (startgame != null)
                                startgame.Update(gameTime);
                            break;
                    }
                }
                //Chapter 2
                if (level1 == 2)
                {
                    switch (chapter2)
                    {
                        case Screen.Chapter2:
                            if (startgame2 != null)
                                startgame2.Update(gameTime);
                            break;
                    }
                }
                if (level1 == 3)
                {
                    switch (chapter2b)
                    {
                        case Screen.Chapter2b:
                            if (startgame2b != null)
                                startgame2b.Update(gameTime);
                            break;
                    }
                }
                if (level1 == 4 || level1 == 5 || level1 == 6 || level1 == 7)
                {
                    switch (RandomRoom)
                    {
                        case Screen.RandomRoom:
                            if (room != null)
                                room.Update(gameTime);
                            break;
                    }
                }


            }

            //Pause
            if (pausegame == 1)
            {
                switch (gamepause)
                {
                    case Screen.Pause:
                        if (pause != null)
                            pause.Update(gameTime);
                        break;
                }
            }

            switch (text)
            {
                case Screen.Text:
                    if (textbox != null)
                        textbox.Update(gameTime);
                    break;
            }

            switch (sounds)
            {
                case Screen.Music:
                    if (music != null)
                        music.Update(gameTime);
                    break;
            }

            //Exit
            KeyboardState keyboardState = Keyboard.GetState();
            newState = keyboardState;
            if (newState.IsKeyDown(Keys.Escape)) { this.Exit(); }
            
            //Keyboard Shortcuts to levels for debugging
            if (newState.IsKeyDown(Keys.D1))
            {
                level1 = 1;
            }
            if (newState.IsKeyDown(Keys.D2))
            {
                level1 = 2;
            }
            if (newState.IsKeyDown(Keys.D3))
            {
                level1 = 3;
            }
            if (newState.IsKeyDown(Keys.D4))
            {
                level1 = 4;
            }
            if (newState.IsKeyDown(Keys.D5))
            {
                level1 = 5;
            }
            if (newState.IsKeyDown(Keys.D6))
            {
                level1 = 6;
            }
            if (newState.IsKeyDown(Keys.D7))
            {
                level1 = 7;
            }
            if (newState.IsKeyDown(Keys.D8))
            {
                level1 = 8;
            }
            if (newState.IsKeyDown(Keys.D9))
            {
                level1 = 9;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            if (pausegame == 0)
            {
                GraphicsDevice.Clear(Color.Black);
                //Draw SplashScreen
                if (start == 0 || start == 2)
                {
                    switch (currentScreen)
                    {
                        case Screen.StartScreen:
                            if (startscreen != null)
                                startscreen.Draw(spriteBatch);
                            break;

                    }
                }


               
                

                if (intro.time <= 16)
                {
                    //Draw Intro
                    switch (introScreen)
                    {
                        case Screen.Prologue:
                            if (intro != null)
                                intro.Draw(spriteBatch);
                            break;
                    }
                }

                if (level1 == 1)
                {
                    //Chapter 1
                    switch (chapter1)
                    {
                        case Screen.Chapter1:
                            if (startgame != null)
                                startgame.Draw(spriteBatch);
                            break;
                    }
                }
                if (level1 == 2)
                {
                    //Chapter 2
                    switch (chapter2)
                    {
                        case Screen.Chapter2:
                            if (startgame2 != null)
                                startgame2.Draw(spriteBatch);
                            break;
                    }
                }
                if (level1 == 3)
                {
                    //Chapter 2
                    switch (chapter2b)
                    {
                        case Screen.Chapter2b:
                            if (startgame2b != null)
                                startgame2b.Draw(spriteBatch);
                            break;
                    }
                }
                if (level1 == 4 || level1 == 5 || level1 == 6 || level1 == 7)
                {
                    switch (RandomRoom)
                    {
                        case Screen.RandomRoom:
                            if (room != null)
                                room.Draw(spriteBatch);
                            break;
                    }
                }

                //Character Movement
                if (level1 >= 1)
                {
                    switch (gameplayscreen)
                    {
                        case Screen.Gameplay:
                            if (gameplay != null)
                                gameplay.Draw(spriteBatch);
                            break;
                    }
                }

            }
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            spriteBatch.DrawString(Font, mousex.ToString(), new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(Font, mousey.ToString(), new Vector2(50, 0), Color.White);
            spriteBatch.DrawString(Font, level1.ToString(), new Vector2(100, 0), Color.White);
            spriteBatch.End();


            if (JumpScare.shock >= 1)
            {
                switch (Jump)
                {
                    case Screen.JumpScare:
                        if (scare != null)
                            scare.Draw(spriteBatch);
                        break;
                }
            }

            switch (text)
            {
                case Screen.Text:
                    if (textbox != null)
                        textbox.Draw(spriteBatch);
                    break;
            }

            //Pause
            if (pausegame == 1)
            {
                switch (gamepause)
                {
                    case Screen.Pause:
                        if (pause != null)
                            pause.Draw(spriteBatch);
                        break;
                }
            }

            

            base.Draw(gameTime);
        }
    }
}
