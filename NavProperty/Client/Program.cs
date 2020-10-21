using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components;
using Grpc.Net.Client.Web;
using Grpc.Net.Client;
using grpcStuff;

namespace NavProperty.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("app");

			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

			builder.Services.AddSingleton( servis =>
			{
				string serverDje = servis.GetRequiredService<NavigationManager>().BaseUri;
				var klijent = new HttpClient(new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler()));
				var kanal = GrpcChannel.ForAddress(serverDje, new GrpcChannelOptions {HttpClient = klijent});

				return new KorisniciServ.KorisniciServClient(kanal);
			});

			await builder.Build().RunAsync();
		}
	}
}
