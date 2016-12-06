using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PagedList;
using Domain.EF;

namespace Domain.DAO {
    public class OrderDetailDAO {
        private PetStoreDbContext db = null;
        public OrderDetailDAO() {
            this.db = new PetStoreDbContext();
        }

        public IEnumerable<OrderDetail> ListAll() {
            return db.OrderDetail.Include(o => o.Orders).Include(o => o.Product);
        }

        public IPagedList<OrderDetail> ListAllPaging(int page, int pageSize) {
            return db.OrderDetail.OrderByDescending(o => o.OrderID).ToPagedList(page, pageSize);
        }

        public OrderDetail GetByID(long? orderID, long? productID ) {
            return db.OrderDetail.SingleOrDefault(x => x.OrderID == orderID && x.ProductID == productID);
        }

        public bool Create(OrderDetail orderDetail) {
            try {
                db.OrderDetail.Add(orderDetail);
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool Edit(OrderDetail orderDetail) {
            try {
                db.Entry(orderDetail).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool Delete(long orderID, long productID) {
            try {
                OrderDetail orderDetail = db.OrderDetail.Find(orderID, productID);
                db.OrderDetail.Remove(orderDetail);
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }




    }
}
