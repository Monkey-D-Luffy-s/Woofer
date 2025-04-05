using System.ComponentModel.DataAnnotations;

namespace Jumbo.Modals.DTO
{
    public class AddWoofDTO
    {

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int SlotId { get; set; }
    }
}
