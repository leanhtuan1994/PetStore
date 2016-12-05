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
            return db.Products.Find(id);
        }

        public IEnumerable<Product> ListAll() {
            return db.Products.Include(p => p.ProductCategory);
        }

        public IEnumerable<Product> ListAllPaging(int page, int pageSize) {
            return db.Products.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public bool Create(Product product) {
            try {
                db.Products.Add(product);
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
                Product product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }



    }
}
