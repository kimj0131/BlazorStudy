using BlazorApp.Components;
using BlazorApp.Data;

namespace BlazorApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorComponents()
				.AddInteractiveServerComponents();

			#region Dependency Injection 실습

			// Dependency Injection(의존성 주입) 테스트
			builder.Services.AddSingleton<IFoodService, FastFoodService>();
			// 생성자에서 알아서 연결해준다.
			builder.Services.AddSingleton<PaymentService>();

			// 3가지 모드의 생명 주기
			// 서버가 동작하고 생성이후 변화가없음
			// >> 데이터 변동이 없고 누구한테나 똑같은 정보를 보여야 할 때 활용가능
			builder.Services.AddSingleton<SingletonService>();
			// 인터페이스 요청이 있을때 마다 변화가 발생 
			builder.Services.AddTransient<TransientService>();
			// HTTP 요청당 한번 생성 후 재사용 (새로고침 등 HTTP 요청이 새로 들어오면 다시 생성)
			builder.Services.AddScoped<ScopedService>();

			#endregion

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			app.UseStaticFiles();
			app.UseAntiforgery();

			app.MapRazorComponents<App>()
				.AddInteractiveServerRenderMode();

			app.Run();
		}
	}
}
