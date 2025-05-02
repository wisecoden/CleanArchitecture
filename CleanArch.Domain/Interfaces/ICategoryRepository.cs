using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces
{
    namespace CleanArch.Domain.Interfaces
    {
        public interface ICategoryRepository
        {
            Task<IEnumerable<Category>> GetAllAsync();
            Task<Category> GetByIdAsync(int id);
        }
    }

}
