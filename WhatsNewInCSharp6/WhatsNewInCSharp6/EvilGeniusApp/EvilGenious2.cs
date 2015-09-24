using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using static System.Threading.Interlocked;

namespace WhatsNewInCSharp6.EvilGeniusApp
{
    public class EvilGenius2
    {
        #region Properties

        public string Name { get; }

        private HenchMen _minion;
        public HenchMen Minion => _minion;

        #endregion Properties

        #region Constructors

        /// <exception cref="ArgumentNullException"><paramref name=""/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException">Evil genius must have a name</exception>
        public EvilGenius2(string name)
        {
            if(name == null)
            {
                throw new ArgumentNullException(nameof(name), "Evil genius has to have name");
            }
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Evil genius must have a name", nameof(name));
            }
            Name = name;
        }

        #endregion Constructors


        public string CatchPhrase { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{nameof(Name)}: {Name}");
            sb.AppendLine($"{nameof(Minion)}: {Minion?.Name}");

            return sb.ToString();
        }

        /// <exception cref="NullReferenceException">The address of <paramref name="location1" /> is a null pointer. </exception>
        public void ReplaceHenchmen(HenchMen newMinion)
        {
            //This will now cause a compiler error
            //Name = "something";

            //did static using for Interlock.Exchange
            var oldMinion = Exchange(ref _minion, newMinion);
            (oldMinion as IDisposable)?.Dispose();
        }

        /// <exception cref="NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.</exception>
        public static JArray ToJson(IEnumerable<EvilGenius2> evilness)
        {
            var result = new JArray();
            if(evilness != null)
            {
                foreach(var evil in evilness)
                {
                    result.Add(JObject.FromObject(evil));
                }
            }
            return result;
        }
    }
}
