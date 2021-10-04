using Hotel_Dictionar_V2.Servicii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Dictionar_V2.Model
{
    public class Client
    {
        public int ID { get; set; }
        public String Nume { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public String Telefon { get; set; }

        public Client(int ID, String Nume, String Password, String Email, String Telefon)
        {
            this.ID = ID;
            this.Nume = Nume;
            this.Password = Password;
            this.Email = Email;
            this.Telefon = Telefon;
        }

        public Client(String client) : this(int.Parse(client.Split(',')[0]), client.Split(',')[1], client.Split(',')[2], client.Split(',')[3], client.Split(',')[4])
        {

        }

        public override bool Equals(object obj)
        {
            Client other = obj as Client;
            if (this.ID == other.ID)
                return true;
            return false;
        }

        public override string ToString()
        {
            return ID + "," + Nume + "," + Password + "," + Email + "," + Telefon;
        }
    }
}
