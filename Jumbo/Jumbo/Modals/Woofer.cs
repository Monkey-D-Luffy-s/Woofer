using System.ComponentModel.DataAnnotations;

namespace Jumbo.Modals
{
    public class Woofer
    {
        [Key]
        public Guid Id { get; set; }

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
