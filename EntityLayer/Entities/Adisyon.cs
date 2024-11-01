using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Adisyon
    {
        [Key]
        public int Adisyon_Id { get; set; }
        [ForeignKey("Siparisler")]
        public int Siparis_Id { get; set; }
        public virtual Siparisler? Siparisler { get; set; }
        [ForeignKey("Servisler")]
        public int? Servis_Id { get; set; }
        public virtual Servisler? Servisler { get; set; }
        public int? Adet { get; set; }
    }
}
