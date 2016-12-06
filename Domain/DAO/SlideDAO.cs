using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.EF;

namespace Domain.DAO {
    public class SlideDAO {
        private PetStoreDbContext db = null;
        public SlideDAO() {
            this.db = new PetStoreDbContext();
        }

        public Slide GetByID(long? id) {
            return db.Slide.Find(id);
        }

        public IEnumerable<Slide> ListAll() {
            return db.Slide.ToList();
        }

        public bool Create(Slide slide) {
            try {
                db.Slide.Add(slide);
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool Edit(Slide slide) {
            try {
                db.Entry(slide).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool Delete(long id) {
            try {
                Slide slide = db.Slide.Find(id);
                db.Slide.Remove(slide);
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

    }
}
