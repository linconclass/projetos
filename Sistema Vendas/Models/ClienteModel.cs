using SistemaVendas.Uteis;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Sistema_Vendas.Models
{
    public class ClienteModel
    {
        public string? Id { get; set; }

        [Required(ErrorMessage ="Informe o Nome do cliente")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Informe o CPF ou CNPJ do cliente")]
        public string? CPF { get; set; }

        [Required(ErrorMessage = "Informe o Email do cliente")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido!")]
        public string? Email { get; set; }

        public string? Senha { get; set; }

        public List<ClienteModel> ListarTodosClientes()
        {
            List<ClienteModel> lista = new List<ClienteModel>();
            ClienteModel item;
            DAL objDAL = new();
            string sql =
                "SELECT id, nome, cpf_cnpj, email, senha " +
                "FROM Cliente order by nome asc";

            DataTable dt = objDAL.RetDataTable(sql);
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    item = new ClienteModel
                    {
                        Id = dt.Rows[i]["Id"].ToString(),
                        Nome = dt.Rows[i]["Nome"].ToString(),
                        CPF = dt.Rows[i]["cpf_cnpj"].ToString(),
                        Email = dt.Rows[i]["Email"].ToString(),
                        Senha = dt.Rows[i]["Senha"].ToString()
                    };
                    lista.Add(item);
                }
            }
            return lista;
        }

        public void Inserir()
        {
            DAL objDAL = new DAL();
            string sql = $"INSERT INTO CLIENTE(nome, cpf_cnpj, email, senha) VALUES('{Nome}','{CPF}','{Email}','cliente123')";
            objDAL.ExecutarComandoSQL(sql);
        }
    }
}
