using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsBD.EF
{
    [Table(name:"Stores")]
    public partial class Store
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(30)]
        public string? Name { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
