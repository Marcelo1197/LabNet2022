using Linq.Queries.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Queries.Logic
{
    public class ProductsLogic : BaseLogic
    {
        public IQueryable<ProductsDto> queryProductosSinStock() // Query #2
        {
            return _context.Products
                .Where(p => p.UnitsInStock == 0)
                .Select(p => new ProductsDto
                {
                    ProductID = p.ProductID,
                    ProductName = p.ProductName,
                    UnitsInStock = p.UnitsInStock,
                });
        }

        public IQueryable<ProductsDto> queryProdFiltradosPrecioStock() // Query #3
        {
            return _context.Products
                .Where(p => p.UnitsInStock == 0 && p.UnitPrice > 3)
                .Select(p => new ProductsDto
                {
                    ProductID = p.ProductID,
                    ProductName = p.ProductName,
                    UnitPrice = p.UnitPrice,
                    UnitsInStock = p.UnitsInStock
                });
        }

        public ProductsDto producto789() // Query #5
        {
            return _context.Products
                .Where(p => p.ProductID == 789)?
                .Select(p => new ProductsDto
                {
                    ProductID = p.ProductID,
                    ProductName = p.ProductName,
                })
                .FirstOrDefault();
        }

        public IQueryable<ProductsDto> queryProductosOrdenadosNombre()
        {
            return from p in _context.Products
                   orderby p.ProductName
                   select new ProductsDto
                   {
                       ProductName = p.ProductName
                   };
        }

        public IQueryable<ProductsDto> queryProductosOrdenadosStock()
        {
            return from p in _context.Products
                   orderby p.UnitsInStock descending
                   select new ProductsDto
                   {
                       ProductID = p.ProductID,
                       UnitsInStock = p.UnitsInStock,
                   };
        }

        public IQueryable<ProductsWithCategoriesDto> productosConCategorias()
        {
            return from p in _context.Products
                   join ca in _context.Categories
                   on new { c = p.CategoryID }
                   equals new { c = (int?)ca.CategoryID }
                   select new ProductsWithCategoriesDto
                   {
                       ProductID = p.ProductID,
                       ProductName = p.ProductName,
                       CategoryID = ca.CategoryID,
                       CategoryName = ca.CategoryName
                   };
        }

        public ProductsDto PrimerProducto()
        {
            return (from p in _context.Products
                    select new ProductsDto
                    {
                        ProductID = p.ProductID,
                        ProductName = p.ProductName
                    })
                    .First();
        }
    }
}
