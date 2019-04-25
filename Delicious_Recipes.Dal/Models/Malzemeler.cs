using System;
using System.Collections.Generic;

namespace Delicious_Recipes.Dal.Models
{
    public partial class Malzemeler
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public int? TarifId { get; set; }
        public int? MiktarId { get; set; }

        public Miktar Miktar { get; set; }
        public Tarifler Tarif { get; set; }
    }
}
