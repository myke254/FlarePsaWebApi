namespace Flare.Data.Entities
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
   
    public class CategoryModel : BaseModel
    {
        public string? Category { get; set; }
        public string? Image { get; set; }
        public string? Requirements { get; set; }
    }
}
