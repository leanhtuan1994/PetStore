using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.EF;
using PagedList;


namespace Domain.DAO {
    public class FeedbackDAO {
        private PetStoreDbContext db = null;
        public FeedbackDAO() {
            this.db = new PetStoreDbContext();
        }


        public Feedback GetByID(long? id) {
            return db.Feedback.Find(id);
        }

        public IEnumerable<Feedback> ListAll() {
            return db.Feedback.ToList();
        }

        public IPagedList<Feedback> ListAllPaging(int page, int pageSize) {
            return db.Feedback.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public bool Create(Feedback feedback) {
            try {
                db.Feedback.Add(feedback);
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool Create(string name, string phone, string address, string email, string content) {
            try {
                Feedback feed = new Feedback();
                feed.Name = name;
                feed.Phone = phone;
                feed.Address = address;
                feed.Email = email;
                feed.CreatedDate = DateTime.Now;
                feed.Status = true;
                this.Create(feed);
                return true;
            } catch (Exception ex) {
                return false;
            }
        }


        public bool Edit(Feedback feedback) {
            try {
                db.Entry(feedback).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool Delete(long id) {
            try {
                Feedback feedback = db.Feedback.Find(id);
                db.Feedback.Remove(feedback);
                db.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

    }
}
