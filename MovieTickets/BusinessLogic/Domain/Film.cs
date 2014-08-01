using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Domain
{
    public class Film : EntityBase
    {
        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        public virtual ICollection<Seance> Seances { get; set; }
    }
}