using HumanRessources_Light_API.Models;
using HumanRessources_Light_API.Requests;
using HumanRessources_Light_API.Responses;
using HumanRessources_Light_API.Shared;
using HumanRessources_Light_API.Shared.Responses;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HumanRessources_Light_API.Services
{
    /// <summary>
    ///     Authentification service
    /// </summary>
    public class AuthentificationService
    {
        private readonly IGenericService<Account> _accountService;
        private readonly IGenericService<Role> _roleService;
        private readonly IGenericService<Employee> _employeeService;
        private readonly IGenericService<Administrator> _administratorService;
        private readonly IConfiguration _configuration;
        public AuthentificationService(IGenericService<Account> accountService,
                                       IGenericService<Role> roleService,
                                       IGenericService<Employee> employeeService,
                                       IGenericService<Administrator> administratorService,
                                       IConfiguration configuration)
        {
            _accountService = accountService;
            _roleService = roleService;
            _employeeService = employeeService;
            _administratorService = administratorService;
            _configuration = configuration;
        }

        /// <summary>
        ///     verify the validity of user credentials 
        ///     send-back important informations to use other services
        /// </summary>
        /// <param name="request"> SignInRequest </param>
        /// <returns> SignInResponse object </returns>
        public async Task<IResponse> SignIn(SignInRequest request)
        {
            var response = new SignInResponse();
            var account = await ((AccountService)_accountService).GetAccountByLoginService(request.login);
            if(ValidCredentials(request, response, account))
            {
                var role = await _roleService.GetByIdAsyncService(account.RoleId);
                response.roleName = role.RoleName ;
                response.account = account;
                response = await GetUser(response, role.RoleName, account.OwnerId);
                response.Token = GetToken(account.Login, role.RoleName);
                response.SetStatus(200, "Succes");
            }
            return await Task.FromResult(response);
        }

        /// <summary>
        ///     Verify the validity of credentials
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        private bool ValidCredentials(SignInRequest request, IResponse response, Account account)
        {
            if (account == null)
            {
                response.SetStatus(400, "Invalid login");
                return false;
            }
            if (!PasswordHandler.Verify(request.password, account.Password))
            {
                response.SetStatus(400, "Invalid password");
                return false;
            }
            return true;
        }

        /// <summary>
        ///     Get User based on Role
        /// </summary>
        /// <param name="response"></param>
        /// <param name="roleName"></param>
        /// <param name="UserId"></param>
        /// <returns> The user</returns>
        private async Task<SignInResponse> GetUser(SignInResponse response, string roleName, string UserId)
        {
            switch (RolesEnumConverter.ToRolesEnum(roleName))
            {
                case RolesEnum.Administrator:
                    response.user = await _administratorService.GetByIdAsyncService(UserId);
                    break;
                case RolesEnum.Employee:
                    response.user = await _employeeService.GetByIdAsyncService(UserId);
                    break;
                default: response.user = null; break;
            }
            return await Task.FromResult(response);
        }

        /// <summary>
        ///     Create a token for a specific user
        /// </summary>
        /// <param name="login"></param>
        /// <param name="roleName"></param>
        /// <returns> Token string</returns>
        private string GetToken(string login, string roleName)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("login", login));
            claims.Add(new Claim(ClaimTypes.Role, roleName));
            var token = JwtHelper.GetJwtToken(
                            login,
                            _configuration["jwt:Key"],
                            _configuration["jwt:Issuer"],
                            _configuration["jwt:Audience"],
                            TimeSpan.FromMinutes(60),
                            claims.ToArray());
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
