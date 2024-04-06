using System;
using LegacyApp.Interface;

namespace LegacyApp
{
    public class UserService
    {
        private IClientRepository _clientRepository;
        private ICreditService _creditService;
        public UserService()
        {
            this._clientRepository = new ClientRepository();
            this._creditService = new UserCreditService();
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (Walidator.CheckIsNullOrEmpty(firstName) || Walidator.CheckIsNullOrEmpty(lastName))
            {
                return false;
            }

            if (Walidator.CheckEmail(email))
            {
                return false;
            }

            if (Walidator.CheckAge(dateOfBirth))
            {
                return false;
            }

            var client = _clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else
            {
                int creditLimit = _creditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                if (client.Type == "ImportantClient")
                {
                    creditLimit = creditLimit * 2;
                }
                else
                {
                    user.HasCreditLimit = true;
                }

                user.CreditLimit = creditLimit;
            }

            if (Walidator.CheckCreditLimit(user.HasCreditLimit,user.CreditLimit))
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
