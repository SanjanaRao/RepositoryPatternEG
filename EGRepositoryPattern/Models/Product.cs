using System;
using System.ComponentModel.DataAnnotations;

namespace EGRepositoryPattern.Models
{
	public class Product
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
	}
}

