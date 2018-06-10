using System.ComponentModel.DataAnnotations;

namespace IdGenerator.Api.InputModel
{
    public class UniqueParts
    {
        [Required]
        [StringLength(10, MinimumLength = 4)]
        public string CategoryId { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 4)]
        public string FactoryId { get; set; }
    }
}
