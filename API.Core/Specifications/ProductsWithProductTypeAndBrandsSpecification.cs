using API.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace API.Core.Specifications
{
    public class ProductsWithProductTypeAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithProductTypeAndBrandsSpecification(ProductSpecParams productSpecParams)
            :base (x=> (!productSpecParams.BrandId.HasValue || x.ProductBrandId == productSpecParams.BrandId)
            &&
            (!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId))
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            //AddOrderBy(x => x.Name);
            if (!string.IsNullOrWhiteSpace(productSpecParams.Sort)) 
            {
                switch(productSpecParams.Sort) 
                {
                    case "priceAsc":
                        AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesending(x => x.Price);
                        break;
                    default: 
                        AddOrderBy(x => x.Name); 
                        break;

                }
            }
        }
        public ProductsWithProductTypeAndBrandsSpecification(int id)
            :base(x=> x.Id == id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}
