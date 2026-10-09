using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRegistrationCRUDoperation_TemplateDrivenForm.Models
{
    [Table("CustInfo")]
    public class CustomerInfo 
    {
        [Key]
        public int Cid { get; set; }
        public string Cname { get; set; }
        public string Cemail { get; set; }  
        public long Cphone { get; set; }
        public string Cproduct { get; set; }

        public int Cprice { get; set; }

        public string Caddress { get; set; }

    }
}
