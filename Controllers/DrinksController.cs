using System;
using System.Collections.Generic;
using burger_shack.Models;
using Microsoft.AspNetCore.Mvc;

namespace burger_shack
{
    [Route("api/[controller]")]
    public class DrinksController : Controller
    {
        List<Drink> Drinks { get; set; }
        public DrinksController()
        {
            Drinks = new List<Drink>() {
        new Drink("drink1", "drink1 description", 1.99),
        new Drink("drink2", "drink2 description", 2.99),
        new Drink("drink3", "drink3 description", 3.99)
       };
        }

        [HttpGet]
        public IEnumerable<Drink> Get()
        {
            return Drinks;
        }

        [HttpGet("{id}")]
        public Drink Get(int id)
        {
            return id > -1 && id < Drinks.Count - 1 ? Drinks[id] : null;
        }

        [HttpPost]
        public IEnumerable<Drink> AddDrink([FromBody]Drink drink)
        {
            if (ModelState.IsValid)
            {
                Drinks.Add(drink);
            }
            return Drinks;
        }

        [HttpPut("{id}")]
        public IEnumerable<Drink> editDrink(int id, [FromBody]Drink drink)
        {
            if (id > -1 && id < Drinks.Count && ModelState.IsValid)
            {
                Drinks[id] = drink;
                return Drinks;
            }
            return Drinks;
        }

        [HttpDelete("{id}")]
        public IEnumerable<Drink> deleteDrink(int id)
        {
            if (id > -1 && id < Drinks.Count)
            {
                Drinks.RemoveAt(id);
            }
            return Drinks;
        }

    }
}