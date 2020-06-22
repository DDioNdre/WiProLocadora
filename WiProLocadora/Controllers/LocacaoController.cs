using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WiProLocadora.Domain.UseCases.DTO;
using WiProLocadora.Domain.UseCases.Service;

namespace WiProLocadora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly ILocacaoService iLocacaoService;
        private readonly ILogger<LocacaoController> iLogger;

        public LocacaoController(ILocacaoService iLocacaoService, ILogger<LocacaoController> iLogger)
        {
            this.iLocacaoService = iLocacaoService;
            this.iLogger = iLogger;
        }

        [HttpGet("ValidarEstoqueFilme/{id}")]
        public async Task<ActionResult<ResponseDTO>> ValidarEstoqueFilme(int id)
        {
            try
            {
                FilmeDTO filmeDTO = await iLocacaoService.VeriricarEstoqueFilme(id);
                if (filmeDTO != null)
                {
                    return Ok(new ResponseDTO(StatusCodes.Status200OK, "OK", filmeDTO));
                }
                else
                {
                    return BadRequest(new ResponseDTO(StatusCodes.Status400BadRequest, "Filme indisponível no estoque", id));
                }
            }
            catch (Exception ex)
            {
                iLogger.LogError(ex.Message);
                return BadRequest(new ResponseDTO(StatusCodes.Status500InternalServerError, "Error", null));
            }
        }

        [HttpPut("ClienteDevolverFilme/{idCliente}")]
        public async Task<ActionResult<ResponseDTO>> ClienteDevolverFilme(int idCliente, [FromBody] FilmeDTO reqFilmeDTO)
        {
            try
            {
                FilmeDTO resFilmeDTO = await iLocacaoService.ClienteDevolverFilme(idCliente, reqFilmeDTO);
                if(resFilmeDTO != null)
                {
                    return Ok(new ResponseDTO(StatusCodes.Status200OK, "OK", resFilmeDTO));
                }
                else
                {
                    return BadRequest(new ResponseDTO(StatusCodes.Status400BadRequest, "Filme com atraso na devolução", reqFilmeDTO));
                }
            }
            catch (Exception ex)
            {
                iLogger.LogError(ex.Message);
                return BadRequest(new ResponseDTO(StatusCodes.Status500InternalServerError, "Error", null));
            }
        }
    }
}