using MyApplicationVer_2.Commands.BaseCommand;
using MyApplicationVer_2.Models;
using MyApplicationVer_2.ViewModels.BaseViewModels;
using MyApplicationVer_2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace MyApplicationVer_2.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        #region Variables

        protected ObservableCollection<Client> clientList;
        protected ObservableCollection<Employee> employeeList;
        public static Employee selectedEmployee;
        protected Consultant consultant;
        protected Client selectedClient;
        protected Manager manager;

        protected BaseCommand _openAddNewClientWindow;
        protected BaseCommand _openEditClientWindow;
        protected BaseCommand _deleteClient;

        #endregion

        #region Constructor

        public MainWindowViewModel()
        {
            Employees = BaseRepository.GetEmployees();
            consultant = new Consultant();
            manager = new Manager();
        }

        #endregion

        #region Properties

        public string Title { get; } = "Клиентский справочник";

        public ObservableCollection<Employee> Employees
        {
            get { return employeeList; }
            set
            {
                if (employeeList != value)
                {
                    employeeList = value;
                    OnPropertyChanged(nameof(Employees));
                }
            }
        }

        public ObservableCollection<Client> Clients
        {
            get { return clientList; }
            set
            {
                if (clientList != value)
                {
                    clientList = value;
                    OnPropertyChanged(nameof(Clients));
                }
            }
        }

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                if (selectedEmployee != value)
                {
                    selectedEmployee = value;
                    OnPropertyChanged(nameof(SelectedEmployee));

                    switch (SelectedEmployee.Id)
                    {
                        case 1:
                            Clients = consultant.GetClients();
                            break;
                        case 2:
                            Clients = manager.GetClients();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public Client SelectedClient
        {
            get { return selectedClient; }
            set
            {
                if (selectedClient != value)
                {
                    selectedClient = value;
                    OnPropertyChanged(nameof(SelectedClient));
                }
            }
        }

        #endregion

        #region Commands

        public BaseCommand OpenAddNewClientWindow
        {
            get
            {
                return _openAddNewClientWindow ?? new BaseCommand(obj =>
                {
                    switch (SelectedEmployee.Id)
                    {
                        case 1:
                            MessageBox.Show("Недостаточно прав для выполнения данного действия", caption: "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        case 2:
                            OpenAddNewClientWindowMethod();
                            break;
                        default:
                            break;
                    }
                });
            }
        }

        public BaseCommand OpenEditClientWindow
        {
            get
            {
                return _openEditClientWindow ?? new BaseCommand(obj =>
                {
                    if (SelectedClient is Client client)
                    {
                        switch (SelectedEmployee.Id)
                        {
                            case 1:
                                EditClientWindowViewModel._selectedClient = client;

                                OpenEditClientWindowMethod();
                                break;
                            case 2:
                                EditClientWindowViewModel._selectedClient = client;

                                OpenEditClientWindowMethod();
                                break;
                            default:
                                break;
                        }
                    }
                    else { MessageBox.Show("Для начала выберите клиента из списка", caption: "Внимание", MessageBoxButton.OK, MessageBoxImage.Information); }
                });
            }
        }

        public BaseCommand DeleteClient
        {
            get
            {
                return _deleteClient ?? new BaseCommand(obj =>
                {
                    if (SelectedClient is Client client)
                    {
                        switch (SelectedEmployee.Id)
                        {
                            case 1:
                                MessageBox.Show("Недостаточно прав для выполнения данного действия", caption: "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                                break;
                            case 2:
                                manager.DeleteClient(client);
                                break;
                        }
                    }
                    else { MessageBox.Show("Для начала выберите клиента из списка", caption: "Внимание", MessageBoxButton.OK, MessageBoxImage.Information); }
                });
            }
        }

        #endregion

        #region Methods

        private void OpenAddNewClientWindowMethod()
        {
            AddNewClientWindow addNewClientWindow = new AddNewClientWindow();

            SetCenterPositionAndOpen(addNewClientWindow);
        }

        private void OpenEditClientWindowMethod()
        {
            if (SelectedEmployee.Id == 1)
            {
                ConsultantEditClientWindow consultantEditClientWindow = new ConsultantEditClientWindow();

                SetCenterPositionAndOpen(consultantEditClientWindow);
            }
            if (SelectedEmployee.Id == 2)
            {
                EditClientWindow editClientWindow = new EditClientWindow();

                SetCenterPositionAndOpen(editClientWindow);
            }
        }

        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

        #endregion
    }
}
