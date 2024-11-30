using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Reflection;
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
                string moduleName = mi.Module.Substring(0, mi.Module.Length - 4);
                string dllPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @$"..\..\..\..\{moduleName}\bin\Debug\net8.0-windows\")) + mi.Module;
                //string dllPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\")) + mi.Module;
                Assembly assembly = Assembly.LoadFrom(dllPath);

                Type windowType = assembly.GetType(mi.Method);
                if (windowType != null)
                {
                    UserControl controller = (UserControl)Activator.CreateInstance(windowType);

                    Grid.SetRow(controller, 1);
                    MainGrid.Children.Add(controller);
                }
                else
                {
                    MessageBox.Show("Не удалось найти тип окна в DLL.");
                }
            }
        }

        void MenuDraw()
        {
            Menu menu = new Menu();
            Dictionary<int?, List<MainMenuItem>> menuHierarchy;

            // Получение всех записей из базы данных
            using (var db = new ApplicationContext())
            {
                //menuItemsFromDB = db.MainMenuItems.ToList();
                menuHierarchy = db.MainMenuItems.GroupBy(item => item.ParrentID)
                    .ToDictionary(group => group.Key, group => group.OrderBy(x => x.Sequence).ToList());
            }


            // Добавление корневых элементов 
            if (menuHierarchy.ContainsKey(0))
            {
                BuildMenuItems(menuHierarchy[0], menu.Items);
            }

            // Метод для построения дерева меню
            void BuildMenuItems(List<MainMenuItem> items, ItemCollection parentCollection)
            {

                void Build(MainMenuItem item, bool IsCheck = true)
                {
                    MenuItem menuItem = new MenuItem { Header = item.Name, IsEnabled = IsCheck };
                    
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

                User user = Application.Current.Properties["CurrentUser"] as User;
                
                List<UserPermissions> userPermissions = user.GetUserPermissions(new UserPermissionsGetter());
                if (user.Login != "admin")
                {
                    foreach (var item in items)
                    {
                        var permissionsDictionary = userPermissions.ToDictionary(p => p.IdMenuItem);
                        permissionsDictionary.TryGetValue(item.ID, out var us);

                       // UserPermissions us = userPermissions.FirstOrDefault(x => x.IdMenuItem == item.ID); // поиск пункта меню
                        if (item.Name == "Сменить пароль" || item.Name == "Разное") // Если это главный элемент, нужно отобразить всегда
                        {
                            if (item.Name != "Права пользователей")
                            {
                                Build(item);
                            }
                        }
                        else
                        {
                            if ((us == null) || (us.CanRead == 0 && us.CanWrite == 0 && us.CanEdit == 0 && us.CanDelete == 0)) // если записей о пункте меню для пользователя нет или пользователю ничего нельзя
                            {
                                Build(item, false);
                            }
                            else
                            {
                                Build(item);
                            }
                        }
                    }
                }
                else
                {
                    foreach (var item in items) Build(item);
                }
            }
            Grid.SetRow(menu, 0);
            MainGrid.Children.Add(menu);  // Добавляем меню в Grid с именем MainGrid
        }
    }
}
