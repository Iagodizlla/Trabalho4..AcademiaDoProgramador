namespace Trabalho4.AP.Compartilhado;

public abstract class RepositorioBase
{
    private EntidadeBase[] registros = new EntidadeBase[100];
    private int contadorIds = 0;

    public void CadastrarRegistro(EntidadeBase novoRegistro)
    {
        novoRegistro.Id = ++contadorIds;

        InserirRegistro(novoRegistro);
    }

    public bool EditarRegistro(int idRegistro, EntidadeBase registroEditado)
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

    public EntidadeBase[] SelecionarRegistros()
    {
        return registros;
    }

    public EntidadeBase SelecionarRegistroPorId(int idRegistro)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            EntidadeBase e = registros[i];

            if (e == null)
                continue;

            else if (e.Id == idRegistro)
                return e;
        }

        return null!;
    }

    private void InserirRegistro(EntidadeBase registro)
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