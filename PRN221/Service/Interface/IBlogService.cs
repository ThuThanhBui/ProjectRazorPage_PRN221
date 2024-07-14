using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IBlogService
    {
        public Task<bool> AddBlog(BlogModel blog);
        public Task<bool> DeleteBlog(Guid blog);
        public Task<bool> UpdateBlog(BlogModel blog);
        public Task<List<BlogModel>> GetAllBlogs();
        public Task<List<BlogModel>> GetAllBlogsById(Guid userid);
        public Task<BlogModel> GetBlogById(Guid id);
        public Task<List<BlogModel>> Search(string txtSearch);
    }
}
