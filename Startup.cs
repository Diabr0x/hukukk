using hukukk.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace hukukk
{
    public class Startup
    {
        // ConfigureServices metodunda gerekli servislerin eklenmesi
        public void ConfigureServices(IServiceCollection services)

        {
            services.AddScoped<UyeDbİsle>();
            services.AddControllersWithViews(); // MVC servislerini eklemek için
        }

        // Configure metodunda HTTP isteği işleme mantığı
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Geliştirme ortamında hata sayfasını kullan
            }
            else
            {
                // Prodüksiyon ortamı için hata yönetimi
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts(); // HTTP Strict Transport Security (HSTS) özelliğini kullan
            }

            app.UseHttpsRedirection(); // HTTPS'e yönlendirme
            app.UseStaticFiles(); // Statik dosyaları sunma (css, js, resimler vb.)

            app.UseRouting(); // Routing (yönlendirme) işlemleri

            app.UseAuthorization(); // Yetkilendirme

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"); // Varsayılan MVC yönlendirmesi
            });
        }
    }
}