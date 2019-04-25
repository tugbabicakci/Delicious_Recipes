using System;
using System.Collections.Generic;

namespace Delicious_Recipes.Dal.Models
{
    public partial class Miktar
    {
        public Miktar()
        {
            Malzemeler = new HashSet<Malzemeler>();
        }

        public int Id { get; set; }
        public decimal? Adet { get; set; }
        public int? BirimId { get; set; }

        public Birim Birim { get; set; }
        public ICollection<Malzemeler> Malzemeler { get; set; }
    }
}
