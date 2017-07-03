using System;
namespace InMemApi.Models
{
	public class Product
	{
		public Guid Id { get; private set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public bool IsInStock { get; private set; }

		public void SetId()
		{
			this.Id = Guid.NewGuid();
		}

		public void SetInventoryStatus(bool val)
		{
			this.IsInStock = val;
		}
	}
}
