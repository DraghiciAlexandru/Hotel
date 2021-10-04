using Hotel_Dictionar_V2.Model;
using Hotel_Dictionar_V2.Servicii;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Dictionar_V2.Controler
{
    class ControlRooms
    {
        String path = Application.StartupPath;

        public ListaSimpla<Room> listaRooms;

        public ControlRooms()
        {
            listaRooms = new ListaSimpla<Room>();
            open();
        }

        private void open()
        {
            StreamReader reader = new StreamReader(path + "\\rooms.txt");
            String linie = "";
            while ((linie = reader.ReadLine()) != null)
            {
                listaRooms.addFinish(new Room(linie));
            }
            reader.Close();
        }

        public void remove(Room Room)
        {
            listaRooms.deletePosition(listaRooms.position(Room));
        }

        private int lastId()
        {
            return listaRooms.getLast().Data.Numar + 1;
        }

        public void add(Room Room)
        {
            Room.Numar = lastId();
            listaRooms.addFinish(Room);
        }

        public void updateTip(int nr, String newTip)
        {
            for (int i = 0; i < listaRooms.size(); i++)
            {
                if (listaRooms.getAtPosition(i).Numar == nr)
                {
                    listaRooms.getAtPosition(i).Tip = newTip;
                }
            }
        }

        public void updatePrice(int nr, double newPrice)
        {
            for (int i = 0; i < listaRooms.size(); i++)
            {
                if (listaRooms.getAtPosition(i).Numar == nr)
                {
                    listaRooms.getAtPosition(i).Pret = newPrice;
                }
            }
        }

        public void updateNrPers(int nr, int nrPersoane)
        {
            for (int i = 0; i < listaRooms.size(); i++)
            {
                if (listaRooms.getAtPosition(i).Numar == nr)
                {
                    listaRooms.getAtPosition(i).NumarPersoane = nrPersoane;
                }
            }
        }

        public void updateState(int nr, bool newState)
        {
            for (int i = 0; i < listaRooms.size(); i++)
            {
                if (listaRooms.getAtPosition(i).Numar == nr)
                {
                    listaRooms.getAtPosition(i).Rezervat = newState;
                }
            }
        }

        public void save()
        {
            StreamWriter writer = new StreamWriter(path + "\\rooms.txt");

            writer.Write(listaRooms.ToString());

            writer.Close();
        }

        public bool isOcupat(int nr)
        {
            return listaRooms.getAtPosition((nr - 1)).Rezervat;
        }
    }
}
