using Microsoft.EntityFrameworkCore;
using WebAPI_Project.DataContext;
using WebAPI_Project.Models;

namespace WebAPI_Project.Service.FuncionarioService
{
    public class FuncionarioService : IFuncionarioInterface
    {

        private readonly ApplicationDbContext _context;
        public FuncionarioService(ApplicationDbContext context)
        {
            _context = context; 
        }


        public async Task<ServiceResponse<List<FuncionarioModels>>> CreateFuncionarios(FuncionarioModels novoFuncionario)
        {
            ServiceResponse<List<FuncionarioModels>> serviceResponse = new ServiceResponse<List<FuncionarioModels>>();

            try
            {

                if (novoFuncionario == null) 
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoFuncionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();
                

            }catch (Exception ex){

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;

            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModels>>> DeleteFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModels>> serviceResponse = new ServiceResponse<List<FuncionarioModels>>();

            try 
            {
                FuncionarioModels funcionario = _context.Funcionarios.FirstOrDefault(x => x.IdMyProperty == id);


                if (funcionario == null) 
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não encontrado";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;

                }

                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();
                   
            }
            catch(Exception ex) 
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
                
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<FuncionarioModels>> GetFuncionarioById(int id)
        {
           ServiceResponse<FuncionarioModels> serviceResponse = new ServiceResponse<FuncionarioModels>();

            try
            {
                FuncionarioModels funcionario = _context.Funcionarios.FirstOrDefault(x => x.IdMyProperty == id);

                if(funcionario == null) 
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Funcionario não encontrado!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = funcionario;


            }
            catch (Exception ex) 
            {
                serviceResponse.Mensagem=ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModels>>> GetFuncionarios()
        {
            ServiceResponse<List<FuncionarioModels>> serviceResponse = new ServiceResponse<List<FuncionarioModels>>();

            try 
            {


                serviceResponse.Dados = _context.Funcionarios.ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }

            } 
            catch(Exception ex) 
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModels>>> InativaFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModels>> serviceResponse = new ServiceResponse<List<FuncionarioModels>>();

            try {
                FuncionarioModels funcionario = _context.Funcionarios.FirstOrDefault(x => x.IdMyProperty == id);

                if (funcionario == null) 
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Funcionario não encontrado!";
                    serviceResponse.Sucesso = false;
                }

                funcionario.Ativo = false;
                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(funcionario);

                await _context.SaveChangesAsync();


                serviceResponse.Dados = _context.Funcionarios.ToList();
            } 
            catch (Exception ex) 
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
            
        }

        public async Task<ServiceResponse<List<FuncionarioModels>>> UpdateFuncionario(FuncionarioModels editadoFuncionario)
        {
            ServiceResponse<List<FuncionarioModels>> serviceResponse = new ServiceResponse<List<FuncionarioModels>>();

            try 
            {
                FuncionarioModels funcionario = _context.Funcionarios.AsNoTracking().FirstOrDefault(x => x.IdMyProperty == editadoFuncionario.IdMyProperty);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Funcionario não encontrado";
                    serviceResponse.Sucesso = false;
                }

                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(editadoFuncionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();

            } 
            catch(Exception ex) 
            {
              serviceResponse.Mensagem=ex.Message; 
              serviceResponse.Sucesso=false;
            }

            return serviceResponse;
        }
    }
}
