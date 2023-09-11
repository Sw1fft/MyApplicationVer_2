using MyApplicationVer_2.Commands.BaseCommand;
using MyApplicationVer_2.Models;
using MyApplicationVer_2.ViewModels.BaseViewModels;
using System.Windows;

namespace MyApplicationVer_2.ViewModels
{
    class AddNewClientWindowViewModel : BaseViewModel
    {
        #region Variables

        protected readonly BaseCommand _addNewClient;

        private readonly int id = BaseRepository.GetCount() + 1;
        private string surname;
        private string name;
        private string patronymic;
        private string phoneNumber;
        private string passportSeries;
        private string passportNumber;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство Surname
        /// </summary>
        public string Surname
        {
            get { return surname; }
            set
            {
                if (surname != value)
                {
                    surname = value;
                    OnPropertyChanged(nameof(Surname));
                }
            }
        }

        /// <summary>
        /// Свойство Name
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        /// <summary>
        /// Свойство Patronymic
        /// </summary>
        public string Patronymic
        {
            get { return patronymic; }
            set
            {
                if (patronymic != value)
                {
                    patronymic = value;
                    OnPropertyChanged(nameof(Patronymic));
                }
            }
        }

        /// <summary>
        /// Свойство Patronymic
        /// </summary>
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (phoneNumber != value)
                {
                    phoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                }
            }
        }

        /// <summary>
        /// Свойство PassportSeries
        /// </summary>
        public string PassportSeries
        {
            get { return passportSeries; }
            set
            {
                if (passportSeries != value)
                {
                    passportSeries = value;
                    OnPropertyChanged(nameof(PassportSeries));
                }
            }
        }

        /// <summary>
        /// Свойство PassportNumber
        /// </summary>
        public string PassportNumber
        {
            get { return passportNumber; }
            set
            {
                if (passportNumber != value)
                {
                    passportNumber = value;
                    OnPropertyChanged(nameof(PassportNumber));
                }
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Комманда добавления нового клиента
        /// </summary>
        public BaseCommand AddNewClient
        {
            get
            {
                return _addNewClient ?? new BaseCommand(obj =>
                {
                    if (Surname == null || Name == null || Patronymic == null || PhoneNumber == null || PassportSeries == null || PassportNumber == null)
                    {
                        MessageBox.Show("Заполните все поля", caption: "Заполните поля", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        Manager manager = new Manager();

                        Client client = new Client(id, Surname, Name, Patronymic, PhoneNumber, PassportSeries, PassportNumber);

                        manager.AddNewClient(client);

                        CloseWindow();
                    }
                });
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Метод закрытия окна
        /// </summary>
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

        #endregion
    }
}
