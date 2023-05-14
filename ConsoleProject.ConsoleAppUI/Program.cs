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
            Create(companyService);
            break;
        case 2:
            Console.Clear();
            Update(companyService);
            break;
        case 3:
            Console.Clear();
            GetAll(companyService);
            break;
        case 4:
            Console.Clear();
            GetById(companyService);
            break;
        case 5:
            Console.Clear();
            GetAllDepartment(companyService);
            break;
        case 6:
            Console.Clear();
            Delete(companyService);
            break;
        case 7:
            Console.Clear();
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

void Create(CompanyService companyService)
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

    companyService.Create(companyName);
}


void Update(CompanyService companyService)
{
    string companyName;
    string newCompanyName;
    bool isValidInput = false;
    do
    {
        Console.WriteLine("Update etmek istediyniz sirketin adini daxil edin:");
        foreach (Company company in companyService.GetAll())
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
    companyService.Update(companyName, newCompanyName);
}


void Delete(CompanyService companyService)
{
    int companyId;
    bool isValidInput = false;

    do
    {
        Console.WriteLine("Silmək istədiyiniz şirkətin id-ni daxil edin: ");
        foreach (Company company in companyService.GetAll())
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
                    companyService.Delete(companyId);
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

void GetById(CompanyService companyService)
{
    int companyId;
    bool isValidInput = false;
    do
    {
        Console.WriteLine("Baxmaq istədiyiniz şirkətin id-ni daxil edin: ");
        foreach (Company company in companyService.GetAll())
        {
            Console.WriteLine($"ID: {company.Id}, Şirkətin Adı: {company.CompanyName}");
        }
        string input = Console.ReadLine();
        if (int.TryParse(input, out companyId))
        {
            var company = companyService.GetById(companyId);
            if (company != null)
            {
                isValidInput = true;
                Console.WriteLine("Şirkət tapıldı: " + company.CompanyName);
            }
            else
            {
                Console.WriteLine("Daxil edilən id ilə şirkət yoxdur. Düzgün daxil edin.");
                break;
            }
        }
        else
        {
            Console.WriteLine("Daxil edilən id düzgün deyil. Düzgün daxil edin.");
        }
    } while (!isValidInput);
}

void GetAll(CompanyService companyService)
{
    Console.WriteLine("Bütün Şirkətlər:");
    foreach (Company company in companyService.GetAll())
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
        foreach (Company company in companyService.GetAll())
        {
            Console.WriteLine($"ID: {company.Id}, Şirkətin Adı: {company.CompanyName}");
        }
        companyName = Console.ReadLine();

        var exist = companyRepository.GetByName(companyName);
        if (exist!=null)
        {
            var exitsDepartment = departmentRepository.GetCompaniesId(exist.Id);
            companyService.GetAllDepartment(companyName);
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
