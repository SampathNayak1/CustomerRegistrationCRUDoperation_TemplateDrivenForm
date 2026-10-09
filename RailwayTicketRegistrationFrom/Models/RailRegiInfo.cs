using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RailwayTicketRegistrationFrom.Models
{
    [Table("RailTicketForm")] 
    public class RailRegiInfo
    {
        [Key]
        public int Pid {  get; set; }
        public string Pfirstname { get; set; }
        public string Plastname { get; set; }
        public string pgender { get; set; } 
        public int page { get; set; }
        public DateOnly pdob {  get; set; }
        public long pmobile { get; set; }
        public string pemail { get; set; }
        public long padhar { get; set; }
        public DateTime pdate {  get; set; }  
        public string pfrom { get; set; }   
        public string pto { get; set; }

    }
}
