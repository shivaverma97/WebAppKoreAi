using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KoreAiDatabase.KoreAiDatabaseModels
{
    public class CustomerInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Customer_Id { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Email { get; set; }
        public int Customer_PhoneNo { get; set; }
        public int Customer_Age { get; set; }
        public string Customer_Gender { get; set; }
    }
}
