using Stroigaz_info_clients.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace Stroigaz_info_clients.Models
{
    class Methods
    {
        #region Методы для работы с данными Заказчика
        private static Offline_DataBase dbContext = new Offline_DataBase();
        // Метод для удаления
        public static bool DeleteInfo(Information item)
        {
            try
            {
                var existingItem = dbContext.Information_DB.Find(item.Id);
                if (existingItem != null)
                {
                    dbContext.Information_DB.Remove(existingItem);
                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    MessageBox.Show("Запись не найдена.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении записи: " + ex.Message);
                return false;
            }
        }
        // Метод для добавления новых данных о заказчике
        public static bool AddInfo(Information item)
        {
            try
            {
                dbContext.Information_DB.Add(item);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении записи: " + ex.Message);
                return false;
            }
        }

        // Метод для редактирования
        public static bool EditInfo(Information item)
        {
            try
            {
                var editItem = dbContext.Information_DB.Find(item.Id);
                if (editItem != null)
                {
                    editItem.Number_Brigade = item.Number_Brigade;
                    editItem.Construction_Plan = item.Construction_Plan;
                    editItem.Сlientele = item.Сlientele;
                    editItem.Email = item.Email;
                    editItem.Phone = item.Phone;
                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    MessageBox.Show("Запись не найдена.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при редактировании записи: " + ex.Message);
                return false;
            }
        }
        #endregion
        #region Методы для Автосохранения
        // Метод для автосохранения
        public static void AutoSave(object sender, ElapsedEventArgs e)
        {
            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при автосохранение: " + ex.Message);
            }
        }

        // Таймер для автосохранения каждые 5 минут
        public static void TimerAutoSave()
        {
            var timer = new Timer();
            timer.Elapsed += AutoSave;
            timer.Interval = 5 * 60 * 1000; // 5 минут
            timer.Start();
        }
        #endregion
    }
}
