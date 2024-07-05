using AutoMapper;
using Data.Entities;
using Repository.Repository.Interface;
using Service.Interface;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _repository;
        private readonly IMapper _mapper;

        public BlogService(IBlogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> AddBlog(BlogModel blog)
        {
            try
            {
                var s = _mapper.Map<Blog>(blog);
                var t = await _repository.Add(s);
                if (t)
                {
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteBlog(BlogModel blog)
        {
            var s = _mapper.Map<Blog>(blog);
            return await _repository.Delete(s);
        }

        public async Task<List<BlogModel>> GetAllBlogs()
        {
            List<Blog> b = await _repository.GetAll();
            return _mapper.Map<List<BlogModel>>(b);
        }

        public async Task<List<BlogModel>> GetAllBlogsById(Guid userid)
        {
            List<Blog> b = await _repository.GetAllById(userid);
            return _mapper.Map<List<BlogModel>>(b);
        }

        public async Task<BlogModel> GetBlogById(Guid id)
        {
            Blog b = await _repository.GetById(id);
            return _mapper.Map<BlogModel>(b);
        }

        public async Task<bool> UpdateBlog(BlogModel blog)
        {
            Blog bg = _mapper.Map<Blog>(blog);
            return await _repository.Update(bg);
        }
    }
}
