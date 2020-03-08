namespace Backend_ApiNetCore3_1.Application.ViewModels.Request
{
    public class AppUserViewModelRequest : ViewModelBase
    {
        public int Id { get; set; }

        public int BusinessUnitId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public char UserRoleCode { get; set; }

    }


}
