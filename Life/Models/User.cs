using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace Life.Models
{
    public class User
    {
 
        public int Id { get; set; }
        [Required(ErrorMessage = "CPF ou CNPJ é obrigatório.")]
        [RegularExpression(@"^\d{11}$|^\d{14}$", ErrorMessage = "Digite um CPF ou CNPJ válido.")]
        public string CpfCnpj { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Selecione o nicho de trabalho.")]
        public string NichoTrabalho { get; set; }
        public string Email { get; set; }
        public string TelefoneComercial { get; set; }
        public string Senha { get; set; }
        public string CpfOuCnpj { get; set; }

    }
}

