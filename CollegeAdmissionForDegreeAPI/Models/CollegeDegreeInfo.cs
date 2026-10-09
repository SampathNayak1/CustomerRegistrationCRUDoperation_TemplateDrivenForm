using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeAdmissionForDegreeAPI.Models
{
    [Table("CollegeAdmissionForDegree")]
    public class CollegeDegreeInfo
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public DateOnly SSCPassedYear { get; set; }
        public decimal SSCPercentage { get; set; }
        public string SchoolName { get; set; }
        public string IntermediateGroup { get; set; }
        public decimal IntermediatePercentage { get; set; }
        public DateOnly IntermediatePassedYear { get; set; }
        public string ExpectedDegreeGroup { get; set; }
        public string MobileNumber { get; set; }
        public string EmailID { get; set; }
        public string AdmmissionStatus { get; set; } 
    }
}
