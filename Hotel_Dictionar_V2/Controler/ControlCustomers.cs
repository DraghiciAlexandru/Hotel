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
    public class ControlCustomers
    {
        String path = Application.StartupPath;

        public ListaSimpla<Client> listaClienti;
        public Client loged;

        public ControlCustomers()
        {
            listaClienti = new ListaSimpla<Client>();
            open();
        }

        private void open()
        {
            StreamReader reader = new StreamReader(path + "\\clients.txt");
            String linie = "";
            while ((linie = reader.ReadLine()) != null)
            {
                listaClienti.addFinish(new Client(linie));
            }
            reader.Close();
        }

        public void remove(Client client)
        {
            listaClienti.deletePosition(listaClienti.position(client));
        }

        public int lastId()
        {
            return listaClienti.getLast().Data.ID + 1;
        }

        public void add(Client client)
        {
            client.ID = lastId();
            listaClienti.addFinish(client);
        }

        public void updateName(int id, String name)
        {
            for (int i = 0; i < listaClienti.size(); i++)
            {
                if (listaClienti.getAtPosition(i).ID == id)
                {
                    listaClienti.getAtPosition(i).Nume = name;
                }
            }
        }

        public void updatePassword(int id, String password)
        {
            for (int i = 0; i < listaClienti.size(); i++)
            {
                if (listaClienti.getAtPosition(i).ID == id)
                {
                    listaClienti.getAtPosition(i).Password = password;
                }
            }
        }

        public void updateEmail(int id, String email)
        {
            for (int i = 0; i < listaClienti.size(); i++)
            {
                if (listaClienti.getAtPosition(i).ID == id)
                {
                    listaClienti.getAtPosition(i).Email = email;
                }
            }
        }

        public void updatePhone(int id, String phone)
        {
            for (int i = 0; i < listaClienti.size(); i++)
            {
                if (listaClienti.getAtPosition(i).ID == id)
                {
                    listaClienti.getAtPosition(i).Telefon = phone;
                }
            }
        }

        public void save()
        {
            StreamWriter writer = new StreamWriter(path + "\\clients.txt");

            writer.Write(listaClienti.ToString());

            writer.Close();
        }

        public Client getClient(int id)
        {
            for (int i = 0; i < listaClienti.size(); i++)
            {
                if (listaClienti.getAtPosition(i).ID == id)
                {
                    return listaClienti.getAtPosition(i);
                }
            }
            return null;
        }

        public Client getClient(String nume)
        {
            for (int i = 0; i < listaClienti.size(); i++)
            {
                if (listaClienti.getAtPosition(i).Nume == nume)
                {
                    return listaClienti.getAtPosition(i);
                }
            }
            return null;
        }
    }
}
