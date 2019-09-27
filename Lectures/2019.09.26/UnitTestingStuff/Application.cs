using System;

namespace Ewu.Cscd371.UnitTestingStuff
{
    public class Application
    {
        public bool Login(string userName, string password)
        {
            if (password is null)
            {
                throw new ArgumentNullException("password");
            }

            return (password.StartsWith("m"));
        }
    }
}
