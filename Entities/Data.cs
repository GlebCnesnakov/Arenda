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

        public static bool WriteData(Rentor rentor) // передается готовый рентор
        {
            using (var db = new EntitiesApplicationContext())
            {
                try
                {
                    if (rentor.Individual != null)
                    {
                        db.Rentors.Add(rentor);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        Street street = db.Streets.FirstOrDefault(x => x.Name == rentor.Street);
                        Bank bank = db.Banks.FirstOrDefault(x => x.Name == rentor.Bank);
                        District district = db.Districts.FirstOrDefault(x => x.Name == rentor.District);

                        rentor.Legal.Street = street;
                        rentor.Legal.District = district;
                        rentor.Legal.Bank = bank;
                        db.Rentors.Add(rentor);
                        db.SaveChanges();
                        return true;
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось добавить новую запись " + ex.Message);
                    return false;
                }
            }
        }

        public static void DeleteData(Rentor rentor)
        { 
            using(var db = new EntitiesApplicationContext())
            {
                try
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
                    MessageBox.Show("Запись удалена");
                }
                catch(SqliteException ex)
                {
                    MessageBox.Show("Не удалось удалить запись (sqliteexc)" + ex.Message);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Не удалось удалить запись " + ex.Message);
                }
            } 
        }

        public static bool EditData<T>(Rentor editedRentor) where T : class 
        {
            using (var db = new EntitiesApplicationContext())
            {
                if (typeof(T) == typeof(Individual))
                {
                    try
                    {
                        //Rentor r = db.Rentors.FirstOrDefault(x => x.ID == rentorForEdit.ID);
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
                        return true;
                    }
                    catch(Exception ex)
                    {
                        return false;
                    }
                }
                else if (typeof(T) == typeof(Liquid))
                {
                    try
                    {
                        // Получение справочников
                        Bank bank = db.Banks.FirstOrDefault(x => x.Name == editedRentor.Bank);
                        Street street = db.Streets.FirstOrDefault(x => x.Name == editedRentor.Street);
                        District district = db.Districts.FirstOrDefault(x => x.Name == editedRentor.District);

                        Rentor r = db.Rentors.Include(x => x.Legal).ThenInclude(x => x.Street).Include(x => x.Legal).ThenInclude(x => x.District).Include(x => x.Legal).ThenInclude(x => x.Bank).FirstOrDefault(x => x.ID == editedRentor.ID);
                        r.Legal.Bank = bank;
                        r.Legal.Street = street;
                        r.Legal.District = district;
                        r.Name = editedRentor.Name;
                        r.Surname = editedRentor.Surname;
                        r.MiddleName = editedRentor.MiddleName;
                        r.Phone = editedRentor.Phone;
                        r.Legal.INN = editedRentor.INN;
                        r.Legal.BuildingNumber = editedRentor.Legal.BuildingNumber;
                        r.Legal.Housing = editedRentor.Housing;
                        r.Legal.NameLiquid = editedRentor.NameLiquid;

                        db.SaveChanges();
                        return true;
                    }
                    catch(Exception ex)
                    {
                        return false;
                    }
                }
                return false;
            }
        }
    }
}
