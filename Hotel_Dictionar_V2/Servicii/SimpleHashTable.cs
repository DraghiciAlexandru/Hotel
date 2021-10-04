using Hotel_Dictionar_V2.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_Dictionar_V2.Servicii
{
    class SimpleHashTable
    {
        private Stored<Client, ListaSimpla<Rezervare>>[] hashtable;
        
        public SimpleHashTable()
        {
            hashtable = new Stored<Client, ListaSimpla<Rezervare>>[100];
        }

        //functia hash

        private int hashKey(Client key)
        {
            return key.ID;
        }

        public void put(Client key, ListaSimpla<Rezervare> value)
        {
            int pozitie = hashKey(key);

            if (ocupied(pozitie))
            {
                Console.WriteLine("Nu avem loc");
            }
            else
            {
                hashtable[pozitie] = new Stored<Client, ListaSimpla<Rezervare>>();
                hashtable[pozitie].Key = key;
                hashtable[pozitie].Value = value;
            }

        }

        private bool ocupied(int index)
        {
            return hashtable[index] != null;
        }

        private int findKey(Client key)
        {
            int pozitie = hashKey(key);

            if (hashtable[pozitie] != null && hashtable[pozitie].Key.Equals(key))
            {
                return pozitie;
            }
            
            int stop = pozitie;

            if (pozitie == hashtable.Length - 1)
            {
                pozitie = 0;
            }
            else
            {
                pozitie++;
            }


            while (pozitie != stop && hashtable[pozitie] != null && !hashtable[pozitie].Key.Equals(key)) 
            {
                
                pozitie = (pozitie + 1) % hashtable.Length;
            }


            if (hashtable[pozitie] != null && hashtable[pozitie].Key.Equals(key)) 
            {
                return pozitie;
            }
            else
            {
                return -1;
            }
           
        }

        public ListaSimpla<Rezervare> get(Client key)
        {
            int pozitie = findKey(key);

            Console.WriteLine(pozitie);

            if (pozitie != -1)
            {
                return hashtable[pozitie].Value;
            }

            return null;
        }

        public override string ToString()
        {
            String text = "";

            for (int i = 0; i < hashtable.Length; i++) 
            {
                if (hashtable[i] != null)
                    text += hashtable[i].Key.ToString() + Environment.NewLine + hashtable[i].Value.ToString() + Environment.NewLine;
            }

            return text;

        }

        public void remove(Client key, Rezervare rezervare)
        {
            int pozitie = hashKey(key);
            hashtable[pozitie].Value.deletePosition(hashtable[pozitie].Value.position(rezervare));
        }

        public ListaSimpla<Client> getKeys()
        {
            ListaSimpla<Client> lista = new ListaSimpla<Client>();
            for (int i = 0; i < hashtable.Length; i++)
            {
                if (hashtable[i] != null)
                {
                    lista.addFinish(hashtable[i].Key);
                }
            }
            return lista;
        }

        public ListaSimpla<ListaSimpla<Rezervare>> getValues()
        {
            ListaSimpla<ListaSimpla<Rezervare>> lista = new ListaSimpla<ListaSimpla<Rezervare>>();
            for (int i = 0; i < hashtable.Length; i++)
            {
                if (hashtable[i] != null)
                {
                    lista.addFinish(hashtable[i].Value);
                }
            }
            return lista;
        }

        public void addRezervare(int key, Rezervare rezervare)
        {
            ListaSimpla<Rezervare> rez = hashtable[key].Value;

            rez.addFinish(rezervare);
        }
    }
}
