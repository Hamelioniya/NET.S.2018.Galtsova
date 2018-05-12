using System;

namespace Task1.Solution
{
    public interface IVerifier
    {
        Tuple<bool, string> Verify(string password);
    }
}
