using System;
using System.Configuration;
using System.Drawing;
using System.Threading;
using static FinalFantasyXThunderBoltDodger.DirectxKeyboardSender;
using static FinalFantasyXThunderBoltDodger.NativeFunctions;

namespace FinalFantasyXThunderBoltDodger
{
    internal class ThunderBoltDodger
    {
        private static DirectXKeyStrokes DodgeKey => DirectXKeyStrokes.DIK_C;

        public void StartDodging(Point location)
        {
            var grayscaleThunderThreshold = int.Parse(ConfigurationManager.AppSettings["grayscaleThunderThreadhold"]);
            var finalFantasyXhandler = FindWindow("PhyreFrameworkClass", "FINAL FANTASY X");
            SetForegroundWindow(finalFantasyXhandler);

            while (true)
            {
                Console.WriteLine($"Checking point {location}");
                var luminance = ColorChecker.GetLuminance(location);

                Console.WriteLine($"Luminance is {luminance}. Will dodge if above {grayscaleThunderThreshold}");
                if (luminance > grayscaleThunderThreshold)
                {
                    Dodge();
                }

                Thread.Sleep(200);
            }
        }

        private void Dodge()
        {
            Console.WriteLine("I think it's time to dodge");
            SendKey(DodgeKey, false, InputType.Keyboard);
            Thread.Sleep(50);
            SendKey(DodgeKey, true, InputType.Keyboard);
            Thread.Sleep(500);
        }
    }
}
