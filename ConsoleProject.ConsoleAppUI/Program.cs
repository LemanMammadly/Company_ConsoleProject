using ConsoleProject.Business.Services;
using ConsoleProject.Core.Entities;


////CompanyService companyService = new CompanyService();

////Console.WriteLine("firts");
////companyService.Create("sdfsd");



////Console.WriteLine("second");
////companyService.Create("sdk");


////Console.WriteLine("third");
////companyService.Create("sdfss");


////foreach (Company item in companyService.GetAll())
////{
////    Console.WriteLine($"{item.CompanyName}   {item.creationTime}");
//}

////Console.WriteLine(companyService.GetById(1));


////companyService.Delete(3);

////companyService.Create("sdffw");


////foreach (Company item in companyService.GetAll())
////{
////    Console.WriteLine($"{item.CompanyName}   {item.creationTime}");
////}



////companyService.Create("qwewqe");





////departmentService.Delete(0);

////companyService.Delete(1);


////departmentService.Delete(0);

////companyService.GetAllDepartment("sdfss");


////foreach (Department item in companyService.GetAllDepartment("sdfss"))
////{
////    Console.WriteLine(item);
////}

////Console.WriteLine(departmentService.GetById(0));


////foreach (Department item in departmentService.GetAll())
////{
////    Console.WriteLine(item);
////}




//Console.WriteLine("employe");
////employeeService.Create("Laman", "", 1);
////Console.WriteLine("department");

//DepartmentService departmentService = new DepartmentService();
//EmployeeService employeeService = new EmployeeService();

//departmentService.Create("sdf", 5, 1);
//departmentService.Create("asdd", 1, 1);
//departmentService.Create("adsad", 1, 2);

//Employee employee = new Employee("Laman", "Mammadly", 1);
//Employee employee1 = new Employee("Laman", "Mammadly", 1);
//Employee employee2 = new Employee("Laman", "Mammadly", 1);
//Employee employee3 = new Employee("Laman", "Mammadly", 1);
//Employee employee4 = new Employee("Laman", "Mammadly", 1);
//Employee employee5 = new Employee("Laman", "Mammadly", 1);



//employeeService.Create(employee);
//employeeService.Create(employee1);
//employeeService.Create(employee2);
//employeeService.Create(employee3);
//employeeService.Create(employee4);



//departmentService.AddEmployee(employee,1);
//departmentService.AddEmployee(employee1,1);
//departmentService.AddEmployee(employee2,1);
//departmentService.AddEmployee(employee3,1);
//departmentService.AddEmployee(employee4,1);
//departmentService.AddEmployee(employee5,1);


//employeeService.Update(4, "laman", "Mammadli", 1, 2);


////departmentService.Update("sdsdf", "sdF", 2);

//employeeService.Delete(2);

////foreach (Employee item in departmentService.GetDepartmentEmployees("sdf"))
////{
////    Console.WriteLine(item);
////}


////foreach (Employee item in employeeService.GetAll())
////{
////    Console.WriteLine(item);
////}


//Console.WriteLine(employeeService.GetById(3));


CompanyService companyService = new CompanyService();
companyService.Create("PullBear");
companyService.Create("Bershka");

//companyService.Create("pulbaar");
//companyService.Delete(2);

//companyService.Update("PullBear", "Bershka");
//Console.WriteLine(companyService.GetById(2)); 


foreach (Company item in companyService.GetAll())
{
    Console.WriteLine($"{item.CompanyName}  id: {item.Id}");
}

DepartmentService departmentService = new DepartmentService();
departmentService.Create("Ganjlik Mall",10,1);
departmentService.Create("28 Mall", 10, 2);
departmentService.Update("28 Mall", "28 may", 1);


foreach (Department item in departmentService.GetAll())
{
    Console.WriteLine($"{item.DepartmentName} limit: {item.EmployeeLimit}  id: {item.Id}  CompanyId: {item.CompanyId}");
}

EmployeeService employeeService = new EmployeeService();

Employee employee1 = new Employee("Laman", "Mammadli", 15000);
Employee employee2 = new Employee("Nicat", "Mammadli", 20000);
Employee employee3 = new Employee("Laman", "Muxtarova", 35000);

employeeService.Create(employee1);
employeeService.Create(employee2);
employeeService.Create(employee3);


foreach (Employee item in employeeService.GetAll())
{
    Console.WriteLine($"{item.Name} {item.Surname} salary:{item.Salary} id: {item.Id}");
}
