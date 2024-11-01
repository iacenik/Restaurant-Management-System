using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Personeller
    {
        [Key]
        public int Personel_Id { get; set; }
        public string AdSoyad { get; set; } = string.Empty;

        [ForeignKey("Masalar")]
        public int Masa_Id { get; set; }

        public virtual Masalar? Masalar { get; set; }

        [ForeignKey("Roller")]
        public int Rol_Id { get; set; }
        
        public virtual Roller? Roller { get; set; }
    }
}
