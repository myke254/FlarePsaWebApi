using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Flare.Data.Entities
{
    public class ListingModel : BaseModel
    {
        
        public double Price { get; set; }
        public Currency Currency { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
              
        public string? Description { get; set; }
        [NotMapped]
        public CoordsModel? Coords { get; set; }
        [JsonIgnore]
        public string Coordinates { 
            get 
            {
                if (Coords == null)
                {
                    Coords = new CoordsModel();
                }
                return JsonSerializer.Serialize(Coords);
            } 
            set
            {
                Coords = JsonSerializer.Deserialize<CoordsModel>(value)!;
            }
        }

        [NotMapped]
        public List<ImageModel>? Image{get; set;}

        [JsonIgnore]
        public string Images
        {
            get
            {
                if (Image == null)
                {
                    Image = new List<ImageModel>();
                }
                return JsonSerializer.Serialize(Image);
            }
            set
            {
                Image = JsonSerializer.Deserialize<List<ImageModel>>(value)!;
            }
        }

    }
}
