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

    public class RandomRoom
    {
        public Game1 game;
        public Texture2D background, toxicgas;
        public Rectangle border1, border2, border3, border4, border5, border6, border7, border8, border9, border10,
                border11, border12, border13, border14, border15, border16, border17, border18, border19, border20,
                pitfall1, pitfall2, pitfall3, pitfall4, spikes1, spikes2, spikes3, spikes4, toxic1, endborder;
        int room;
        int toxic = 1;
        int flipping;
        int flip;
        int moveright, moveup;
        Vector2 Toxpos;
        Random rint = new Random();
        Vector2 starting;

        public RandomRoom(Game1 game)
        {
            background = game.Content.Load<Texture2D>("images/S2");
            toxicgas = game.Content.Load<Texture2D>("images/Toxic Gas");
            this.game = game;
            
        }
        #region
        public void BorderControl(Rectangle border)
        {
            if (Gameplay.KurtPos.X >= border.X - 84 && Gameplay.KurtPos.X <= border.X - 84 + 10)
            {
                Gameplay.KurtPos.X = border.X - 84;
            }
            if (Gameplay.KurtPos.X <= border.Width + border.X && Gameplay.KurtPos.X >= border.Width + border.X - 10)
            {
                Gameplay.KurtPos.X = border.X + border.Width;
            }
            if (Gameplay.KurtPos.Y >= border.Y - 108 && Gameplay.KurtPos.Y <= border.Y - 108 + 12)
            {
                Gameplay.KurtPos.Y = border.Y - 108;
            }
            if (Gameplay.KurtPos.Y <= border.Height + border.Y && Gameplay.KurtPos.Y >= border.Height + border.Y - 12)
            {
                Gameplay.KurtPos.Y = border.Y + border.Height;
            }
        }
        public void BorderFlip(Rectangle border)
        {
            if (flip == 1)
            {
                border1.X = (1151 - border1.X) - border1.Width;
                border2.X = (1151 - border2.X) - border2.Width;
                border3.X = (1151 - border3.X) - border3.Width;
                border4.X = (1151 - border4.X) - border4.Width;
                border5.X = (1151 - border5.X) - border5.Width;
                border6.X = (1151 - border6.X) - border6.Width;
                border7.X = (1151 - border7.X) - border7.Width;
                border8.X = (1151 - border8.X) - border8.Width;
                border9.X = (1151 - border9.X) - border9.Width;
                border10.X = (1151 - border10.X) - border10.Width;
                border11.X = (1151 - border11.X) - border11.Width;
                border12.X = (1151 - border12.X) - border12.Width;
                border13.X = (1151 - border13.X) - border13.Width;
                pitfall1.X = (1151 - pitfall1.X) - pitfall1.Width;
                pitfall2.X = (1151 - pitfall2.X) - pitfall2.Width;
                pitfall3.X = (1151 - pitfall3.X) - pitfall3.Width;
                pitfall4.X = (1151 - pitfall4.X) - pitfall4.Width;
                spikes1.X = (1151 - spikes1.X) - spikes1.Width;
                spikes2.X = (1151 - spikes2.X) - spikes2.Width;
                spikes3.X = (1151 - spikes3.X) - spikes3.Width;
                spikes4.X = (1151 - spikes4.X) - spikes4.Width;
                endborder.X = (1151 - endborder.X) - endborder.Width;
                toxic1.X = (1151 - toxic1.X) - toxic1.Width;
            }
            if (flip == 2)
            {
                border1.Y = (750 - border1.Y) - border1.Height;
                border2.Y = (750 - border2.Y) - border2.Height;
                border3.Y = (750 - border3.Y) - border3.Height;
                border4.Y = (750 - border4.Y) - border4.Height;
                border5.Y = (750 - border5.Y) - border5.Height;
                border6.Y = (750 - border6.Y) - border6.Height;
                border7.Y = (750 - border7.Y) - border7.Height;
                border8.Y = (750 - border8.Y) - border8.Height;
                border9.Y = (750 - border9.Y) - border9.Height;
                border10.Y = (750 - border10.Y) - border10.Height;
                border11.Y = (750 - border11.Y) - border11.Height;
                border12.Y = (750 - border12.Y) - border12.Height;
                border13.Y = (750 - border13.Y) - border13.Height;
                pitfall1.Y = (750 - pitfall1.Y) - pitfall1.Height;
                pitfall2.Y = (750 - pitfall2.Y) - pitfall2.Height;
                pitfall3.Y = (750 - pitfall3.Y) - pitfall3.Height;
                pitfall4.Y = (750 - pitfall4.Y) - pitfall4.Height;
                spikes1.Y = (750 - spikes1.X) - spikes1.Width;
                spikes2.Y = (750 - spikes2.X) - spikes2.Width;
                spikes3.Y = (750 - spikes3.X) - spikes3.Width;
                spikes4.Y = (750 - spikes4.X) - spikes4.Width;
                endborder.Y = (750 - endborder.Y) - endborder.Height;
                toxic1.Y = (750 - toxic1.Y) - toxic1.Height;
            }
            if (flip == 3)
            {
                border1.X = (1151 - border1.X) - border1.Width;
                border1.Y = (750 - border1.Y) - border1.Height;
                border2.X = (1151 - border2.X) - border2.Width;
                border2.Y = (750 - border2.Y) - border2.Height;
                border3.X = (1151 - border3.X) - border3.Width;
                border3.Y = (750 - border3.Y) - border3.Height;
                border4.X = (1151 - border4.X) - border4.Width;
                border4.Y = (750 - border4.Y) - border4.Height;
                border5.X = (1151 - border5.X) - border5.Width;
                border5.Y = (750 - border5.Y) - border5.Height;
                border6.X = (1151 - border6.X) - border6.Width;
                border6.Y = (750 - border6.Y) - border6.Height;
                border7.X = (1151 - border7.X) - border7.Width;
                border7.Y = (750 - border7.Y) - border7.Height;
                border8.X = (1151 - border8.X) - border8.Width;
                border8.Y = (750 - border8.Y) - border8.Height;
                border9.X = (1151 - border9.X) - border9.Width;
                border9.Y = (750 - border9.Y) - border9.Height;
                border10.X = (1151 - border10.X) - border10.Width;
                border10.Y = (750 - border10.Y) - border10.Height;
                border11.X = (1151 - border11.X) - border11.Width;
                border11.Y = (750 - border11.Y) - border11.Height;
                border12.X = (1151 - border12.X) - border12.Width;
                border12.Y = (750 - border12.Y) - border12.Height;
                border13.X = (1151 - border13.X) - border13.Width;
                border13.Y = (750 - border13.Y) - border13.Height;
                pitfall1.X = (1151 - pitfall1.X) - pitfall1.Width;
                pitfall1.Y = (750 - pitfall1.Y) - pitfall1.Height;
                pitfall2.X = (1151 - pitfall2.X) - pitfall2.Width;
                pitfall2.Y = (750 - pitfall2.Y) - pitfall2.Height;
                pitfall3.X = (1151 - pitfall3.X) - pitfall3.Width;
                pitfall3.Y = (750 - pitfall3.Y) - pitfall3.Height;
                pitfall4.X = (1151 - pitfall4.X) - pitfall4.Width;
                pitfall4.Y = (750 - pitfall4.Y) - pitfall4.Height;
                spikes1.X = (1151 - spikes1.X) - spikes1.Width;
                spikes1.Y = (750 - spikes1.Y) - spikes1.Height;
                spikes2.X = (1151 - spikes2.X) - spikes2.Width;
                spikes2.Y = (750 - spikes2.Y) - spikes2.Height;
                spikes3.X = (1151 - spikes3.X) - spikes3.Width;
                spikes3.Y = (750 - spikes3.Y) - spikes3.Height;
                spikes4.X = (1151 - spikes4.X) - spikes4.Width;
                spikes4.Y = (750 - spikes4.Y) - spikes4.Height;
                endborder.X = (1151 - endborder.X) - endborder.Width;
                endborder.Y = (750 - endborder.Y) - endborder.Height;
                toxic1.X = (1151 - toxic1.X) - toxic1.Width;
                toxic1.Y = (750 - toxic1.Y) - toxic1.Height;
            }
        }
        
        public void ToxicGas()
        {
                if (Toxpos.X <= -800)
                    moveright = 1;
                if (moveright == 1)
                    Toxpos.X += .5f;
                if (Toxpos.X >= 0)
                    moveright = 0;
                if (moveright == 0)
                    Toxpos.X -= 1;
                if (Toxpos.Y <= -400)
                    moveup = 1;
                if (moveup == 1)
                    Toxpos.Y += .5f;
                if (Toxpos.Y >= 0)
                    moveup = 0;
                if (moveup == 0)
                    Toxpos.Y -= 1;
                Gameplay.Health -= 1;
        }
        public void Pitfall()
        {
            Gameplay.Health -= 100;
            StartingPoint(starting);
        }
        public void Spikesx(Rectangle Spikey)
        {
            while (Spikey.X - Gameplay.KurtPos.X <= 200)
            {
                Gameplay.KurtPos.X -= 25;
                Gameplay.Health -= 30;
            }
        }
        public void Spikesy(Rectangle Spikey)
        {
            while (Spikey.Y - Gameplay.KurtPos.Y <= 200)
            {
                Gameplay.KurtPos.Y -= 25;
                Gameplay.Health -= 30;
            }
        }
        public void StartingPoint(Vector2 starting)
        {
            if (flip == 1)
            {
                starting.X = 1050 - starting.X;
            }
            if (flip == 2)
            {
                starting.Y = 650 - starting.Y;
            }
            if (flip == 3)
            {
                starting.X = 1050 - starting.X;
                starting.Y = 650 - starting.Y;
            }
            Gameplay.KurtPos = starting;
        }
        public void EndRoom(Rectangle end)
        {
            Gameplay.Health += 50;
            game.level1 += 1;
            room = 0;
            //endborder = new Rectangle(0, 0, 0, 0);
        }
        #endregion
        public void Update(GameTime Gametime)
        {
            if (room == 0)
            {
                flipping = 0;
                toxic = 0;
                room = rint.Next(3, 3);
            }
            //room1
            #region
            if (room == 1) //Map does not flip borders
            {
                background = game.Content.Load<Texture2D>("images/1");

                if (flipping == 0)
                {
                    flip = rint.Next(0, 0);
                    border1 = new Rectangle(144, 245, 705, 309);
                    border2 = new Rectangle(0, 0, 541, 126);
                    border3 = new Rectangle(657, 0, 476, 128);
                    border4 = new Rectangle(144, 247, 706, 308);
                    border5 = new Rectangle(972, 247, 300, 308);
                    border6 = new Rectangle(850, 247, 250, 63);
                    border7 = new Rectangle(0, 0, 26, 719);
                    border8 = new Rectangle(0, 672, 1148, 718);
                    border9 = new Rectangle(1132, 0, 0, 278);
                    border10 = new Rectangle(0, 0, 1150, 0);
                    endborder = new Rectangle(1140, 555, 20, 100);
                    //border12 = new Rectangle(0, 0, 0, 0);
                    //border13 = new Rectangle(0, 0, 0, 0);
                    //pitfall1 = new Rectangle(0, 0, 0, 0);
                    //pitfall2 = new Rectangle(0, 0, 0, 0);
                    toxic1 = new Rectangle(4, 303, 103, 100);
                    BorderFlip(border1);
                    BorderFlip(border2);
                    BorderFlip(border3);
                    BorderFlip(border4);
                    BorderFlip(border5);
                    BorderFlip(border6);
                    BorderFlip(border7);
                    BorderFlip(border8);
                    BorderFlip(border9);
                    BorderFlip(border10);
                    BorderFlip(endborder);
                    BorderFlip(toxic1);
                    //BorderFlip(border12);
                    //BorderFlip(border13);
                    //BorderFlip(pitfall1);
                    //BorderFlip(pitfall2);
                    starting = new Vector2(555, 16);
                    StartingPoint(starting);
                    flipping = 1;
                }
                if (toxic == 1) { ToxicGas(); }

                if (Gameplay.KurtRect.Intersects(border1)) { BorderControl(border1); }
                if (Gameplay.KurtRect.Intersects(border2)) { BorderControl(border2); }
                if (Gameplay.KurtRect.Intersects(border3)) { BorderControl(border3); }
                if (Gameplay.KurtRect.Intersects(border4)) { BorderControl(border4); }
                if (Gameplay.KurtRect.Intersects(border5)) { BorderControl(border5); }
                if (Gameplay.KurtRect.Intersects(border6)) { BorderControl(border6); }
                if (Gameplay.KurtRect.Intersects(border7)) { BorderControl(border7); }
                if (Gameplay.KurtRect.Intersects(border8)) { BorderControl(border8); }
                if (Gameplay.KurtRect.Intersects(border9)) { BorderControl(border9); }
                if (Gameplay.KurtRect.Intersects(border10)) { BorderControl(border10); }
                if (Gameplay.KurtRect.Intersects(endborder)) { EndRoom(endborder); }
                if (Gameplay.KurtRect.Intersects(toxic1)) { toxic = 1; }
            }
            #endregion
            //room 2
            #region
            if (room == 2)
            {
                
                background = game.Content.Load<Texture2D>("images/2");

                if (flipping == 0)
                {
                    flip = rint.Next(0, 3);
                    border1 = new Rectangle(139, 129, 661, 79);
                    border2 = new Rectangle(1124, 14, 0, 700);
                    border3 = new Rectangle(520, 460, 490, 257);
                    border4 = new Rectangle(137, 463, 265, 696);
                    border5 = new Rectangle(139, 131, 265, 211);
                    border6 = new Rectangle(941, 130, 185, 168);
                    border7 = new Rectangle(520, 208, 302, 137);
                    border8 = new Rectangle(822, 302, 303, 43);
                    border9 = new Rectangle(404, 599, 115, 10);
                    border10 = new Rectangle(22, 699, 113, 10);
                    endborder = new Rectangle(950, 700, 200, 0);
                    border12 = new Rectangle(4, 4, 1151, 10);
                    border13 = new Rectangle(4, 4, 10, 750);
                    pitfall1 = new Rectangle(404, 210, 116, 65);
                    pitfall2 = new Rectangle(21, 646, 116, 60);
                    BorderFlip(border1);
                    BorderFlip(border2);
                    BorderFlip(border3);
                    BorderFlip(border4);
                    BorderFlip(border5);
                    BorderFlip(border6);
                    BorderFlip(border7);
                    BorderFlip(border8);
                    BorderFlip(border9);
                    BorderFlip(border10);
                    //BorderFlip(border11);
                    BorderFlip(border12);
                    BorderFlip(border13);
                    BorderFlip(endborder);
                    BorderFlip(pitfall1);
                    BorderFlip(pitfall2);
                    starting = new Vector2(20, 20);
                    StartingPoint(starting);
                    flipping = 1;
                }
                if(toxic == 1) { ToxicGas(); }

                if (Gameplay.KurtRect.Intersects(border1)) { BorderControl(border1); }
                if (Gameplay.KurtRect.Intersects(border2)) { BorderControl(border2); }
                if (Gameplay.KurtRect.Intersects(border3)) { BorderControl(border3); }
                if (Gameplay.KurtRect.Intersects(border4)) { BorderControl(border4); }
                if (Gameplay.KurtRect.Intersects(border5)) { BorderControl(border5); }
                if (Gameplay.KurtRect.Intersects(border6)) { BorderControl(border6); }
                if (Gameplay.KurtRect.Intersects(border7)) { BorderControl(border7); }
                if (Gameplay.KurtRect.Intersects(border8)) { BorderControl(border8); }
                if (Gameplay.KurtRect.Intersects(border9)) { BorderControl(border9); }
                if (Gameplay.KurtRect.Intersects(border10)) { BorderControl(border10); }
                if (Gameplay.KurtRect.Intersects(endborder)) { EndRoom(endborder); }
                if (Gameplay.KurtRect.Intersects(border12)) { BorderControl(border12); }
                if (Gameplay.KurtRect.Intersects(border13)) { BorderControl(border13); }
                if (Gameplay.KurtRect.Intersects(pitfall1)) { Pitfall(); }
                if (Gameplay.KurtRect.Intersects(pitfall2)) { Pitfall(); }
            }
            #endregion
            //room 3
            #region
            if (room == 3) //Map does not flip borders
            {
                background = game.Content.Load<Texture2D>("images/3");

                if (flipping == 0)
                {
                    flip = rint.Next(0, 3);
                    border1 = new Rectangle(0, 0, 1148, 30);
                    border2 = new Rectangle(689, 147, 294, 104);
                    border3 = new Rectangle(447, 365, 534, 72);
                    border4 = new Rectangle(0, 148, 568, 99);
                    border5 = new Rectangle(0, 148, 332, 287);
                    border6 = new Rectangle(1097, 0, 100, 686);
                    border7 = new Rectangle(0, 554, 687, 132);
                    border8 = new Rectangle(802, 551, 181, 129);
                    border9 = new Rectangle(687, 686, 150, 100);
                    border10 = new Rectangle(983, 642, 130, 0);
                    border11 = new Rectangle(193, 438, 0, 100);
                    border12 = new Rectangle(782, 609, 20, 50);
                    border13 = new Rectangle(0, 0, 0, 150);
                    endborder = new Rectangle(0, 438, 0, 150);
                    pitfall1 = new Rectangle(803, 253, 116, 65);
                    //pitfall2 = new Rectangle(21, 646, 116, 60);
                    spikes1 = new Rectangle(983, 642, 130, 0);
                    BorderFlip(border1);
                    BorderFlip(border2);
                    BorderFlip(border3);
                    BorderFlip(border4);
                    BorderFlip(border5);
                    BorderFlip(border6);
                    BorderFlip(border7);
                    BorderFlip(border8);
                    BorderFlip(border9);
                    BorderFlip(border10);
                    BorderFlip(border11);
                    BorderFlip(border12);
                    BorderFlip(border13);
                    BorderFlip(endborder);
                    BorderFlip(pitfall1);
                    //BorderFlip(pitfall2);
                    BorderFlip(spikes1);
                    starting = new Vector2(20, 25);
                    StartingPoint(starting);
                    flipping = 1;
                }
                if (toxic == 1) { ToxicGas(); }

                if (Gameplay.KurtRect.Intersects(border1)) { BorderControl(border1); }
                if (Gameplay.KurtRect.Intersects(border2)) { BorderControl(border2); }
                if (Gameplay.KurtRect.Intersects(border3)) { BorderControl(border3); }
                if (Gameplay.KurtRect.Intersects(border4)) { BorderControl(border4); }
                if (Gameplay.KurtRect.Intersects(border5)) { BorderControl(border5); }
                if (Gameplay.KurtRect.Intersects(border6)) { BorderControl(border6); }
                if (Gameplay.KurtRect.Intersects(border7)) { BorderControl(border7); }
                if (Gameplay.KurtRect.Intersects(border8)) { BorderControl(border8); }
                if (Gameplay.KurtRect.Intersects(border9)) { BorderControl(border9); }
                if (Gameplay.KurtRect.Intersects(border10)) { BorderControl(border10); }
                if (Gameplay.KurtRect.Intersects(border11)) { BorderControl(border11); }
                if (Gameplay.KurtRect.Intersects(border12)) { border11 = new Rectangle(0, 0, 0, 0); }
                if (Gameplay.KurtRect.Intersects(border13)) { BorderControl(border13); }
                if (Gameplay.KurtRect.Intersects(endborder)) { EndRoom(endborder); }
                if (Gameplay.KurtRect.Intersects(pitfall1)) { Pitfall(); }
                if (Gameplay.KurtRect.Intersects(pitfall2)) { Pitfall(); }
                if (Gameplay.KurtRect.Intersects(spikes1)) { Spikesy(spikes1); }
            }
            #endregion
            //room 4
            #region
            if (room == 4)
            {
                background = game.Content.Load<Texture2D>("images/4");

                if (flipping == 0)
                {
                    flip = rint.Next(0, 3);
                    border1 = new Rectangle(0, 0, 1151, 24);
                    border2 = new Rectangle(1128, 0, 0, 750);
                    border3 = new Rectangle(180, 144, 730, 176);
                    border4 = new Rectangle(912, 295, 116, 35);
                    border5 = new Rectangle(1026, 144, 100, 176);
                    border6 = new Rectangle(0, 145, 58, 423);
                    border7 = new Rectangle(0, 447, 482, 120);
                    border8 = new Rectangle(0, 447, 28, 300);
                    border9 = new Rectangle(600, 447, 500, 120);
                    border10 = new Rectangle(144, 686, 1000, 200);
                    border11 = new Rectangle(0, 0, 0, 750);
                    border12 = new Rectangle(486, 554, 114, 0);
                    border13 = new Rectangle(1007, 230, 18, 34);
                    endborder = new Rectangle(30, 700, 100, 200);
                    pitfall1 = new Rectangle(1100, 29, 116, 60);
                    pitfall2 = new Rectangle(1075, 330, 116, 60);
                    spikes1 = new Rectangle(1000, 642, 130, 0);
                    BorderFlip(border1);
                    BorderFlip(border2);
                    BorderFlip(border3);
                    BorderFlip(border4);
                    BorderFlip(border5);
                    BorderFlip(border6);
                    BorderFlip(border7);
                    BorderFlip(border8);
                    BorderFlip(border9);
                    BorderFlip(border10);
                    BorderFlip(border11);
                    BorderFlip(border12);
                    BorderFlip(border13);
                    BorderFlip(endborder);
                    BorderFlip(pitfall1);
                    BorderFlip(pitfall2);
                    BorderFlip(spikes1);
                    starting = new Vector2(20, 25);
                    StartingPoint(starting);
                    flipping = 1;
                }
                if (toxic == 1) { ToxicGas(); }

                if (Gameplay.KurtRect.Intersects(border1)) { BorderControl(border1); }
                if (Gameplay.KurtRect.Intersects(border2)) { BorderControl(border2); }
                if (Gameplay.KurtRect.Intersects(border3)) { BorderControl(border3); }
                if (Gameplay.KurtRect.Intersects(border4)) { BorderControl(border4); }
                if (Gameplay.KurtRect.Intersects(border5)) { BorderControl(border5); }
                if (Gameplay.KurtRect.Intersects(border6)) { BorderControl(border6); }
                if (Gameplay.KurtRect.Intersects(border7)) { BorderControl(border7); }
                if (Gameplay.KurtRect.Intersects(border8)) { BorderControl(border8); }
                if (Gameplay.KurtRect.Intersects(border9)) { BorderControl(border9); }
                if (Gameplay.KurtRect.Intersects(border10)) { BorderControl(border10); }
                if (Gameplay.KurtRect.Intersects(border11)) { BorderControl(border11); }
                if (Gameplay.KurtRect.Intersects(border12)) { BorderControl(border12); }
                if (Gameplay.KurtRect.Intersects(border13)) { border12 = new Rectangle(0, 0, 0, 0); }
                if (Gameplay.KurtRect.Intersects(endborder)) { EndRoom(endborder); }
                if (Gameplay.KurtRect.Intersects(pitfall1)) { Pitfall(); }
                if (Gameplay.KurtRect.Intersects(pitfall2)) { Pitfall(); }
                if (Gameplay.KurtRect.Intersects(spikes1)) { Spikesx(spikes1); }
            }
            #endregion
            //room 5
            #region
            if (room == 5)  //Map does not flip borders
            {
                background = game.Content.Load<Texture2D>("images/5");

                if (flipping == 0)
                {
                    flip = rint.Next(0, 3);
                    flip = 2;
                    border1 = new Rectangle(0, 0, 172, 300);
                    border2 = new Rectangle(0, 0, 686, 26);
                    border3 = new Rectangle(290, 27, 191, 273);
                    border4 = new Rectangle(827, 0, 300, 26);
                    border5 = new Rectangle(600, 145, 619, 157);
                    border6 = new Rectangle(600, 418, 400, 158);
                    border7 = new Rectangle(0, 418, 482, 158);
                    border8 = new Rectangle(0, 691, 1151, 0);
                    border9 = new Rectangle(0, 576, 42, 120);
                    border10 = new Rectangle(1118, 301, 0, 500);
                    border11 = new Rectangle(688, 28, 150, 0);
                    //border12 = new Rectangle(486, 554, 114, 0);
                    border13 = new Rectangle(73, 578, 30, 14);
                    endborder = new Rectangle(688, 1, 150, 0);
                    pitfall1 = new Rectangle(185, 63, 94, 56);
                    pitfall2 = new Rectangle(500, 460, 80, 64);
                    spikes1 = new Rectangle(1060, 30, 0, 20);
                    BorderFlip(border1);
                    BorderFlip(border2);
                    BorderFlip(border3);
                    BorderFlip(border4);
                    BorderFlip(border5);
                    BorderFlip(border6);
                    BorderFlip(border7);
                    BorderFlip(border8);
                    BorderFlip(border9);
                    BorderFlip(border10);
                    BorderFlip(border11);
                    //BorderFlip(border12);
                    BorderFlip(border13);
                    BorderFlip(endborder);
                    BorderFlip(pitfall1);
                    BorderFlip(pitfall2);
                    BorderFlip(spikes1);
                    starting = new Vector2(20, 314);
                    StartingPoint(starting);
                    flipping = 1;
                }
                if (toxic == 1) { ToxicGas(); }

                if (Gameplay.KurtRect.Intersects(border1)) { BorderControl(border1); }
                if (Gameplay.KurtRect.Intersects(border2)) { BorderControl(border2); }
                if (Gameplay.KurtRect.Intersects(border3)) { BorderControl(border3); }
                if (Gameplay.KurtRect.Intersects(border4)) { BorderControl(border4); }
                if (Gameplay.KurtRect.Intersects(border5)) { BorderControl(border5); }
                if (Gameplay.KurtRect.Intersects(border6)) { BorderControl(border6); }
                if (Gameplay.KurtRect.Intersects(border7)) { BorderControl(border7); }
                if (Gameplay.KurtRect.Intersects(border8)) { BorderControl(border8); }
                if (Gameplay.KurtRect.Intersects(border9)) { BorderControl(border9); }
                if (Gameplay.KurtRect.Intersects(border10)) { BorderControl(border10); }
                if (Gameplay.KurtRect.Intersects(border11)) { BorderControl(border11); }
                //if (Gameplay.KurtRect.Intersects(border12)) { BorderControl(border12); }
                if (Gameplay.KurtRect.Intersects(border13)) { border11 = new Rectangle(0, 0, 0, 0); }
                if (Gameplay.KurtRect.Intersects(endborder)) { EndRoom(endborder); }
                if (Gameplay.KurtRect.Intersects(pitfall1)) { Pitfall(); }
                if (Gameplay.KurtRect.Intersects(pitfall2)) { Pitfall(); }
                if (Gameplay.KurtRect.Intersects(spikes1)) { Spikesx(spikes1); }
            }
            #endregion
            //room 6
            #region
            if (room == 6)
            {
                background = game.Content.Load<Texture2D>("images/6");

                if (flipping == 0)
                {
                    flip = rint.Next(0, 3);
                    border1 = new Rectangle(0, 0, 1151, 21);
                    border2 = new Rectangle(0, 0, 0, 750);
                    border3 = new Rectangle(187, 136, 1151, 40);
                    border4 = new Rectangle(0, 139, 71, 600);
                    border5 = new Rectangle(72, 297, 820, 119);
                    border6 = new Rectangle(188, 536, 1000, 40);
                    border7 = new Rectangle(0, 730, 1151, 0 );
                    border8 = new Rectangle(1120, 0, 30, 576);
                    //border9 = new Rectangle(600, 447, 500, 120);
                    //border10 = new Rectangle(144, 686, 1000, 200);
                    //border11 = new Rectangle(0, 0, 0, 750);
                    //border12 = new Rectangle(486, 554, 114, 0);
                    //border13 = new Rectangle(1007, 230, 18, 34);
                    endborder = new Rectangle(1135, 676, 100, 200);
                    pitfall1 = new Rectangle(1035, 21, 116, 60);
                    //pitfall2 = new Rectangle(1075, 330, 116, 60);
                    //spikes1 = new Rectangle(1000, 642, 130, 0);
                    toxic1 = new Rectangle(1007, 310, 103, 100);
                    BorderFlip(border1);
                    BorderFlip(border2);
                    BorderFlip(border3);
                    BorderFlip(border4);
                    BorderFlip(border5);
                    BorderFlip(border6);
                    BorderFlip(border7);
                    BorderFlip(border8);
                    //BorderFlip(border9);
                    //BorderFlip(border10);
                    //BorderFlip(border11);
                    //BorderFlip(border12);
                    //BorderFlip(border13);
                    BorderFlip(endborder);
                    BorderFlip(pitfall1);
                    //BorderFlip(pitfall2);
                    //BorderFlip(spikes1);
                    BorderFlip(toxic1);
                    starting = new Vector2(20, 25);
                    StartingPoint(starting);
                    flipping = 1;
                }
                if (toxic == 1) { ToxicGas(); }

                if (Gameplay.KurtRect.Intersects(border1)) { BorderControl(border1); }
                if (Gameplay.KurtRect.Intersects(border2)) { BorderControl(border2); }
                if (Gameplay.KurtRect.Intersects(border3)) { BorderControl(border3); }
                if (Gameplay.KurtRect.Intersects(border4)) { BorderControl(border4); }
                if (Gameplay.KurtRect.Intersects(border5)) { BorderControl(border5); }
                if (Gameplay.KurtRect.Intersects(border6)) { BorderControl(border6); }
                if (Gameplay.KurtRect.Intersects(border7)) { BorderControl(border7); }
                if (Gameplay.KurtRect.Intersects(border8)) { BorderControl(border8); }
                //if (Gameplay.KurtRect.Intersects(border9)) { BorderControl(border9); }
                //if (Gameplay.KurtRect.Intersects(border10)) { BorderControl(border10); }
                //if (Gameplay.KurtRect.Intersects(border11)) { BorderControl(border11); }
                //if (Gameplay.KurtRect.Intersects(border12)) { BorderControl(border12); }
                //if (Gameplay.KurtRect.Intersects(border13)) { border12 = new Rectangle(0, 0, 0, 0); }
                if (Gameplay.KurtRect.Intersects(endborder)) { EndRoom(endborder); }
                if (Gameplay.KurtRect.Intersects(pitfall1)) { Pitfall(); }
                //if (Gameplay.KurtRect.Intersects(pitfall2)) { Pitfall(); }
                //if (Gameplay.KurtRect.Intersects(spikes1)) { Spikesx(spikes1); }
                if (Gameplay.KurtRect.Intersects(toxic1)) { toxic = 1; }
            }
            #endregion
            if (room == 7)
            {
                background = game.Content.Load<Texture2D>("images/7");

                if (flipping == 0)
                {
                    flip = rint.Next(0, 3);
                    border1 = new Rectangle(0, 0, 1151, 21);
                    border2 = new Rectangle(0, 0, 0, 750);
                    border3 = new Rectangle(187, 136, 1151, 40);
                    border4 = new Rectangle(0, 139, 71, 600);
                    border5 = new Rectangle(72, 297, 820, 119);
                    border6 = new Rectangle(188, 536, 1000, 40);
                    border7 = new Rectangle(0, 730, 1151, 0);
                    border8 = new Rectangle(1120, 0, 30, 576);
                    border9 = new Rectangle(600, 447, 500, 120);
                    border10 = new Rectangle(144, 686, 1000, 200);
                    border11 = new Rectangle(0, 0, 0, 750);
                    border12 = new Rectangle(486, 554, 114, 0);
                    //border13 = new Rectangle(1007, 230, 18, 34);
                    endborder = new Rectangle(1135, 676, 100, 200);
                    pitfall1 = new Rectangle(1035, 21, 116, 60);
                    //pitfall2 = new Rectangle(1075, 330, 116, 60);
                    //spikes1 = new Rectangle(1000, 642, 130, 0);
                    toxic1 = new Rectangle(1007, 310, 103, 100);
                    BorderFlip(border1);
                    BorderFlip(border2);
                    BorderFlip(border3);
                    BorderFlip(border4);
                    BorderFlip(border5);
                    BorderFlip(border6);
                    BorderFlip(border7);
                    BorderFlip(border8);
                    BorderFlip(border9);
                    BorderFlip(border10);
                    BorderFlip(border11);
                    BorderFlip(border12);
                    //BorderFlip(border13);
                    BorderFlip(endborder);
                    BorderFlip(pitfall1);
                    //BorderFlip(pitfall2);
                    //BorderFlip(spikes1);
                    BorderFlip(toxic1);
                    starting = new Vector2(20, 25);
                    StartingPoint(starting);
                    flipping = 1;
                }
                if (toxic == 1) { ToxicGas(); }

                if (Gameplay.KurtRect.Intersects(border1)) { BorderControl(border1); }
                if (Gameplay.KurtRect.Intersects(border2)) { BorderControl(border2); }
                if (Gameplay.KurtRect.Intersects(border3)) { BorderControl(border3); }
                if (Gameplay.KurtRect.Intersects(border4)) { BorderControl(border4); }
                if (Gameplay.KurtRect.Intersects(border5)) { BorderControl(border5); }
                if (Gameplay.KurtRect.Intersects(border6)) { BorderControl(border6); }
                if (Gameplay.KurtRect.Intersects(border7)) { BorderControl(border7); }
                if (Gameplay.KurtRect.Intersects(border8)) { BorderControl(border8); }
                if (Gameplay.KurtRect.Intersects(border9)) { BorderControl(border9); }
                if (Gameplay.KurtRect.Intersects(border10)) { BorderControl(border10); }
                if (Gameplay.KurtRect.Intersects(border11)) { BorderControl(border11); }
                if (Gameplay.KurtRect.Intersects(border12)) { BorderControl(border12); }
                //if (Gameplay.KurtRect.Intersects(border13)) { border12 = new Rectangle(0, 0, 0, 0); }
                if (Gameplay.KurtRect.Intersects(endborder)) { EndRoom(endborder); }
                if (Gameplay.KurtRect.Intersects(pitfall1)) { Pitfall(); }
                if (Gameplay.KurtRect.Intersects(pitfall2)) { Pitfall(); }
                if (Gameplay.KurtRect.Intersects(spikes1)) { Spikesx(spikes1); }
                if (Gameplay.KurtRect.Intersects(spikes3)) { Spikesx(spikes2); }
                if (Gameplay.KurtRect.Intersects(spikes2)) { Spikesx(spikes3); }
                if (Gameplay.KurtRect.Intersects(toxic1)) { toxic = 1; }
            }
            if (room == 8)
            {
                flip = 0;
                background = game.Content.Load<Texture2D>("images/S2");
                border1 = new Rectangle(0, 0, 0, 0);
                border2 = new Rectangle(0, 0, 0, 0);
                border3 = new Rectangle(0, 0, 0, 0);
                border4 = new Rectangle(0, 0, 0, 0);
                border5 = new Rectangle(0, 0, 0, 0);
                border6 = new Rectangle(0, 0, 0, 0);
                border7 = new Rectangle(0, 0, 0, 0);
                border8 = new Rectangle(0, 0, 0, 0);
            }

        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            if (toxic == 1) { spritebatch.Draw(toxicgas, Toxpos, null, Color.White * 0.5f, 0, Vector2.Zero, 1, SpriteEffects.None, 1); }
            //spritebatch.Draw(background, Vector2.Zero, null, Color.White, 0, Vector2.Zero, game.scale, SpriteEffects.None, 1);
            if (flip == 0)
            {
                spritebatch.Draw(background, new Vector2(Gameplay.KurtPos.X - 100 + 21, Gameplay.KurtPos.Y - 100 + 54), new Rectangle(((int)((Gameplay.KurtPos.X - 75) / game.scale)), ((int)((Gameplay.KurtPos.Y - 50) / game.scale)), 200, 200), Color.White, 0, Vector2.Zero, game.scale, SpriteEffects.None, 1);
            }
            if (flip == 1)  //y=-1x+1151
            {
                spritebatch.Draw(background, new Vector2(Gameplay.KurtPos.X - 100 + 21, Gameplay.KurtPos.Y - 100 + 54), new Rectangle(((int)((-Gameplay.KurtPos.X - 25  + 1151 - 173) / game.scale)), ((int)((Gameplay.KurtPos.Y - 50) / game.scale)), 200, 200), Color.White, 0, Vector2.Zero, game.scale, SpriteEffects.FlipHorizontally, 1);
            }
            if (flip == 2)  //y=-1x+750
            {
                spritebatch.Draw(background, new Vector2(Gameplay.KurtPos.X - 100 + 21, Gameplay.KurtPos.Y - 100 + 54), new Rectangle(((int)((Gameplay.KurtPos.X - 75) / game.scale)), ((int)((-Gameplay.KurtPos.Y + 750 - 316 + 75) / game.scale)), 200, 200), Color.White, 0, Vector2.Zero, game.scale, SpriteEffects.FlipVertically, 1);
            }
            if (flip == 3)  //both
            {
                spritebatch.Draw(background, new Vector2(Gameplay.KurtPos.X - 100 + 21, Gameplay.KurtPos.Y - 100 + 54), new Rectangle(((int)((-Gameplay.KurtPos.X - 25 + 1151 - 173) / game.scale)), ((int)((-Gameplay.KurtPos.Y + 750 - 316 + 75) / game.scale)), 200, 200), Color.White, 0, Vector2.Zero, game.scale, SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically, 1);
            }
                spritebatch.End();
        }
    }
}

