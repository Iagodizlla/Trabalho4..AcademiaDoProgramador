namespace Trabalho4.AP.Compartilhado;

public abstract class RepositorioBaseEmMemoria<T> where T : EntidadeBase<T>
{
    private List<T> registros = new List<T>();
    private int contadorIds = 0;

    public void CadastrarRegistro(T novoRegistro)
    {
        novoRegistro.Id = ++contadorIds;

        registros.Add(novoRegistro);
    }

    public bool EditarRegistro(int idRegistro, T registroEditado)
    {
        foreach (var registro in registros)
        {
            if (registro.Id == idRegistro)
            {
                registro.AtualizarRegistro(registroEditado);

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
