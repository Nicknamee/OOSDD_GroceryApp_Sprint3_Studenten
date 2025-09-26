using Grocery.Core.Helpers;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services;

public class AuthService : IAuthService
{
	private readonly IClientService _clientService;
	private Client? _currentClient;

	public AuthService(IClientService clientService)
	{
		_clientService = clientService;
	}

	public bool Register(string emailAddress, string password)
	{
		var existingClient = _clientService.Get(emailAddress);
		if (existingClient != null) return false;

		var hashedPassword = PasswordHelper.HashPassword(password);
		var name = emailAddress.Split('@')[0];
		var newId = _clientService.GetAll().Count() + 1;

		var newClient = new Client(newId, name, emailAddress, hashedPassword);
		_clientService.Add(newClient);
		return true;
	}

	public Client? Login(string emailAddress, string password)
	{
		var client = _clientService.Get(emailAddress);
		if (client == null) return null;

		if (PasswordHelper.VerifyPassword(password, client.Password))
		{
			_currentClient = client;
			return client;
		}

		return null;
	}

	public void Logout()
	{
		_currentClient = null;
	}
}
