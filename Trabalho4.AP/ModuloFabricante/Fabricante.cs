namespace Trabalho4.AP.ModuloFabricante
{
    public class Fabricante
    {
        public int Id;
        public string Nome;
        public string Email;
        public string Telefone;

        public Fabricante(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
    }
}