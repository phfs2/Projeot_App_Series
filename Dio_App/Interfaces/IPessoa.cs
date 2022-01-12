using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dio_App.Interfaces
{
    public interface IPessoa<T>
    {
        List<T> Lista();
        void InserirPessoa(T entidade); 
        void atualizarCadastro(int Id, T entidade);      
        int ProximoId();
        T retornaPorId(int id);
        void BloquearAcesso(int id);



    }
        
}
        

