using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Forum.Service.Models
{
    public class Result
    {
        public bool Succeeded => Errors.Count == 0;
        public List<string> Errors { get; set; } = new List<string>();
        public string Message { get; set; }

        public void AddErrors(IEnumerable<string> errors) => Errors.AddRange(errors);
        public void AddError(string error) => Errors.Add(error);
        public void AddMessage(string message) => Message = message;
        public string Token { get; set; }
    }
    public class Result<T> : Result
    {
      public T Data { get; set; }
    }
}
