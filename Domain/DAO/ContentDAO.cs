using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Domain.EF;
using System.Data.Entity;

namespace Domain.DAO {
    public class ContentDAO {
        private PetStoreDbContext db = null;
        public ContentDAO() {
            this.db = new PetStoreDbContext();
        }

        public Content GetByID(long? id) {
            return db.Content.Find(id);
        }

        public IEnumerable<Content> ListAll() {
            return db.Content.Include(p => p.Category);
        }

        public IEnumerable<Content> ListAllPaging(int page, int pageSize) {
            return db.Content.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public bool Create(Content content) {
            try {
                db.Content.Add(content);
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool Edit(Content content) {
            try {
                db.Entry(content).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool Delete(long id) {
            try {
                Content content = db.Content.Find(id);
                db.Content.Remove(content);
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }
    }
}
