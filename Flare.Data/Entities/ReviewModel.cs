using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Flare.Data.Entities
{
    public class ReviewModel : BaseModel
    {
        [ForeignKey("ListingRefId")]
        public Guid ListingRefId { get; set; }
        [JsonIgnore]
        public ListingModel? ListingModel { get; set; }
        public string? Review { get; set; }
        public Guid? ReviewerId { get; set; }
        [Range(1.0, 5.0)]
        public double Rating { get; set; }
        
    }
}
