using Backend_ApiNetCore3_1.Domain.Core.Models;

namespace Backend_ApiNetCore3_1.Domain.Models
{
    public class AppUser : BaseEntity<int>
    {
        public AppUser(int id, int businessUnitId, string name)
        {
            Id = id;
            UserName = name;
            BusinessUnitId = businessUnitId;
        }

        // Empty constructor for EF
        protected AppUser() { }

        #region Properties
        public int BusinessUnitId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public char UserRoleCode { get; set; }
        #endregion




        #region Relations


        #endregion
    }
}