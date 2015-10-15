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

    public class Music
    {
        int music;
        SoundEffect Theme;
        public Game1 game;

        public Music(Game1 game)
        {
            this.game = game;
            Theme = game.Content.Load<SoundEffect>("Sounds/Theme");
        }
        public void Update(GameTime Gametime)
        {
            if (game.start == 1 && music == 0)
            {
                music = 1;
                Theme.Play();
            }
        }
    }
}


