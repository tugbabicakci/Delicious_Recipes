using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Delicious_Recipes.Dal.Models;

namespace Delicious_Recipes.Dal.Abstract
{
    public interface ITariflerRepo
    {
       
        List<Tarifler> All(int pageNo, int pageSize);
        List<Tarifler> AllX();
        void Add(Tarifler tarifler);
        List<string> Categories();

 


    }
}
