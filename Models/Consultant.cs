using System;
using System.Collections.ObjectModel;
using System.IO;

namespace MyApplicationVer_2.Models
{
    class Consultant : BaseRepository
    {
        /// <summary>
        /// Метод получения клиентов для консультанта
        /// </summary>
        /// <returns></returns>
        public override ObservableCollection<Client> GetClients()
        {
            clients.Clear();
            copyClients.Clear();

            using (StreamReader sr = new StreamReader(clientPath, true))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] lines = line.Split(';');

                    Client client = new Client(Convert.ToInt32(lines[0]), lines[1], lines[2], lines[3], lines[4], lines[5], lines[6]);

                    clients.Add(client);
                }

                foreach (var item in clients)
                    copyClients.Add(new Client(item.Id, item.Surname, item.Name, item.Patronymic, item.PhoneNumber, item.PassportSeries, item.PassportNumber));

                foreach (var item in copyClients)
                {
                    item.PassportSeries = "** **";
                    item.PassportNumber = "*** ***";
                }
            }

            return copyClients;
        }

        /// <summary>
        /// Метод редактирования данных для клиента
        /// </summary>
        /// <param name="client"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public override ObservableCollection<Client> EditClient(Client client, string phoneNumber)
        {
            client.PhoneNumber = phoneNumber;

            clients[client.Id - 1].PhoneNumber = client.PhoneNumber;

            WriteToFile();

            return clients;
        }
    }
}
