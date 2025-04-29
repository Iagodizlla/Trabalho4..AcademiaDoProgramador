using Microsoft.Win32;
using System.Text.Json.Serialization;
using System.Text.Json;
using Trabalho4.AP.ModuloChamado;
using Trabalho4.AP.ModuloEquipamento;
using Trabalho4.AP.ModuloFabricante;
namespace Trabalho4.AP.Compartilhado;

public class ContextoDados
{
    public List<Chamado> Chamados { get; set; }
    public List<Equipamento> Equipamentos { get; set; }
    public List<Fabricante> Fabricantes { get; set; }

    protected string pastaArmazenamento = "C:\\tempo";
    protected string arquivoArmazenamento = "dados.json";

    public ContextoDados()
    {
        Fabricantes = new List<Fabricante>();
        Chamados = new List<Chamado>();
        Equipamentos = new List<Equipamento>();
    }
    public ContextoDados(bool carregarDados) : this()
    {
        if (carregarDados)
            Carregar();
    }
    public void Salvar()
    {
        string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

        JsonSerializerOptions jsonOpcoes = new JsonSerializerOptions();
        jsonOpcoes.WriteIndented = true;
        jsonOpcoes.ReferenceHandler = ReferenceHandler.Preserve;

        string json = JsonSerializer.Serialize(this, jsonOpcoes);

        if (!Directory.Exists(pastaArmazenamento))
            Directory.CreateDirectory(pastaArmazenamento);

        File.WriteAllText(caminhoCompleto, json);
    }
    private void Carregar()
    {
        string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

        if (!File.Exists(caminhoCompleto)) return;

        string json = File.ReadAllText(caminhoCompleto);

        if (string.IsNullOrWhiteSpace(json)) return;

        JsonSerializerOptions jsonOpcoes = new JsonSerializerOptions();
        jsonOpcoes.ReferenceHandler = ReferenceHandler.Preserve;

        ContextoDados contextoArmazenado = JsonSerializer.Deserialize<ContextoDados>(json, jsonOpcoes)!;

        if(contextoArmazenado == null) return;

        this.Fabricantes = contextoArmazenado.Fabricantes;
        this.Equipamentos = contextoArmazenado.Equipamentos;
        this.Chamados = contextoArmazenado.Chamados;
    }
}