using CompletKitInstall.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingBlazor.Data.Acces.Repositories;
using TestingBlazor.Data.Models;

namespace TestingBlazor.Data.Acces
{
    public interface IProductRepository : IRepository<Product, ProductViewModel>
    {

    }
    public class ProductRepository : Repository<Product, ProductViewModel>, IProductRepository
    {
        public ProductRepository(TestingBlazorContext ctx) : base(ctx)
        {

        }

        public override async Task<Product> Add(ProductViewModel item)
        {
            try
            {
                if (item == null)
                    return null;
                if (item.Description == null)
                    return null;
                var product = new Product
                {
                    Name = item.Name,
                    Description = item.Description,
                    //ImageUrl = item.ImageUrl,
                    //CategoryId = item.CategoryId,
                    //Category = await _ctx.Categories.FirstOrDefaultAsync(x => x.Id == item.CategoryId),
                    //DateCreated = DateTime.Now
                };
                _ctx.Products.Add(product);
                await _ctx.SaveChangesAsync();
                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public override async Task<IEnumerable<ProductViewModel>> Get(bool asNoTracking = false)
        {
            try
            {
                var rv = new List<ProductViewModel>();
                var sourceCollection = await _ctx.Products.ToListAsync();
                foreach (var product in sourceCollection)
                {
                    var vm = new ProductViewModel()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                    };
                    rv.Add(vm);

                }
                return rv;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public override async Task<ProductViewModel> GetById(int id, bool asNoTracking = false)
        {
            try
            {
                var sourceCollection = _ctx.Products.AsQueryable();
                if (asNoTracking)
                    sourceCollection = sourceCollection.AsNoTracking();
                var product = await sourceCollection.FirstOrDefaultAsync(x => x.Id == id);
                if (product == null)
                    return null;
                var rv = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                };
                return rv;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public override Task<bool> Remove(ProductViewModel item)
        {
            throw new NotImplementedException();
        }

        public override async Task<Product> RemoveById(int id)
        {
            try
            {
                var product = await _ctx.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (product == null)
                    throw new ArgumentNullException($"The Product with Id= '{id}' does not exist.");
                _ctx.Products.Remove(product);
                await _ctx.SaveChangesAsync();
                return product;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public override async Task<bool> Update(int id, ProductViewModel newData)
        {
            try
            {
                var product = await _ctx.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (product == null)
                    return false;
                if (newData.Description != null)
                {
                    product.Description = newData.Description;
                }
                if (newData.Name != null)
                {
                    product.Name = newData.Name;
                }
                await _ctx.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
