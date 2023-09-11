using MyApplicationVer_2.ViewModels.BaseViewModels;

namespace MyApplicationVer_2.Models
{
    class Client : BaseViewModel
    {
        #region Variables

        private int _id;
        private string _surname;
        private string _name;
        private string _patronymic;
        private string _phoneNumber;
        private string _passportSeries;
        private string _passportNumber;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство ID
        /// </summary>
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        /// <summary>
        /// Свойство Surname
        /// </summary>
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        /// <summary>
        /// Свойство Name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        /// <summary>
        /// Свойство Patronymic
        /// </summary>
        public string Patronymic
        {
            get { return _patronymic; }
            set
            {
                _patronymic = value;
                OnPropertyChanged(nameof(Patronymic));
            }
        }

        /// <summary>
        /// Свойство PhoneNumber
        /// </summary>
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        /// <summary>
        /// Свойство PassportSeries
        /// </summary>
        public string PassportSeries
        {
            get { return _passportSeries; }
            set
            {
                _passportSeries = value;
                OnPropertyChanged(nameof(PassportSeries));
            }
        }

        /// <summary>
        /// Свойство PassportNumber
        /// </summary>
        public string PassportNumber
        {
            get { return _passportNumber; }
            set
            {
                _passportNumber = value;
                OnPropertyChanged(nameof(PassportNumber)); 
            }
        }

        #endregion

        #region Constructor

        public Client(int id, string surname, string name, string patronymic, string phoneNumber, string passportSeries, string passportNumber)
        {
            this.Id = id;
            this.Surname = surname;
            this.Name = name;
            this.Patronymic = patronymic;
            this.PhoneNumber = phoneNumber;
            this.PassportSeries = passportSeries;
            this.PassportNumber = passportNumber;
        }

        #endregion
    }
}
