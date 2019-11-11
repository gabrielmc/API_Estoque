using Estoque.Business.interfaces;
using Estoque.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Estoque.Controllers
{

    [ApiController]
    [ApiVersion("1")]
    [ControllerName("tipoMaterial")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class TipoMaterialController : ControllerBase
    {
        private ITipoMaterialBusiness _tipoMaterialBusiness;

        public TipoMaterialController(ITipoMaterialBusiness tipoMaterialBusiness)
        {
            _tipoMaterialBusiness = tipoMaterialBusiness;
        }

        #region GET
        [HttpGet(Name = "GetAllTiposMateriais")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var tiposmateriais = await _tipoMaterialBusiness.FindAll();
                if (tiposmateriais.Count > 0)
                    return Ok(tiposmateriais);

                return NotFound("Nenhum tipo de material encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetByIdTipoMaterial")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return BadRequest(ModelState);

                var tipomaterial = await _tipoMaterialBusiness.FindById(Convert.ToInt32(id));
                if (tipomaterial == null)
                    return NotFound("Tipo de material não encontrado");

                return Ok(tipomaterial);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        #endregion

        #region POST
        [HttpPost(Name = "CreateTipoMaterial")]
        public async Task<IActionResult> Create([FromBody]TipoMaterial tipoMaterial)
        {
            try
            {
                if (!ModelState.IsValid || tipoMaterial == null)
                    return BadRequest(ModelState);

                var newtipomaterial = await _tipoMaterialBusiness.Create(tipoMaterial);
                return CreatedAtRoute("GetByIdTipoMaterial", new { id = newtipomaterial.Id });
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        #endregion

        #region PUT
        [HttpPut("atualizar", Name = "UpdateTipoMaterial")]
        public async Task<IActionResult> Update(TipoMaterial tipoMaterial)
        {
            try
            {
                if (tipoMaterial == null)
                    return BadRequest("Entrada nula");

                var putTipoMaterial = await _tipoMaterialBusiness.Update(tipoMaterial);
                return CreatedAtRoute("GetByIdTipoMaterial", new { id = putTipoMaterial.Id });
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}", Name = "DeleteTipoMaterial")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(id)))
                    return NotFound("ID não informado!");

                await _tipoMaterialBusiness.Delete(id);
                return Ok("Item deletado!");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
        #endregion
    }
 //linha desnecessário
}
