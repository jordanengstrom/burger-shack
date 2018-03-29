using System;
using System.Collections.Generic;
using burger_shack.Models;
using Microsoft.AspNetCore.Mvc;

namespace burger_shack
{
    [Route("api/[controller]")]
    public class SidesController : Controller
    {
        List<Side> Sides { get; set; }
        public SidesController()
        {
            Sides = new List<Side>() {
        new Side("Side1", "Side1 description", 2.99),
        new Side("Side2", "Side2 description", 3.99),
        new Side("Side3", "Side3 description", 4.99)
       };
        }

        [HttpGet]
        public IEnumerable<Side> Get()
        {
            return Sides;
        }

        [HttpGet("{id}")]
        public Side Get(int id)
        {
            return id > -1 && id < Sides.Count - 1 ? Sides[id] : null;
        }

        [HttpPost]
        public IEnumerable<Side> AddSide([FromBody]Side side)
        {
            if (ModelState.IsValid)
            {
                Sides.Add(side);
            }
            return Sides;
        }

        [HttpPut("{id}")]
        public IEnumerable<Side> editSide(int id, [FromBody]Side side)
        {
            if (id > -1 && id < Sides.Count && ModelState.IsValid)
            {
                Sides[id] = side;
                return Sides;
            }
            return Sides;
        }

        [HttpDelete("{id}")]
        public IEnumerable<Side> deleteSide(int id)
        {
            if (id > -1 && id < Sides.Count)
            {
                Sides.RemoveAt(id);
            }
            return Sides;
        }
    }
}