using Microsoft.Win32;
using System.Text.Json;
using System.Text.Json.Serialization;
using Trabalho4.AP.ModuloFabricante;

namespace Trabalho4.AP.Compartilhado;

public abstract class RepositorioBaseEmArquivo<T> where T : EntidadeBase<T>
{
    private List<T> registros = new List<T>();
    private int contadorIds;
    protected ContextoDados contexto;

    protected RepositorioBaseEmArquivo(ContextoDados contexto)
    {
        this.contexto = contexto;

        registros = ObterRegistros();

        int maiorId = 0;

        foreach (var registro in registros)
        {
            if(registro.Id > maiorId)
                maiorId = registro.Id;
        }
        contadorIds = maiorId;
    }
    protected abstract List<T> ObterRegistros();
    public void CadastrarRegistro(T novoRegistro)
    {
        novoRegistro.Id = ++contadorIds;

        registros.Add(novoRegistro);

        contexto.Salvar();
    }

    public bool EditarRegistro(int idRegistro, T registroEditado)
    {
        foreach (var registro in registros)
        {
            if (registro.Id == idRegistro)
            {
                registro.AtualizarRegistro(registroEditado);

                contexto.Salvar();

                return true;
            }
        }
        return false;
    }

    public bool ExcluirRegistro(int idRegistro)
    {
        T registroSelecionado = SelecionarRegistroPorId(idRegistro);

        if (registroSelecionado != null)
        {
            registros.Remove(registroSelecionado);

            contexto.Salvar();
            
            return true;
        }

        return false;
    }

    public List<T> SelecionarRegistros()
    {
        return registros;
    }

    public T SelecionarRegistroPorId(int idRegistro)
    {
        foreach (var registro in registros)
        {
            if (registro.Id == idRegistro)
                return registro;
        }
        return null!;
    }
}