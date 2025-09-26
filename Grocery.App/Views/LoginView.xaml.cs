using Grocery.App.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Grocery.App.Views;

public partial class LoginView : ContentPage
{
	public LoginView() : this(App.Current.Services.GetService<LoginViewModel>())
	{
	}

	public LoginView(LoginViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}