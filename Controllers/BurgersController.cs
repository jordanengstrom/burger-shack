using System;
using System.Collections.Generic;
using burger_shack.Models;
using Microsoft.AspNetCore.Mvc;

namespace burger_shack
{
    [Route("api/[controller]")]
    public class BurgersController : Controller
    {
        List<Burger> Burgers { get; set; }
        public BurgersController()
        {
            Burgers = new List<Burger>() {
        new Burger("The Aloha Burger", "Tasty meat with Pineapple (taste the island)", 11.99),
        new Burger("The BBQ Brittany", "tasty meat with BBQ Sauce.... its a secret", 15.74),
        new Burger("The Veg", "dont worry its gross", 2.99)
       };
        }

        [HttpGet]
        public IEnumerable<Burger> Get()
        {
            return Burgers;
        }

        [HttpGet("{id}")]
        public Burger Get(int id)
        {
            return id > -1 && id < Burgers.Count - 1 ? Burgers[id] : null;
        }

        [HttpPost]
        public IEnumerable<Burger> AddBurger([FromBody]Burger burger)
        {
            if (ModelState.IsValid)
            {
                Burgers.Add(burger);
            }
            return Burgers;
        }

        [HttpPut("{id}")]
        public IEnumerable<Burger> editBurger(int id, [FromBody]Burger burger)
        {
            if (id > -1 && id < Burgers.Count && ModelState.IsValid)
            {
                Burgers[id] = burger;
                return Burgers;
            }
            return Burgers;
        }

        [HttpDelete("{id}")]
        public IEnumerable<Burger> deleteBurger(int id)
        {
            if (id > -1 && id < Burgers.Count)
            {
                Burgers.RemoveAt(id);
            }
            return Burgers;
        }

    }
}