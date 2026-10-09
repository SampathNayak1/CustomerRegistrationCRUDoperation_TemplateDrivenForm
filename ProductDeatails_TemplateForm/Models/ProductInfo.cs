using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductDeatails_TemplateForm.Models
{
    [Table("ProductDetails")]
    public class ProductInfo
    {
        [Key]
        public int Productid { get; set; }
        public string Productname {  get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice {  get; set; }
        public string Paymentmode {  get; set; }
        public string Delivaryaddress { get; set; }

    }
}
