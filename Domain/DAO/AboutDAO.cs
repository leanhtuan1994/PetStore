using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.EF;
using System.Data.Entity;

namespace Domain.DAO {
   public class AboutDAO {
        private PetStoreDbContext db = null;
        public AboutDAO() {
            this.db = new PetStoreDbContext();
        }

        public About GetByID(long? id) {
            return db.About.Find(id);
        }

        public IEnumerable<About> ListAll() {
            return db.About.ToList();
        }

        public bool Create(About about) {
            try {
                db.About.Add(about);
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool Edit(About about) {
            try {
                db.Entry(about).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool Delete(long id) {
            try {
                About about = db.About.Find(id);
                db.About.Remove(about);
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }
    }
}
