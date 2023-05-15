using System.ComponentModel.Design;
using ConsoleProject.Business.Helpers;
using ConsoleProject.Business.Services;
using ConsoleProject.Core.Entities;
using ConsoleProject.DataAccess.Contexts;
using ConsoleProject.DataAccess.Implementations;

CompanyService companyService = new CompanyService();
DepartmentService departmentService = new DepartmentService();
EmployeeService employeeService = new EmployeeService();
DepartmentRepository departmentRepository = new DepartmentRepository();
CompanyRepository companyRepository = new CompanyRepository();
EmployeeRepository employeeRepository = new EmployeeRepository();

do
{
    Console.WriteLine("*************Welcomeee!!!!!*************");
    Console.WriteLine("Etmek istediyiniz emeliyyatin reqemini daxil edin:\n ");
    Console.WriteLine("1.Şirkət yaratmaq: ");
    Console.WriteLine("2.Şirkət update etmek: ");
    Console.WriteLine("3.Bütün şirkətləri göstərmək: ");
    Console.WriteLine("4.İd`sinə görə şirkəti gətirmək: ");
    Console.WriteLine("5.Şirkətdəki bütün departamentləri göstərmək: ");
    Console.WriteLine("6.Şirkət silmək: ");
    Console.WriteLine("7.Departament yaratmaq: ");
    Console.WriteLine("8.Departament update etmek: ");
    Console.WriteLine("9.Bütün departamentləri göstərmək: ");
    Console.WriteLine("10.İd`sinə görə departameni gətirmək: ");
    Console.WriteLine("11.Departamentdəki bütün employeeleri göstərmək: ");
    Console.WriteLine("12.Departament silmək: ");
    Console.WriteLine("13.Departamente Employee elave etmek: ");
    Console.WriteLine("14.Employee yaratmaq: ");
    Console.WriteLine("15.Employee update etmək: ");
    Console.WriteLine("16.Bütün employeeləri gətirmək: ");
    Console.WriteLine("17.İd`sinə görə employeeləri gətirmək: ");
    Console.WriteLine("18.Employee silmək: ");
    Console.WriteLine("0.Menyudan çıx: ");
    string choose = Console.ReadLine();
    int chooseNum;
    while (!int.TryParse(choose, out chooseNum) || chooseNum > 19 || chooseNum < 1)
    {
        Console.WriteLine("Etmək istədiyiniz əməliyyatı düzgün qeyd edin:");
        choose = Console.ReadLine();
    }
    switch (chooseNum)
    {
        case 1:
            Console.Clear();
            CreateCompany(companyService);
            break;
        case 2:
            Console.Clear();
            UpdateCompany(companyService);
            break;
        case 3:
            Console.Clear();
            GetAllCompany(companyService);
            break;
        case 4:
            Console.Clear();
            GetByIdCompany(companyService);
            break;
        case 5:
            Console.Clear();
            GetAllDepartment(companyService);
            break;
        case 6:
            Console.Clear();
            DeleteCompany(companyService);
            break;
        case 7:
            Console.Clear();
            CreateDepartment(departmentService);
            break;
        case 8:
            Console.Clear();
            UpdateDepartment(departmentService);
            break;
        case 9:
            Console.Clear();
            GetAllDepartments(departmentService);
            break;
        case 10:
            Console.Clear();
            GetByIdDepartment(departmentService);
            break;
        case 11:
            Console.Clear();
            GetDepartmentEmployees(departmentService);
            break;
        case 12:
            Console.Clear();
            DeleteDepartment(departmentService);
            break;
        case 13:
            Console.Clear();
            AddEmployee(departmentService);
            break;
        case 14:
            Console.Clear();
            CreateEmployee(employeeService);
            break;
        case 15:
            Console.Clear();
            UpdateEmployee(employeeService);
            break;
        case 16:
            Console.Clear();
            GetAllEmployee(employeeService);
            break;
        case 17:
            Console.Clear();
            GetByIdEmployee(employeeService);
            break;
        case 18:
            Console.Clear();
            DeleteEmployee(employeeService);
            break;
        case 0:
            Console.Clear();
            return;
    }
} while (true);


