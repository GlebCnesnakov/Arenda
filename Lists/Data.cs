using Banks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lists
{
    internal class Data
    {
        public static List<T> ReadData<T>() where T : class
        {
            using (var db = new ListsApplicationContext())
            {
                return db.Set<T>().ToList();
            }
        }
        public static void WriteData<T, TName>(TName name) where T : class, INameAble<TName>, new()
        {
            using (var db = new ListsApplicationContext())
            {
                try
                {
                    T entity = new T() { Name = name };
                    db.Set<T>().Add(entity);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось добавить новую запись");
                }
            }
        }
        public static void EditData<T, TName>(TName name, TName newName) where T: class, INameAble<TName>
        {
            using (var db = new ListsApplicationContext())
            {
                var ed = db.Set<T>().FirstOrDefault(x => x.Name.Equals(name));
                if (ed != null)
                {
                    try
                    {
                        ed.Name = newName;
                        db.SaveChanges();
                    }
                    catch(SqliteException ex)
                    {
                        MessageBox.Show("Не удалось обновить запись");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Не удалось обновить значение");
                }
            }
        }
        public static void DeleteData<T, TName>(TName name) where T : class, INameAble<TName>
        {
            using (var db = new ListsApplicationContext())
            {
                try
                {
                    var dd = db.Set<T>().FirstOrDefault(x => x.Name.Equals(name));
                    if (dd != null)
                    {
                        db.Set<T>().Remove(dd);
                        db.SaveChanges();
                        MessageBox.Show("Элемент удалён");

                    }
                }
                catch(SqliteException ex)
                {
                    MessageBox.Show("Данные невозможно удалить");
                }
                catch(DbUpdateException ex)
                {
                    MessageBox.Show("Данные невозможно удалить");
                }
            }
        }
        public static List<T> SearchData<T, TName>(TName toSearch) where T : class, INameAble<TName>
        {
            using(var db = new ListsApplicationContext())
            {
                return db.Set<T>().Where(x => x.Name.ToString().Contains(toSearch.ToString())).ToList();
            }
        }
    }
}
