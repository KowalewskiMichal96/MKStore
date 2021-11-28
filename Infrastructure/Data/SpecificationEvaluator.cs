using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {

        // 8. przekazany typ oraz opis przerabiamy metoda
        // query = dbset<product>
        public static IQueryable<TEntity> GetQuery(
            IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
            {
                var query = inputQuery;

                // jesli opis nie jest pusty
                if(spec.Criteria != null)
                {
                    // product = product.where(x => x.id == id)
                    query = query.Where(spec.Criteria);
                }

                // połaczy w całość product, typ i markę 
                query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

                return query;
            }
    }
}