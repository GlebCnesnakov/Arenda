using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    internal class Data
    {
        public static List<T> GetLists<T>() where T : class
        {
            using (var db = new ContractsApplicationContext())
            {
                return db.Set<T>().ToList();
            }
        }
        public static List<Premises> GetPremises()
        {
            using (var db = new ContractsApplicationContext())
            {
                return db.Premises.Include(x => x.Building).ThenInclude(x => x.Street).Include(x => x.Building).ThenInclude(x => x.District).Where(x => !db.ContractPremises.Any(pr => pr.PremisesID == x.ID)).ToList();
            }
        }
        public static List<Contract> ReadContracts()
        {
            using (var db = new ContractsApplicationContext())
            {
                return db.Contracts.Include(x => x.Rentor).Include(x => x.PaymentFrequency).ToList();
            }
        }

        public static List<Contract> SearchContract(string searched)
        {
            using (var db = new ContractsApplicationContext())
            {
                return db.Contracts.Where(x => x.ContractNumber.ToString().Contains(searched)).Include(x => x.Rentor).ToList();
            }
        }

        public static List<ContractPremises> ReadPremisesOfContract(Contract contract)
        {
            using (var db = new ContractsApplicationContext())
            {
                return db.ContractPremises.Where(x => x.ContractID == contract.ID).Include(x => x.RentPurpose).Include(x => x.Premises).ThenInclude(x => x.Building).ThenInclude(x => x.Street).Include(x => x.Premises).ThenInclude(x => x.Building).ThenInclude(x => x.District).ToList();
            }
        }

        public static void WriteContract(Contract contract)
        {
            using (var db = new ContractsApplicationContext())
            {
                db.Attach(contract.PaymentFrequency);
                db.Attach(contract.Rentor);
                db.Contracts.Add(contract);
                db.SaveChanges();
            }
        }

        public static void WritePremisesForContract(ContractPremises contractPremises)
        {
            using (var db = new ContractsApplicationContext())
            {
                contractPremises.Contract = db.Contracts.FirstOrDefault(x => x.ContractNumber == contractPremises.Contract.ContractNumber);
                contractPremises.RentPurpose = db.RentPurposes.FirstOrDefault(x => x.ID == contractPremises.RentPurpose.ID);
                contractPremises.Premises = db.Premises.FirstOrDefault(x => x.ID == contractPremises.Premises.ID);
                db.ContractPremises.Add(contractPremises);
                db.SaveChanges();
            }
        }

        public static void DeletePremisesFromContract(ContractPremises contractPremises)
        {
            using (var db = new ContractsApplicationContext())
            {
                db.ContractPremises.Remove(contractPremises);
                db.SaveChanges();
            }
        }

        public static void DeleteContract(Contract contract)
        {
            using (var db = new ContractsApplicationContext())
            {
                //удалить все contrprem
                List<ContractPremises> cp = db.ContractPremises.Where(x => x.Contract.ID == contract.ID).ToList();
                db.ContractPremises.RemoveRange(cp);
                db.Contracts.Remove(contract);
                db.SaveChanges();
            }
        }

        public static void EditPremisesOfContract(ContractPremises contractPremises)
        {
            using (var db = new ContractsApplicationContext())
            {
                db.ContractPremises.Update(contractPremises);
                db.SaveChanges();
            }
        }

        public static void EditContract(Contract contract)
        {
            using (var db = new ContractsApplicationContext())
            {
                db.Contracts.Update(contract);
                db.SaveChanges();
            }
        }
    }
}
