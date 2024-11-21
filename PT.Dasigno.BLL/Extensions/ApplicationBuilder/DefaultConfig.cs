using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace PT.Dasigno.BLL.Extensions.ApplicationBuilder
{
    public static class DefaultConfig
    {
        public static void InitconfigurationAPI(this WebApplication app, IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("AllowMyOrigin");
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers(); // Registrar controladores en el pipeline
        }
    }
}
