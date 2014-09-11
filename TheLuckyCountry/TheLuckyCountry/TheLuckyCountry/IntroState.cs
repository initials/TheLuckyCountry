using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using org.flixel;

using System.Linq;
using System.Xml.Linq;

namespace TheLuckyCountry
{
    public class IntroState : FlxState
    {
        private FlxGroup tileGrp;
        private FlxGroup boats;

        override public void create()
        {
            FlxG.resetHud();
            FlxG.hideHud();

            FlxG.backColor = Color.DarkTurquoise;

            base.create();



            FlxCaveGeneratorExt caveExt = new FlxCaveGeneratorExt(100, 60, 0.42f, 3);
            string[,] caveLevel = caveExt.generateCaveLevel();

            tileGrp = new FlxGroup();

            for (int i = 0; i < caveLevel.GetLength(1); i++)
            {
                for (int y = 0; y < caveLevel.GetLength(0); y++)
                {
                    //string toPrint = tiles[y, i];
                    if (Convert.ToInt32(caveLevel[y, i]) != 0)
                    {
                        FlxSprite x = new FlxSprite(i * 8, y * 8);
                        //x.createGraphic(8, 8, colors[Convert.ToInt32(caveLevel[y, i])]);
                        x.loadGraphic("flixel/autotilesIsland", false, false, 8, 8);
                        //x.color = colors[Convert.ToInt32(caveLevel[y, i])];

                        x.frame = Convert.ToInt32(caveLevel[y, i]);
                        //x.scale = 2;
                        x.angularDrag = 250;
                        //x.setOffset(4, 4);

                        x.@fixed = true;
                        tileGrp.add(x);
                    }
                    //Console.Write(toPrint);
                }

                //Console.WriteLine();
            }

            //string newMap = caveExt.convertMultiArrayStringToString(caveLevel);


            add(tileGrp);

            boats = new FlxGroup();

            for (int i = 0; i < 20; i++)
            {
                Boat b = new Boat((int)FlxU.random(0, FlxG.width), (int)FlxU.random(0, FlxG.height));
                b.velocity.X = FlxU.random(-40, 40);
                b.velocity.Y = FlxU.random(-40, 40);


                boats.add(b);
            }

            add(boats);
        }

        override public void update()
        {


            FlxU.collide(tileGrp, boats);

            base.update();
        }


    }
}
