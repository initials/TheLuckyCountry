#region File Description
//-----------------------------------------------------------------------------
// Flixel for XNA.
// Original repo : https://github.com/StAidan/X-flixel
// Extended and edited repo : https://github.com/initials/XNAMode
//-----------------------------------------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using org.flixel;
using Microsoft.Xna.Framework;

namespace Loader_TLC
{
    /// <summary>
    /// Flixel enters here.
    /// <code>FlxFactory</code> refers to it as the "masterclass".
    /// </summary>
    public class FlixelEntryPoint2 : FlxGame
    {
        public FlixelEntryPoint2(Game game)
            : base(game)
        {

            Console.WriteLine("Flixel Entry Point");

            int w = FlxG.resolutionWidth / FlxG.zoom;
            int h = FlxG.resolutionHeight / FlxG.zoom;

            initGame(w, h, new TheLuckyCountry.IntroState(), new Color(15, 15, 15), true, new Color(5, 5, 5));

            FlxG.debug = false;
            FlxG.level = 1;


#if DEBUG
            FlxG.debug = true;
#endif

#if DEMO
            Lemonade.Lemonade_Globals.PAID_VERSION = Lemonade.Lemonade_Globals.DEMO_MODE;
#endif
#if FULL
            Lemonade.Lemonade_Globals.PAID_VERSION = Lemonade.Lemonade_Globals.FULL_MODE;
#endif
#if PIRATE
            Lemonade.Lemonade_Globals.PAID_VERSION = Lemonade.Lemonade_Globals.PIRATE_MODE;
#endif


            FlxG.BUILD_TYPE = FlxG.BUILD_TYPE_PC;




        }
    }
}
