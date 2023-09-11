using MyApplicationVer_2.ViewModels.BaseViewModels;

namespace MyApplicationVer_2.Models
{
    class Employee : BaseViewModel
    {
        private int _id;
        private string _name;

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
        /// Конструктор
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Employee(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
