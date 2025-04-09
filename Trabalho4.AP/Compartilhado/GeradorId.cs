namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado;

public static class GeradorIds
{
    public static int IdFabricantes = 0;
    public static int IdEquipamentos = 0;
    public static int IdChamados = 0;

    public static int GerarIdEquipamento()
    {
        IdEquipamentos++;

        return IdEquipamentos;
    }

    public static int GerarIdChamado()
    {
        IdChamados++;

        return IdChamados;
    }

    public static int GerarIdFabricante()
    {
        IdFabricantes++;

        return IdFabricantes;
    }
}