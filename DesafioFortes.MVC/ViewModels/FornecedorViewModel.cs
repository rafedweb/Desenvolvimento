using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DesafioFortes.MVC.ViewModels
{
    public class FornecedorViewModel
    {
        [Key]
        public int FornecedorID { get; set; }             

        [Required(ErrorMessage = "Preencha o campo CNPJ")]       
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Preencha o campo RazaoSocial")]
        [MaxLength(150, ErrorMessage = "Maximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Preencha o campo UF")]
        public string UF { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(100, ErrorMessage = "Maximo {0} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail válido")]
        [DisplayName("E-mail")]
        public string EmailContato { get; set; }

        [Required(ErrorMessage = "Preencha o campo NomeContatos")]
        [MaxLength(150, ErrorMessage = "Maximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string NomeContato { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

        public virtual IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}