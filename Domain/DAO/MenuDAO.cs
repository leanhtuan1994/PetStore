using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.EF;

namespace Domain.DAO {
    public class MenuDAO {
        private PetStoreDbContext db = null;
        public MenuDAO() {
            this.db = new PetStoreDbContext();
        }

        public Menu GetByID(long? id) {
            return db.Menu.Find(id);
        }

        public IEnumerable<Menu> ListAll() {
            return db.Menu.Include(p => p.MenuType);
        }

        public IEnumerable<Menu> ListByGroupID(long id) {
            return db.Menu.Where(x => x.TypeID == id && x.Status == true).OrderBy(x => x.DisplayOrder);
        }

        public bool Create(Menu menu) {
            try {
                db.Menu.Add(menu);
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool Edit(Menu menu) {
            try {
                db.Entry(menu).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool Delete(long id) {
            try {
                Menu menu = db.Menu.Find(id);
                db.Menu.Remove(menu);
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }


    }
}
