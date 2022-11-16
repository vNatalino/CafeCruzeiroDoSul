using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PIT.Models.Usuarios
{
    [Table("TblUsuarios")]
    public class Usuario
    {
        public int UsuarioID { get; set; }
        [Display(Name = "Nome: ")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }
        [Display(Name = "Email: ")]
        [EmailAddress(ErrorMessage = "Digite um email válido")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Email { get; set; }
        [Display(Name = "Telefone: ")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Endereço: ")]
        public string Endereco { get; set; }
        [Display(Name = "Senha: ")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Senha { get; set; }
        [NotMapped]
        [Display(Name = "Confirmar Senha: ")]
        [Compare("Senha", ErrorMessage = "A senha não é compatível")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string ConfirmaSenha { get; set; }
    }
}
