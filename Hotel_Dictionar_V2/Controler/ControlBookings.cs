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
    class ControlBookings
    {
        String path = Application.StartupPath;

        public ListaSimpla<Rezervare> listaRezervari;

        public ControlBookings()
        {
            listaRezervari = new ListaSimpla<Rezervare>();
            open();
        }

        private void open()
        {
            StreamReader reader = new StreamReader(path + "\\rezervari.txt");
            String linie = "";
            while ((linie = reader.ReadLine()) != null)
            {
                listaRezervari.addFinish(new Rezervare(linie));
            }
            reader.Close();
        }

        public void remove(Rezervare Rezervare)
        {
            listaRezervari.deletePosition(listaRezervari.position(Rezervare));
        }

        private int lastId()
        {
            return listaRezervari.getLast().Data.ID + 1;
        }

        public void add(Rezervare Rezervare)
        {
            Rezervare.ID = lastId();
            listaRezervari.addFinish(Rezervare);
        }

        public void updateRoom(int id, int idRoom)
        {
            for (int i = 0; i < listaRezervari.size(); i++)
            {
                if (listaRezervari.getAtPosition(i).ID == id)
                {
                    listaRezervari.getAtPosition(i).CameraID = idRoom;
                }
            }
        }

        public void updateChkIn(int id, DateTime chkIn)
        {
            for (int i = 0; i < listaRezervari.size(); i++)
            {
                if (listaRezervari.getAtPosition(i).ID == id)
                {
                    listaRezervari.getAtPosition(i).CheckIn = chkIn;
                }
            }
        }

        public void updateChkOut(int id, DateTime chkOut)
        {
            for (int i = 0; i < listaRezervari.size(); i++)
            {
                if (listaRezervari.getAtPosition(i).ID == id)
                {
                    listaRezervari.getAtPosition(i).CheckOut = chkOut;
                }
            }
        }

        public void save()
        {
            StreamWriter writer = new StreamWriter(path + "\\rezervari.txt");

            writer.Write(listaRezervari.ToString());

            writer.Close();
        }

        public Rezervare getRezervare(int id)
        {
            for (int i = 0; i < listaRezervari.size(); i++)
            {
                if (listaRezervari.getAtPosition(i).ID == id)
                {
                    return listaRezervari.getAtPosition(i);
                }
            }
            return null;
        }
    }
}
