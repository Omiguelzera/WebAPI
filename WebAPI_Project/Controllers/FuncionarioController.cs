using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Project.Models;
using WebAPI_Project.Service.FuncionarioService;

namespace WebAPI_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionarioInterface;
        public FuncionarioController(IFuncionarioInterface funcionarioInterface)
        {
            _funcionarioInterface = funcionarioInterface;
        }

        [HttpGet]

        public async Task<ActionResult<ServiceResponse<List<FuncionarioModels>>>> GetFuncioanrios() {

            return Ok(await _funcionarioInterface.GetFuncionarios());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ServiceResponse<FuncionarioModels>>> GetFuncionarioById(int id) 
        {
           ServiceResponse<FuncionarioModels> serviceResponse = await _funcionarioInterface.GetFuncionarioById(id);

            return Ok(serviceResponse);
        }

        [HttpPost]

        public async Task<ActionResult<ServiceResponse<List<FuncionarioModels>>>> CreateFuncionario(FuncionarioModels novoFuncionario)
        {
            return Ok(await _funcionarioInterface.CreateFuncionarios(novoFuncionario));  
         
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModels>>>> UpdateFuncionario(FuncionarioModels editadoFuncionario)
        { 
          ServiceResponse<List<FuncionarioModels>> serviceResponse = await _funcionarioInterface.UpdateFuncionario(editadoFuncionario);

            return Ok(serviceResponse);

        }

        [HttpPut("InativaFuncionario")]

        public async Task<ActionResult<ServiceResponse<List<FuncionarioModels>>>> InativaFuncionario(int id) 
        {
            ServiceResponse<List<FuncionarioModels>> serviceResponse = await _funcionarioInterface.InativaFuncionario(id);

            return Ok(serviceResponse);
        }

        [HttpDelete]

        public async Task<ActionResult<ServiceResponse<List<FuncionarioModels>>>> DeleteFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModels>> serviceResponse = await _funcionarioInterface.DeleteFuncionario(id);

            return Ok(serviceResponse);
            

        }

    }
}
