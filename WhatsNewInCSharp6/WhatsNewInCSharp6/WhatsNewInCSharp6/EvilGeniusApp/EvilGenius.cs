using System;
using static System.Threading.Interlocked;

namespace WhatsNewInCSharp6.EvilGeniusApp
{
    public class EvilGenius
    {
        public string Name { get; set; }

        public HenchMen Minion => minion;
        private HenchMen minion;

        public string CatchPhrase { get; set; }

        //Expression bodied members cannot be multiple lines, must be a single statement
        //public override string ToString() => Name;


        //This version doesn't handle null
        //public override string ToString() => string.Format("{0}, {1}", Name, Minion.Name);

        public override string ToString() => $"{Name}, {Minion?.Name}";

        public void ReplaceHenchmen(HenchMen newMinion)
        {
            //did static using for Interlock.Exchange
            var oldMinion = Exchange(ref minion, newMinion);
           (oldMinion as IDisposable)?.Dispose();
        }
    }
}
