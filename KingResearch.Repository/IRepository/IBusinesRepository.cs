using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingResearch.Repository.IRepository
{
    public interface IBusinesRepository<T>
    {
        public List<T> GetAll();
        int Update(T Model);

        int Remove(T Model);

        int Insert(T Model);

        T GetById(int id);

    }
}
