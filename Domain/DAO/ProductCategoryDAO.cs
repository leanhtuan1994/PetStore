using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.EF;
using System.Data.Entity;
using PagedList;

namespace Domain.DAO {
    public class ProductCategoryDAO {
        private PetStoreDbContext db = null;

        public ProductCategoryDAO() {
            this.db = new PetStoreDbContext();
        }

        public ProductCategory GetProductCategoryByID(long? id) {
           return db.ProductCategories.Find(id);
        }

        public IEnumerable<ProductCategory> ListAll() {
            return  db.ProductCategories.Include(p => p.ProductCategory2);
        }

        public IEnumerable<ProductCategory> ListAllPaging(int page, int pageSize) {
            return db.ProductCategories.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public bool Create(ProductCategory productCategory) {
            try {
                db.ProductCategories.Add(productCategory);
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }  
        }

        public bool Edit(ProductCategory productCategory) {
            try {
                db.Entry(productCategory).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }  catch (Exception ex) {
                return false;
            }
        }

        public bool Delete(long id) {
             try {
                ProductCategory productCategory = db.ProductCategories.Find(id);
                db.ProductCategories.Remove(productCategory);
                db.SaveChanges();
                return true;
            }   catch ( Exception ex) {
                return false;
            }
        }



    }
}
