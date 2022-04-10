using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using SistemaVendas.Uteis;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Vendas.Models
{
    public class LoginModel
    {
        public string? Id { get; set; }
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Informe o e-mail do usuário!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido!")]
        public string? Email { get; set; }
        //public string Email { get => Email; set => Email = value; }

        [Required(ErrorMessage = "Informe a senha do usuário!")]
        public string? Senha { get; set; }
        //public string Senha { get => Senha; set => Senha = value; }


        //Existe um problema grave de segurança com essa abordagem => SQL Inject
        //Vamos depois criar um método mais adequado na próxima aula
        public bool ValidarLogin()
        {
            string sql = $"SELECT ID, NOME FROM VENDEDOR WHERE EMAIL='{Email}' AND SENHA='{Senha}'";

            DAL objDAL = new();
            DataTable dt = objDAL.RetDataTable(sql);
            if(dt.Rows.Count == 1)
            {
                Id = dt.Rows[0]["ID"].ToString();
                Nome = dt.Rows[0]["NOME"].ToString();
                return true;
            }
            return false;
        }
    }
}
