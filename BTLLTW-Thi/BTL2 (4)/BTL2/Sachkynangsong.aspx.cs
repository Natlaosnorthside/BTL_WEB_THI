using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL2
{
    public partial class Sachkynangsong : System.Web.UI.Page
    {
        protected void getProductsListBySearch(string search, List<Product> productsListsBySearch, List<Product> productsLists)
        {
            foreach (Product product in productsLists)
            {
                if (product.Name.ToLower().IndexOf(search) != -1)
                {
                    productsListsBySearch.Add(product);
                }
            }
            sachkynangsong1.DataSource = productsListsBySearch;
            sachkynangsong1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usename"] != null)
            {
                login.InnerHtml = "<p class='user'>Xin chào " + Session["usename"].ToString() + " | " + "</p>" +
                                  "<a href = 'Dangxuat.aspx'> Đăng xuất </a>";

            }

            List<Product> ProductList = (List<Product>)Application["productList"];
            List<Product> sach = new List<Product>();
            string search = Request.QueryString.Get("search");
            if (search != null)
            {
                search = search.ToLower();
                Page.Title = "Tìm kiếm";


                List<Product> productsListBySearch = new List<Product>();

                getProductsListBySearch(search, productsListBySearch, ProductList);
            }
            else
            {
                foreach (Product product in ProductList)
                {
                    sach.Add(product);

                }
                sachkynangsong1.DataSource = sach;
                sachkynangsong1.DataBind();
            }


        }
        protected void search_button_ServerClick(object sender, EventArgs e)
        {
            string searchText = "";

            if (search_text.Value != "")
            {
                searchText = search_text.Value.ToLower();
            }

            Response.Redirect($"Sachkynangsong.aspx?search={searchText}");
        }

    }
}
