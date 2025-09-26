using CommunityToolkit.Mvvm.ComponentModel;

namespace Grocery.Core.Models
{
    public abstract partial class Model(int id, string name) : ObservableObject
    {
        public int Id { get; set; } = id;
        [ObservableProperty]
        public string name = name;
    }
	public class User
	{
		public int Id { get; set; }
		public string Username { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
	}
}
