﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Student_Database_Exam.BussinessLogic.Interfaces;
using Student_Database_Exam.BussinessLogic.Services;
using Student_Database_Exam.Repository;
using Student_Database_Exam.Repository.Interfaces;
using Student_Database_Exam.Repository.Repos;

namespace Student_Database_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            var mainMenuService = host.Services.GetService<IMainMenuService>();
            mainMenuService.MainMenu();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            return Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) =>
            {
                //Database
                services.AddDbContext<Student_Database_ExamDbContext>(options => { options.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection")); }, ServiceLifetime.Scoped);
                services.AddScoped<IClassesRepo, ClassesRepo>();
                services.AddScoped<IDepartmentsRepo, DepartmentsRepo>();
                services.AddScoped<IStudentsRepo, StudentsRepo>();
                //Bussiness logic
                services.AddScoped<IClassService, ClassService>();
                services.AddScoped<IDepartmentService, DepartmentService>();
                services.AddScoped<IMainMenuService, MainMenuService>();
                services.AddScoped<IStudentService, StudentService>();
                services.AddScoped<IUIService, UIService>();
                //Database managment
                services.AddScoped<IDatabaseManagmentService, DatabaseManagmentService>();
                services.AddScoped<DepartmentService>();
            });
        }
    }
}