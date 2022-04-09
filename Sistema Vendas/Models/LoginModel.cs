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
        [Required(ErrorMessage="Informe o e-mail do usuário!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="O e-mail informado é inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário!")]  
        public string Senha { get; set; }


        //Existe um problema grave de segurança com essa abordagem => SQL Inject
        //Vamos depois criar um método mais adequado na próxima aula
        public bool ValidarLogin()
        {
            string sql = $"SELECT ID FROM VENDEDOR WHERE EMAIL='{Email}' AND SENHA='{Senha}'";

            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);
            if(dt.Rows.Count == 1)
            {
                return true;
            }
            return false;
        }
    }
}
