using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Kategoriler
    {
        [Key]
        public int Kategori_Id { get; set; }
        public string Kategori_Ad { get; set; } = string.Empty;

        public virtual List<Servisler>? Servislers { get; set; }
    }
}
