﻿using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace web_api.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MedicamentosController : ApiController
    {
        private readonly Repositories.SQLServer.Medicamento repositorioMedicamento;

        public MedicamentosController()
        {
            this.repositorioMedicamento = new Repositories.SQLServer.Medicamento(Configurations.Database.getConnectionString());
        }

        // GET: api/Medicamentos
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                return Ok(await this.repositorioMedicamento.Select());
            }
            catch (Exception ex)
            {
                Utils.Logger.WriteException(Configurations.Logger.GetFullPath(), ex);

                return InternalServerError();
            }
        }

        // GET: api/Medicamentos/5
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                Models.Medicamento medicamento = await this.repositorioMedicamento.Select(id);
                
                if (medicamento is null)
                    return NotFound();
                
                return Ok(medicamento);
            }
            catch (Exception ex)
            {
                Utils.Logger.WriteException(Configurations.Logger.GetFullPath(), ex);
                return InternalServerError();
            }
        }

        // GET: api/Medicamentos?nome=cap
        [HttpGet]
        public async Task<IHttpActionResult> Get(string nome) {

            try
            {
                if (nome.Length < 3)
                    return BadRequest("O nome deve ter no mínimo 3 caracteres.");

                return Ok(await this.repositorioMedicamento.Select(nome));
            }
            catch (Exception ex)
            {
                Utils.Logger.WriteException(Configurations.Logger.GetFullPath(), ex);

                return InternalServerError();
            }
        }

        // POST: api/Medicamentos
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] Models.Medicamento medicamento)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (medicamento.DataVencimento != null && !Validations.Medicamento.DtVencimentoMaiorQueDtFabricacao(medicamento))
                    return BadRequest("Data vencimento não pode ser menor ou igual que a data de fabricação.");

                await this.repositorioMedicamento.Insert(medicamento);      

                return Ok(medicamento);
            }
            catch (Exception ex)
            {
                Utils.Logger.WriteException(Configurations.Logger.GetFullPath(), ex);

                return InternalServerError();
            }
        }

        // PUT: api/Medicamentos/5
        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, [FromBody] Models.Medicamento medicamento)
        {
            try
            {
                if (!Validations.Requisicao.IdRequisicaoIgualIdMedicamento(id, medicamento.Id))
                    return BadRequest("O Id da requisição não coincide com o Id do medicamento");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (medicamento.DataVencimento != null && !Validations.Medicamento.DtVencimentoMaiorQueDtFabricacao(medicamento))
                    return BadRequest("Data vencimento não pode ser menor ou igual que a data de fabricação.");

                if (!await this.repositorioMedicamento.Update(medicamento))
                    return NotFound();

                return Ok(medicamento);
            }
            catch (Exception ex)
            {
                Utils.Logger.WriteException(Configurations.Logger.GetFullPath(), ex);

                return InternalServerError();
            }
        }

        // DELETE: api/Medicamentos/5
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                if (!await this.repositorioMedicamento.Delete(id))
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
