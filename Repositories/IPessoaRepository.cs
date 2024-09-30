using System.Collections.Generic;

public interface IPessoaRepository
{
    void Adicionar(Pessoa pessoa);
    void Atualizar(Pessoa pessoa);
    void Remover(string cpf);
    List<Pessoa> BuscarTodas();
    Pessoa BuscarPorCpf(string cpf);
    List<Pessoa> BuscarPorIMC();
    List<Pessoa> BuscarPorNome(string nome);
}
