using HTTPClient.ViewModels;

namespace HTTPClient.Views;

public partial class PostView : ContentPage
{
	public PostView()
	{
        InitializeComponent();
		BindingContext = new PostViewModel();
	}
}