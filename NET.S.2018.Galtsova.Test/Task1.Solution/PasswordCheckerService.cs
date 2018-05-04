using System;

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


        public Tuple<bool, string> VerifyPassword(string password, Func<string, Tuple<bool, string>> verifier)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password must not be empty or equal to null.", nameof(password));
            }

            if (ReferenceEquals(verifier, null))
            {
                throw new ArgumentNullException(nameof(verifier));
            }

            var verifiers = verifier.GetInvocationList();

            foreach (var item in verifiers)
            {
                Tuple<bool, string> result = ((Func<string, Tuple<bool, string>>)item).Invoke(password);

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
