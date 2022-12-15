namespace KoreAiWebService.RequestModel
{
    public class CustomerInformationInsertRequest
    {
        public string customerName { get; set; }
        public string customerEmail { get; set; }
        public int customerPhoneNo { get; set; }
        public int customerAge { get; set; }
        public string customerGender { get; set; }
    }
}
