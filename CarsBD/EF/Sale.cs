using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsBD.EF
{
    [Table(name:"Sales")]
    public partial class Sale
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? car_id { get; set; }
        public int? store_id { get; set; }
        public int? Price { get; set; }
        public int? Date { get; set; }

        [ForeignKey(name: "car_id")]
        public virtual Car Car { get; set; }

        [ForeignKey(name: "store_id")]
        public virtual Store Store { get; set; }
    }
}
