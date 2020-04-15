using System.Drawing;
using System.Windows.Forms;

namespace FinalFantasyXThunderBoltDodger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var thunderBoltDodger = new ThunderBoltDodger();

            var primaryScreenBounds = Screen.PrimaryScreen.Bounds;
            var centerScreenLocation = new Point(primaryScreenBounds.Width / 2, primaryScreenBounds.Height / 2);

            thunderBoltDodger.StartDodging(centerScreenLocation);
        }
    }
}
