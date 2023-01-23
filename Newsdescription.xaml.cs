using New_App.models;

namespace New_App;

public partial class Newsdescription : ContentPage
{
	public Newsdescription(Article article)
	{
		InitializeComponent();
		imgnews.Source=article.Image;
		lbltitle.Text = article.Title;
		lbldesc.Text = article.Content;

	}
}