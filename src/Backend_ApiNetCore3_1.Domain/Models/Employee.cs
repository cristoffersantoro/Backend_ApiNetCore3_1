using Backend_ApiNetCore3_1.Domain.Core.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Backend_ApiNetCore3_1.Domain.Models
{
    public class Employee : CustomEntityWithLog<int>
    {
        public Employee()
        {

        }

        public Employee(int id, int positionId)
        {
            Id = id;

            PositionId = positionId;
        }

        #region Properties


        [Required]
        public int PositionId { get; set; }

        [MaxLength(200)]
        public string EmployeeName { get; set; }

        [MaxLength(1)]
        public string GenderCode { get; set; }

        public DateTime? HiringDate { get; set; }

        [MaxLength(10)]
        public string DependentsQuantity { get; set; }

        public string SalaryValue { get; set; }


        #endregion

        #region Relations

        public virtual Position Position { get; set; }

        #endregion
    }
}
