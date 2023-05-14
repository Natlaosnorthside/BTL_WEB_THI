using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string usename = Request.Form.Get("user");
                string password = Request.Form.Get("pass");
                string repassword = Request.Form.Get("repass");
                string email = Request.Form.Get("email");
                string sdt = Request.Form.Get("sdt");
                int dt = Convert.ToInt32(sdt);
                List<Nguoidung> Users = (List<Nguoidung>)Application["Users"];
                bool check = true;
              
                if (usename != "" && password != "" && repassword != "" && email != "")
                {
                    foreach (Nguoidung user in Users)
                    {
                        if (usename == user.usename)
                        {
                            loi_tk.InnerHtml = "Tài khoản đã có người sử dụng";
                            check = false;
                        }
                    }
                    
                }
                    if(check)
                    {
                            check = true;
                            login2.InnerHtml = "Đăng kí thành công";
                            Nguoidung newuser = new Nguoidung(usename, email ,password, repassword,dt);
                            Users.Add(newuser);
                            Application["Users"] = Users;
                    }
                }
            }
        }
    }
