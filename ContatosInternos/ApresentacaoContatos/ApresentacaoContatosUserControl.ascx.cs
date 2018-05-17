using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;


namespace DBS.ContatosInternos.ApresentacaoContatos
{
    public partial class ApresentacaoContatosUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //CABEÇALHO
                TableRow cabecalho = new TableRow();
                //cabecalho.CssClass = "cabecalho_tabela_contatos";
                //cabecalho.CssClass = "grid_cabecalho";

                String[] itensCabecalho = new String[] { "Setor", "Colaborador", "Ramal", "ID Radio", "Celular", "E-mail" };
                foreach (String s in itensCabecalho)
                {
                    TableCell tc = new TableCell();
                    tc.Text = s;
                    tc.CssClass = "grid_cabecalho";
                    cabecalho.Cells.Add(tc);

                }
                tabela_contatos.Rows.Add(cabecalho);

                ////Lista de departamentos
                using (SPWeb oWebsiteRoot = SPContext.Current.Site.RootWeb)
                {
                    SPList usuarios = oWebsiteRoot.SiteUserInfoList;

                    if (usuarios.Items.Count > 0)
                    {
                        List<UsuarioExibicao> usuariosExibicao = new List<UsuarioExibicao>();

                        //Capturo todos os usuários para uma lista de objetos tipados
                        foreach (SPListItem item in usuarios.Items)
                        {
                            //Só aceita quem tem nome resumido
                            if (item["Nome Resumido"] != null)
                            {
                                UsuarioExibicao usuarioExibicao = new UsuarioExibicao();

                                usuarioExibicao.Ramal = item["Ramal"] == null ? "" : item["Ramal"].ToString();
                                usuarioExibicao.NomeResumido = item["Nome Resumido"] == null ? "" : item["Nome Resumido"].ToString();
                                usuarioExibicao.Nome = item["Nome"] == null ? "" : item["Nome"].ToString();
                                usuarioExibicao.Departamento = item["Setor"] == null ? "" : item["Setor"].ToString().Substring(item["Setor"].ToString().IndexOf("#")+1);

                                //Tratamento para item proveniente de outra lista
                                if (item["Setor"] != null)
                                {
                                    if (item["Setor"].ToString().Contains("#"))
                                    {
                                        //Como o item vem de uma outra lista, o nome deve chegar como "4;#Marketing". Vou remover os primeiros caracteres, deixando só os depois da #
                                        item["Setor"] = item["Setor"].ToString().Substring(item["Setor"].ToString().IndexOf("#") + 1);
                                    }
                                    usuarioExibicao.Departamento = item["Setor"].ToString();
                                }
                                else
                                {
                                    usuarioExibicao.Departamento = "";
                                }

                                usuarioExibicao.Email = item["PublishingContactEmail"] == null ? "" : item["PublishingContactEmail"].ToString();
                                usuarioExibicao.Cargo = item["Cargo"] == null ? "" : item["Cargo"].ToString();
                                usuarioExibicao.IdRadio = item["ID Radio"] == null ? "" : item["ID Radio"].ToString();
                                usuarioExibicao.Celular = item["Telefone Celular"] == null ? "" : item["Telefone Celular"].ToString();

                                usuariosExibicao.Add(usuarioExibicao);
                            }
                        }
                        List<UsuarioExibicao> usuariosOrdenados = new List<UsuarioExibicao>();

                        //Executo o sort via linq
                        var ordenados =
                            from u in usuariosExibicao
                            orderby u.Departamento, u.Nome
                            select new { u.Nome, u.NomeResumido, u.Email, u.IdRadio, u.Departamento, u.Ramal, u.Celular};

                        int contador = 0;
                        String depto = "";

                        foreach (var p in ordenados)
                        {
                            contador++;

                            //Se trocar de departamento
                            if (!p.Departamento.Equals(depto))
                            {
                                TableRow linhaDepto = new TableRow();

                                TableCell tcDepartamentoTitulo = new TableCell();
                                TableCell tcVazio = new TableCell();
                                TableCell tcVazio1 = new TableCell();
                                TableCell tcVazio2 = new TableCell();
                                TableCell tcVazio3 = new TableCell();
                                TableCell tcVazio4 = new TableCell();
                                tcDepartamentoTitulo.Text = p.Departamento;
                                tcVazio.Text = "";
                                //tcVazio.CssClass = "departamento";
                                //tcVazio.CssClass = "grid_setor";

                                linhaDepto.Cells.Add(tcDepartamentoTitulo);
                                linhaDepto.Cells.Add(tcVazio);
                                linhaDepto.Cells.Add(tcVazio1);
                                linhaDepto.Cells.Add(tcVazio2);
                                linhaDepto.Cells.Add(tcVazio3);
                                linhaDepto.Cells.Add(tcVazio4);      

                                //linhaDepto.CssClass = "departamento";  
                                linhaDepto.CssClass = "grid_setor";  

                                tabela_contatos.Rows.Add(linhaDepto);
                                depto = p.Departamento;
                                contador = 0;
                            }

                            Console.WriteLine(p.Nome + " - " + p.NomeResumido + " - " + p.Departamento);

                            TableCell tcNomeResumido = new TableCell();
                            TableCell tcDepartamento = new TableCell();
                            TableCell tcRamal = new TableCell();
                            TableCell tcIdRadio = new TableCell();
                            TableCell tcCelular = new TableCell();
                            TableCell tcEmail = new TableCell();

                            tcNomeResumido.Text = p.NomeResumido;
                            tcNomeResumido.CssClass = "grid_conteudo";
                            
                            tcDepartamento.Text = "";// p.Departamento;
                            tcDepartamento.CssClass = "grid_conteudo";

                            tcRamal.Text = p.Ramal;
                            tcRamal.CssClass = "grid_conteudo";

                            tcIdRadio.Text = p.IdRadio;
                            tcIdRadio.CssClass = "grid_conteudo";

                            tcCelular.Text = p.Celular;
                            tcCelular.CssClass = "grid_conteudo";

                            tcEmail.Text = p.Email;
                            tcEmail.CssClass = "grid_conteudo";

                            //{ "Departamento", "Colaborador", "Ramal", "ID Radio", "Celular", "E-mail" };
                            TableRow linha = new TableRow();
                            
                            linha.Cells.Add(tcDepartamento);
                            linha.Cells.Add(tcNomeResumido);                                                                                 
                            linha.Cells.Add(tcRamal);
                            linha.Cells.Add(tcIdRadio);
                            linha.Cells.Add(tcCelular);
                            linha.Cells.Add(tcEmail);
                            
                            /*
                            if (contador % 2 == 0)
                            {
                                //linha.CssClass = "fundo_escuro";
                                linha.CssClass = "grid_conteudo1";
                            }
                            else
                            {*/
                                //linha.CssClass = "fundo_claro";
                                //linha.CssClass = "grid_conteudo";
                            //}

                            tabela_contatos.Rows.Add(linha);
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

        }
    }
}