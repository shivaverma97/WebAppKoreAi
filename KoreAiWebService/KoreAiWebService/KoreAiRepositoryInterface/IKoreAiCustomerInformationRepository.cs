using KoreAiDatabase.KoreAiDatabaseModels;

namespace KoreAiWebService.KoreAiCustomerInformationRepositoryInterface
{
    public interface IKoreAiCustomerInformationRepository
    {
        Task<(List<CustomerInformation>, string, bool)> GetAllCustomerInformationRecordsFromDbAsync();

        Task<(CustomerInformation, string, bool)> GetCustomerInformationRecordByIdFromDbAsync(int customerId);

        Task<(string, bool)> InsertCustomerInformationRecordInDbAsync(CustomerInformation customerInformationRecord);

        Task<(string, bool)> UpdateCustomerInformationRecordByIdInDbAsync(int customerId, string emailId);

        Task<(string, bool)> DeleteCustomerInformationRecordByIdInDbAsync(int customerId);

        Task<(string, bool)> DeleteAllCustomerInformationRecordsInDbAsync();
    }
}
