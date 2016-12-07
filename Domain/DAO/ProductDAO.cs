using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.EF;
using PagedList;
using System.Data.Entity;


namespace Domain.DAO {
    public class ProductDAO {
        private PetStoreDbContext db = null;
        public ProductDAO() {
            this.db = new PetStoreDbContext();
        }

        public Product GetByID(long? id) {
            return db.Product.Find(id);
        }

        public IEnumerable<Product> ListAll() {
            return db.Product.Include(p => p.ProductCategory);
        }

        public IEnumerable<Product> ListAllPaging(int page, int pageSize) {
            return db.Product.Include(p => p.ProductCategory).OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public IEnumerable<Product> ListNewProduct(int top) {
            return db.Product.Include(p => p.ProductCategory).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        public IEnumerable<Product> ListFeatureProduct(int top) {
            return db.Product.Include(p => p.ProductCategory)
                              .OrderByDescending(p => p.ViewCount)
                              .Take(top)
                              .ToList();
        }

        public bool Create(Product product) {
            try {
                db.Product.Add(product);
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool Edit(Product product) {
            try {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool Delete(long id) {
            try {
                Product product = db.Product.Find(id);
                db.Product.Remove(product);
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }



    }
}
