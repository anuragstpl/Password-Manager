using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.DataHelper
{
    public class AccountHelper
    {
        DataLayer.UnitOfWork.UnitOfWork uow = null;
        public bool AddAccount(AccountData actData)
        {
            bool isAdded = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    Account acct = new Account();
                    acct.AccountID = actData.AccountID;
                    acct.Description = actData.Description;
                    acct.Name = actData.Name;
                    acct.AddedOn = DateTime.Now.ToString();
                    acct.AddedBy = actData.AddedBy;
                    uow.AccountRepository.Insert(acct);
                    uow.Save();
                    isAdded = true;
                }
                catch
                {
                    isAdded = false;
                }
            }

            return isAdded;
        }

        public bool UpdateAccount(AccountData actData)
        {
            bool isUpdated = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    Account acct = uow.AccountRepository.GetById(actData.AccountID);
                    acct.AccountID = actData.AccountID;
                    acct.Description = actData.Description;
                    acct.Name = actData.Name;
                    uow.AccountRepository.Update(acct);
                    uow.Save();
                    isUpdated = true;
                }
                catch
                {
                    isUpdated = false;
                }
            }

            return isUpdated;
        }

        public bool DeleteAccount(int AccountID)
        {
            bool isDeleted = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    Account acct = uow.AccountRepository.GetById(AccountID);

                    uow.AccountRepository.Delete(acct);
                    uow.Save();
                    isDeleted = true;
                }
                catch
                {
                    isDeleted = false;
                }
            }

            return isDeleted;
        }

        public AccountData GetAccountsByID(int accountID)
        {
            AccountData accountData = new AccountData();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                accountData = uow.AccountRepository.Get().Where(x => x.AccountID == accountID).Select(p => new AccountData
                {
                    AccountID = p.AccountID,
                    AddedBy = p.AddedBy,
                    AddedOn = p.AddedOn,
                    Description = p.Description,
                    Name = p.Name,
                    userid = p.User.Id
                }).FirstOrDefault();
            }
            return accountData;
        }

        public List<AccountData> GetAllAccountsByUserID(int userid)
        {
            List<AccountData> lstAccountData = new List<AccountData>();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                lstAccountData = uow.AccountRepository.Get().Where(x => x.AddedBy == userid).Select(p => new AccountData
                {
                    AccountID = p.AccountID,
                    AddedBy = p.AddedBy,
                    AddedOn = p.AddedOn,
                    Description = p.Description,
                    Name = p.Name,
                    userid = p.User.Id
                }).ToList();
                //var AccountList = uow.AccountRepository.Get().Where(x => x.AddedBy == userid)
                //    .Join(uow.UserRepository.Get(), t => t.AddedBy, a => a.Id, (t, a) => new { }).ToList();
            }
            return lstAccountData;
        }

    }
}
