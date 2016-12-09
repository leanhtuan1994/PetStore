using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Domain.EF;
using System.Data.Entity;

namespace Domain.DAO {
   public  class CustomerDAO {
        private PetStoreDbContext db = null;
        public CustomerDAO() {
            this.db = new PetStoreDbContext();
        }

        public IEnumerable<Customer> ListAll() {
            return db.Customer.ToList();
        }

        public IPagedList<Customer> ListAllPaging(int page, int pageSize) {
            return db.Customer.OrderByDescending(c => c.CreatedDate).ToPagedList(page, pageSize);
        }

        public Customer GetByID(long? id) {
            return db.Customer.Find(id);
        }

        public bool Create(Customer customer) {
            try {
                db.Customer.Add(customer);
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }
        public long? Create(string name, string address, string email, string phone, string shipName, string shipAddress, string shipPhone) {
            try {
                var customer = new Customer();
                customer.CreatedDate = DateTime.Now;
                customer.Name = name;
                customer.Address = address;
                customer.Email = email;
                customer.Phone = phone;
                customer.ShipName = shipName;
                customer.ShipAddress = shipAddress;
                customer.ShipPhone = phone;

                this.Create(customer);
                return customer.ID;
            } catch( Exception ex) {
                return null;
            }

        }


        public bool Edit(Customer customer) {
            try {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool Delete(long id) {
            try {
                Customer customer = db.Customer.Find(id);
                db.Customer.Remove(customer);
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

    }
}
