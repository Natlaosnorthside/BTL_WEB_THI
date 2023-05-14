using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL2
{
    public partial class Dangnhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int lan = int.Parse(Session["dnsai"].ToString());
         
            if (IsPostBack)
            {
                String user = Request.Form.Get("user");
                String pass = Request.Form.Get("pass");
                int dem = 1;
                if (user != "" && pass != "")
                {
                    List<Nguoidung> users = (List<Nguoidung>)Application["Users"];

                    foreach (Nguoidung a in users)
                    {
                        if (user == a.usename)
                        {
                            dem = 0;
                            if (pass == a.password)
                            {
                                Session["usename"] = user;
                                Response.Redirect("Trangchu.aspx");
                                break;
                            }
                            else
                            {
                                lan++;
                                /*loi_mk1.InnerHtml = "Sai mật khẩu Lần thứ" + (lan);
                                Session["dnsai"] = lan;*/
                                if (lan > 3)
                                {
                                    lan = 0;
                                    Session["dnsai"] = lan;
                                    Response.Redirect("Trangchu.aspx");
                                    
                                }
                                else
                                {
                                    loi_mk1.InnerHtml = "Sai mật khẩu Lần thứ" + (lan);
                                    Session["dnsai"] = lan;
                                }
                            }
                        }

                    }
                    if (dem == 1) { 
                            loilogin.InnerHtml = "<p text-align='center'>Tài khoản không tồn tại!</p>";
                        }
                    }
                }
            }
        }
    }
