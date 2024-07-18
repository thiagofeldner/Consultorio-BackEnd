using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace web_api.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AutenticacoesController : ApiController
    {
        private readonly Repositories.SQLServer.Autenticar repoAutenticar;
            
        public  AutenticacoesController()
        {
            repoAutenticar = new Repositories.SQLServer.Autenticar(Configurations.Database.getConnectionString());            
        }
    
        [HttpPost]
        public async Task<IHttpActionResult> Autenticar([FromBody]Models.Login login)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (!await this.repoAutenticar.Select(login))
                    return NotFound();
                
                return Ok(login);
            }
            catch (Exception ex)
            {
                Utils.Logger.WriteException(Configurations.Logger.GetFullPath(), ex);
                return InternalServerError();
            }
        }
    }
}
