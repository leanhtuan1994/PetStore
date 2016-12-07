using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using System.Data.Entity;
using Domain.EF;

namespace Domain.DAO {
    public class OrdersDAO {
        private PetStoreDbContext db = null;
        public OrdersDAO() {
            this.db = new PetStoreDbContext();
        }

        public Orders GetByID(long? id) {
            return db.Orders.Find(id);
        }

        public IEnumerable<Orders> ListAll() {
            return db.Orders.Include(p => p.Customer);
        }

        public IPagedList<Orders> ListAllPaging(int page, int pageSize) {
            return db.Orders.Include(p => p.Customer).OrderByDescending(x => x.OrderDate).ToPagedList(page, pageSize);
        }

        public bool Create(Orders orders) {
            try {
                db.Orders.Add(orders);
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool Edit(Orders orders) {
            try {
                db.Entry(orders).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool Delete(long id) {
            try {
                Orders orders = db.Orders.Find(id);
                db.Orders.Remove(orders);
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }


    }
}
