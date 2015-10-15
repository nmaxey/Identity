//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Audio;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.GamerServices;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using Microsoft.Xna.Framework.Media;
//using System.Runtime.InteropServices;

//namespace identity
//{

//    public class Chapter1
//    {

//        public Chapter1(Game1 game)
//        {

//        }
//        public void Update(GameTime Gametime)
//        {

//        }
//        public void Draw(SpriteBatch spritebatch)
//        {
//        }
//    }
//}




//spritebatch.Draw(background, new Vector2(Gameplay.KurtPos.X - 100, Gameplay.KurtPos.Y - 100), new Rectangle(((int)((Gameplay.KurtPos.X - 50) / game.scale)),((int)((Gameplay.KurtPos.Y - 50) / game.scale)), 200, 200), Color.White, 0, Vector2.Zero, game.scale, SpriteEffects.None, 1);
//Complete Collision Detection with Rectangles
 //if (Gameplay.KurtRect.Intersects(border3))
 //               {
 //                   if (Gameplay.KurtPos.X >= border3.X - 84 && Gameplay.KurtPos.X <= border3.X - 84 + 10)
 //                   {
 //                       Gameplay.KurtPos.X = border3.X - 84;
 //                   }
 //                   if (Gameplay.KurtPos.X <= border3.Width + border3.X && Gameplay.KurtPos.X >= border3.Width + border3.X - 10)
 //                   {
 //                       Gameplay.KurtPos.X = border3.X + border3.Width;
 //                   }
 //                   if (Gameplay.KurtPos.Y >= border3.Y - 108 && Gameplay.KurtPos.Y <= border3.Y - 108 + 10)
 //                   {
 //                       Gameplay.KurtPos.Y = border3.Y - 108;
 //                   }
 //                   if (Gameplay.KurtPos.X <= border3.Height + border3.Y && Gameplay.KurtPos.X >= border3.Height + border3.Y - 10)
 //                   {
 //                       Gameplay.KurtPos.X = border3.Y + border3.Height;
 //                   }
 //               }