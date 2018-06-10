using System.ComponentModel.DataAnnotations;

namespace IdGenerator.Api.InputModel
{
    public class Factory
    {
        [Required]
        [StringLength(10, MinimumLength = 4)]
        public string Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; }
    }
}
