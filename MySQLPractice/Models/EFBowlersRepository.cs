﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLPractice.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {
        private BowlersDbContext _context { get; set; }
        public EFBowlersRepository (BowlersDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Bowler> Bowlers => _context.Bowlers;

        public Bowler GetBowler(int b)
        {
            return Bowlers.Single(x => x.BowlerID == b);
        }

        public void SaveBowler(Bowler b)
        {
            _context.Update(b);
            _context.SaveChanges();
        }

        public void CreateBowler(Bowler b)
        {
            _context.Bowlers.Add(b);
            _context.SaveChanges();
        }

        public void DeleteBowler(Bowler b)
        {
            _context.Bowlers.Remove(b);
            _context.SaveChanges();
        }


    }
}
