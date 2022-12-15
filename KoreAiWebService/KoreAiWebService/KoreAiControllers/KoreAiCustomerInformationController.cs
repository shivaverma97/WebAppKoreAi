using KoreAiDatabase.KoreAiDatabaseModels;
using KoreAiWebService.KoreAiCustomerInformationServiceInterface;
using KoreAiWebService.RequestModel;
using KoreAiWebService.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace KoreAiWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KoreAiCustomerInformationController : ControllerBase
    {
        #region Private methods

        private IKoreAiCustomerInformationService _koreAiCustomerInformationService;

        #endregion Private methods

        #region Public methods

        public KoreAiCustomerInformationController(IKoreAiCustomerInformationService koreAiCustomerInformationService)
        {
            _koreAiCustomerInformationService = koreAiCustomerInformationService;
        }

        #region GetAllCustomerInformationRecords

        [HttpGet]
        public async Task<IActionResult> GetAllCustomerInformationRecords()
        {
            var getAllCustInfResponse = await _koreAiCustomerInformationService.GetAllCustomerInformationRecordsAsync();

            switch (getAllCustInfResponse.ResponseCode)
            {
                case ResponseCode.Success:
                    return StatusCode(200, getAllCustInfResponse.ApplicationData);

                case ResponseCode.NotFound:
                    return StatusCode(404, getAllCustInfResponse.ErrorMessage);

                case ResponseCode.InternalServerError:
                    return StatusCode(500, getAllCustInfResponse.ErrorMessage);

                case ResponseCode.BadRequest:
                    return StatusCode(400, getAllCustInfResponse.ErrorMessage);

                default:
                    return StatusCode(500, getAllCustInfResponse.ResponseCode);
            }
        }

        #endregion GetAllCustomerInformationRecords

        #region GetCustomerInformationRecordById

        [HttpGet]
        [Route("{customerId}")]
        public async Task<IActionResult> GetCustomerInformationRecordById(int customerId)
        {
            KoreAiControllerResponse<CustomerInformation> custInfRecordResponse = new KoreAiControllerResponse<CustomerInformation>();

            if (customerId == 0)
            {
                custInfRecordResponse.ErrorMessage = "Customer Id cannot be null. Wrong input parameters.";
                custInfRecordResponse.ResponseCode = ResponseCode.BadRequest;
                return StatusCode(400, custInfRecordResponse.ErrorMessage);
            }

            custInfRecordResponse = await _koreAiCustomerInformationService.GetCustomerInformationRecordByIdAsync(customerId);

            switch (custInfRecordResponse.ResponseCode)
            {
                case ResponseCode.Success:
                    return StatusCode(200, custInfRecordResponse.ApplicationData);

                case ResponseCode.NotFound:
                    return StatusCode(404, custInfRecordResponse.ErrorMessage);

                case ResponseCode.InternalServerError:
                    return StatusCode(500, custInfRecordResponse.ErrorMessage);

                case ResponseCode.BadRequest:
                    return StatusCode(400, custInfRecordResponse.ErrorMessage);

                default:
                    return StatusCode(500, custInfRecordResponse.ResponseCode);
            }
        }

        #endregion GetCustomerInformationRecordById

        #region InsertCustomerInformationRecordById

        [HttpPost]
        public async Task<IActionResult> InsertCustomerInformationRecordById([FromBody] CustomerInformationInsertRequest customerInformationRecord)
        {
            KoreAiControllerResponse<string> insertCustInfRecordByIdResponse = new KoreAiControllerResponse<string>();

            if (customerInformationRecord == null)
            {
                insertCustInfRecordByIdResponse.ErrorMessage = "Wrong input parameters.";
                insertCustInfRecordByIdResponse.ResponseCode = ResponseCode.BadRequest;
                return StatusCode(400, insertCustInfRecordByIdResponse.ErrorMessage);
            }

            insertCustInfRecordByIdResponse = await _koreAiCustomerInformationService.InsertCustomerInformationRecordAsync(customerInformationRecord);

            switch (insertCustInfRecordByIdResponse.ResponseCode)
            {
                case ResponseCode.Success:
                    return StatusCode(200, insertCustInfRecordByIdResponse.ResponseCode);

                case ResponseCode.NotFound:
                    return StatusCode(404, insertCustInfRecordByIdResponse.ErrorMessage);

                case ResponseCode.InternalServerError:
                    return StatusCode(500, insertCustInfRecordByIdResponse.ErrorMessage);

                case ResponseCode.BadRequest:
                    return StatusCode(400, insertCustInfRecordByIdResponse.ErrorMessage);

                default:
                    return StatusCode(500, insertCustInfRecordByIdResponse.ResponseCode);
            }
        }

        #endregion InsertCustomerInformationRecordById

        #region  UpdateCustomerInformationRecordById

        [HttpPut]
        public async Task<IActionResult> UpdateCustomerInformationRecordById([FromQuery] int customerId, string emailId)
        {
            KoreAiControllerResponse<string> updateCustomerInformationRecordResponse = new KoreAiControllerResponse<string>();

            if (customerId == 0 || emailId.IsNullOrEmpty())
            {
                updateCustomerInformationRecordResponse.ErrorMessage = "Customer Id or emailId cannot be null. Wrong input parameters.";
                updateCustomerInformationRecordResponse.ResponseCode = ResponseCode.BadRequest;
                return StatusCode(400, updateCustomerInformationRecordResponse.ErrorMessage);
            }

            updateCustomerInformationRecordResponse = await _koreAiCustomerInformationService.UpdateCustomerInformationRecordByIdAsync(customerId, emailId);

            switch (updateCustomerInformationRecordResponse.ResponseCode)
            {
                case ResponseCode.Success:
                    return StatusCode(200, updateCustomerInformationRecordResponse.ResponseCode);

                case ResponseCode.NotFound:
                    return StatusCode(404, updateCustomerInformationRecordResponse.ErrorMessage);

                case ResponseCode.InternalServerError:
                    return StatusCode(500, updateCustomerInformationRecordResponse.ErrorMessage);

                case ResponseCode.BadRequest:
                    return StatusCode(400, updateCustomerInformationRecordResponse.ErrorMessage);

                default:
                    return StatusCode(500, updateCustomerInformationRecordResponse.ResponseCode);
            }
        }
        #endregion UpdateCustomerInformationRecordById

        #region DeleteCustomerInformationRecordById

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomerInformationRecordById(int customerId)
        {
            KoreAiControllerResponse<string> deleteCustInfRecordByIdResponse = new KoreAiControllerResponse<string>();

            if (customerId == 0)
            {
                deleteCustInfRecordByIdResponse.ErrorMessage = "Customer Id cannot be null. Wrong input parameters.";
                deleteCustInfRecordByIdResponse.ResponseCode = ResponseCode.BadRequest;
                return StatusCode(400, deleteCustInfRecordByIdResponse.ErrorMessage);
            }

            deleteCustInfRecordByIdResponse = await _koreAiCustomerInformationService.DeleteCustomerInformationRecordByIdAsync(customerId);

            switch (deleteCustInfRecordByIdResponse.ResponseCode)
            {
                case ResponseCode.Success:
                    return StatusCode(200, deleteCustInfRecordByIdResponse.ResponseCode);

                case ResponseCode.NotFound:
                    return StatusCode(404, deleteCustInfRecordByIdResponse.ErrorMessage);

                case ResponseCode.InternalServerError:
                    return StatusCode(500, deleteCustInfRecordByIdResponse.ErrorMessage);

                case ResponseCode.BadRequest:
                    return StatusCode(400, deleteCustInfRecordByIdResponse.ErrorMessage);

                default:
                    return StatusCode(500, deleteCustInfRecordByIdResponse.ResponseCode);
            }
        }
        #endregion DeleteCustomerInformationRecordById

        #endregion Public methods
    }
}
