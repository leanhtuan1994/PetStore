using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.EF;
using PagedList;
using System.Data.Entity;



namespace Domain.DAO {
    public class CategoryDAO {
        private PetStoreDbContext db = null;

        public CategoryDAO() {
            this.db = new PetStoreDbContext();
        }

        public Category GetByID(long? id) {
            return db.Category.Find(id);
        }

        public IEnumerable<Category> ListAll() {
            return db.Category.Include(p => p.Category2);
        }

        public IEnumerable<Category> ListAllPaging(int page, int pageSize) {
            return db.Category.Include(p => p.Category2).OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public bool Create(Category category) {
            try {
                db.Category.Add(category);
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool Edit(Category category) {
            try {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool Delete(long id) {
            try {
                Category category = db.Category.Find(id);
                db.Category.Remove(category);
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

    }
}
