using ConsoleProject.Business.Services;
using ConsoleProject.Core.Entities;
using ConsoleProject.DataAccess.Contexts;

CompanyService companyService = new CompanyService();
DepartmentService departmentService = new DepartmentService();
EmployeeService employeeService = new EmployeeService();

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
            break;
        case 5:
            Console.Clear();
            break;
        case 6:
            Console.Clear();
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
        companyName = Console.ReadLine();
        Console.WriteLine("Yeni sirket adi daxil edin");
        newCompanyName = Console.ReadLine();
        var exist = DbContext.Companies.Find(c => c.CompanyName==companyName);
        if (companyName.Trim().Length > 0)
        {
            if (exist != null)
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


void GetAll(CompanyService companyService)
{
    Console.WriteLine("Bütün Şirketler:");
    foreach (Company company in companyService.GetAll())
    {
        Console.WriteLine($"Şirket Adı: {company.CompanyName}");
    }
}