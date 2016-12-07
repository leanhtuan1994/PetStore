using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.EF;

namespace Domain.DAO {
    public class FooterDAO {
        private PetStoreDbContext db = null;
        public FooterDAO() {
            this.db = new PetStoreDbContext();
        }

        public IEnumerable<Footer> ListAll() {
            return db.Footer.ToList();
        }

        public Footer GetFooter() {
            return db.Footer.SingleOrDefault(x => x.Status == true);
        }
    }
}
