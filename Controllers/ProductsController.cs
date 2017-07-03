using System;
using Microsoft.AspNetCore.Mvc;
using InMemApi.Models;
using InMemApi.Services;

namespace InMemApi.Controllers
{

    public class ProductsController : Controller
    {
        
        readonly InMemoryRepository _inmemoryRepo;

        public ProductsController(InMemoryRepository inmemoryRepo)
        {
            _inmemoryRepo = inmemoryRepo;
        }

        [HttpGet]
        [Route("/api/product")]
        public IActionResult GetProducts()
        {
            return Ok(_inmemoryRepo.GetAll());
        }

        [HttpGet]
        [Route("/api/product/{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(_inmemoryRepo.GetById(Guid.Parse(id)));
        }

        [HttpPost]
        [Route("/api/product")]
        public IActionResult IActionResult([FromBody]Product obj)
        {
            var created = _inmemoryRepo.Add(obj);
            return Created($"api/product/{created.Id}", created);
        }

        [HttpDelete("{id}")]
        [Route("/api/product/{id}")]
        public IActionResult Delete(string id)
        {
            _inmemoryRepo.Remove(Guid.Parse(id));
            return Ok();
        }
    }
}