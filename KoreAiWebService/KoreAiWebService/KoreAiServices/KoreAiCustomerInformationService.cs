using KoreAiDatabase.KoreAiDatabaseModels;
using KoreAiWebService.KoreAiCustomerInformationRepositoryInterface;
using KoreAiWebService.KoreAiCustomerInformationServiceInterface;
using KoreAiWebService.RequestModel;
using KoreAiWebService.ResponseModel;

namespace KoreAiWebService.KoreAiServices
{
    public class KoreAiCustomerInformationService : IKoreAiCustomerInformationService
    {
        #region Private methods

        private IKoreAiCustomerInformationRepository _koreAiCustomerInformationRepository;

        #endregion Private methods

        #region Public methods

        public KoreAiCustomerInformationService(IKoreAiCustomerInformationRepository koreAiCustomerInformationRepository)
        {
            _koreAiCustomerInformationRepository = koreAiCustomerInformationRepository;
        }

        #region GetAllCustomerInformationRecordsAsync

        public async Task<KoreAiControllerResponse<CustomerInformation>> GetAllCustomerInformationRecordsAsync()
        {
            KoreAiControllerResponse<CustomerInformation> koreAiCustInfResponse = new KoreAiControllerResponse<CustomerInformation>();

            var responseFromDb = await _koreAiCustomerInformationRepository.GetAllCustomerInformationRecordsFromDbAsync();

            if(responseFromDb.Item3)
            {
                koreAiCustInfResponse.ApplicationData = responseFromDb.Item1;
                koreAiCustInfResponse.ResponseCode = ResponseCode.Success;
            }
            else
            {
                koreAiCustInfResponse.ErrorMessage = responseFromDb.Item2;
                koreAiCustInfResponse.ResponseCode = ResponseCode.BadRequest;
            }

            return koreAiCustInfResponse;
        }

        #endregion GetAllCustomerInformationRecordsAsync

        #region GetCustomerInformationRecordByIdAsync

        public async Task<KoreAiControllerResponse<CustomerInformation>> GetCustomerInformationRecordByIdAsync(int customerId)
        {
            KoreAiControllerResponse<CustomerInformation> koreAiCustInfResponse = new KoreAiControllerResponse<CustomerInformation>();

            var responseFromDb = await _koreAiCustomerInformationRepository.GetCustomerInformationRecordByIdFromDbAsync(customerId);

            if (responseFromDb.Item3)
            {
                koreAiCustInfResponse.ApplicationData.Add(responseFromDb.Item1);
                koreAiCustInfResponse.ResponseCode = ResponseCode.Success;
            }
            else
            {
                koreAiCustInfResponse.ErrorMessage = responseFromDb.Item2;
                koreAiCustInfResponse.ResponseCode = ResponseCode.BadRequest;
            }

            return koreAiCustInfResponse;
        }

        #endregion GetCustomerInformationRecordByIdAsync

        #region InsertCustomerInformationRecordAsync 

        public async Task<KoreAiControllerResponse<string>> InsertCustomerInformationRecordAsync(CustomerInformationInsertRequest customerInformationRecord)
        {
            KoreAiControllerResponse<string> insertCustomerInformationRecordResponse = new KoreAiControllerResponse<string>();

            var customerInformationDbRecord = MapCustomerInformationRecord(customerInformationRecord);

            var responseFromDb = await _koreAiCustomerInformationRepository.InsertCustomerInformationRecordInDbAsync(customerInformationDbRecord);

            if (responseFromDb.Item2)
            {
                insertCustomerInformationRecordResponse.ResponseCode = ResponseCode.Success;
            }
            else
            {
                insertCustomerInformationRecordResponse.ErrorMessage = responseFromDb.Item1;
                insertCustomerInformationRecordResponse.ResponseCode = ResponseCode.BadRequest;
            }

            return insertCustomerInformationRecordResponse;
        }

        #endregion InsertCustomerInformationRecordAsync

        #region UpdateCustomerInformationRecordByIdAsync

        public async Task<KoreAiControllerResponse<string>> UpdateCustomerInformationRecordByIdAsync(int customerId, string emailId)
        {
            KoreAiControllerResponse<string> updateCustomerInformationResponse = new KoreAiControllerResponse<string>();

            var responseFromDb = await _koreAiCustomerInformationRepository.UpdateCustomerInformationRecordByIdInDbAsync(customerId, emailId);

            if (responseFromDb.Item2)
            {
                updateCustomerInformationResponse.ResponseCode = ResponseCode.Success;
            }
            else
            {
                updateCustomerInformationResponse.ErrorMessage = responseFromDb.Item1;
                updateCustomerInformationResponse.ResponseCode = ResponseCode.BadRequest;
            }

            return updateCustomerInformationResponse;
        }

        #endregion UpdateCustomerInformationRecordByIdAsync

        #region DeleteCustomerInformationRecordByIdAsync

        public async Task<KoreAiControllerResponse<string>> DeleteCustomerInformationRecordByIdAsync(int customerId)
        {
            KoreAiControllerResponse<string> deleteCustomerInformationRecordResponse = new KoreAiControllerResponse<string>();

            var responseFromDb = await _koreAiCustomerInformationRepository.DeleteCustomerInformationRecordByIdInDbAsync(customerId);

            if (responseFromDb.Item2)
            {
                deleteCustomerInformationRecordResponse.ResponseCode = ResponseCode.Success;
            }
            else
            {
                deleteCustomerInformationRecordResponse.ErrorMessage = responseFromDb.Item1;
                deleteCustomerInformationRecordResponse.ResponseCode = ResponseCode.BadRequest;
            }

            return deleteCustomerInformationRecordResponse;
        }

        #endregion DeleteCustomerInformationRecordByIdAsync

        #region DeleteAllCustomerInformationRecordsAsync

        public async Task<KoreAiControllerResponse<string>> DeleteAllCustomerInformationRecordsAsync()
        {
            KoreAiControllerResponse<string> deleteAllCustomerInformationRecordsResponse = new KoreAiControllerResponse<string>();

            var responseFromDb = await _koreAiCustomerInformationRepository.DeleteAllCustomerInformationRecordsInDbAsync();

            if (responseFromDb.Item2)
            {
                deleteAllCustomerInformationRecordsResponse.ResponseCode = ResponseCode.Success;
            }
            else
            {
                deleteAllCustomerInformationRecordsResponse.ErrorMessage = responseFromDb.Item1;
                deleteAllCustomerInformationRecordsResponse.ResponseCode = ResponseCode.BadRequest;
            }

            return deleteAllCustomerInformationRecordsResponse;
        }

        #endregion  DeleteAllCustomerInformationRecordsAsync

        #endregion Public methods

        #region Private methods - InsertCustomerInformationRecordAsync
        private CustomerInformation MapCustomerInformationRecord(CustomerInformationInsertRequest customerInformationRecord)
        {
            CustomerInformation customerInformationDbRecord = new CustomerInformation();

            customerInformationDbRecord.Customer_Name = customerInformationRecord.customerName;
            customerInformationDbRecord.Customer_Gender = customerInformationRecord.customerGender;
            customerInformationDbRecord.Customer_Email = customerInformationRecord.customerEmail;
            customerInformationDbRecord.Customer_PhoneNo = customerInformationRecord.customerPhoneNo;
            customerInformationDbRecord.Customer_Age = customerInformationRecord.customerAge;

            return customerInformationDbRecord;
        }

        #endregion Private methods - InsertCustomerInformationRecordAsync
    }
}
