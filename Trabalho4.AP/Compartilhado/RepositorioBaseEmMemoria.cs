namespace Trabalho4.AP.Compartilhado;

public abstract class RepositorioBaseEmMemoria<T> where T : EntidadeBase<T>
{
    private T[] registros = new T[100];
    private int contadorIds = 0;

    public void CadastrarRegistro(T novoRegistro)
    {
        novoRegistro.Id = ++contadorIds;

        InserirRegistro(novoRegistro);
    }

    public bool EditarRegistro(int idRegistro, T registroEditado)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null)
                continue;

            else if (registros[i].Id == idRegistro)
            {
                registros[i].AtualizarRegistro(registroEditado);

                return true;
            }
        }

        return false;
    }

    public bool ExcluirRegistro(int idRegistro)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null)
                continue;

            else if (registros[i].Id == idRegistro)
            {
                registros[i] = null!;
                return true;
            }
        }

        return false;
    }

    public T[] SelecionarRegistros()
    {
        return registros;
    }

    public T SelecionarRegistroPorId(int idRegistro)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            T e = registros[i];

            if (e == null)
                continue;

            else if (e.Id == idRegistro)
                return e;
        }

        return null!;
    }

    private void InserirRegistro(T registro)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null)
            {
                registros[i] = registro;
                return;
            }
        }
    }
}