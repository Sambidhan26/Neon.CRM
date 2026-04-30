using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Neon.CRM.Webapp.Data.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        [Display(Name = "Vacation")]
        public int VacationPackageId { get; set; }
        [Display(Name = "Booking Date")]
        public DateTime BookingDate { get; set; }
        [Display(Name = "Confirmed")]
        public bool IsConfirmed { get; set; }

        // Navigation properties
        public Customer? Customer { get; set; }
        [Display(Name = "Vacation Packages")]
        public VacationPackage? VacationPackage { get; set; }

    }
}