void CreateCompany(CompanyService companyService)
{
    string companyName;
    bool isValidInput = false;

    do
    {
        Console.Write("Şirkətin adı: ");
        companyName = Console.ReadLine();

        if ((!string.IsNullOrWhiteSpace(companyName)))
        {
            Company? existingCompany = DbContext.Companies.Find(c => c.CompanyName.Equals(companyName, StringComparison.OrdinalIgnoreCase));

            if (existingCompany == null)
            {
                isValidInput = true;
            }
            else
            {
                Console.WriteLine("Bu adda şirkət var.Başqa ad daxil edin: \n");
            }
        }
        else
        {
            Console.WriteLine("Düzgün şirkət adı daxil edin: .\n");
        }
    } while (!isValidInput);

    companyService.CreateCompany(companyName);
}


void UpdateCompany(CompanyService companyService)
{
    string companyName;
    string newCompanyName;
    bool isValidInput = false;
    do
    {
        Console.WriteLine("Update etmek istediyniz sirketin adini daxil edin:");
        foreach (Company company in companyService.GetAllCompany())
        {
            Console.WriteLine($"Şirkətin Adı: {company.CompanyName}");
        }
        companyName = Console.ReadLine();
        Console.WriteLine("Yeni sirket adi daxil edin");
        newCompanyName = Console.ReadLine();
        var exist = DbContext.Companies.Find(c => c.CompanyName == companyName);
        var existNewname = DbContext.Companies.Find(c => c.CompanyName == newCompanyName);
        if (companyName.Trim().Length > 0)
        {
            if (exist != null)
            {
                if (existNewname == null)
                {
                    if (companyName.Trim().ToLower() != newCompanyName.Trim().ToLower())
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Şirkət adı eynidir");
                    }
                }
                else
                {
                    Console.WriteLine("Bu adda şirkət mövcuddur");
                }
            }
            else
            {
                Console.WriteLine("Bu adda şirkət yoxdur");
            }
        }
        else
        {
            Console.WriteLine("Şirkətin adının uzunlugu azdir");
        }
    } while (!isValidInput);
    companyService.UpdateCompany(companyName, newCompanyName);
}


void DeleteCompany(CompanyService companyService)
{
    int companyId;
    bool isValidInput = false;

    do
    {
        Console.WriteLine("Silmək istədiyiniz şirkətin id-ni daxil edin: ");
        foreach (Company company in companyService.GetAllCompany())
        {
            Console.WriteLine($"ID: {company.Id}, Şirkətin Adı: {company.CompanyName}");
        }
        string input = Console.ReadLine();

        if (int.TryParse(input, out companyId))
        {
            var company = DbContext.Companies.Find(c => c.Id == companyId);
            if (company != null)
            {
                bool hasDepartments = DbContext.Departments.Any(d => d.CompanyId == companyId);
                if (!hasDepartments)
                {
                    isValidInput = true;
                    companyService.DeleteCompany(companyId);
                    Console.WriteLine("Şirkət silindi: " + company.CompanyName);
                }
                else
                {
                    Console.WriteLine("Şirkət silinə bilməz çünki şirkətin içində departamentlər mövcuddur.");
                }
            }
            else
            {
                Console.WriteLine("Daxil edilən id ilə şirkət tapılmadı.Düzgün daxil edin");
            }
        }
        else
        {
            Console.WriteLine("Daxil edilən id doğru deyil.Düzgün daxil edin");
        }

    } while (!isValidInput);
}

void GetByIdCompany(CompanyService companyService)
{
    int companyId;
    bool isValidInput = false;
    do
    {
        Console.WriteLine("Baxmaq istədiyiniz şirkətin id-ni daxil edin: ");
        foreach (Company company in companyService.GetAllCompany())
        {
            Console.WriteLine($"ID: {company.Id}, Şirkətin Adı: {company.CompanyName}");
        }
        string input = Console.ReadLine();
        if (int.TryParse(input, out companyId))
        {
            var company = DbContext.Companies.Find(c => c.Id == companyId);
            if (company != null)
            {
                isValidInput = true;
                Console.WriteLine("Şirkət tapıldı: " + company.CompanyName);
            }
            else
            {
                Console.WriteLine("Sirket yoxdur.");
            }
        }
        else
        {
            Console.WriteLine("Daxil edilən id düzgün deyil. Düzgün daxil edin.");
        }
    } while (!isValidInput);
}

