using Backend_ApiNetCore3_1.Domain.Core.Models;
using System.Collections.Generic;

namespace Backend_ApiNetCore3_1.Domain.Models
{
    public class Position : CustomEntityWithLog<int>
    {
        public Position()
        {

        }

        public Position(int id, string positionName, string positionCode)
        {
            Id = id;
            PositionName = positionName;
            PositionCode = positionCode;
        }

        #region Properties

        public string PositionName { get; set; }
        public string PositionCode { get; set; }
        //public string MGCode { get; set; }

        #endregion

        #region Relations

        public virtual IEnumerable<Employee> Employees { get; set; }

        #endregion
    }
}
