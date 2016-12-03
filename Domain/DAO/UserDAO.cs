using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.EF;
using PagedList;
using System.Data.Entity;
                
namespace Domain.DAO {
    public class UserDAO {
        private PetStoreDbContext data = null;
        public UserDAO() {
            this.data = new PetStoreDbContext();
        }

        public long Insert(User user) {
            data.Users.Add(user);
            data.SaveChanges();
            return user.ID;
        }

        public User GetByUername(string username) {
            return data.Users.SingleOrDefault(x => x.Username == username);
        }

        public User GetByID(long? id) {
            return data.Users.Find(id);
        }
        public bool Login(string username, string password) {
            var result = data.Users.Count(x => x.Username == username && x.Password == password);
            return result > 0 ? true : false;
        }

        // lấy danh sách theo từng page
        public IEnumerable<User> ListAllPaging(int page, int pageSize) {
            return data.Users.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public bool Edit(User user) {
            try {
                data.Entry(user).State = EntityState.Modified;
                data.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        public bool Delete(long id) {
            try {
                var user = GetByID(id);
                data.Users.Remove(user);
                data.SaveChanges();
                return true;
            } catch (Exception ex) {
                return false;
            }
        }
    }
}
