using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL2
{
    public partial class Trangchu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {
            if (Session["usename"] != null)
            {

                login.InnerHtml = "<p class='user'>Xin chào " + Session["usename"].ToString() + " | " + "</p>" +
                                  "<a href = 'Dangxuat.aspx'> Đăng xuất </a>";

                if (Request.Cookies["cart"] != null)
                {
                    List<Product> cartList = new List<Product>();
                    List<Product> productList = (List<Product>)Application["ProductList"];
                    string[] productsID = Request.Cookies["cart"].Value.Split(',');
                    foreach (string productID in productsID)
                    {
                        foreach (Product product in productList)
                        {
                            if (product.Id == productID)
                            {

                                cartList.Add(product);

                            }
                        }
                        sogiohang.InnerHtml = "<p> ( " + cartList.Count.ToString() + ")</p>";
                    }
                }

            } 

                List<Product> ProductList = (List<Product>)Application["productList"];
                List<Product> banchay = new List<Product>();
                List<Product> timkiem = new List<Product>();
                string tensp = Request.Form["timkiemsanpham"];

             


                foreach (Product product in ProductList)
                {
                    string id = product.Id;
                    if (id == "1" || id == "2" || id == "3" || id == "4" || id == "5" || id == "6" || id == "7" || id == "8")
                    {
                        banchay.Add(product);
                    }


                }
                sanphambanchay.DataSource = banchay;
                sanphambanchay.DataBind();


            }

        }
    }
