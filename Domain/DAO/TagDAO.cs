using Domain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Domain.DAO {
    public class TagDAO {
        private PetStoreDbContext db = null;

        public TagDAO() {
            this.db = new PetStoreDbContext();
        }

        public IEnumerable<Tag> ListAll() {
            return db.Tag.ToList();
        }



    }
}
