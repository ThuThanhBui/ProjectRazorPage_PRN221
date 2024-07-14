using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interface
{
    public interface IBlogRepository
    {
        public Task<bool> Add(Blog blog);
        public Task<bool> Delete(Guid id);
        public Task<bool> Update(Blog blog);
        public Task<List<Blog>> Search(string txtsearch);
        public Task<List<Blog>> GetAll();
        public Task<List<Blog>> GetAllById(Guid userid);
        public Task<Blog> GetById(Guid id);
    }
}
