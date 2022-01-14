using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchMvc.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    [Produces("application/json")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;

        private readonly IClienteService _clienteService;

        public ClienteController(ILogger<ClienteController> logger, IClienteService clienteService)
        {
            _logger = logger;
            _clienteService = clienteService;
        }
        /// <summary>
        /// Consulta todos os clientes do banco
        /// </summary>
        /// <returns></returns>
        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CLienteDTO>>> Get()
        {
            var clientes = await _clienteService.GetClientes();

            if (clientes == null) return NotFound("Nao possui clientes cadastrado no banco!!");
            
            return Ok(clientes);
        }
        /// <summary>
        /// Consulta o Cliente pelo Guid
        /// </summary>
        /// <param name="id">"3fa85f64-5717-4562-b3fc-2c963f66afa6"</param>
        /// <returns></returns>
        // GET api/<ClienteController>/5
        [HttpGet("{id}", Name="GetCliente")]
        public async Task<ActionResult<CLienteDTO>> Get(Guid id)
        {
            var clientes = await _clienteService.GetById(id);

            if (clientes == null) return NotFound("Cliente nao encontrado!!");

            return Ok(clientes);
        }
        /// <summary>
        /// Cadastrar um novo cliente
        /// </summary>
        /// <param name="cliente">
        /* {
                "id": "0e7865d8-19f7-4022-8553-4b114440b8fd",
                "name": "Maria da silva ",
                "idade": 23
            }*/
        /// </param>
        /// <returns></returns>
        // POST api/<ClienteController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CLienteDTO cliente)
        {
            if (cliente == null)
                return BadRequest("Cliente nao pode ser null!!");

            await _clienteService.Create(cliente);

            return new CreatedAtRouteResult("GetCliente", new { id = cliente.Id }, cliente);
        }
        /// <summary>
        /// Alterar o cliente informando seus dados
        /// </summary>
        /// <param name="cliente">
        /// {
        ///    "id": "0e7865d8-19f7-4022-8553-4b114440b8fd",
        ///    "name": "Maria da silva ",
        ///    "idade": 25
        /// }
        /// </param>
        /// <returns></returns>
        // PUT api/<ClienteController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CLienteDTO cliente)
        {
            if (cliente == null)
                return BadRequest("Cliente nao pode ser null!!");

            await _clienteService.Update(cliente);

            return new CreatedAtRouteResult("GetCliente", new { id = cliente.Id }, cliente);
        }

        /// <summary>
        /// Apagar um cliente da aplicacao
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var clientes = await _clienteService.GetById(id);

            if (clientes == null) return NotFound("Cliente nao encontrado!!");

            await _clienteService.Remove(clientes.Id);

            return Ok("Cliente foi apagado com sucesso!!!");
        }
    }
}
