using System;
using System.Collections.Generic;

namespace Delicious_Recipes.Dal.Models
{
    public partial class Tarifler
    {
        public Tarifler()
        {
            Kategoriler = new HashSet<Kategoriler>();
            Malzemeler = new HashSet<Malzemeler>();
        }

        public int Id { get; set; }
        public string Talimatlar { get; set; }

        public ICollection<Kategoriler> Kategoriler { get; set; }
        public ICollection<Malzemeler> Malzemeler { get; set; }
    }
}
