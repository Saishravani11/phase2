using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using Hospital.Models;
namespace Hospital.Models
{
    public interface IAuthService
    {
        Task<string> Authenticate(string username, string password);
    }
}