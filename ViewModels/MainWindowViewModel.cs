using MyApplicationVer_2.Commands.BaseCommand;
using MyApplicationVer_2.Models;
using MyApplicationVer_2.ViewModels.BaseViewModels;
using MyApplicationVer_2.Views;
using System.Collections.ObjectModel;
using System.Windows;

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

        /// <summary>
        /// Свойство Title
        /// </summary>
        public string Title { get; } = "Клиентский справочник";

        /// <summary>
        /// Свойсвто Employees
        /// </summary>
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

        /// <summary>
        /// Свойство Clients
        /// </summary>
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

        /// <summary>
        /// Свойство SelectedEmployee
        /// </summary>
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

        /// <summary>
        /// Свойство SelectedClient
        /// </summary>
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

        /// <summary>
        /// Открывает окно для добавления нового сотрудника
        /// </summary>
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

        /// <summary>
        /// Открывает окно для редактирования сотрудника
        /// </summary>
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

        /// <summary>
        /// Удаляет сотрудника
        /// </summary>
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

        /// <summary>
        /// Метод открытия окна добавления сотрудника
        /// </summary>
        private void OpenAddNewClientWindowMethod()
        {
            AddNewClientWindow addNewClientWindow = new AddNewClientWindow();

            SetCenterPositionAndOpen(addNewClientWindow);
        }

        /// <summary>
        /// Метод открытия окна редактирования сотрудника
        /// </summary>
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

        /// <summary>
        /// Метод позиционирования окна
        /// </summary>
        /// <param name="window"></param>
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

        #endregion
    }
}
