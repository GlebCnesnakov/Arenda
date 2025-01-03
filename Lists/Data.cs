﻿using Banks;
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
                T entity = new T() { Name = name };
                db.Set<T>().Add(entity);
                db.SaveChanges();
            }
        }
        public static void EditData<T, TName>(TName name, TName newName) where T: class, INameAble<TName>
        {
            using (var db = new ListsApplicationContext())
            {
                var ed = db.Set<T>().FirstOrDefault(x => x.Name.Equals(name));
                if (ed != null)
                {
                    ed.Name = newName;
                    db.SaveChanges();
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
                var dd = db.Set<T>().FirstOrDefault(x => x.Name.Equals(name));
                if (dd != null)
                {
                    db.Set<T>().Remove(dd);
                    db.SaveChanges();
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
