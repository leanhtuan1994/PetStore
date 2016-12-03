using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Common {

    [Serializable]
    public class UserLogin {
        public long UserID {
            get;    set;
        }

        public string Username {
            get;    set;
        }

        public bool RememberMe {
            get;    set;
        }
    }
}