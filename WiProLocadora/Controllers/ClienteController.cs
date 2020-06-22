using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using WiProLocadora.Domain.UseCases.DTO;
using WiProLocadora.Domain.UseCases.Service;

namespace WiProLocadora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService iClienteService;
        private readonly ILogger<WeatherForecastController> iLogger;
        public ClienteController(IClienteService iClienteService, ILogger<WeatherForecastController> iLogger)
        {
            this.iClienteService = iClienteService;
            this.iLogger = iLogger;
        }

        [HttpGet("ObterTodosClientes")]
        public async Task<ActionResult<ResponseDTO>> ObterTodosClientes()
        {
            try
            {
                IEnumerable<ClienteDTO> clienteDTOs = await iClienteService.ObterTodosClientes();

                return Ok(new ResponseDTO(StatusCodes.Status200OK, "OK", clienteDTOs));
            }
            catch (Exception ex)
            {
                iLogger.LogError(ex.Message);
                return BadRequest(new ResponseDTO(StatusCodes.Status500InternalServerError, "Error", null));
            }
        }

        [HttpGet("ObterClientePorId/{id}")]
        public async Task<ActionResult<ResponseDTO>> ObterClientePorId(int id)
        {
            try
            {
                ClienteDTO clienteDTO = await iClienteService.ObterClientePorId(id);
                return Ok(new ResponseDTO(StatusCodes.Status200OK, "OK", clienteDTO));
            }
            catch (Exception ex)
            {
                iLogger.LogError(ex.Message);
                return BadRequest(new ResponseDTO(StatusCodes.Status500InternalServerError, "Error", null));
            }
        }

        [HttpPost("InserirCliente")]
        public async Task<ActionResult<ResponseDTO>> InserirCliente([FromBody] ClienteDTO reqClienteDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                ClienteDTO resClienteDTO = await iClienteService.InserirCliente(reqClienteDTO);
                if (resClienteDTO != null)
                {
                    return Ok(new ResponseDTO(StatusCodes.Status200OK, "OK", resClienteDTO));
                }
                else
                {
                    return BadRequest(new ResponseDTO(StatusCodes.Status400BadRequest, "Cliente já Cadastrado", reqClienteDTO));
                }

            }
            catch (Exception ex)
            {
                iLogger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("AtualizarCliente")]
        public async Task<ActionResult<ResponseDTO>> AtualizarCliente([FromBody] ClienteDTO reqClienteDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                ClienteDTO resClienteDTO = await iClienteService.AtualizarCliente(reqClienteDTO);
                if (resClienteDTO != null)
                {
                    return Ok(new ResponseDTO(StatusCodes.Status200OK, "OK", resClienteDTO));
                }
                else
                {
                    return BadRequest(new ResponseDTO(StatusCodes.Status400BadRequest, "Cliente inexistente", reqClienteDTO));
                }
            }
            catch (Exception ex)
            {
                iLogger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}