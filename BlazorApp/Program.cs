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

			#region Dependency Injection �ǽ�

			// Dependency Injection(������ ����) �׽�Ʈ
			builder.Services.AddSingleton<IFoodService, FastFoodService>();
			// �����ڿ��� �˾Ƽ� �������ش�.
			builder.Services.AddSingleton<PaymentService>();

			// 3���� ����� ���� �ֱ�
			// ������ �����ϰ� �������� ��ȭ������
			// >> ������ ������ ���� �������׳� �Ȱ��� ������ ������ �� �� Ȱ�밡��
			builder.Services.AddSingleton<SingletonService>();
			// �������̽� ��û�� ������ ���� ��ȭ�� �߻� 
			builder.Services.AddTransient<TransientService>();
			// HTTP ��û�� �ѹ� ���� �� ���� (���ΰ�ħ �� HTTP ��û�� ���� ������ �ٽ� ����)
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
