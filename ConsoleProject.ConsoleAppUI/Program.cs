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

//companyService.Create("sdffw");


//foreach (Company item in companyService.GetAll())
//{
//    Console.WriteLine($"{item.CompanyName}   {item.creationTime}");
//}



//companyService.Create("qwewqe");





//departmentService.Delete(0);

//companyService.Delete(1);


//departmentService.Delete(0);

companyService.GetAllDepartment("sdfss");


//foreach (Department item in companyService.GetAllDepartment("sdfss"))
//{
//    Console.WriteLine(item);
//}

//Console.WriteLine(departmentService.GetById(0));


//foreach (Department item in departmentService.GetAll())
//{
//    Console.WriteLine(item);
//}




Console.WriteLine("employe");
//employeeService.Create("Laman", "", 1);
//Console.WriteLine("department");

DepartmentService departmentService = new DepartmentService();
EmployeeService employeeService = new EmployeeService();

departmentService.Create("sdf", 2, 1);
departmentService.Create("asdd", 4, 1);
departmentService.Create("adsad", 5, 2);

Employee employee = new Employee("Laman", "Mammadly", 1);
Employee employee1 = new Employee("Laman", "Mammadly", 1);



employeeService.Create(employee);


departmentService.AddEmployee(employee,1);
departmentService.AddEmployee(employee1, 1);

