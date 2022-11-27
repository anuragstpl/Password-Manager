using DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreCommunication.Common
{
    public class Helper
    {
        UnitOfWork uow = null;
        string _connectionString = string.Empty;

        public Helper()
        {

        }

        public Helper(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public bool IsPharmacyNameExist(string PharmacyName)
        {
            bool isNameAlreadyExists = false;

            using (uow = new UnitOfWork())
            {

                isNameAlreadyExists = uow.PharmacyRepository.Get().
                                         Any(sp => PharmacyName.Equals(sp.Name, StringComparison.OrdinalIgnoreCase));
            }
            return isNameAlreadyExists;
        }
    }
}