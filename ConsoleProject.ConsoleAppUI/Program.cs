using System.ComponentModel.Design;
using ConsoleProject.Business.Services;
using ConsoleProject.Core.Entities;
using ConsoleProject.DataAccess.Contexts;
using ConsoleProject.DataAccess.Implementations;

CompanyService companyService = new CompanyService();
DepartmentService departmentService = new DepartmentService();
EmployeeService employeeService = new EmployeeService();
DepartmentRepository departmentRepository = new DepartmentRepository();
CompanyRepository companyRepository = new CompanyRepository();

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
    Console.WriteLine("13.Departament yaratmaq: ");
    Console.WriteLine("14.Employee yaratmaq: ");
    Console.WriteLine("15.Employee update etmək: ");
    Console.WriteLine("16.Bütün employeeləri gətirmək: ");
    Console.WriteLine("17.İd`sinə görə employeeləri gətirmək: ");
    Console.WriteLine("18.Employee silmək: ");
    Console.WriteLine("19.Menyudan çıx: ");
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
            break;
        case 9:
            Console.Clear();
            break;
        case 10:
            Console.Clear();
            break;
        case 11:
            Console.Clear();
            break;
        case 12:
            Console.Clear();
            break;
        case 13:
            Console.Clear();
            break;
        case 14:
            Console.Clear();
            break;
        case 15:
            Console.Clear();
            break;
        case 16:
            Console.Clear();
            break;
        case 17:
            Console.Clear();
            break;
        case 18:
            Console.Clear();
            break;
        case 19:
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

        if ((!string.IsNullOrWhiteSpace(companyName)) )
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
        var exist = DbContext.Companies.Find(c => c.CompanyName==companyName);
        var existNewname = DbContext.Companies.Find(c => c.CompanyName==newCompanyName);
        if (companyName.Trim().Length > 0)
        {
            if (exist != null)
            {
                if(existNewname==null)
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
            var company = DbContext.Companies.Find(c=>c.Id==companyId);
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
        if (exist!=null)
        {
            var exitsDepartment = departmentRepository.GetCompaniesId(exist.Id);
            foreach (Department item in companyService.GetAllDepartment(companyName))
            {
                Console.WriteLine(item.DepartmentName);
            }
            isValidInput = true;
             if(exitsDepartment.Count==0)
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

    departmentService.CreateDepartment(departmentName, departmentLimit,companyId);
}
