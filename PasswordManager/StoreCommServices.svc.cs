using DataLayer;
using DataLayer.UnitOfWork;
using EntityLayer.DTO;
using EntityLayer.Request;
using EntityLayer.Response;
using StoreCommunication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Transactions;

namespace StoreCommunication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StoreCommServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StoreCommServices.svc or StoreCommServices.svc.cs at the Solution Explorer and start debugging.
    public class StoreCommServices : IStoreCommServices
    {

        UnitOfWork uow = null;

        public AddPharmacyResponse AddPharmacy(AddPharmacyRequest pharmacy)
        {
            AddPharmacyResponse addPharmacyResponse = new AddPharmacyResponse();
            addPharmacyResponse.IsSuccess = false;
            addPharmacyResponse.Message = "Pharmacy Registration not successfull.";

            if (new Helper().IsPharmacyNameExist(pharmacy.PharmacyData.Name))
            {
                addPharmacyResponse.Message = "Pharmacy Name already exists";
                return addPharmacyResponse;
            }

            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                try
                {
                    if (pharmacy != null)
                    {
                        using (uow = new UnitOfWork())
                        {
                            Pharmacy pharmacyDal = new Pharmacy();
                            pharmacyDal.Name = pharmacy.PharmacyData.Name;
                            pharmacyDal.Address = pharmacy.PharmacyData.Address;
                            pharmacyDal.Description = pharmacy.PharmacyData.Description;
                            uow.PharmacyRepository.Insert(pharmacyDal);
                            uow.Save();

                            addPharmacyResponse.Message = "Pharmacy added successfully.";
                            addPharmacyResponse.PharmacyID = pharmacyDal.PharmacyID;
                            addPharmacyResponse.IsLoggedIn = true;
                            addPharmacyResponse.IsSuccess = true;

                        }
                    }
                }
                catch (Exception)
                {
                    transactionScope.Dispose();
                    addPharmacyResponse.Message = "An error occurred while registration.";
                }
            }

            return addPharmacyResponse;
        }

        public GetPharmacyResponse GetPharmacies(string searchTerm)
        {
            GetPharmacyResponse getPharmacyResponse = new GetPharmacyResponse();
            getPharmacyResponse.IsSuccess = false;
            getPharmacyResponse.Message = "Get Pharmacy not successfull.";

            using (uow = new UnitOfWork())
            {
                try
                {
                    if (String.IsNullOrEmpty(searchTerm) || searchTerm.Equals("*"))
                    {
                        List<PharmacyDTO> pharmacyList = uow.PharmacyRepository.Get().Select(ps => new PharmacyDTO
                        {
                            Name = ps.Name,
                            Address = ps.Address,
                            Description = ps.Description,
                            PharmacyID = ps.PharmacyID
                        }).ToList();

                        getPharmacyResponse.listPharmacies = pharmacyList;
                        getPharmacyResponse.IsSuccess = true;
                        getPharmacyResponse.Message = "Pharmacy list get successfully";
                    }
                }
                catch (Exception)
                {
                    getPharmacyResponse.IsSuccess = false;
                    getPharmacyResponse.Message = "Some error occured while getting pharmacies.";
                }
            }

            return getPharmacyResponse;
        }

    }
}
