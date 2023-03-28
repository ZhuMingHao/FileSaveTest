using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
namespace TestApp;
public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>().UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
    
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<ViewModel>();
        builder.Services.AddSingleton<IFileSaver>(FileSaver.Default);
        return builder.Build();
	}
}
