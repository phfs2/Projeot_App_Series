using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dio_App.Classes
{
    public class Pessoa
    {   
        private string Nome { get; set; }
        private int Idade { get; set; }
        private string Login { get; set; }
        private string Senha { get; set; }
        private int Id { get; set;}
        private TipoAcesso Acesso { get; set; }
        private string Chave { get; set; }
        private bool IsValid { get; set; }
        public Pessoa(int id, TipoAcesso acesso,string nome, int idade, string Login, string Senha){
                this.Nome = nome;
                this.Idade = Idade;
                this.Id = id;
                this.Login = Login;
                this.Senha = Senha;
                this.Acesso = acesso;
                this.Chave = "dio";
                this.IsValid = true;
                
        }

        public bool RetornarIsValid(){
            return this.IsValid;
        }

        public void TirarAcesso(){
            this.IsValid = false;
        }

        public string retornarChave()
        {
            return this.Chave;
        }

        public TipoAcesso retornarAcesso()
		{
			return this.Acesso;
		}
         public string retornarNome()
		{
			return this.Nome;
		}
       
        public string retornarLogin()
		{
			return this.Login;
		}
        public string retornarSenha()
		{
			return this.Senha;
		}

		public int retornarId()
		{
			return this.Id;
		}


        public override string ToString()
		{
            string retorno = "";
            retorno += "Id: " + this.Id + Environment.NewLine;
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Login: " + this.Login + Environment.NewLine;
            retorno += "Idade: " + this.Idade + Environment.NewLine;
			return retorno;
		}

    }
}