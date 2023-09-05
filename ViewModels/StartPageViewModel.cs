using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppDotNet.Models;

namespace WpfAppDotNet.ViewModels
{
    public class StartPageViewModel : INotifyPropertyChanged
    {
        #region Constructors
        public StartPageViewModel() 
        {
            PersonList = GetPersonList();
            CreatedPerson = new Person();
        }
        #endregion

        #region Fields
        private ObservableCollection<Person> _personList;
        private Person _selectedPerson;
        private Person _createdPerson;
        #endregion

        #region Properties

        public ObservableCollection<Person> PersonList
        {
            get { return _personList; }
            set 
            { 
                _personList = value;
                OnPropertyChanged("PersonList");
            }
        }
        public Person SelectedPerson { 
            get { return _selectedPerson; }
            set 
            {
                _selectedPerson = value;
                OnPropertyChanged("SelectedPerson");
            }
        }
        public Person CreatedPerson  // Создание по хорошему это должно быть в другом UserControl или View
        {
            get { return _createdPerson; }
            set
            {
                _createdPerson = value;
                OnPropertyChanged("CreatedPerson");
            }
        }
        public ObservableCollection<Person> GetPersonList()
        {
            try
            {
                ConnectDb.db.Database.EnsureCreated(); // А если БД уже существует?
                ConnectDb.db.Persons.Load(); // А если БД не ответит (например не успела создастся)?
                return new ObservableCollection<Person>(ConnectDb.db.Persons);
            }
            catch
            {
                System.Windows.MessageBox.Show("Не удалось подгрузить список Person's с БД");
                return new ObservableCollection<Person>();
            }            
        }
        #endregion
        #region Commands
        private Command _addNewPersonCommand;
        public Command AddCommand
        {
            get
            {
                return _addNewPersonCommand ??
                  (_addNewPersonCommand = new Command(obj =>
                  {
                      AddNewPerson(CreatedPerson);
                  }));
            }
        }
        #endregion
        #region Methods
        public void AddNewPerson(Person newPerson)
        {
            try
            {
                ConnectDb.db.Persons.Add(CreatedPerson);
                ConnectDb.db.SaveChanges();
                PersonList.Add(newPerson);
                OnPropertyChanged("PersonList");
            }
            catch
            {
                System.Windows.MessageBox.Show("Не удалось сохранить нового Person");
            }
            
        }
        #endregion

        #region INotifyPropertyChange

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
