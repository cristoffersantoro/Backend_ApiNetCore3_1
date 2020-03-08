using Backend_ApiNetCore3_1.Domain.Core.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Backend_ApiNetCore3_1.Domain.Models.History
{
    public class EmployeeHistory : CustomEntityWithLog<int>
    {
        public EmployeeHistory()
        {

        }

        public EmployeeHistory(int id, int scenarioId, int costCenterId, int positionId)
        {
            Id = id;
            ScenarioId = scenarioId;
            CostCenterId = costCenterId;
            PositionId = positionId;
        }
        [Required]
        public int ScenarioId { get; set; }

        [Required]
        public int CostCenterId { get; set; }

        [Required]
        public int PositionId { get; set; }

        [MaxLength(200)]
        public string EmployeeName { get; set; }

        [Required]
        public string MatriculaNu { get; set; }

        [MaxLength(3)]
        public string MGCode { get; set; }

        [MaxLength(1)]
        public string GenderCode { get; set; }

        public DateTime HiringDate { get; set; }

        [MaxLength(10)]
        public string DependentsQuantity { get; set; }

        [MaxLength(70)]
        public string UnionName { get; set; }

        public string SalaryValue { get; set; }

        public string EmployeeProvisionsValue { get; set; }

        public string LaborChargesValue { get; set; }
    }
}
