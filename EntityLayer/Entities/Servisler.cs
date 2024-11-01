using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Servisler
    {
        [Key]
        public int Servis_Id { get; set; }
        public string? Servis_Ad { get; set; }

        [ForeignKey("Kategoriler")]
        public int Kategori_Id { get; set; }
        public virtual Kategoriler? Kategoriler { get; set; }

        public double? Fiyat { get; set; }

        public virtual List <Adisyon> Adisyons { get; set; }= new List<Adisyon>();

    }
}
