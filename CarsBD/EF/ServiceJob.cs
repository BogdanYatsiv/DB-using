using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsBD.EF
{
    [Table(name: "ServiceJobs")]
    public partial class ServiceJob
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? centere_id { get; set; }
        public int? car_id { get; set; }

        [ForeignKey(name: "centere_id")]
        public virtual ServiceCenter ServiceCenter { get; set; }

        [ForeignKey(name:"car_id")]
        public virtual Car Car { get; set; }
    }
}
