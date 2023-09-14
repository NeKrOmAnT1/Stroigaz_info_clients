using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Stroigaz_info_clients.DB;
using Stroigaz_info_clients.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Stroigaz_info_clients.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Information> Info { get; set; }
        public Information selectedItem { get; set; }
        public ICommand DeleteItemCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Methods.DeleteInfo(selectedItem);
                    Info.Remove(selectedItem);
                });
            }
        }
        public MainWindowViewModel()
        {
            using (var db = new Offline_DataBase())
            {
                db.Database.Migrate();
            }
            Info = new ObservableCollection<Information>
            {
                new Information
                {
                    Сlientele = "Компания Альфа Газ",
                    Email = "info@alphagaz.com",
                    Phone = "8 123-456-7890",
                    Number_Brigade = "ГСБ-02",
                    Construction_Plan = "План A"
                },
                new Information
                {
                    Сlientele = "Компания Бета Газ",
                    Email = "info@betagaz.com",
                    Phone = "8 987-654-3210",
                    Number_Brigade = "ГСБ-01",
                    Construction_Plan = "План B"
                },
                new Information
                {
                    Сlientele = "Компания Гамма Газ",
                    Email = "info@gammagaz.com",
                    Phone = "8 321-767-1453",
                    Number_Brigade = "ГСБ-04",
                    Construction_Plan = "План C"

                },  
                new Information
                {
                    Сlientele = "Компания Омега Газ",
                    Email = "info@omegagaz.com",
                    Phone = "8 444-213-3213",
                    Number_Brigade = "ГСБ-03",
                    Construction_Plan = "План A"

                }, 
                new Information
                {
                    Сlientele = "Компания Дельта Газ",
                    Email = "info@deltagaz.com",
                    Phone = "8 333-535-6215",
                    Number_Brigade = "ГСБ-02",
                    Construction_Plan = "План D"

                },

            };
        }
    }    
}
