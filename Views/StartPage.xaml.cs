using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfAppDotNet.Models;
using WpfAppDotNet.ViewModels;

namespace WpfAppDotNet.Views
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            DataContext = new StartPageViewModel();
            InitializeComponent();            
        }
    }
}
