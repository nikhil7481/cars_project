using System.ComponentModel.DataAnnotations;

namespace Kevin_API.Models.Dto
{
    public class ModelDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public int Occupancy { get; set; }
        public int HP { get; set; }

    }
}
