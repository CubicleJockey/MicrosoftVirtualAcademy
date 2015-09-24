using System;
using System.ComponentModel;

namespace WhatsNewInCSharp6.EvilGeniusApp
{
    public class EvilPlanViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string evilGenius;

        /// <exception cref="Exception" accessor="set">A delegate callback throws an exception.</exception>
        public string EvilGeniusCreator
        {
            get { return evilGenius; }
            set
            {
                if(value != evilGenius)
                {
                    evilGenius = value;
                    //Evil operator make it thread safe
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EvilGeniusCreator)));
                }
            }
        }
    }
}
