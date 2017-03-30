using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Models;

namespace WingtipToys
{
    public partial class EditarCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {

            using (ContextoProduto contexto = new ContextoProduto())
            {
                Categoria c = new Categoria();

                c.Nome = txtNome.Text;
                c.Descricao = txtDescricao.Text;
                
                contexto.Categorias.Add(c);
                contexto.SaveChanges();
                Response.Redirect("/EditarCategoria.aspx");
            }
        }
    }
}