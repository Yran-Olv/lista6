using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class PessoaController : ControllerBase
{
    private readonly IPessoaRepository _pessoaRepository;

    public PessoaController(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }

    [HttpPost]
    public IActionResult AdicionarPessoa([FromBody] Pessoa pessoa)
    {
        _pessoaRepository.Adicionar(pessoa);
        return Ok();
    }

    [HttpPut]
    public IActionResult AtualizarPessoa([FromBody] Pessoa pessoa)
    {
        _pessoaRepository.Atualizar(pessoa);
        return Ok();
    }

    [HttpDelete("{cpf}")]
    public IActionResult RemoverPessoa(string cpf)
    {
        _pessoaRepository.Remover(cpf);
        return Ok();
    }

    [HttpGet]
    public IActionResult BuscarTodas()
    {
        var pessoas = _pessoaRepository.BuscarTodas();
        return Ok(pessoas);
    }

    [HttpGet("{cpf}")]
    public IActionResult BuscarPorCpf(string cpf)
    {
        var pessoa = _pessoaRepository.BuscarPorCpf(cpf);
        if (pessoa == null) return NotFound();
        return Ok(pessoa);
    }

    [HttpGet("imc-bom")]
    public IActionResult BuscarPorIMC()
    {
        var pessoas = _pessoaRepository.BuscarPorIMC();
        return Ok(pessoas);
    }

    [HttpGet("buscar-nome/{nome}")]
    public IActionResult BuscarPorNome(string nome)
    {
        var pessoas = _pessoaRepository.BuscarPorNome(nome);
        return Ok(pessoas);
    }
}
