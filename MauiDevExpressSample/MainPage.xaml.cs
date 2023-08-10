using DevExpress.Maui.Editors;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace MauiDevExpressSample;

public partial class MainPage : ContentPage
{
    private readonly HttpClient httpClient = new();

    public ObservableCollection<Monkey> Monkeys { get; set; } = new();

    public ObservableCollection<string> MyItems { get; set; } = new()
	{
		"Gerald",
		"YouTube",
		"Subscribe",
		"DevExpress"
	};

    public ObservableCollection<Appointment> Appointments { get; set; } = new()
    {
        new()
        {
            Id = 1337,
            Subject = "Subscribe to Gerald",
            StartTime = new DateTime(2023, 08, 08, 13, 37, 0),
            EndTime = new DateTime(2023, 08, 08, 16, 0, 0),
        }
    };

    public MainPage()
	{
		InitializeComponent();

        LoadMonkeys();

		BindingContext = this;
    }
    private async Task LoadMonkeys()
    {
        var monkeys = await httpClient.GetFromJsonAsync<Monkey[]>("https://montemagno.com/monkeys.json");
        Monkeys.Clear();

        foreach (Monkey monkey in monkeys)
        {
            Monkeys.Add(monkey);
        }
    }

    void OnDelegateRequested(object sender, ItemsRequestEventArgs e)
    {
        e.Request = () => {
            return MyItems.Where(i => i.StartsWith(e.Text, StringComparison.CurrentCultureIgnoreCase)).ToList();
        };
    }
}

