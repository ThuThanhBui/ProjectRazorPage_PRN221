﻿using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly PRNDbContext _context;

        public BlogRepository(PRNDbContext context)
        {
            _context = context;

        }
        public async Task<bool> Add(Blog blog)
        {
            await _context.Blogs.AddAsync(blog);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Blog blog)
        {
            blog.isDeleted = true;
            await Update(blog);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Blog>> GetAll()
        {
            List<Blog> list = await _context.Blogs.ToListAsync();
            return list;
        }

        public async Task<List<Blog>> GetAllById(Guid userid)
        {
            List<Blog> list = await _context.Blogs.Where(x => x.userId == userid).ToListAsync();
            return list;
        }

        public async Task<Blog> GetById(Guid id)
        {
            return await _context.Blogs.FindAsync(id);
        }

        public async Task<bool> Update(Blog blog)
        {
            _context.Blogs.Update(blog);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
