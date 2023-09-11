using MyApplicationVer_2.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace MyApplicationVer_2.Models
{
    abstract class BaseRepository
    {
        protected static readonly ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        protected static ObservableCollection<Client> clients = new ObservableCollection<Client>();
        protected ObservableCollection<Client> copyClients = new ObservableCollection<Client>();

        protected readonly string clientPath = @"ClientCollection.txt";
        protected static readonly string employeePath = @"EmployeeCollection.txt";

        /// <summary>
        /// Метод получения списка клиентов из файла
        /// </summary>
        /// <returns></returns>
        public virtual ObservableCollection<Client> GetClients()
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

        /// <summary>
        /// Метод получения списка сотрудников из файла
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Employee> GetEmployees()
        {
            using (StreamReader sr = new StreamReader(employeePath, true))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] lines = line.Split(';');

                    Employee employee = new Employee(Convert.ToInt32(lines[0]), lines[1]);

                    employees.Add(employee);
                }
            }

            return employees;
        }

        /// <summary>
        /// Метод добавления нового клиента в список
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public virtual ObservableCollection<Client> AddNewClient(Client client)
        {
            clients.Add(client);

            WriteToFile();

            return clients;
        }

        public virtual ObservableCollection<Client> EditClient(Client client, string phoneNumber) { return clients; }
        public virtual ObservableCollection<Client> EditClient(Client client, string surname, string name, string partronymic, string phoneNumber, string passportSeries, string passportNumber)
        {
            client.Surname = surname;
            client.Name = name;
            client.Patronymic = partronymic;
            client.PhoneNumber = phoneNumber;
            client.PassportSeries = passportSeries;
            client.PassportNumber = passportNumber;

            clients.Insert(client.Id, client);
            clients.Remove(client);

            WriteToFile();

            return clients;
        }

        /// <summary>
        /// Метод удаления клиента из списка
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public virtual ObservableCollection<Client> DeleteClient(Client client)
        {
            clients.Remove(client);

            WriteToFile();

            return clients;
        }

        /// <summary>
        /// Метод получения количества клиентов
        /// </summary>
        /// <returns></returns>
        public static int GetCount() => clients.Count;

        /// <summary>
        /// Метод записи данных в файл
        /// </summary>
        public virtual void WriteToFile()
        {
            File.WriteAllText(clientPath, string.Empty);

            using (StreamWriter sw = new StreamWriter(clientPath, true))
            {
                foreach (var item in clients)
                    sw.WriteLine($"{item.Id};{item.Surname};{item.Name};{item.Patronymic};{item.PhoneNumber};{item.PassportSeries};{item.PassportNumber}");
            }
        }
    }
}
