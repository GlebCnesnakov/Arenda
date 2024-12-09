using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Premises
{
    internal class Data
    {

        public static int GetOccupiedRentPlacesOfBuilding(Building building)
        {
            using (var db = new PremisesApplicationContext())
            {
                try
                {
                    return db.Premises.Where(x => x.BuildingID == building.ID).Count();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не вытащил количество помещений для здания");
                    return 0;
                }
            }
        } 

        public static List<T> GetLists<T>() where T : class
        {
            using (var db = new PremisesApplicationContext())
            {
                return db.Set<T>().ToList();
            }
        }

        public static List<T> ReadData<T>() where T : class
        {
            using (var db = new PremisesApplicationContext())
            {
                IQueryable<T> query = db.Set<T>();

                if (typeof(T) == typeof(Building))
                {
                    query = db.Buildings.Include(x => x.Street).Include(x => x.District) as IQueryable<T>;
                }
                else if (typeof(T) == typeof(Premises))
                {
                    query = db.Premises.Include(x => x.Decoration).Include(x => x.Building).ThenInclude(x => x.Street).Include(x => x.Building).ThenInclude(x => x.District) as IQueryable<T>;
                }
                return query.ToList();
            }
        }

        public static List<T> SearchData<T>(string searched) where T : class
        {
            using (var db = new PremisesApplicationContext())
            {
                IQueryable<T> query = db.Set<T>();

                if (typeof(T) == typeof(Building))
                {
                    query = db.Buildings.Include(b => b.Street).Include(x => x.District).Where(x => x.Street.Name.Contains(searched)) as IQueryable<T>;
                }
                else if (typeof(T) == typeof(Premises))
                {
                    query = query = db.Premises.Include(x => x.Decoration).Include(x => x.Building).ThenInclude(x => x.Street).Include(x => x.Building).ThenInclude(x => x.District).Where(x => x.Building.Street.Name.Contains(searched)) as IQueryable<T>;
                }
                return query.ToList();
            }
        }

        public static void WriteBuilding(Building building)
        {
            using (var db = new PremisesApplicationContext())
            {
                db.Streets.Attach(building.Street);
                db.Districts.Attach(building.District);
                db.Buildings.Add(building);
                db.SaveChanges();
            }
        }

        public static void WritePremises(Premises premises)
        {
            using (var db = new PremisesApplicationContext())
            {
                db.Decorations.Attach(premises.Decoration);
                db.Buildings.Attach(premises.Building);
                // Занято мест
                int occupiedPlaces = GetOccupiedRentPlacesOfBuilding(premises.Building);
                //если помещений под аренду в здании меньше чем занятых. + 1 т.к. база еще не сохранилась
                if (premises.Building.RentPlaces < occupiedPlaces + 1) throw new InvalidOperationException();
                db.Premises.Add(premises);
                db.SaveChanges();
            }
        }
        public static void EditData<T>(T forEdit) where T : class
        {
            using (var db = new PremisesApplicationContext())
            {
                db.Set<T>().Update(forEdit);
                db.SaveChanges();
            }
        }

        public static void DeleteData<T>(T toDelete) where T : class, InterfaceID
        {
            using (var db = new PremisesApplicationContext())
            {
                if (typeof(T) == typeof(Premises)) db.Set<T>().Remove(toDelete);
                else if (typeof(T) == typeof(Building))
                {
                    List<Premises> buildingPremisesList = db.Premises.Where(x => x.BuildingID == toDelete.ID).ToList();
                    db.Premises.RemoveRange(buildingPremisesList);
                    db.Set<T>().Remove(toDelete);
                }
                db.SaveChanges();
            }
        }
    }
}
