using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace web_api.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsuariosController : ApiController
    {
        private readonly Repositories.SQLServer.Usuario repoUsuario;

        public UsuariosController()
        {
            this.repoUsuario = new Repositories.SQLServer.Usuario(Configurations.Database.getConnectionString());
        }

        // GET: api/Usuarios
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                return Ok(await this.repoUsuario.Select());
            }
            catch (Exception ex)
            {
                Utils.Logger.WriteException(Configurations.Logger.GetFullPath(), ex);
                return InternalServerError();
            }
        }

        // GET: api/Usuarios/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                Models.Usuario usuario = await this.repoUsuario.Select(id);

                if (usuario is null)
                    return NotFound();

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                Utils.Logger.WriteException(Configurations.Logger.GetFullPath(), ex);
                return InternalServerError();
            }
        }

        // GET: api/Usuarios?nome=
        public async Task<IHttpActionResult> Get(string nome)
        {
            try
            {              
                return Ok(await this.repoUsuario.Select(nome));
            }
            catch (Exception ex)
            {
                Utils.Logger.WriteException(Configurations.Logger.GetFullPath(), ex);
                return InternalServerError();
            }
        }

        // POST: api/Usuarios
        public async Task<IHttpActionResult> Post([FromBody]Models.Usuario usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await this.repoUsuario.Insert(usuario);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                Utils.Logger.WriteException(Configurations.Logger.GetFullPath(), ex);
                return InternalServerError();
            }
        }

        // PUT: api/Usuarios/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] Models.Usuario usuario)
        {
            if (!Validations.Requisicao.IdRequisicaoIgualUsuario(id, usuario.Id))
                return BadRequest("O Id da requisição não coincide com o Id do usuário");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await this.repoUsuario.Update(usuario))
                return NotFound();

            return Ok(usuario);
        }

        // DELETE: api/Usuarios/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                if (!await this.repoUsuario.Delete(id))
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                Utils.Logger.WriteException(Configurations.Logger.GetFullPath(), ex);

                return InternalServerError();
            }
        }
    }
}
