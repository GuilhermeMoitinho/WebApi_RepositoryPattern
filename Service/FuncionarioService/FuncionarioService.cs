using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi_ASPNETCore.DataContext;
using WebApi_ASPNETCore.Models;

namespace WebApi_ASPNETCore.Service.FuncionarioService
{
    public class FuncionarioService : IFuncionarioInterface
    {

        private readonly ApplicationDbContext _context;

        public FuncionarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionarios(FuncionarioModel modelCreate)
        {
            ServiceResponse<List<FuncionarioModel>> serviceresponse = new ServiceResponse<List<FuncionarioModel>>();

            try{

                if(modelCreate == null)
                {
                    serviceresponse.Dados = null;
                    serviceresponse.Mensagem = "Informar dados!";
                    serviceresponse.Sucesso = false;

                    return serviceresponse;
                }

                _context.Add(modelCreate);
                await _context.SaveChangesAsync();

                serviceresponse.Dados = _context.Funcionarios.ToList();
                serviceresponse.Mensagem = "Dado criado com sucesso!";

            }catch(Exception ex){

                serviceresponse.Mensagem = ex.Message;
                serviceresponse.Sucesso = false;
            }

            return serviceresponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionarios(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceresponse = new ServiceResponse<List<FuncionarioModel>>();

             try{
                FuncionarioModel funcionario = _context.Funcionarios.Find(id);

                if(funcionario == null)
                {
                    serviceresponse.Dados = null;
                    serviceresponse.Mensagem = "Funcionario não foi encontrado!";
                    serviceresponse.Sucesso = false;
                }

                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();

                serviceresponse.Dados = _context.Funcionarios.ToList();
                serviceresponse.Mensagem = "Funcionario deletado com sucesso!";


            }catch(Exception ex){
                
                serviceresponse.Mensagem = ex.Message;
                serviceresponse.Sucesso = false;
            }

            return serviceresponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
        {
            ServiceResponse<List<FuncionarioModel>> serviceresponse = new ServiceResponse<List<FuncionarioModel>>();

            try{
                serviceresponse.Dados = _context.Funcionarios.ToList();

                if(serviceresponse.Dados.Count == 0)
                {
                    serviceresponse.Mensagem = "Sem dados por enquanto!";
                }else
                {
                    serviceresponse.Mensagem = "Processo concluido com sucesso!";
                }

            }catch(Exception ex){
                
                serviceresponse.Mensagem = ex.Message;
                serviceresponse.Sucesso = false;
            }

            return serviceresponse;
        }

        public async Task<ServiceResponse<FuncionarioModel>> GetFuncionariosById(int id)
        {
            ServiceResponse<FuncionarioModel> serviceresponse = new ServiceResponse<FuncionarioModel>();

            try{
                FuncionarioModel funcionario = _context.Funcionarios.Find(id);

                if(funcionario == null)
                {
                    serviceresponse.Dados = null;
                    serviceresponse.Mensagem = "Funcionario não foi encontrado!";
                    serviceresponse.Sucesso = false;
                }

                serviceresponse.Dados = funcionario;
                serviceresponse.Mensagem = "Funcionario encontrado!"; 

            }catch(Exception ex){
                
                serviceresponse.Mensagem = ex.Message;
                serviceresponse.Sucesso = false;
            }

            return serviceresponse;

        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceresponse = new ServiceResponse<List<FuncionarioModel>>();

             try{
                FuncionarioModel funcionario = _context.Funcionarios.Find(id);

                if(funcionario == null)
                {
                    serviceresponse.Dados = null;
                    serviceresponse.Mensagem = "Funcionario não foi encontrado!";
                    serviceresponse.Sucesso = false;
                }
                
               funcionario.Ativo = false;
               funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

               _context.Update(funcionario);
               await _context.SaveChangesAsync();

               serviceresponse.Dados = _context.Funcionarios.ToList();
               serviceresponse.Mensagem = "Funcionario desativado com sucesso!";

            }catch(Exception ex){
                
                serviceresponse.Mensagem = ex.Message;
                serviceresponse.Sucesso = false;
            }

            return serviceresponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionarios(FuncionarioModel modelUpdate, int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceresponse = new ServiceResponse<List<FuncionarioModel>>();

             try{
              FuncionarioModel funcionario = _context.Funcionarios.Find(id);

               if(funcionario == null)
                {
                    serviceresponse.Dados = null;
                    serviceresponse.Mensagem = "Funcionario não foi encontrado!";
                    serviceresponse.Sucesso = false;
                }

                funcionario.Nome = modelUpdate.Nome;
                funcionario.Sobrenome = modelUpdate.Sobrenome;
                funcionario.Departamento = modelUpdate.Departamento;
                funcionario.Ativo = modelUpdate.Ativo;
                funcionario.Turno = modelUpdate.Turno;
               funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

               _context.Update(funcionario);
               await _context.SaveChangesAsync();

               serviceresponse.Dados = _context.Funcionarios.ToList();
               serviceresponse.Mensagem = "Funcionario atualizado com sucesso!";

            }catch(Exception ex){
                
                serviceresponse.Mensagem = ex.Message;
                serviceresponse.Sucesso = false;
            }

            return serviceresponse;
        }
    }
}