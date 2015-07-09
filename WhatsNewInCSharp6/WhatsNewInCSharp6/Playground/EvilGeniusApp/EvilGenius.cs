using System;

namespace WhatsNewInCSharp6.EvilGeniusApp
{
    public class EvilGenius
    {
        public string Name { get; set; }
        public HenchMen Minion { get; set; }
        public string CatchPhrase { get; set; }

        //Expression bodied members cannot be multiple lines, must be a single statement
        //public override string ToString() => Name;


        //This version doesn't handle null
        //public override string ToString() => string.Format("{0}, {1}", Name, Minion.Name);

        public override string ToString() => string.Format("{0}, {1}", Name, Minion?.Name);

        public void Retirehenchmen()
        {
            //If minion implements IDisposable a nulling out will be a memory leak 
            //Minion = null;

            #region Old way

            //var disposableMinion = Minion as IDisposable;
            //if (disposableMinion != null)
            //{
            //    disposableMinion.Dispose();
            //}
            //Minion = null;

            #endregion Old Way

            #region New Way

            (Minion as IDisposable)?.Dispose();
            Minion = null;

            #endregion New Way
        }
    }
}
