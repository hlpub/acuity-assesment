using System.ComponentModel.DataAnnotations;

namespace Library.Core.Domain.Models
{
    public abstract class ModelBase
    {
        [Key]
        public int Id { get; private set; }
    }
}