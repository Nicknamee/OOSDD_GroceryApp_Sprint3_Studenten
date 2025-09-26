using System;
using Grocery.App.ViewModels;
using Grocery.App.Views;

namespace Grocery.App
{
	public partial class App : Application
	{

		public static new App Current => (App)Application.Current;

		public IServiceProvider Services { get; }

		public App(LoginViewModel viewModel, IServiceProvider services)
		{
			InitializeComponent();

			Services = services;

			//MainPage = new AppShell();
			MainPage = new LoginView(viewModel);
		}
	}
}