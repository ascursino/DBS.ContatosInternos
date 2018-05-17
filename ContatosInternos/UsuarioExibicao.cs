using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBS.ContatosInternos
{
    class UsuarioExibicao
    {
        private String nomeResumido;

        public String NomeResumido
        {
            get { return nomeResumido; }
            set { nomeResumido = value; }
        }

        private String nome;        

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        private String cargo;

        public String Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }
        
        private String departamento;

        public String Departamento
        {
            get { return departamento; }
            set { departamento = value; }
        }
        private String ramal;

        public String Ramal
        {
            get { return ramal; }
            set { ramal = value; }
        }
        private String idRadio;

        public String IdRadio
        {
            get { return idRadio; }
            set { idRadio = value; }
        }
        private String celular;

        public String Celular
        {
            get { return celular; }
            set { celular = value; }
        }
        private String email;

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

    }
}
