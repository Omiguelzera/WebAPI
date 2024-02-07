using WebAPI_Project.Models;

namespace WebAPI_Project.Service.FuncionarioService
{
    public interface IFuncionarioInterface
    {
        Task<ServiceResponse<List<FuncionarioModels>>> GetFuncionarios();

        Task<ServiceResponse<List<FuncionarioModels>>> CreateFuncionarios(FuncionarioModels novoFuncionario);

        Task<ServiceResponse<FuncionarioModels>> GetFuncionarioById(int id);

        Task<ServiceResponse<List<FuncionarioModels>>> UpdateFuncionario(FuncionarioModels editadoFuncionario);

        Task<ServiceResponse<List<FuncionarioModels>>> DeleteFuncionario(int id);

        Task<ServiceResponse<List<FuncionarioModels>>> InativaFuncionario(int id);
    }
}
