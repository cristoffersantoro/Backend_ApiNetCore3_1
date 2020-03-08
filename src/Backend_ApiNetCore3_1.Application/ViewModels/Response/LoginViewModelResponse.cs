namespace Backend_ApiNetCore3_1.Application.ViewModels.Response
{
    public class LoginViewModelResponse
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserTokenViewModel UserToken { get; set; }
    }
}
