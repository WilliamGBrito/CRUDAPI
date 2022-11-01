using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDAPI.Model;

namespace CRUDAPI.Repository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> BuscaTodosUsuarios();

        Task<Usuario> BuscaUsuario(int id);

        void AdicionaUsuario(Usuario usuario);
        void AtualizaUsuario(Usuario usuario);
        void DeletaUsuario(Usuario usuario);

        Task<bool> SaveChangesAsync();
    }
}