using System.ComponentModel.DataAnnotations;
using burger_shack.Interfaces;

namespace burger_shack.Models
{
  public class Burger : IMenuItem
  {
    [Required]
    [MinLength(3)]
    public string Name { get; set; }
    public string Description { get; set; }
    [Required]
    public double Price { get; set; }
    public Burger(string name, string desc, double price)
    {
      Name = name;
      Description = desc;
      Price = price;
    }
  }
}