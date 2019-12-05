using System.Net.NetworkInformation;
using AdventOfCode.Year2019.Interfaces;

namespace AdventOfCode.Year2019.Implementations
{
    public class PasswordGenerator : IPasswordGenerator
    {
        private readonly IPasswordValidator _passwordValidator;

        public PasswordGenerator(IPasswordValidator passwordValidator)
        {
            _passwordValidator = passwordValidator;
        }

        public int FindValidPasswords(int start, int end)
        {
            var validPasswords = 0;

            for (int password = start; password < end; password++)
            {
                if (_passwordValidator.Validate(password))
                    validPasswords += 1;
            }

            return validPasswords;
        }

        public int FindValidPasswordsNoLargeGroupsOfNumbers(int start, int end)
        {
            var validPasswords = 0;

            for (int password = start; password < end; password++)
            {
                if (_passwordValidator.Validate(password, limitGroupSizeToMinSize: true))
                    validPasswords += 1;
            }

            return validPasswords;
        }
    }
}