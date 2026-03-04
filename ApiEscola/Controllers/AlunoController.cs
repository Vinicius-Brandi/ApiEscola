using Microsoft.AspNetCore.Mvc;
using ApiEscola.Domain.Entidades;
using ApiEscola.Domain.Interfaces.Servicos;

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
        public IActionResult Adicionar([FromBody] Aluno aluno)
        {
            var criado = _servicoAluno.Incluir(aluno);
            if (criado == null)
                return BadRequest(_servicoAluno.Mensagens);

            return CreatedAtAction(nameof(RetornaAluno), new { id = criado.Id }, criado);
        }

        [HttpPut]
        public IActionResult Editar([FromBody] Aluno aluno)
        {
            var editado = _servicoAluno.Editar(aluno);
            if (editado == null)
                return BadRequest(_servicoAluno.Mensagens);

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

        // POST /aluno/{idAluno}/matricula
        [HttpPost("{idAluno}/matricula")]
        public IActionResult Matricular(long idAluno, [FromBody] long idTurma)
        {
            var matricula = new Matricula { IdAluno = idAluno, IdTurma = idTurma };
            var criado = _servicoAluno.Matricular(matricula);
            if (criado == null)
                return BadRequest(_servicoAluno.Mensagens);

            return Created(string.Empty, criado);
        }

        // DELETE /aluno/{idAluno}/matricula/{idTurma}
        [HttpDelete("{idAluno}/matricula/{idTurma}")]
        public IActionResult CancelarMatricula(long idAluno, long idTurma)
        {
            var cancelado = _servicoAluno.CancelarMatricula(idAluno, idTurma);
            if (!cancelado)
                return BadRequest(_servicoAluno.Mensagens);

            return NoContent();
        }

        // GET /aluno/{idAluno}/turmas
        [HttpGet("{idAluno}/turmas")]
        public IActionResult RetornaTurmasDoAluno(long idAluno)
        {
            var aluno = _servicoAluno.Retorna(idAluno);
            if (aluno == null)
                return NotFound();

            return Ok(_servicoAluno.RetornaTurmasDoAluno(idAluno));
        }
    }
}
