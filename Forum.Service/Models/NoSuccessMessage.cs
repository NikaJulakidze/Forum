using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.Service.Models
{
    public class NoSuccessMessage
    {
        public List<string> Errors { get; set; }

        public static NoSuccessMessage AddErrors(List<string> errors)
        {
            return new NoSuccessMessage { Errors = errors };
        }
        public static NoSuccessMessage AddError(string error)
        {
            var noSuccessMessage = new NoSuccessMessage();
            noSuccessMessage.Errors.Add(error);
            return noSuccessMessage;
        }
    }
}
