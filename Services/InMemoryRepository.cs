using System;
using System.Collections.Generic;
using System.Linq;
using InMemApi.Models;
using Microsoft.Extensions.Caching.Memory;

namespace InMemApi.Services
{
    
    public class InMemoryRepository
    {

        IMemoryCache _cache;
        List<Product> _productsRepo;

        public InMemoryRepository(IMemoryCache cache)
        {
            _cache = cache;
            var products = _cache.Get<List<Product>>("Products");
            if (products == null)
            {
                Seed();
                _cache.Set("Products", _productsRepo);
            }
            _productsRepo = products;

        }

        public Product Add(Product obj)
        {
            obj.SetId();
            _productsRepo.Add(obj);
            return obj;
        }

        public void Remove(Guid id)
        {
            var del = _productsRepo.Find(x => x.Id == id);
            if (del != null)
            {
                _productsRepo.Remove(del);
            }
        }

        public List<Product> GetAll()
        {
            return _productsRepo;
        }

        public Product GetById(Guid id)
        {

            var ret = _productsRepo.SingleOrDefault(x => x.Id == id);
            return ret;
        }

        public void Seed()
        {
            _productsRepo = new List<Product>();
            Add(new Product { Name = "Coke", Price = 1.34m });
            Add(new Product { Name = "KitKat", Price = 1.99m });
            Add(new Product { Name = "Fritos", Price = 3.34m });
            Add(new Product { Name = "Gum", Price = 0.55m });
            Add(new Product { Name = "Fire Log", Price = 11.44m });
	    Add(new Product { Name = "Donut", Price = 0.99m });
	    Add(new Product { Name = "Nachos", Price = 5.99m });
	    Add(new Product { Name = "Yogurt", Price = 2.34m });
	    Add(new Product { Name = "Coffee", Price = 1.25m });
	    Add(new Product { Name = "Snickers", Price = 1.76m });
        }

    }
}
