using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyApplicationVer_2.Models
{
    class Consultant : BaseRepository
    {
        public override ObservableCollection<Client> GetClients()
        {
            clients.Clear();

            using (StreamReader sr = new StreamReader(clientPath, true))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] lines = line.Split(';');

                    Client client = new Client(Convert.ToInt32(lines[0]), lines[1], lines[2], lines[3], lines[4], lines[5], lines[6]);

                    clients.Add(client);
                }
            }

            return clients;
        }

        public override ObservableCollection<Client> EditClient(Client client, string phoneNumber)
        {
            client.PhoneNumber = phoneNumber;

            clients.Insert(client.Id, client);
            clients.Remove(client);

            WriteToFile();

            return clients;
        }
    }
}
