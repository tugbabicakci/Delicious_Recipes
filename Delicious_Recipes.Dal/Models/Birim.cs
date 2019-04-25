using System;
using System.Collections.Generic;

namespace Delicious_Recipes.Dal.Models
{
    public partial class Birim
    {
        public Birim()
        {
            Miktar = new HashSet<Miktar>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }

        public ICollection<Miktar> Miktar { get; set; }
    }
}
