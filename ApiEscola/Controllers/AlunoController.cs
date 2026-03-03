using Microsoft.AspNetCore.Mvc;
using ApiEscola.Entidades;
using ApiEscola.Interfaces.Servicos;

namespace ApiEscola.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IServicoAluno _servicoAluno;

        public AlunoController(IServicoAluno servicoAluno)
        {
            _servicoAluno = servicoAluno;
        }

        [HttpGet("{id}")]
        public IActionResult RetornaAluno(long id)
        {
            var aluno = _servicoAluno.Retorna(id);
            if (aluno == null)
                return NotFound();

            return Ok(aluno);
        }

        [HttpGet]
        public IActionResult RetornaAlunos()
        {
            return Ok(_servicoAluno.RetornaTodos());
        }

        [HttpPost]
        public IActionResult Matricular([FromBody] Aluno aluno)
        {
            var criado = _servicoAluno.Matricular(aluno);
            if (criado == null)
                return BadRequest(_servicoAluno.Mensagens);

            return CreatedAtAction(nameof(RetornaAluno), new { id = criado.Id }, criado);
        }

        [HttpPut]
        public IActionResult Editar([FromBody] Aluno aluno)
        {
            var editado = _servicoAluno.Editar(aluno);
            if (editado == null)
                return NotFound();

            return Ok(editado);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(long id)
        {
            var aluno = _servicoAluno.Retorna(id);
            if (aluno == null)
                return NotFound();

            _servicoAluno.Excluir(aluno);
            return NoContent();
        }
    }
}
