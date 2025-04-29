using Microsoft.Win32;
using System.Text.Json;
using Trabalho4.AP.ModuloFabricante;

namespace Trabalho4.AP.Compartilhado;

public abstract class RepositorioBaseEmArquivo<T> where T : EntidadeBase<T>
{
    protected string caminhoPastaTemp = "C:\\tempo";
    protected string nomeArquivo;
    private T[] registros = new T[100];
    private int contadorIds;


    protected RepositorioBaseEmArquivo(string nomeArquivo)
    {
        this.nomeArquivo = nomeArquivo;

        registros = Deserializar().ToArray();

        int maiorId = 0;

        foreach (var registro in registros)
        {
            if(registro.Id > maiorId)
                maiorId = registro.Id;
        }
        contadorIds = maiorId;
    }
    public void CadastrarRegistro(T novoRegistro)
    {
        novoRegistro.Id = ++contadorIds;

        InserirRegistro(novoRegistro);

        Serializar();
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

                Serializar();

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

                Serializar();

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

    public void InserirRegistro(T registro)
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
    protected void Serializar()
    {
        string caminhoCompleto = Path.Combine(caminhoPastaTemp, nomeArquivo);
        string json = JsonSerializer.Serialize(registros);

        if (!Directory.Exists(caminhoPastaTemp))
            Directory.CreateDirectory(caminhoPastaTemp);

        File.WriteAllText(caminhoCompleto, json);
    }
    protected List<T> Deserializar()
    {
        List<T> registrosArmazenados = [];
        string caminhoCompleto = Path.Combine(caminhoPastaTemp, nomeArquivo);

        if (!File.Exists(caminhoCompleto))
            return registrosArmazenados;

        string json = File.ReadAllText(caminhoCompleto);

        if (string.IsNullOrWhiteSpace(json))
            return registrosArmazenados;

        registrosArmazenados = JsonSerializer.Deserialize<List<T>>(json)!;

        return registrosArmazenados;
    }
}