using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL2
{
    public partial class New : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Nguoidung> U = (List<Nguoidung>)Application["Users"];
            String html = "";
               foreach(Nguoidung i in U)
                {
                    html += "<table><tr><td>" + i.usename + "</td><td>"+i.email +"</td></tr></table>";
                }
               anh.InnerHtml=html;
            
        }
    }
}