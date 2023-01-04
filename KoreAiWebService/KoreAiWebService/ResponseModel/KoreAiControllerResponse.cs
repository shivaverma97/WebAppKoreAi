namespace KoreAiWebService.ResponseModel
{
    public class KoreAiControllerResponse<T>
    {
        public List<T> ApplicationData { get; set; }
        public string ErrorMessage { get; set; }
        public ResponseCode ResponseCode {get; set;}

        public KoreAiControllerResponse()
        {
            ApplicationData = new List<T>();
        }
    }
}
