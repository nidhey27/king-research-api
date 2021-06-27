using KingResearch.Domain.Models;
using KingResearch.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingResearch.Repository.Repository
{
    public class BusinesRepository<T> : IBusinesRepository<T>where T : class
    {
        private KingResearchDbContext _context;
        public BusinesRepository(KingResearchDbContext context)
        {
            _context = context;
        }
        public List<T> GetAll()
        {
            Type type = typeof(T);

            if (type == typeof(Event))
            {
                return _context.Events.Cast<T>().ToList();
            }
            else if (type == typeof(Service))
            {
                return _context.Services.Cast<T>().ToList();
            }
            else if (type == typeof(Video))
            {
                return _context.Videos.Cast<T>().ToList();
            }
            else
            {
                return _context.Dmats.Cast<T>().ToList();
            }
        }

        public T GetById(int id)
        {
            return _context.Find<T>(id);
        }

        public int Insert(T Model)
        {
            _context.Add<T>(Model);
            return _context.SaveChanges();            
        }

        public int Remove(T Model)
        {
            _context.Remove<T>(Model);
            return _context.SaveChanges();
        }

        public int Update(T Model)
        {
            //_context.Attach<T>(Model);
            _context.Entry<T>(Model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return _context.SaveChanges();
        }
    }
}
