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
        //public static void WriteData<T>(string name) where T : class
        //{
        //    using (var db = new ListsApplicationContext())
        //    {
        //        try
        //        {
        //            var entity = Activator.CreateInstance<T>();
        //            var property = typeof(T).GetProperty("Name");
        //            property.SetValue(entity, name);
        //            db.Set<T>().Add(entity);
        //            db.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Не удалось добавить новую запись");
        //        }
        //    }
        //}
        public static void WriteData<T>(string name) where T : class, INameAble, new()
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
        public static void EditData<T>(string name, string newName) where T: class, INameAble
        {
            using (var db = new ListsApplicationContext())
            {
                var ed = db.Set<T>().FirstOrDefault(x => x.Name == name);
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
        public static void DeleteData<T>(string name) where T : class, INameAble
        {
            using (var db = new ListsApplicationContext())
            {
                var dd = db.Set<T>().FirstOrDefault(x => x.Name == name);
                if (dd != null)
                {
                    try
                    {
                        db.Set<T>().Remove(dd);
                        db.SaveChanges();
                        MessageBox.Show("Элемент удалён");
                    }
                    catch (SqliteException ex) 
                    {
                        MessageBox.Show("Элемент невозможно удалить");
                    }
                }
            }
        }
        public static List<T> SearchData<T>(string toSearch) where T : class, INameAble
        {
            using(var db = new ListsApplicationContext())
            {
                return db.Set<T>().Where(x => x.Name.ToLower().Contains(toSearch)).ToList();
            }
        }
    }
}
