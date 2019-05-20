using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleTokenService.Data.Entities
{
    public class EnumEntity<T>  
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public T Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
    }
}
