using CRUDAPI.Model;
using CRUDAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CRUDAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _repository.BuscaTodosUsuarios();
            return usuarios.Any()
                    ? Ok(usuarios)
                    : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _repository.BuscaUsuario(id);
            return usuario != null
                    ? Ok(usuario)
                    : NotFound("Usuário não encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            _repository.AdicionaUsuario(usuario);

            return await _repository.SaveChangesAsync()
                    ? Ok("Usuário adicionado com sucésso")
                    : BadRequest("Erro ao salvar usuário");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Usuario usuario)
        {
            var usuariodb = await _repository.BuscaUsuario(id);
            if (usuariodb == null) return NotFound("Usuário não encontrado");

            usuariodb.Nome = usuario.Nome ?? usuariodb.Nome;
            usuariodb.DataNascimento = usuario.DataNascimento != new DateTime()
            ? usuario.DataNascimento : usuariodb.DataNascimento;

            _repository.AtualizaUsuario(usuariodb);

            return await _repository.SaveChangesAsync()
                    ? Ok("Usuário atualizado com sucésso")
                    : BadRequest("Erro ao atualizar usuário");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuariodb = await _repository.BuscaUsuario(id);
            if (usuariodb == null) return NotFound("Usuário não encontrado");

            _repository.DeletaUsuario(usuariodb);

            return await _repository.SaveChangesAsync()
                    ? Ok("Usuário deletado com sucésso")
                    : BadRequest("Erro ao deletar usuário");
        }

    }
}