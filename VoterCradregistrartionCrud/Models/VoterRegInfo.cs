using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoterCradregistrartionCrud.Models
{
    [Table("VotercardReg")]

    public class VoterRegInfo
    {
        [Key]
         public  int Voterid { get; set; }
         public string Fullname { get; set; }
         public DateTime Dob { get; set; }
         public string Father { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Adhardetails { get; set; } 
    }
}
