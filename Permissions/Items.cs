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
                    var parrentIDs = db.MainMenuItems.Select(x => x.ParrentID).ToHashSet();
                    return db.MainMenuItems.Where(x => x.ParrentID != 0 || !parrentIDs.Contains(x.ID)).Select(x => x.Name).ToArray();
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
