
using ConsoleProject.Business.Services;
using ConsoleProject.Core.Entities;


CompanyService companyService = new CompanyService();

Console.WriteLine("firts");
companyService.Create("sdfsd");


Console.WriteLine("second");
companyService.Create("sdfs");


companyService.GetAll();



companyService.Update("sdfs", "1");
//companyService.Delete(1);

foreach (Company item in companyService.GetAll())
{
    Console.WriteLine(item.Id);
}

//Console.WriteLine(companyService.GetById(1).ToString());


//companyService.Delete(3);