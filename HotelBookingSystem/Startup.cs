using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Database;

namespace HotelBookingSystem
{
    // ����������� ������ � �������� �������� ����������.
    // ����������� ��� ������ ����� ����������.
    public class Startup
    {
        //��������� ��������� ���������� � ������� ���������� ������������.
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // �������������� ����� ConfigureServices() ������������ �������, ������� ������������ �����������. 
        public void ConfigureServices(IServiceCollection services) // � �������� ��������� ����� ConfigureServices() ��������� ������ IServiceCollection, ������� ������������ ��������� �������� � ����������.
        {
            // � ������� ������� ���������� ����� ������� ������������ ������������ ���������� ��� ������������� ��������. ��� ������ ����� ����� Add[��������_�������].
            services.AddControllers();// ��������� ������� ��� ������������
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "test", Version = "v1" });
            });

            services.AddDbContext<HotelContext>(       options => options.UseSqlServer("name=ConnectionStrings:db"));
        }

        // ����� Configure �������������, ��� ���������� ����� ������������ ������. ���� ����� �������� ������������.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) //��� ��������� �����������, ������� ������������ ������
        {
            // ���� ���������� � �������� ����������
            if (env.IsDevelopment())
            {
                // �� ������� ���������� �� ������, ��� ������� ������
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "test v1"));
            }
            
            app.UseHttpsRedirection();
            
            // ��������� ����������� �������������
            app.UseRouting();

            // ��������� ������������� ����������� �����������, ������� �������� ����������� �����������.
            app.UseAuthorization();

            // ������������� ������, ������� ����� ��������������
            app.UseEndpoints(endpoints =>
            {
                // ��������� �������� ����� ��� �������� �����������
                endpoints.MapControllers();
            });

        }
    }
}
