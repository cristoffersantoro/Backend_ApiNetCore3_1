using Backend_ApiNetCore3_1.Application.ViewModels.Response;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Backend_ApiNetCore3_1.Application.ViewModels.Request
{
    public class PositionViewModelRequest
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This Name is Required")]
        public string PositionName { get; set; }

        [Required(ErrorMessage = "This Code is Required")]
        public string PositionCode { get; set; }
        public string MGCode { get; set; }
        
    }
}
