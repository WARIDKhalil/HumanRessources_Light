using HumanRessources_Light_API.Models;
using HumanRessources_Light_API.Repositories;
using HumanRessources_Light_API.Shared;
using System.Threading.Tasks;

namespace HumanRessources_Light_API.Services
{
    public class AccountService : GenericService<Account>
    {
        public AccountService(IRepository<Account> repository) 
            : base(repository)
        {

        }

        /// <summary>
        ///   An Overrided Creating account service
        ///   Uses Hashing password before creatingthe account
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> new Account</returns>
        public override Task<Account> AddAsyncService(Account entity)
        {
            entity.Password = PasswordHandler.Hash(entity.Password);
            return base.AddAsyncService(entity);
        }

        /// <summary>
        ///     Getting the account based on Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns>The target account</returns>
        public async Task<Account> GetAccountByLoginService(string login)
        {
            return await ((AccountRepository)_repository).GetAccountByLogin(login);
        }

    }
}
