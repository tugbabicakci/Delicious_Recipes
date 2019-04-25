using Delicious_Recipes.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Delicious_Recipes.Dal.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace Delicious_Recipes.Dal.Concreate
{
  public   class TariflerRepo:ITariflerRepo
    {
        Delicious_RecipeContext ctx=new Delicious_RecipeContext();


       

        public List<Tarifler> All(int pageNo, int pageSize)
        {
            int skip = (pageNo - 1) * pageSize;

           

            var k = ctx.Tarifler
                . Include(tarifler => tarifler.Kategoriler)
                . Include(tarifler => tarifler.Malzemeler)
                .Skip(skip).Take(pageSize).ToList();


            return k;
        }

        public List<Tarifler> AllX()
        {
            return ctx.Tarifler.ToList();
        }

        public void Add(Tarifler tarifler)
        {
      
            ctx.Tarifler.Add(tarifler);
            ctx.SaveChanges();

        }

        public List<string> Categories()
        {
            var model = ctx.Kategoriler.Select(x => x.Adi).ToList();
         
           return model;
        }
    }
}
