﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModels
{
    public class NoSuccessMessage
    {
        public List<string> Errors { get; set; }
        public NoSuccessMessage()
        {
            Errors = new List<string>();
        }

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
