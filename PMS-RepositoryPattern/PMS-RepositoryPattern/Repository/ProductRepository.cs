﻿using PMS_RepositoryPattern.Data;
using PMS_RepositoryPattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS_RepositoryPattern.Repository
{
    public class ProductRepository : IProductRepository
    {
        ProductDBContext _context;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_context"></param>
        public ProductRepository(ProductDBContext _context)
        {
            try
            {
                this._context = _context;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            try
            {
                _context.Add(product);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Product GetProduct(int Id)
        {
            try
            {
                return _context.Products.Where(product => product.Id == Id).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public Product GetProduct(string productName)
        {
            try
            {
                return _context.Products.Where(user => user.ProductName.ToLower() == productName.ToLower()).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts()
        {
            try
            {
                return _context.Products;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        public void UpdateProduct(Product product)
        {
            try
            {
                _context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
