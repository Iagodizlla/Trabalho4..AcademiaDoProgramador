using Microsoft.Win32;
using System.Text.Json;
using System.Text.Json.Serialization;
using Trabalho4.AP.ModuloFabricante;

namespace Trabalho4.AP.Compartilhado;

public abstract class RepositorioBaseEmArquivo<T> where T : EntidadeBase<T>
{
    protected string caminhoPastaTemp = "C:\\tempo";
    protected string nomeArquivo;
    private List<T> registros = new List<T>();
    private int contadorIds;


    protected RepositorioBaseEmArquivo(string nomeArquivo)
    {
        this.nomeArquivo = nomeArquivo;

        registros = Deserializar();

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

        registros.Add(novoRegistro);

        Serializar();
    }

    public bool EditarRegistro(int idRegistro, T registroEditado)
    {
        foreach (var registro in registros)
        {
            if (registro.Id == idRegistro)
            {
                registro.AtualizarRegistro(registroEditado);

                Serializar();

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

    protected void Serializar()
    {
        string caminhoCompleto = Path.Combine(caminhoPastaTemp, nomeArquivo);

        JsonSerializerOptions jsonOpcoes = new JsonSerializerOptions();
        jsonOpcoes.WriteIndented = true;
        jsonOpcoes.ReferenceHandler = ReferenceHandler.Preserve;

        string json = JsonSerializer.Serialize(registros, jsonOpcoes);

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

        JsonSerializerOptions jsonOpcoes = new JsonSerializerOptions();
        jsonOpcoes.ReferenceHandler = ReferenceHandler.Preserve;

        registrosArmazenados = JsonSerializer.Deserialize<List<T>>(json, jsonOpcoes)!;

        return registrosArmazenados;
    }
}