using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Dictionar_V2.Model
{
    class Room
    {
        public int Numar { get; set; }
        public String Tip { get; set; }
        public double Pret { get; set; }
        public int NumarPersoane { get; set; }
        public bool Rezervat { get; set; }

        public Room(int Numar, String Tip, double Pret, int NumarPersoane, bool Rezervat)
        {
            this.Numar = Numar;
            this.Tip = Tip;
            this.Pret = Pret;
            this.NumarPersoane = NumarPersoane;
            this.Rezervat = Rezervat;
        }

        public Room(String room) : this(int.Parse(room.Split(',')[0]), room.Split(',')[1], double.Parse(room.Split(',')[2]), int.Parse(room.Split(',')[3]), bool.Parse(room.Split(',')[4]))
        {

        }

        public override bool Equals(object obj)
        {
            Room other = obj as Room;
            if (this.Numar == other.Numar)
                return true;
            return false;
        }

        public override string ToString()
        {
            return Numar + "," + Tip + "," + Pret + "," + NumarPersoane + "," + Rezervat;
        }
    }
}
