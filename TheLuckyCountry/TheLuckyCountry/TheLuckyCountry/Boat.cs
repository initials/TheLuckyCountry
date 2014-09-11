using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using org.flixel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace TheLuckyCountry
{
    class Boat : FlxSprite
    {

        public Boat(int xPos, int yPos)
            : base(xPos, yPos)
        {
            loadGraphic(FlxG.Content.Load<Texture2D>("boats"), true, false, 16, 16);

            addAnimation("up", new int[] { 0,1 }, (int)FlxU.random(4,8), true);
            addAnimation("right", new int[] { 18, 19 }, (int)FlxU.random(4, 8), true);
            addAnimation("down", new int[] { 36, 37 }, (int)FlxU.random(4, 8), true);
            addAnimation("left", new int[] { 54, 55 }, (int)FlxU.random(4, 8), true);
            addAnimation("stopped", new int[] { 36 }, (int)FlxU.random(4, 8), true);


            play("right");
        }

        override public void update()
        {
            if (velocity.X > 0)
            {
                double rot = Math.Atan2((float)velocity.Y, (float)velocity.X);
                double degrees = rot * 180 / Math.PI;

                angle = (float)degrees;
            }
            else
            {
                double rot = Math.Atan2((float)velocity.Y, (float)velocity.X);
                double degrees = rot * 180 / Math.PI;

                angle = (float)degrees;
            }

            if (angle > 0 && angle < 90)
            {
                play("right");
            }
            else if (angle > 90 && angle < 180)
            {
                play("down");
            }
            else if (angle > -180 && angle < -90)
            {
                play("left");
            }
            else if (angle > -90 && angle < 0)
            {
                play("up");
            }


            angle = 0;

            if (velocity.X == 0)
            {
                play("stopped");
            }


            base.update();

        }


    }
}
