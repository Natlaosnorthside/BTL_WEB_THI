using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL2
{
    public class Nguoidung
    {
        public String usename;
        public String email;
        public String password;
        public String repassword;
        public int sdt;

        public Nguoidung(string usename,string email,string password,string repassword,int sdt)
        {
            this.usename = usename;
            this.email = email;
            this.password = password;
            this.repassword = repassword;
            this.sdt = sdt;
        }
    }
}