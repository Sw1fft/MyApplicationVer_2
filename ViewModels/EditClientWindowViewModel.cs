using MyApplicationVer_2.Commands.BaseCommand;
using MyApplicationVer_2.Models;
using MyApplicationVer_2.ViewModels.BaseViewModels;
using System.Windows;

namespace MyApplicationVer_2.ViewModels
{
    class EditClientWindowViewModel : BaseViewModel
    {
        #region Variables

        private int id;
        private string surname;
        private string name;
        private string patronymic;
        private string phoneNumber;
        private string passportSeries;
        private string passportNumber;

        private Visibility elementVisibility;

        public static Client _selectedClient;

        private readonly BaseCommand _saveChanges;

        #endregion

        #region Constructor

        public EditClientWindowViewModel()
        {
            SelectedClient(_selectedClient);
        }

        #endregion

        #region Properties

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Patronymic
        {
            get { return patronymic; }
            set
            {
                patronymic = value;
                OnPropertyChanged(nameof(Patronymic));
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        public string PassportSeries
        {
            get { return passportSeries; }
            set
            {
                passportSeries = value;
                OnPropertyChanged(nameof(PassportSeries));
            }
        }

        public string PassportNumber
        {
            get { return passportNumber; }
            set
            {
                passportNumber = value;
                OnPropertyChanged(nameof(PassportNumber));
            }
        }

        #endregion

        #region Commands

        public BaseCommand SaveChanges
        {
            get
            {
                return _saveChanges ?? new BaseCommand(obj =>
                {
                    if (MainWindowViewModel.selectedEmployee.Id == 1)
                    {
                        Consultant consultant = new Consultant();

                        consultant.EditClient(_selectedClient, PhoneNumber);

                        CloseWindow();
                    }
                    if (MainWindowViewModel.selectedEmployee.Id == 2)
                    {
                        Manager manager = new Manager();

                        manager.EditClient(_selectedClient, Surname, Name, Patronymic, PhoneNumber, PassportSeries, PassportNumber);

                        CloseWindow();
                    }
                });
            }
        }

        #endregion

        #region Methods

        private void CloseWindow()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                    break;
                }
            }
        }

        private void SelectedClient(Client client)
        {
            Surname = client.Surname;
            Name = client.Name;
            Patronymic = client.Patronymic;
            PhoneNumber = client.PhoneNumber;
            PassportSeries = client.PassportSeries;
            PassportNumber = client.PassportNumber;
        }

        #endregion
    }
}
