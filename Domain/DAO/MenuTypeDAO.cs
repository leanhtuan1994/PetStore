using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.EF;

namespace Domain.DAO {
    public class MenuTypeDAO {
        private PetStoreDbContext db = null;
        public MenuTypeDAO() {
            this.db = new PetStoreDbContext();
        }

        public MenuType GetByID(long? id) {
            return db.MenuType.Find(id);
        }

        public IEnumerable<MenuType> ListAll() {
            return db.MenuType.ToList();
        }

        public bool Create(MenuType menuType) {
            try {
                db.MenuType.Add(menuType);
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool Edit(MenuType menuType) {
            try {
                db.Entry(menuType).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool Delete(long id) {
            try {
                MenuType menuType = db.MenuType.Find(id);
                db.MenuType.Remove(menuType);
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

    }
}
