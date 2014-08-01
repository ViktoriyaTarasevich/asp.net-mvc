using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Domain
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
    }
}