using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_ASPNETCore.Models;

namespace WebApi_ASPNETCore.Service.FuncionarioService
{
    public interface IFuncionarioInterface
    {
        Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios(); 
        Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionarios(FuncionarioModel modelCreate); 
        Task<ServiceResponse<FuncionarioModel>> GetFuncionariosById(int id); 
        Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionarios(FuncionarioModel modelUpdate, int id); 
        Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionarios(int id); 
        Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id); 
    }
}