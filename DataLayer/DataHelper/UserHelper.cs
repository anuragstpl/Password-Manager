using DataLayer.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.DataHelper
{
    public class UserHelper
    {
        DataLayer.UnitOfWork.UnitOfWork uow = null;

        public bool RegisterUser(EntityLayer.User user)
        {
            bool isRegsitered = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    User userdb = new User();
                    userdb.Address = user.Address;
                    userdb.Email = user.Email;
                    userdb.FirstName = user.FirstName;
                    userdb.LastName = user.LastName;
                    userdb.Phone = user.Phone;
                    userdb.Password = EncryptionHelper.Encrypt(user.Password);
                    userdb.Username = user.Username;
                    uow.UserRepository.Insert(userdb);
                    uow.Save();
                    isRegsitered = true;
                }
                catch
                {
                    isRegsitered = false;
                }
            }

            return isRegsitered;
        }

        public string UpdatePassword(EntityLayer.User user)
        {
            string pwdMessage = "";

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    User userdb = uow.UserRepository.Get().Where(x => x.Id == user.UserID).FirstOrDefault();

                    if (userdb.Password == EncryptionHelper.Encrypt(user.oldPassword))
                    {
                        userdb.Password = EncryptionHelper.Encrypt(user.Password);
                        uow.UserRepository.Update(userdb);
                        uow.Save();
                        pwdMessage = "Password updated successfully.";
                    }
                    else
                    {
                        pwdMessage = "This password doesn't belongs to this profile.";
                    }
                }
                catch
                {
                    pwdMessage = "Some error occured.";
                }
            }

            return pwdMessage;
        }

        public EntityLayer.User LoginUser(string usr, string pwd)
        {
            EntityLayer.User usrdt = new EntityLayer.User();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    User usd = uow.UserRepository.Get().Where(x => x.Username == usr && x.Password == EncryptionHelper.Encrypt(pwd)).FirstOrDefault();
                    usrdt.Email = usd.Email;
                    usrdt.FirstName = usd.FirstName;
                    usrdt.LastName = usd.LastName;
                    usrdt.UserID = usd.Id;
                    usrdt.Username = usd.Username;

                }
                catch
                {
                    usrdt = null;
                }
            }
            return usrdt;
        }

        public EntityLayer.User GetUserByUsername(string usrnm)
        {
            EntityLayer.User usrdt = new EntityLayer.User();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    User usd = uow.UserRepository.Get().Where(x => x.Username == usrnm).FirstOrDefault();
                    usrdt.Email = usd.Email;
                    usrdt.FirstName = usd.FirstName;
                    usrdt.LastName = usd.LastName;
                    usrdt.UserID = usd.Id;
                    usrdt.Username = usd.Username;

                }
                catch
                {
                    usrdt = null;
                }
            }
            return usrdt;
        }
    }
}
