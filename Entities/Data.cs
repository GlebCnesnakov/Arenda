using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Entities
{
    /// <summary>
    /// Класс для работы с БД
    /// </summary>
    internal class Data
    {
        public static List<T> GetLists<T>() where T : class
        {
            using(var db = new EntitiesApplicationContext())
            {
                return db.Set<T>().ToList();
            }
        }
        public static List<Rentor> ReadData<T>() where T : class
        {
            using (var db = new EntitiesApplicationContext())
            {
                if (typeof(T) == typeof(Individual))
                {
                    return db.Rentors.Where(x => x.LegalID == null).Include(x => x.Individual).ToList();
                }
                else if (typeof(T) == typeof(Liquid))
                {
                    return db.Rentors.Where(x => x.IndividualID == null).Include(x => x.Legal).ThenInclude(x => x.Street).Include(x => x.Legal).ThenInclude(x => x.Bank).Include(x => x.Legal).ThenInclude(x => x.District).ToList();
                }
                return null;
            }
        }
        public static List<Rentor> SearchData<T>(string searched)
        {
            using(var db = new EntitiesApplicationContext())
            {
                if (typeof(T) == typeof(Individual))
                {
                    return db.Rentors.Where(x => x.Surname.Contains(searched) && x.LegalID == null).ToList();
                }
                else if (typeof(T) == typeof(Liquid))
                {
                    return db.Rentors.Where(x => x.Surname.Contains(searched) && x.IndividualID == null).ToList();
                }
                
                return null;
            }
        }

        public static void WriteData(Rentor rentor) // передается готовый рентор
        {
            using (var db = new EntitiesApplicationContext())
            {
                if (rentor.Individual != null)
                {
                    db.Rentors.Add(rentor);
                    db.SaveChanges();
                }
                else
                {
                    db.Banks.Attach(rentor.Legal.Bank);
                    db.Districts.Attach(rentor.Legal.District);
                    db.Streets.Attach(rentor.Legal.Street);
                    db.Rentors.Add(rentor);
                    db.SaveChanges();
                }
            }
        }

        public static void DeleteData(Rentor rentor)
        { 
            using(var db = new EntitiesApplicationContext())
            {
                db.Rentors.Remove(rentor);
                if (rentor.Individual != null) // каскадное
                {
                    db.Individuals.Remove(rentor.Individual);
                }
                else if (rentor.Legal != null)
                {
                    //дописать
                    db.Liquids.Remove(rentor.Legal);
                }
                db.SaveChanges();
                
            } 
        }

        public static void EditData<T>(Rentor editedRentor) where T : class 
        {
            using (var db = new EntitiesApplicationContext())
            {
                if (typeof(T) == typeof(Individual))
                {
                    Rentor r = db.Rentors.Include(x => x.Individual).FirstOrDefault(x => x.ID == editedRentor.ID);
                    r.Name = editedRentor.Name;
                    r.Surname = editedRentor.Surname;
                    r.MiddleName = editedRentor.MiddleName;
                    r.Phone = editedRentor.Phone;
                    r.Individual.Series = editedRentor.PassportSeries;
                    r.Individual.Number = editedRentor.PassportNumber;
                    r.Individual.Date = editedRentor.DateOfIssue;
                    r.Individual.IssuedBy = editedRentor.IssuedBy;
                    db.SaveChanges();
                }
                else if (typeof(T) == typeof(Liquid))
                {
                    // Получение справочников
                    Rentor r = db.Rentors.Include(x => x.Legal).ThenInclude(x => x.Street).Include(x => x.Legal).ThenInclude(x => x.District).Include(x => x.Legal).ThenInclude(x => x.Bank).FirstOrDefault(x => x.ID == editedRentor.ID);
                    r.Legal.Bank = db.Banks.FirstOrDefault(x => x.Name == editedRentor.Bank);
                    r.Legal.Street = db.Streets.FirstOrDefault(x => x.Name == editedRentor.Street);
                    r.Legal.District = db.Districts.FirstOrDefault(x => x.Name == editedRentor.District);
                    r.Name = editedRentor.Name;
                    r.Surname = editedRentor.Surname;
                    r.MiddleName = editedRentor.MiddleName;
                    r.Phone = editedRentor.Phone;
                    r.Legal.INN = editedRentor.INN;
                    r.Legal.BuildingNumber = editedRentor.Legal.BuildingNumber;
                    r.Legal.Housing = editedRentor.Housing;
                    r.Legal.NameLiquid = editedRentor.NameLiquid;
                }
                db.SaveChanges();
            }
        }
    }
}
