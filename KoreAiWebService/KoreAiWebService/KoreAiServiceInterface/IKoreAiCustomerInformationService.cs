using KoreAiDatabase.KoreAiDatabaseModels;
using KoreAiWebService.RequestModel;
using KoreAiWebService.ResponseModel;

namespace KoreAiWebService.KoreAiCustomerInformationServiceInterface
{
    public interface IKoreAiCustomerInformationService
    {
        Task<KoreAiControllerResponse<CustomerInformation>> GetAllCustomerInformationRecordsAsync();

        Task<KoreAiControllerResponse<CustomerInformation>> GetCustomerInformationRecordByIdAsync(int customerId);

        Task<KoreAiControllerResponse<string>> InsertCustomerInformationRecordAsync(CustomerInformationInsertRequest customerInformationRecord);

        Task<KoreAiControllerResponse<string>> UpdateCustomerInformationRecordByIdAsync(int customerId, string emailId);

        Task<KoreAiControllerResponse<string>> DeleteCustomerInformationRecordByIdAsync(int customerId);

        Task<KoreAiControllerResponse<string>> DeleteAllCustomerInformationRecordsAsync();
    }
}
