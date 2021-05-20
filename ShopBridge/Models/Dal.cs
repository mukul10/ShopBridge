using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopBridge.Models.Context;
using System.Threading.Tasks;

namespace ShopBridge.Models
{
    public class Dal
    {

        private ShopDBcontext db = new ShopDBcontext();

        public IQueryable<Product> GetAllProduct()
        {
            return db.Products;
        }
    
        public async Task<Product> findProduct(int pid)
        {
            return await db.Products.FindAsync(pid);


        }

        public async Task<string> addProduct(Product p)
        {
            try
            {
                db.Products.Add(p);
                int i = await db.SaveChangesAsync();
                if( i == 1)
                {
                    return "Added Successfull";
                }
                else
                {
                    return " Please Try Again";
                }
            }
            catch (Exception)
            {

                throw;
            }
            

            
        }
        public async Task<string> deleteProduct(int id)
        {

            Product product = await db.Products.FindAsync(id);
            try
            {
                if (product != null)
                {
                    db.Products.Remove(product);
                    await db.SaveChangesAsync();
                    return "delete succesful";
                }
                else
                {
                    return "id not Found ";
                }
            }
            catch (Exception e)
            {

                throw new Exception("Not found");

            }


        }
        internal async Task<string> UpdateProduct(int id, Product product)
        {
            try
            {
                Product p = await db.Products.FindAsync(id);
                if(p != null)
                {
                    p = product;
                   await db.SaveChangesAsync();
                    return "Update Succesfull";
                }
                else
                {
                    return "Product Not Found";
                }
            }
            catch (Exception)
            {

                throw;
            }
            

        }

    }
}