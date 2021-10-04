using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Dictionar_V2.Model
{
    class Rezervare : IComparable<Rezervare>
    {
        public int ID { get; set; }
        public int ClientID { get; private set; }
        public int CameraID { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Rezervare(int ID, int ClientID, int CameraID, DateTime CheckIn, DateTime CheckOut)
        {
            this.ID = ID;
            this.ClientID = ClientID;
            this.CameraID = CameraID;
            this.CheckIn = CheckIn;
            this.CheckOut = CheckOut;
        }

        public Rezervare(String rezervare) : this(int.Parse(rezervare.Split(',')[0]), int.Parse(rezervare.Split(',')[1]), int.Parse(rezervare.Split(',')[2]), DateTime.Parse(rezervare.Split(',')[3]), DateTime.Parse(rezervare.Split(',')[4]))
        {

        }

        public int CompareTo(Rezervare other)
        {
            return CheckIn.CompareTo(other.CheckIn);
        }

        public override bool Equals(object obj)
        {
            Rezervare other = obj as Rezervare;
            if (this.ID == other.ID)
                return true;
            return false;
        }

        public override string ToString()
        {
            String text = "";
            text += ID + "," + ClientID + "," + CameraID + ",";
            text += CheckIn.ToString("d") + "," + CheckOut.ToString("d");
            return text;
        }
    }
}
