using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsBD.EF
{
    [Table(name:"ServiceCenter")]
    public partial class ServiceCenter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(30)]
        public string? Name { get; set; }
        public virtual ICollection<ServiceJob> ServiceJobs { get; set; }
    }
}
