using System.ComponentModel.DataAnnotations.Schema;

namespace BarberShop.Models
{
    public class BarberStock
    {
        public long BarberStockID { get; set; }

        public string BarberStockName { get; set; }

        public string BarberStockDescription { get; set; }

        public byte[] BarberStockImage { get; set; }

        [NotMapped]

        public IFormFile FormFile { get; set; }
    }
}
