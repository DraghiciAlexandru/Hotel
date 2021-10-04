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
    class ControlCancel
    {
        String path = Application.StartupPath;

        public ListaSimpla<Rezervare> listaCancel;

        public ControlCancel()
        {
            listaCancel = new ListaSimpla<Rezervare>();
            open();
        }

        private void open()
        {
            StreamReader reader = new StreamReader(path + "\\cancel.txt");
            String linie = "";
            while ((linie = reader.ReadLine()) != null)
            {
                listaCancel.addFinish(new Rezervare(linie));
            }
            reader.Close();
        }

        public void remove(Rezervare Rezervare)
        {
            listaCancel.deletePosition(listaCancel.position(Rezervare));
        }

        public void add(Rezervare Rezervare)
        {
            listaCancel.addFinish(Rezervare);
        }

        public void updateRoom(int id, int idRoom)
        {
            for (int i = 0; i < listaCancel.size(); i++)
            {
                if (listaCancel.getAtPosition(i).ID == id)
                {
                    listaCancel.getAtPosition(i).CameraID = idRoom;
                }
            }
        }

        public void updateChkIn(int id, DateTime chkIn)
        {
            for (int i = 0; i < listaCancel.size(); i++)
            {
                if (listaCancel.getAtPosition(i).ID == id)
                {
                    listaCancel.getAtPosition(i).CheckIn = chkIn;
                }
            }
        }

        public void updateChkOut(int id, DateTime chkOut)
        {
            for (int i = 0; i < listaCancel.size(); i++)
            {
                if (listaCancel.getAtPosition(i).ID == id)
                {
                    listaCancel.getAtPosition(i).CheckOut = chkOut;
                }
            }
        }

        public void save()
        {
            StreamWriter writer = new StreamWriter(path + "\\cancel.txt");

            writer.Write(listaCancel.ToString());

            writer.Close();
        }

        public bool isCancel(int id)
        {
            for (int i = 0; i < listaCancel.size(); i++)
            {
                if (listaCancel.getAtPosition(i).ID == id)
                    return true;
            }
            return false;
        }
    }
}
