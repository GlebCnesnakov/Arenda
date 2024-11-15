using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Arenda
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
            MenuDraw();
        }

        void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (menuItem.Tag is MainMenuItem mi)
            {
                MessageBox.Show(mi.Name);
            }
        }

        void MenuDraw()
        {
            Menu menu = new Menu();
            List<MainMenuItem> menuItemsFromDB;

            // Получение всех записей из базы данных
            using (var db = new ApplicationContext())
            {
                menuItemsFromDB = db.MainMenuItems.ToList();
            }

            // Словарь для хранения пунктов меню по их родительским ID
            Dictionary<int?, List<MainMenuItem>> menuHierarchy = menuItemsFromDB.GroupBy(item => item.ParrentID)
                .ToDictionary(group => group.Key, group => group.OrderBy(x => x.Sequence).ToList());


            // Добавление корневых элементов 
            if (menuHierarchy.ContainsKey(0))
            {
                BuildMenuItems(menuHierarchy[0], menu.Items);
            }

            // Метод для построения дерева меню
            void BuildMenuItems(List<MainMenuItem> items, ItemCollection parentCollection)
            {
                foreach (var item in items)
                {
                    MenuItem menuItem = new MenuItem { Header = item.Name };

                    // Если есть дочерние элементы, добавляем их рекурсивно
                    if (menuHierarchy.ContainsKey(item.ID))
                    {
                        BuildMenuItems(menuHierarchy[item.ID], menuItem.Items);
                    }
                    else
                    {
                        menuItem.Tag = item;
                        menuItem.Click += MenuItem_Click;
                    }

                    parentCollection.Add(menuItem);
                }
            }

            this.Content = menu;
            
        }


    }
}
