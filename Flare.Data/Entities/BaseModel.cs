using System.ComponentModel.DataAnnotations;

namespace Flare.Data.Entities
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Modified { get; set; }= DateTime.Now;
    }
}
