using System.ComponentModel.DataAnnotations;

namespace Life.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? TelefoneComercial { get; set; }
        public string? Foto { get; set; }
        public int NichoTrabalho { get; set; }
        public string? Senha { get; set; }
        public string? CpfCnpj { get; set; }
        public DateTime DataCriacao { get; set; }

        public Nicho? Nicho { get; set; }
    }

    public class Nicho
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
    }
}