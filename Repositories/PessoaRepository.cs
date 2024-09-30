using System.Collections.Generic;
using System.Linq;

public class PessoaRepository : IPessoaRepository
{
    private readonly List<Pessoa> _pessoas = new List<Pessoa>();

    public void Adicionar(Pessoa pessoa)
    {
        _pessoas.Add(pessoa);
    }

    public void Atualizar(Pessoa pessoa)
    {
        var existing = _pessoas.FirstOrDefault(p => p.Cpf == pessoa.Cpf);
        if (existing != null)
        {
            existing.Nome = pessoa.Nome;
            existing.Peso = pessoa.Peso;
            existing.Altura = pessoa.Altura;
        }
    }

    public void Remover(string cpf)
    {
        var pessoa = _pessoas.FirstOrDefault(p => p.Cpf == cpf);
        if (pessoa != null)
        {
            _pessoas.Remove(pessoa);
        }
    }

    public List<Pessoa> BuscarTodas()
    {
        return _pessoas;
    }

    public Pessoa BuscarPorCpf(string cpf)
    {
        return _pessoas.FirstOrDefault(p => p.Cpf == cpf);
    }

    public List<Pessoa> BuscarPorIMC()
    {
        return _pessoas.Where(p => p.CalcularIMC() >= 18 && p.CalcularIMC() <= 24).ToList();
    }

    public List<Pessoa> BuscarPorNome(string nome)
    {
        return _pessoas.Where(p => p.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}
