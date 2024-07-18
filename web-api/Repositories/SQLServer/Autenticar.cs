using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace web_api.Repositories.SQLServer
{
    public class Autenticar
    {
        private readonly SqlConnection conn;
        private readonly SqlCommand cmd;

        public Autenticar(string ConnectionString)
        {
            this.conn = new SqlConnection(ConnectionString);
            this.cmd = new SqlCommand
            {
                Connection = this.conn
            };
        }
        
        public async Task<bool> Select(Models.Login login)
        {
            bool validacao = false;

            using (this.conn)
            {
                await this.conn.OpenAsync();

                using (this.cmd)
                {
                    this.cmd.CommandText = "select email, senha from usuario where email = @email and senha = @senha";
                    cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar)).Value = login.Email;
                    cmd.Parameters.Add(new SqlParameter("@senha", SqlDbType.VarChar)).Value = login.Senha;

                    using (SqlDataReader dr = await this.cmd.ExecuteReaderAsync()){

                        if (await dr.ReadAsync())
                        {
                            validacao = true;
                        }
                    }
                }
            }
            return validacao;
        }
    }
}