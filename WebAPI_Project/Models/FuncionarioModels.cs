using System.ComponentModel.DataAnnotations;
using WebAPI_Project.Enums;

namespace WebAPI_Project.Models
{
    public class FuncionarioModels
    {
        [Key]
        public int IdMyProperty { get; set; }

        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }

        public DepartamentoEnum Departamento { get; set; }

        public bool Ativo { get; set; }

        public TurnoEnum turno { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now.ToLocalTime();

        public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();

    }
}
