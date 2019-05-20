using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatementsTracker.Data.Entities
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
