using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataLayer.DataHelper
{
    public class PasswordHelper
    {
        UnitOfWork.UnitOfWork uow = null;

        public bool AddCredentials(SocialMediaData socialMediaData)
        {
            bool isCredetialsAdded = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    SocialMedia socialMedia = new SocialMedia();
                    socialMedia.Createdon = socialMediaData.Createdon;
                    socialMedia.Password = socialMediaData.Password;
                    socialMedia.Savedon = DateTime.Now.ToString();
                    socialMedia.Type = socialMediaData.Type;
                    socialMedia.UserID = socialMediaData.UserID;
                    uow.SocialMediaRepository.Insert(socialMedia);
                    uow.Save();
                    isCredetialsAdded = true;
                }
                catch
                {
                    isCredetialsAdded = false;
                }
            }

            return isCredetialsAdded;
        }

        public bool UpdateCredentials(SocialMediaData socialMediaData)
        {
            bool isCredetialsUpdated = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    SocialMedia socialMedia = uow.SocialMediaRepository.GetById(socialMediaData.SocialMediaID);
                    socialMedia.Password = socialMediaData.Password;
                    socialMedia.Savedon = DateTime.Now.ToString();
                    socialMedia.Type = socialMediaData.Type;
                    socialMedia.UserID = socialMediaData.UserID;
                    uow.SocialMediaRepository.Update(socialMedia);
                    uow.Save();
                    isCredetialsUpdated = true;
                }
                catch
                {
                    isCredetialsUpdated = false;
                }
            }

            return isCredetialsUpdated;
        }

        public SocialMediaData GetSavedCredentials(int type, int userid)
        {
            SocialMediaData socialMediaData = new SocialMediaData();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                SocialMedia socialMedia = uow.SocialMediaRepository.Get().Where(x => x.Type == type && x.UserID == userid).FirstOrDefault();
                if (socialMedia != null)
                {
                    socialMediaData.Createdon = socialMedia.Createdon;
                    socialMediaData.Password = socialMedia.Password;
                    socialMediaData.Savedon = socialMedia.Savedon;
                    socialMediaData.SocialMediaID = socialMedia.SocialMediaID;
                    socialMediaData.Type = Convert.ToInt32(socialMedia.Type);
                    socialMediaData.UserID = (int)socialMedia.UserID;
                    socialMediaData.Name = socialMedia.Account.Name;
                }
                return socialMediaData;
            }
        }

        public List<SocialMediaData> GetAgedPassword(int userid)
        {
            List<SocialMediaData> lstSocialMediaData = new List<SocialMediaData>();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                lstSocialMediaData = uow.SQLQueryWithParameters<SocialMediaData>("sp_GetOlderPassword @userid", new SqlParameter("@userid", userid)).ToList();
            }
            return lstSocialMediaData;
        }



    }
}
