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
                building.Street = db.Streets.FirstOrDefault(x => x.Name == building.StreetName);
                building.District = db.Districts.FirstOrDefault(x => x.Name == building.DistrictName);

                db.Buildings.Add(building);
                db.SaveChanges();
            }
        }

        public static void WritePremises(Premises premises, string address)
        {
            using (var db = new PremisesApplicationContext())
            {
                string[] s = address.Split(", ");
                string district = s[0];
                string street = s[1];
                int buildingNumber = Int32.Parse(s[2].Substring(2));
                premises.Decoration = db.Decorations.FirstOrDefault(x => x.Name == premises.Decoration.Name);
                // находим здание по адресу
                premises.Building = db.Buildings.FirstOrDefault(x => x.Street.Name == street && x.District.Name == district && x.BuildingNumber == buildingNumber);
                // Занято мест
                int occupiedPlaces = GetOccupiedRentPlacesOfBuilding(premises.Building);
                //если помещений под аренду в здании меньше чем занятых. + 1 т.к. база еще не сохранилась
                if (premises.Building.RentPlaces < occupiedPlaces + 1)
                {
                    throw new InvalidOperationException();
                }
                db.Premises.Add(premises);
                db.SaveChanges();
            }
        }
        public static void EditBuilding(Building editedBuilding)
        {
            using (var db = new PremisesApplicationContext())
            {
                Building building = db.Buildings.FirstOrDefault(x => x.ID == editedBuilding.ID);
                building.Street = db.Streets.FirstOrDefault(x => x.Name == editedBuilding.StreetName);
                building.District = db.Districts.FirstOrDefault(x => x.Name == editedBuilding.DistrictName);

                building.FloorCount = editedBuilding.FloorCount;
                building.RentPlaces = editedBuilding.RentPlaces;
                building.Phone = editedBuilding.Phone;
                building.BuildingNumber = editedBuilding.BuildingNumber;
                db.SaveChanges();
            }
        }

        public static void EditPremises(Premises premises, string address)
        {
            using (var db = new PremisesApplicationContext())
            {
                string[] s = address.Split(", ");
                string district = s[0];
                string street = s[1];
                int buildingNumber = Int32.Parse(s[2].Substring(2));
                Premises premisesForEdit = db.Premises.FirstOrDefault(x => x.ID == premises.ID);
                premisesForEdit.Decoration = db.Decorations.FirstOrDefault(x => x.Name == premises.Decoration.Name);
                // находим здание по адресу
                premisesForEdit.Building = db.Buildings.FirstOrDefault(x => x.Street.Name == street && x.District.Name == district && x.BuildingNumber == buildingNumber);
                premisesForEdit.ApartmentNumber = premises.ApartmentNumber;
                premisesForEdit.PremisesNumber = premises.PremisesNumber;
                premisesForEdit.Area = premises.Area;
                premisesForEdit.FloorNumber = premises.FloorNumber;
                premisesForEdit.Housing = premises.Housing;
                premisesForEdit.IsPhone = premises.IsPhone;
                db.SaveChanges();
            }
        }

        public static void DeleteBuilding(Building building)
        {
            using (var db = new PremisesApplicationContext())
            {
                // Удаляем все помещения, связанные со зданием
                List<Premises> buildingPremisesList = db.Premises.Where(x => x.BuildingID == building.ID).ToList();
                db.Premises.RemoveRange(buildingPremisesList);
                db.Buildings.Remove(building);
                db.SaveChanges();
            }
        }

        public static void DeletePremises(Premises premises)
        {
            using (var db = new PremisesApplicationContext())
            {
                db.Premises.Remove(premises);
                db.SaveChanges();
            }
        }
    }
}
