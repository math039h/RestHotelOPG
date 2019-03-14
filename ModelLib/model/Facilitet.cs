using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib.model
{
    public class Facilitet
    {
        private int facilitetnr;
        private string name;

        public Facilitet()
        {
            
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Facilitetnr
        {
            get { return facilitetnr; }
            set { facilitetnr = value; }
        }
        public override string ToString()

        {

            return $"{nameof(Facilitetnr)}: {Facilitetnr}, {nameof(Name)}: {Name}";

        }
    }
}
