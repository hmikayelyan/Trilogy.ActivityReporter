using System.ComponentModel.DataAnnotations;

namespace Trilogy.ActivityReporter.DataModels.Models
{
    public class ValueModel
    {
        [Required]
        public double Value { get; set; }
    }
}