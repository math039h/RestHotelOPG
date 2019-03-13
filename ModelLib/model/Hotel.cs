using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib.model
{
    public class Hotel
    {
        private int _id;
        private String _name;
        private String _address;
        private int _faciliteterId;

        // HUSK ALTID EN DEFAULT konstruktør til JSON
        public Hotel()
        {
        }

        public Hotel(int id, string name, string address)
        {
            _id = id;
            _name = name;
            _address = address;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Address
        {
            get => _address;
            set => _address = value;
        }

        public int FaciliteterID
        {
            get { return _faciliteterId; }
            set { _faciliteterId = value; }
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Address)}: {Address}";
        }
    }

}

