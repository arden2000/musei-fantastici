using Microsoft.AspNetCore.Components.WebView.Maui;
using musei.Data;
using Radzen;

namespace musei;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
        builder.Services.AddScoped<NotificationService>();
        builder.Services.AddSingleton<CosmosService>();
        builder.Services.AddSingleton<Session>();
        return builder.Build();
	}
}

