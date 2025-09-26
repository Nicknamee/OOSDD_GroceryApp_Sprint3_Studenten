using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Services;

public interface IAuthService
{
	bool Register(string emailAddress, string password);
	Client? Login(string emailAddress, string password);
	void Logout();
}
