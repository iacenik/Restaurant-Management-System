using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Masalar
    {
        [Key]
        public int Masa_Id { get; set; }
        [Required(ErrorMessage ="Masa İsmi Boş Geçemezsiniz")]
        public string Masa_Ad { get; set; } = string.Empty;
        public bool Masa_Durum { get; set; }
        public virtual List<Personeller>? Personellers { get; set;}
    }
}
