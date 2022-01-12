using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dio_App.Interfaces;

namespace Dio_App.Classes
{
    public class PessoaRepositorio : IPessoa<Pessoa>
    {
         private List<Pessoa> listaPessoa = new List<Pessoa>();

         public void InserirPessoa(Pessoa nova)
         {  
             listaPessoa.Add(nova);
         }
        
         public void atualizarCadastro(int id, Pessoa atualizada)
         {
             listaPessoa[id] = atualizada;
         }


         public List<Pessoa> Lista(){

             return listaPessoa;
         }
              
         public int ProximoId()
         {
            return listaPessoa.Count;
         }

         public void BloquearAcesso(int id)
         {
            listaPessoa[id].TirarAcesso();
            
         }

        public Pessoa retornaPorId(int id)
        {
            return listaPessoa[id];
        }
    }
}