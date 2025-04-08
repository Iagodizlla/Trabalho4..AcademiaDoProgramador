using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace Trabalho4.AP.ModuloFabricante
{
    public class TelaFabricante
    {
        public RegistroFabricante registroFabricante;
        public TelaFabricante()
        {
            registroFabricante = new RegistroFabricante();
        }
        public void CadastrarFabricante()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Gestão de Fabricantes");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Cadastrando Fabricante...");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine();

            Console.Write("Digite o nome do fabricante: ");
            string nome = Console.ReadLine()!;

            Console.Write("Digite o email do fabricante: ");
            string email = Console.ReadLine()!;

            Console.Write("Digite o telefone do fabricante: ");
            string telefone = Console.ReadLine()!;

            Fabricante novoFabricante = new Fabricante(nome, email, telefone);

            registroFabricante.CadastrarFabricante(novoFabricante);
        }
        public void VisualizarFabricantes(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Gestão de fabricantes");
                Console.WriteLine("--------------------------------------------");

                Console.WriteLine("Visualizando Fabricante...");
                Console.WriteLine("--------------------------------------------");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -35} | {3, -20}",
                "Id", "Nome", "E-mail", "Telefone"
            );

            Fabricante[] fabricantesCadastrados = registroFabricante.SelecionarFabricantes();

            for (int i = 0; i < fabricantesCadastrados.Length; i++)
            {
                Fabricante e = fabricantesCadastrados[i];

                if (e == null) continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -35} | {3, -20}",
                    e.Id, e.Nome, e.Email, e.Telefone
                );
            }
        }
    }
}