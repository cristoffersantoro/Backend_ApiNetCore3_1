using Backend_ApiNetCore3_1.Application.ViewModels.Request;
using System.Collections.Generic;

namespace Backend_ApiNetCore3_1.Application.ViewModels.Response
{

    public class EmployeeViewModelResponse : EmployeeViewModelRequest
    {
        public PositionViewModelResponse Position { get; set; }      

    }

}
