using New_App.models;
using New_App.serviece;

namespace New_App;

public partial class MainPage : ContentPage
{
	private bool isnext = false;
	public List<Article> Articleslist {get;set;}
	public List<Categories> ListofCategories = new List<Categories>()
	{
		new Categories(){Name="World"},

        new Categories(){Name="Breaking-News"},

        new Categories(){Name="Nation"},

        new Categories(){Name="Technology"},

        new Categories(){Name="Business"},

        new Categories(){Name="Science"},


        new Categories(){Name="Health" },

        new Categories(){Name="Entertainment"},





    };

	public MainPage()
	{
		InitializeComponent();
		Articleslist = new List<Article>();
		NewsCat.ItemsSource = ListofCategories;
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		if (isnext == false) {
            await PassCat("world");


        }

    }
	public async Task PassCat(string catName)
	{
		execnews.ItemsSource = null;//ask
		Articleslist.Clear();//ask
        ApiiServeice apiServeice = new ApiiServeice();
        var ResponseResult = await apiServeice.GetNews(catName);
        foreach (var item in ResponseResult.Articles)
        {
            Articleslist.Add(item);

        }
        execnews.ItemsSource = Articleslist;

    }

    private async void NewsCat_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		var selecteditem = e.CurrentSelection.FirstOrDefault() as Categories;
		await PassCat(selecteditem.Name);
	}

	private void execnews_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		var selecteditem=e.CurrentSelection.FirstOrDefault() as Article;
		isnext = true;
		Navigation.PushAsync(new Newsdescription(selecteditem));
	}
}