void GetAllCompany(CompanyService companyService)
{
    Console.WriteLine("Bütün Şirkətlər:");
    foreach (Company company in companyService.GetAllCompany())
    {
        Console.WriteLine($"Şirkətin Adı: {company.CompanyName}");
    }
}


void GetAllDepartment(CompanyService companyService)
{
    string companyName;
    bool isValidInput = false;
    do
    {
        Console.WriteLine("Departamentlerini görmək istədiyiniz şirkətin adini daxil edin: ");
        foreach (Company company in companyService.GetAllCompany())
        {
            Console.WriteLine($"ID: {company.Id}, Şirkətin Adı: {company.CompanyName}");
        }
        companyName = Console.ReadLine();

        var exist = companyRepository.GetByName(companyName);
        if (exist != null)
        {
            var exitsDepartment = departmentRepository.GetCompaniesId(exist.Id);
            foreach (Department item in companyService.GetAllDepartment(companyName))
            {
                Console.WriteLine(item.DepartmentName);
            }
            isValidInput = true;
            if (exitsDepartment.Count == 0)
            {
                Console.WriteLine("Sirketin departmentleri yoxdur.");
            }
        }
        else
        {
            Console.WriteLine("Bu adda sirket yoxdur");
        }
    } while (!isValidInput);
}

void CreateDepartment(DepartmentService departmentService)
{
    string departmentName;
    int departmentLimit;
    int companyId;
    bool isValidInput = false;

    do
    {
        Console.Write("Departmentin adı: ");
        departmentName = Console.ReadLine();

        Console.Write("Department limitini daxil edin: ");
        departmentLimit = int.Parse(Console.ReadLine());

        Console.Write("Departmentin Company ID'sini qeyd edin (Hansi şirkətə aid olduğunu daxil edin): ");
        foreach (Company company in companyService.GetAllCompany())
        {
            Console.WriteLine($"ID: {company.Id}, Şirkətin Adı: {company.CompanyName}");
        }
        companyId = int.Parse(Console.ReadLine());

        Department existingDepartment = departmentRepository.GetByName(departmentName.Trim());
        Company? existingCompany = companyRepository.Get(companyId);


        if (existingDepartment == null)
        {
            if (departmentLimit > 0)
            {
                if (existingCompany != null)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Daxil edilən company ID ilə şirkət tapılmadı. Düzgün bir company ID daxil edin.");
                }
            }
            else
            {
                Console.WriteLine("Limit 0-dan boyuk olmalidir");
            }
        }
        else
        {
            Console.WriteLine("Bu adda department movcuddur");
        }

    } while (!isValidInput);

    departmentService.CreateDepartment(departmentName, departmentLimit, companyId);
}


