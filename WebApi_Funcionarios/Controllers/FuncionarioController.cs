using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi_ASPNETCore.Models;
using WebApi_ASPNETCore.Service.FuncionarioService;

namespace WebApi_ASPNETCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionarioInterface;

        public FuncionarioController(IFuncionarioInterface funcionarioInterface)
        {
            _funcionarioInterface = funcionarioInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionarios()
        {
             return Ok( await _funcionarioInterface.GetFuncionarios() );
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> GetFuncionariosById(int id)
        {
            return Ok(await _funcionarioInterface.GetFuncionariosById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> CreateFuncionarios(FuncionarioModel modelCreate)
        {
            return Ok(await _funcionarioInterface.CreateFuncionarios(modelCreate));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> UpdateFuncionarios(FuncionarioModel modelCreate, int id)
        {
            return Ok(await _funcionarioInterface.UpdateFuncionarios(modelCreate, id));
        }

        [HttpPut("inativaFuncionario")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> InativaFuncionario(int id)
        {
            return Ok(await _funcionarioInterface.InativaFuncionario(id));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> DeleteFuncionarios(int id)
        {
            return Ok(await _funcionarioInterface.DeleteFuncionarios(id));
        }

      
    }
}