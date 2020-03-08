namespace Backend_ApiNetCore3_1.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(string user);
    }
}
