using KoreAiDatabase;
using KoreAiDatabase.KoreAiDatabaseModels;
using KoreAiWebService.KoreAiCustomerInformationRepositoryInterface;
using Microsoft.EntityFrameworkCore;

namespace KoreAiWebService.KoreAiRepository
{
    public class KoreAiCustomerInformationRepository : IKoreAiCustomerInformationRepository
    {
        #region Private methods

        private KoreAiDbContext _koreAiDbContext;

        #endregion Private methods

        #region Public methods

        public KoreAiCustomerInformationRepository(KoreAiDbContext koreAiDbContext)
        {
            _koreAiDbContext = koreAiDbContext;
        }

        #region GetAllCustomerInformationRecordsFromDbAsync

        public async Task<(List<CustomerInformation>, string, bool)> GetAllCustomerInformationRecordsFromDbAsync()
        {
            var errorMessage = string.Empty;
            bool isSuccess = false;
            List<CustomerInformation> allCustRecords = new List<CustomerInformation>();

            try
            {
                allCustRecords = await _koreAiDbContext.CustomerInformation.Select(row => row).ToListAsync();

                if (allCustRecords == null ||  allCustRecords.Count == 0)
                {
                    errorMessage = "Records not found as table does not contain any records";
                }
                else
                {
                    isSuccess = true;
                }
            }
            catch(Exception ex)
            {
                errorMessage = $"Failed to  fetch records due to the following exception : {ex}";
            }

            return (allCustRecords, errorMessage, isSuccess);
        }

        #endregion GetAllCustomerInformationRecordsFromDbAsync

        #region GetCustomerInformationRecordByIdFromDbAsync

        public async Task<(CustomerInformation, string, bool)> GetCustomerInformationRecordByIdFromDbAsync(int customerId)
        {
            var errorMessage = string.Empty;
            bool isSuccess = false;
            CustomerInformation customerInformationRecord = new CustomerInformation();

            try
            {
                customerInformationRecord = await (from record in _koreAiDbContext.CustomerInformation where record.Customer_Id == customerId select record).FirstOrDefaultAsync();

                if(customerInformationRecord == null)
                {
                    errorMessage = $"Record not found as customer information table does not contain any record matching with customer Id : {customerId}";
                }
                else
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = $"Failed to fetch the record from customer information table due to the following exception : {ex}";
            }

            return (customerInformationRecord, errorMessage, isSuccess);
        }

        #endregion GetCustomerInformationRecordByIdFromDbAsync

        #region InsertCustomerInformationRecordInDbAsync

        public async Task<(string, bool)> InsertCustomerInformationRecordInDbAsync(CustomerInformation customerInformationRecord)
        {
            var errorMessage = string.Empty;
            bool isSuccess = false;

            try
            {
                var responseFromDb = await _koreAiDbContext.CustomerInformation.AddAsync(customerInformationRecord);
                await _koreAiDbContext.SaveChangesAsync();

                if (responseFromDb == null)
                {
                    errorMessage = $"Failed to insert record in customer information table for customer Id : {customerInformationRecord.Customer_Id}";
                }
                else
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = $"Failed to insert record in customer information table for customer Id : {customerInformationRecord.Customer_Id} due to the following exception: {ex}";
            }

            return (errorMessage, isSuccess);
        }

        #endregion InsertCustomerInformationRecordInDbAsync

        #region UpdateCustomerInformationRecordByIdInDbAsync

        public async Task<(string, bool)> UpdateCustomerInformationRecordByIdInDbAsync(int customerId, string emailId)
        {
            var errorMessage = string.Empty;
            bool isSuccess = false;

            try
            {
                var customerInformationRecord = await (from record in _koreAiDbContext.CustomerInformation where record.Customer_Id == customerId select record).FirstOrDefaultAsync();

                if(customerInformationRecord != null)
                {
                    customerInformationRecord.Customer_Email = emailId;

                    var responseFromDb = await _koreAiDbContext.SaveChangesAsync();

                    if (responseFromDb == 0)
                    {
                        errorMessage = $"Failed to update record in customer information table with customer Id: {customerId}";
                    }
                    else
                    {
                        isSuccess = true;
                    }
                }
               else
               {
                    errorMessage = $"No record found in customer information table for customer Id: {customerId}";
               }
            }
            catch (Exception ex)
            {
                errorMessage = $"Failed to update record in customer information table with customer Id: {customerId} due to the following exception: {ex}";
            }

            return (errorMessage, isSuccess);
        }

        #endregion UpdateCustomerInformationRecordByIdInDbAsync

        #region DeleteCustomerInformationRecordByIdAsync

        public async Task<(string, bool)> DeleteCustomerInformationRecordByIdAsync(int customerId)
        {
            var errorMessage = string.Empty;
            bool isSuccess = false;

            try
            {
                var customerInformationRecord = await (from record in _koreAiDbContext.CustomerInformation where record.Customer_Id == customerId select record).FirstOrDefaultAsync();

                if(customerInformationRecord != null)
                {
                    _koreAiDbContext.Remove(customerInformationRecord);
                    var responseFromDb = await _koreAiDbContext.SaveChangesAsync();

                    if(responseFromDb == 0)
                    {
                        errorMessage = $"Failed to delete the record from customer information table with customer Id = {customerId}";
                    }
                    else
                    {
                        isSuccess = true;
                    }
                }
                else
                {
                    errorMessage = $"No record found in customer information table for customer Id: {customerId}";
                }
            }
            catch(Exception ex)
            {
                errorMessage = $"Failed to delete record in customer information table with customer Id: {customerId} due to the following exception: {ex}";
            }

            return(errorMessage, isSuccess);
        }

        #endregion DeleteCustomerInformationRecordByIdAsync

        #endregion Public methods
    }
}
