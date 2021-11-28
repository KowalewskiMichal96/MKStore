using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Specification
{
    public class ProductWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandsSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

        // 2. Tworzymy Instancję BaseSpecification
        public ProductWithTypesAndBrandsSpecification(int id)
         : base(x => x.Id == id)
        {
        // 4. zostają zainkludowane 
        // Typ produktu oraz Marka
        // Produktu wyszukanego przez konstruktor 3.
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}