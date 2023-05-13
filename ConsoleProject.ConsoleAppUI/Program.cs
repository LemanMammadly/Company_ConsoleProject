using ConsoleProject.Business.Services;
using ConsoleProject.Core.Entities;


CompanyService companyService = new CompanyService();

Console.WriteLine("firts");
companyService.Create("sdfsd");




Console.WriteLine("second");
companyService.Create("sdk");


Console.WriteLine("third");
companyService.Create("sdfss");


foreach (Company item in companyService.GetAll())
{
    Console.WriteLine($"{item.CompanyName}   {item.creationTime}");
}

//Console.WriteLine(companyService.GetById(1));


//companyService.Delete(3);

companyService.Create("sdffw");


foreach (Company item in companyService.GetAll())
{
    Console.WriteLine($"{item.CompanyName}   {item.creationTime}");
}



companyService.Create("qwewqe");