void UpdateDepartment(DepartmentService departmentService)
{
    string departmentName;
    string newDepartmentName;
    int newDepartmentLimit;
    bool isValidInput = false;

    do
    {
        Console.WriteLine("Update etmek istediyiniz departmentin adini qeyd edin:");
        foreach (Department department in departmentService.GetAllDepartments())
        {
            Console.WriteLine($"Department ID: {department.Id} Departmentin Adı: {department.DepartmentName}");
        }
        departmentName = Console.ReadLine();

        Console.WriteLine("Departmentin yeni adini qeyd edin: ");
        newDepartmentName = Console.ReadLine();

        Console.WriteLine("Departmentin yeni limitini qeyd edin:");
        newDepartmentLimit = int.Parse(Console.ReadLine());

        Department existingDepartment = departmentRepository.GetByName(departmentName.Trim());
        Department existingNewDepartment = departmentRepository.GetByName(newDepartmentName.Trim());

        if (existingDepartment != null)
        {
            if (existingNewDepartment == null)
            {
                if (!string.IsNullOrWhiteSpace(newDepartmentName))
                {
                    if (newDepartmentName.Trim().ToUpper() != departmentName.Trim().ToUpper())
                    {
                        if (newDepartmentLimit > departmentService.GetDepartmentEmployees(departmentName).Count)
                        {
                            if (newDepartmentLimit > 0)
                            {
                                isValidInput = true;
                                departmentService.UpdateDepartment(departmentName, newDepartmentName, newDepartmentLimit);
                            }
                            else
                            {
                                Console.WriteLine("Limit 0 dan kick olmamalidir");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Limit duzgun qeyd edilmeyib");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Departmentin yeni adi evvelki ile eyni olmamalidir");
                    }
                }
                else
                {
                    Console.WriteLine("Yeni department adini duzgun qeyd edin");
                }
            }
            else
            {
                Console.WriteLine("Bu adda department movcuddur");
            }
        }
        else
        {
            Console.WriteLine("Bele bir department movcud deyil");
        }

    } while (!isValidInput);
}


void DeleteDepartment(DepartmentService departmentService)
{
    int departmentId;
    bool isValidInput = false;
    do
    {
        Console.WriteLine("Silmek istediyiniz department Id'sini qeyd edin: ");
        foreach (Department department in departmentService.GetAllDepartments())
        {
            Console.WriteLine($"Department ID: {department.Id} Departmentin Adı: {department.DepartmentName}");
        }
        departmentId = int.Parse(Console.ReadLine());
        var existDepartment = departmentRepository.Get(departmentId);
        if (existDepartment != null)
        {
            if (employeeRepository.GetAlDepartmentId(departmentId).Count == 0)
            {
                isValidInput = true;
                departmentService.DeleteDepartment(departmentId);
            }
            else
            {
                Console.WriteLine("Departmentde isci movcuddur.Department siline bilmez");
            }
        }
        else
        {
            Console.WriteLine("Bu id li department movcud deyil");
        }

    } while (!isValidInput);
}

void GetAllDepartments(DepartmentService departmentService)
{
    Console.WriteLine("Bütün Departmentler:");
    foreach (Department department in departmentService.GetAllDepartments())
    {
        Console.WriteLine($"Department ID: {department.Id} Departmentin Adı: {department.DepartmentName}");
    }
}


void GetByIdDepartment(DepartmentService departmentService)
{
    int departmentId;
    bool isValidInput = false;
    do
    {
        Console.WriteLine("Baxmaq istədiyiniz departmentin id-ni daxil edin: ");
        foreach (Department department in departmentService.GetAllDepartments())
        {
            Console.WriteLine($"ID: {department.Id}, Şirkətin Adı: {department.DepartmentName}");
        }
        string input = Console.ReadLine();
        if (int.TryParse(input, out departmentId))
        {
            var department = DbContext.Departments.Find(d => d.Id == departmentId);
            if (department != null)
            {
                isValidInput = true;
                Console.WriteLine("Department tapıldı: " + department.DepartmentName);
            }
            else
            {
                Console.WriteLine("Department yoxdur.");
            }
        }
        else
        {
            Console.WriteLine("Daxil edilən id düzgün deyil. Düzgün daxil edin.");
        }
    } while (!isValidInput);
}


void CreateEmployee(EmployeeService employeeService)
{
    string name;
    string surname;
    double salary;
    bool isValidInput = false;

    do
    {
        Console.WriteLine("Iscinin adini daxil edinL:");
        name = Console.ReadLine();
        Console.WriteLine("Iscinin soyadini daxil edinL:");
        surname = Console.ReadLine();
        Console.WriteLine("Iscinin maasini daxil edinL:");
        salary = double.Parse(Console.ReadLine());

        if (!string.IsNullOrWhiteSpace(name.Trim()))
        {
            if (name.Trim().Length >= 2)
            {
                if (name.Trim().IsOnlyLetters())
                {
                    if (!string.IsNullOrWhiteSpace(surname.Trim()))
                    {
                        if (surname.Trim().IsOnlyLetters())
                        {

                            if (salary > 0)
                            {
                                isValidInput = true;
                            }
                            else
                            {
                                Console.WriteLine("Maas 0 dan boyuk olmalidir");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Soyadi duzgun formatda daxil edin");
                        }
                    }
                    else
                    {
                        isValidInput = true;
                    }
                }
                else
                {
                    Console.WriteLine("Adi duzgun formatda daxil edin");
                }
            }
            else
            {
                Console.WriteLine("Iscinin adinin uzunlugu 2 den kicik ola bilmez");
            }
        }
        else
        {
            Console.WriteLine("Iscinin adini duzgun daxil edin");
        }
    } while (!isValidInput);
    Employee employee = new Employee(name, surname, salary);
    employeeService.CreateEmployee(employee);
}

void AddEmployee(DepartmentService departmentService)
{
    string name;
    string surname;
    double salary;
    int departmentId;
    bool isValidInput = false;

    do
    {
        Console.WriteLine("Iscinin adini daxil edinL:");
        name = Console.ReadLine();
        Console.WriteLine("Iscinin soyadini daxil edinL:");
        surname = Console.ReadLine();
        Console.WriteLine("Iscinin maasini daxil edinL:");
        salary = double.Parse(Console.ReadLine());
        Console.WriteLine("Iscini elave etmek istedyiniz department ID ni secin:");
        foreach (Department department in departmentService.GetAllDepartments())
        {
            Console.WriteLine($"Department ID: {department.Id} Departmentin Adı: {department.DepartmentName}");
        }
        departmentId = int.Parse(Console.ReadLine());

        var existDepartmentId = DbContext.Departments.Find(d => d.Id == departmentId);

        if (!string.IsNullOrWhiteSpace(name.Trim()))
        {
            if (name.Trim().Length >= 2)
            {
                if (name.Trim().IsOnlyLetters())
                {
                    if (!string.IsNullOrWhiteSpace(surname.Trim()))
                    {
                        if (surname.Trim().IsOnlyLetters())
                        {
                            if (salary > 0)
                            {
                                if (existDepartmentId != null)
                                {
                                    if (departmentService.GetDepartmentEmployees(existDepartmentId.DepartmentName).Count < existDepartmentId.EmployeeLimit)
                                    {
                                        Employee employee = new Employee(name, surname, salary);
                                        employeeService.CreateEmployee(employee);
                                        if (employee.DepartmentId == 0)
                                        {
                                            departmentService.AddEmployee(employee, departmentId);
                                            isValidInput = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Isci ferqli departmente mexsusdur");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Limit Isci sayindan az olmamalidir");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Bu Id li department yoxdur.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Maas 0 dan boyuk olmalidir");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Soyadi duzgun formatda daxil edin");
                        }
                    }
                    else
                    {
                        isValidInput = true;
                    }
                }
                else
                {
                    Console.WriteLine("Adi duzgun formatda daxil edin");
                }
            }
            else
            {
                Console.WriteLine("Iscinin adinin uzunlugu 2 den kicik ola bilmez");
            }
        }
        else
        {
            Console.WriteLine("Iscinin adini duzgun daxil edin");
        }
    } while (!isValidInput);
}


void GetDepartmentEmployees(DepartmentService departmentService)
{
    string departmentName;
    bool isValidInput = false;
    do
    {
        Console.WriteLine("Siyahisini gostermek istedyiniz employeelerin department adini qeyd edin:");
        departmentName = Console.ReadLine();

        var exists = departmentRepository.GetByName(departmentName);
        if (exists != null)
        {
            var employess = employeeRepository.GetAlDepartmentId(exists.Id);
            if (employess.Count != 0)
            {
                isValidInput = true;
                foreach (Employee item in departmentService.GetDepartmentEmployees(departmentName))
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Isci yoxdur");
                isValidInput = true;
            }
        }
        else
        {
            Console.WriteLine("Bele bir adda department movcud deyil");
        }

    } while (!isValidInput);
}


void GetAllEmployee(EmployeeService employeeService)
{
    Console.WriteLine("Bütün Isciler:");
    foreach (Employee employee in employeeService.GetAllEmployee())
    {
        Console.WriteLine($"Isci adi: {employee.Name} Isci Soyad: {employee.Surname}  Isci maasi: {employee.Salary}");
    }
}


void GetByIdEmployee(EmployeeService employeeService)
{
    int employeeId;
    bool isValidInput = false;
    do
    {
        Console.WriteLine("Baxmaq istədiyiniz employeenin id-ni daxil edin: ");
        foreach (Employee employee in employeeService.GetAllEmployee())
        {
            Console.WriteLine($"Isci Id : {employee.Id} Isci adi: {employee.Name} Isci Soyad: {employee.Surname} ");
        }
        string input = Console.ReadLine();
        if (int.TryParse(input, out employeeId))
        {
            var employee = DbContext.Employees.Find(e => e.Id == employeeId);
            if (employee != null)
            {
                isValidInput = true;
                employeeService.GetByIdEmployee(employeeId);
                Console.WriteLine($"Employee tapıldı: + {employee.Name}  {employee.Surname}  {employee.Salary}");
            }
            else
            {
                Console.WriteLine("Employee yoxdur.");
            }
        }
        else
        {
            Console.WriteLine("Daxil edilən id düzgün deyil. Düzgün daxil edin.");
        }
    } while (!isValidInput);
}


void UpdateEmployee(EmployeeService employeeService)
{
    int employeeId;
    string name;
    string surname;
    double salary;
    int departmentId;
    bool isValidInput = false;

    do
    {
        Console.WriteLine("Update etmek istediyiniz iscinin Id-sini secin: ");
        foreach (Employee employee in employeeService.GetAllEmployee())
        {
            Console.WriteLine($"Isci Id : {employee.Id} Isci adi: {employee.Name} Isci Soyad: {employee.Surname} ");
        }
        employeeId = int.Parse(Console.ReadLine());
        Console.WriteLine("Yeni ad:");
        name = Console.ReadLine();
        Console.WriteLine("Yeni soyad:");
        surname = Console.ReadLine();
        Console.WriteLine("Yeni maas: ");
        salary = double.Parse(Console.ReadLine());
        Console.WriteLine("Yeni department ID : ");
        departmentId = int.Parse(Console.ReadLine());


        var exists = DbContext.Employees.Find(e => e.Id == employeeId);
        var existsDepartment = DbContext.Departments.Find(d => d.Id == departmentId);

        if (exists != null)
        {
            if (!string.IsNullOrWhiteSpace(name.Trim()))
            {
                if (name.Trim().Length >= 2)
                {
                    if (name.Trim().IsOnlyLetters())
                    {
                        if (!string.IsNullOrWhiteSpace(surname.Trim()))
                        {
                            if (surname.Trim().IsOnlyLetters())
                            {

                                if (salary > 0)
                                {
                                    if (existsDepartment != null)
                                    {
                                        isValidInput = true;
                                        employeeService.UpdateEmployee(employeeId, name, surname, salary, departmentId);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Bu Id li department movcud deyil");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Maas 0 dan boyuk olmalidir");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Soyadi duzgun formatda daxil edin");
                            }
                        }
                        else
                        {
                            isValidInput = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Adi duzgun formatda daxil edin");
                    }
                }
                else
                {
                    Console.WriteLine("Iscinin adinin uzunlugu 2 den kicik ola bilmez");
                }
            }
            else
            {
                Console.WriteLine("Iscinin adini duzgun daxil edin");
            }
        }
        else
        {
            Console.WriteLine("Bu ID li isci movcud deyil");
        }
    } while (!isValidInput);
}



void DeleteEmployee(EmployeeService employeeService)
{
    int employeeId;
    bool isValidInput = false;

    do
    {
        Console.WriteLine("Silmek istediyiniz Employeenin Id-sini yazin:");
        foreach (Employee employee in employeeService.GetAllEmployee())
        {
            Console.WriteLine($"Isci Id : {employee.Id} Isci adi: {employee.Name} Isci Soyad: {employee.Surname} ");
        }
        employeeId = int.Parse(Console.ReadLine());
        var existEmployee = DbContext.Employees.Find(e => e.Id == employeeId);
        if (existEmployee != null)
        {
            isValidInput = true;
            employeeService.DeleteEmployee(employeeId);
        }
        else
        {
            Console.WriteLine("Bu IDli employee movcud deyil");
        }
    } while (!isValidInput);
}