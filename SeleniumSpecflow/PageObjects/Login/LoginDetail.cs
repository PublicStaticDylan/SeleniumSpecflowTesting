using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumSpecflow.PageObjects.Login
{
    public static class LoginDetail
    {
        //get login site url
        public static string GetURL()
        {
            return "https://www.saucedemo.com/";
        }

        //accepted usernames for site, 0-3 are valid usernames and any other integer returns an incorrect one
        //depreciated, using data tables now
        public static string GetUsername(int usernameToUse)
        {
            switch(usernameToUse)
            {
                case 0:
                    return "standard_user";

                case 1:
                    return "locked_out_user";

                case 2:
                    return "problem_user";

                case 3:
                    return "performance_glitch_user";

                default:
                    return "incorrect_password";
            }
        }
        //returns either a correct password for true or incorrect for false
        //depreciated, using data tables now
        public static string Password(bool isCorrectPassword)
        {
            if(isCorrectPassword)
            {
                return "secret_sauce";
            }

            return "wrong_password";
        }

    }
}
