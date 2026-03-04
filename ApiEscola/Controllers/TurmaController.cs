using ApiEscola.Entidades;
using ApiEscola.Interfaces.Servicos;
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
            var turma = _servicoTurma.Retorna(id);
            if (turma == null)
                return NotFound();

            return Ok(turma);
        }

        [HttpGet]
        public IActionResult RetornaTurmas()
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
        public IActionResult Editar([FromBody] Turma turma)
        {
            var editado = _servicoTurma.Editar(turma);
            if (editado == null)
                return BadRequest(_servicoTurma.Mensagens);

            return Ok(editado);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(long id)
        {
            var turma = _servicoTurma.Retorna(id);
            if (turma == null)
                return NotFound();

            _servicoTurma.Excluir(turma);
            return NoContent();
        }

        // GET /turma/{idTurma}/alunos
        [HttpGet("{idTurma}/alunos")]
        public IActionResult RetornaAlunosDaTurma(long idTurma)
        {
            var turma = _servicoTurma.Retorna(idTurma);
            if (turma == null)
                return NotFound();

            return Ok(_servicoTurma.RetornaAlunosDaTurma(idTurma));
        }
    }
}
