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
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
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

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }*/
}
