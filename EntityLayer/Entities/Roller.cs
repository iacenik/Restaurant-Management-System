using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Roller
    {
        [Key]
        public int Rol_Id { get; set; }
        public string Rol_Ad { get; set; } = string.Empty;

        public virtual List<Personeller>? Personellers  { get; set; }
    }
}
