using Arenda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Permissions
{
    internal class Items
    {
        public static string[] GetItems()
        {
            using (var db = new ApplicationContext())
            {
                try
                {
                    return db.MainMenuItems.Select(x => x.Name).ToArray();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show("Ошибка выполнения запроса: " + ex.Message);
                }
                catch (Exception ex) // Обработка всех остальных ошибок
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
                return null;
            }
        }
    }
}
