using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documents
{
    internal class Data
    {
        public static List<Rentor> GetRentors ()
        {
            using (var db = new DocumentsApplicationContext()) return db.Rentors
                    .Include(x => x.Individual)
                    .Include(x => x.Legal)
                    .ThenInclude(x => x.Street)
                    .Include(x => x.Legal)
                    .ThenInclude(x => x.Bank)
                    .Include(x => x.Legal)
                    .ThenInclude(x => x.District)
                    .ToList();
        }
        public static List<Contract> GetContracts(Rentor rentor)
        {
            using (var db = new DocumentsApplicationContext()) return db.Contracts
                    .Include(x => x.PaymentFrequency)
                    .Include(x => x.Rentor)
                    .ThenInclude(x => x.Individual)
                    .Include(x => x.Rentor)
                    .ThenInclude(x => x.Legal)
                    .ThenInclude(x => x.Street)
                    .Include(x => x.Rentor)
                    .ThenInclude(x => x.Legal)
                    .ThenInclude(x => x.Bank)
                    .Include(x => x.Rentor)
                    .ThenInclude(x => x.Legal)
                    .ThenInclude(x => x.District)
                    .Where(x => x.Rentor.ID == rentor.ID)
                    .ToList();
        }
        public static List<ContractPremises> GetContractPremises(Contract contract)
        {
            using (var db = new DocumentsApplicationContext())
            {
                return db.ContractPremises
                    .Include(x => x.RentPurpose)
                    .Include(x => x.Premises)
                    .ThenInclude(x => x.Decoration)
                    .Include(x => x.Premises)
                    .ThenInclude(x => x.Building)
                    .ThenInclude(x => x.District)
                    .Include(x => x.Premises)
                    .ThenInclude(x => x.Building)
                    .ThenInclude(x => x.Street)
                    .Where(x => x.Contract.ID == contract.ID)
                    .ToList();
            }
        }
        public static List<District> GetDistricts()
        {
            using (var db = new DocumentsApplicationContext()) return db.Districts.ToList();
        }
        public static List<Premises> GetPremises(District district)
        {
            using (var db = new DocumentsApplicationContext())
            {
                return db.Premises
                    .Join(db.Buildings, premises => premises.Building.ID, building => building.ID,
                    (premises, building) => new
                    {
                        Premises = premises,
                        Building = building
                    })
                    .Where(x => x.Building.District.Name == district.Name)
                    .Select(x => x.Premises)
                    .Include(x => x.Decoration)
                    .Include(x => x.Building)
                    .ThenInclude(x => x.District)
                    .Include(x => x.Building)
                    .ThenInclude(x => x.Street)
                    .ToList();
            }
        }
    }
}
