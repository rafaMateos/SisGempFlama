using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _01_HelloWorld_WebFornms.Entidades;

namespace _01_HelloWorld_WebFornms
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSaludar_Click(object sender, EventArgs e)
        {
            /*
            String texto;
            //texto = this.TextBox1.Text; //Equivalente al de abajo
            texto = Request.Form["ctl00$MainContent$TextBox1"]; //Debemos el coger el nombre que ha generado el name

            lblResultado.Text = $"Hola {texto}"; 
            */
            clsPersona objeto = new clsPersona();
            objeto.nombre = "Rafa";
            objeto.apellidos = "Mateos";

            lblResultado.Text = $"Soy el objeto {objeto.nombre} {objeto.apellidos}";
            
        }
    }
}