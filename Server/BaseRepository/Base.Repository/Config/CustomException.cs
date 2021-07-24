using System;
using System.Net;

namespace Base.Repository.ExceptionUtils
{
    public class CustomException : System.Exception {
        public CustomException (string message, HttpStatusCode status) : base (message, new System.Exception (Convert.ToInt32 (status).ToString ())) { }
    }
}