using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.EF;


namespace Domain.DAO {
    public class ProductDAO {
        private PetStoreDbContext db = null;
        public ProductDAO() {
            this.db = new PetStoreDbContext();
        }


    }
}
