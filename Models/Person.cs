using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDotNet.Models
{
    public class Person : INotifyPropertyChanged
    {
        int _id;
        string _firstName;
        string _lastName;
        DateTime _birthday;
        public int Id 
        {
            get
            { 
                return _id;
            } 
            set 
            { 
                _id = value;
                OnPropertyChanged("Id");
            } 
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {
                _birthday = value;
                OnPropertyChanged("Birthday");
            }
        }

        #region INotifyPropertyChange

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
    /*public class Person : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string lastName;
        public string LastName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged("LastName");
            }
        }
        public DateTime birthday = new DateTime(2005, 1, 1);
        public DateTime Birthday
        {
            get => birthday;
            set
            {
                birthday = value;
                OnPropertyChanged("Birthday");
            }
        }

        
    }*/

}
