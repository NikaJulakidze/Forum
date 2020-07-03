using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Service.StaticSettings
{
    public static class StaticRoutes
    {
        public static string BaseUrl = "https://localhost:44326/api/";

        public static class Account
        {
            public const string Register = "Register";
            public const string Authenticate = "Authenticate";
            public const string FirstSetup = "FirstSetup";
            public const string ForgotPassword = "ForgotPassword";
            public const string RessetPassword = "RessetPassword";
        }
        public static class Questions
        {
            public const string GetQuestions = "GetQuestions";
        }
        public static class Forums
        {

        }
        public static class PostReplies
        {

        }
        public static class Articles
        {

        }
        public static class Admin
        {
            public const string CreateRole = "CreateRole";
        }

    }
}
