using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.EF;
using System.Data.Entity;

namespace Domain.DAO {
    public class ContactDAO {
        private PetStoreDbContext db = null;
        public ContactDAO() {
            this.db = new PetStoreDbContext();
        }

        public Contact GetByID(long? id) {
            return db.Contact.Find(id);
        }

        public IEnumerable<Contact> ListAll() {
            return db.Contact.ToList();
        }

        public bool Create(Contact contact) {
            try {
                db.Contact.Add(contact);
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool Edit(Contact contact) {
            try {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool Delete(long id) {
            try {
                Contact contact = db.Contact.Find(id);
                db.Contact.Remove(contact);
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }
    }
}
