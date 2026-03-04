using ApiEscola.Entidades;
using ApiEscola.Interfaces.Servicos;
using ApiEscola.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace ApiEscola.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TurmaController : ControllerBase
    {
        private readonly IServicoTurma _servicoTurma;
        public TurmaController(IServicoTurma servicoTurma)
        {
            _servicoTurma = servicoTurma;
        }
        [HttpGet("{id}")]
        public IActionResult RetornaTurma(long id)
        {
            var aluno = _servicoTurma.Retorna(id);
            if (aluno == null)
                return NotFound();

            return Ok(aluno);
        }

        [HttpGet]
        public IActionResult RetornaTurma()
        {
            return Ok(_servicoTurma.RetornaTodos());
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] Turma turma)
        {
            var criado = _servicoTurma.Incluir(turma);
            if (criado == null)
                return BadRequest(_servicoTurma.Mensagens);

            return CreatedAtAction(nameof(RetornaTurma), new { id = criado.Id }, criado);
        }

        [HttpPut]
        public IActionResult Editar([FromBody] Turma aluno)
        {
            var editado = _servicoTurma.Editar(aluno);
            if (editado == null)
                return NotFound();

            return Ok(editado);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(long id)
        {
            var aluno = _servicoTurma.Retorna(id);
            if (aluno == null)
                return NotFound();

            _servicoTurma.Excluir(aluno);
            return NoContent();
        }
    }
}
