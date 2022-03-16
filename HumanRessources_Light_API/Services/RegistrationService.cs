using HumanRessources_Light_API.Models;
using HumanRessources_Light_API.Requests;
using HumanRessources_Light_API.Shared;
using System.Threading.Tasks;

namespace HumanRessources_Light_API.Services
{
    public class RegistrationService
    {

        private readonly IGenericService<Employee> _serviceEmployee;
        private readonly IGenericService<Account> _serviceAccount;
        private readonly IGenericService<Administrator> _serviceAdministrator;
        private readonly IGenericService<Role> _serviceRole;

        public RegistrationService(IGenericService<Employee> serviceEmployee,
                                   IGenericService<Account> serviceAccount,
                                   IGenericService<Administrator> serviceAdministrator,
                                   IGenericService<Role> serviceRole)
        {
            _serviceEmployee = serviceEmployee;
            _serviceAccount = serviceAccount;
            _serviceAdministrator = serviceAdministrator;
            _serviceRole = serviceRole;
        }

        /// <summary>
        ///     Register a new Administrator
        /// </summary>
        /// <param name="request"></param>
        /// <returns>
        ///     true : success
        ///     false : error
        /// </returns>
        public async Task<bool> RegisterAdministratorService(SignUpRequest request)
        {
            try
            {
                // getting the role
                var role = await ((RoleService)_serviceRole).GetRoleByNameService(
                                                             RolesEnum.Administrator.ToString());
                // creating the admin
                var admin = new Administrator{ Firstname = request.Firstname, Lastname = request.Lastname, 
                                               Gender = request.Gender, Birthday = request.Birthday};
                await _serviceAdministrator.AddAsyncService(admin);
                // creating the account
                var account = new Account
                {
                    Login = request.Login,
                    Password = request.Password,
                    OwnerId = admin.Id,
                    RoleId = role.Id
                };
                await ((AccountService)_serviceAccount).AddAsyncService(account);
                // update : adding the account into the accounts having the role
                role.AccountsIds.Add(account.Id);
                await _serviceRole.UpdateAsyncService(role);
                // update : setting the account to the admin
                admin.AccountId = account.Id;
                await _serviceAdministrator.UpdateAsyncService(admin);
                // if all Ok
                return await Task.FromResult(true);
            }
            catch (System.Exception)
            {
                // if troubles then, 
                return await Task.FromResult(false);
            }
        }

        /// <summary>
        ///     Register a new Employee
        /// </summary>
        /// <param name="request"></param>
        /// <returns>
        ///     true : success
        ///     false : error
        /// </returns>
        public async Task<bool> RegisterEmployeeService(SignUpRequest request)
        {
            try
            {
                // getting the role
                var role = await ((RoleService)_serviceRole).GetRoleByNameService(
                                                             RolesEnum.Employee.ToString());
                // creating the employee
                var employee = new Employee { Firstname = request.Firstname, Lastname = request.Lastname,
                                              Gender = request.Gender, Birthday = request.Birthday,
                                              RegistrationNumber = request.RegistrationNumber,
                                              HireDate = request.HireDate, Salary = request.Salary};
                await _serviceEmployee.AddAsyncService(employee);
                // creating the account
                var account = new Account
                {
                    Login = request.Login,
                    Password = request.Password,
                    OwnerId = employee.Id,
                    RoleId = role.Id
                };
                await ((AccountService)_serviceAccount).AddAsyncService(account);
                // update : adding the user into the users of role
                role.AccountsIds.Add(account.Id);
                await _serviceRole.UpdateAsyncService(role);
                // update : setting the account to the employee
                employee.AccountId = account.Id;
                await _serviceEmployee.UpdateAsyncService(employee);
                // if all Ok
                return await Task.FromResult(true);
            }
            catch (System.Exception)
            {
                // if troubles the,
                return await Task.FromResult(false);
            }
        }
        
    }
}
