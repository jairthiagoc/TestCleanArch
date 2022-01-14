using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.DTOs
{
    public class CLienteDTO
    {
        //public CLienteDTO()
        //{
        //    Id = Guid.NewGuid();
        //}
        public Guid? Id { get; set; }

        //[Required(ErrorMessage = "The Nome is Required")]
        //[MinLength(3)]
        //[MaxLength(100)]
        public string? Name { get; set; }

        //[Required(ErrorMessage = "The Idade is Required")]
        //[MinLength(1)]
        //[MaxLength(3)]
        public Int64? Idade { get; set; }
    }
}
