using System;
using System.Collections.Generic;

namespace Task1.Solution
{
    public class PasswordCheckerService
    {
        private IRepository _repository;

        public PasswordCheckerService(IRepository repository)
        {
            Repository = repository;
        }

        private IRepository Repository
        {
            set
            {
                if (ReferenceEquals(value, null))
                {
                    throw new ArgumentNullException(nameof(Repository));
                }

                _repository = value;
            }
        }


        public Tuple<bool, string> VerifyPassword(string password, IEnumerable<IVerifier> verifiers)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password must not be empty or equal to null.", nameof(password));
            }

            if (ReferenceEquals(verifiers, null))
            {
                throw new ArgumentNullException(nameof(verifiers));
            }

            foreach (var verifier in verifiers)
            {
                Tuple<bool, string> result = verifier.Verify(password);

                if (!result.Item1)
                {
                    return result;
                }
            }

            SavePassword(password);

            return Tuple.Create(true, "Password is Ok. User was created");
        }

        private void SavePassword(string password)
        {
            _repository.Create(password);
        }
    }
}
