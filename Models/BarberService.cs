using System.ComponentModel.DataAnnotations.Schema;

namespace BarberShop.Models
{
    public class BarberService
    {
        public long BarberServiceID { get; set; }

        public string BarberServiceFIO { get; set; }

        public string BarberServiceDescription { get; set; }

        public byte[] BarberServiceImage { get; set; }

        [NotMapped]

        public IFormFile FilesForm { get; set; }
    }
}
