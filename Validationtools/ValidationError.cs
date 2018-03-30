using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationTools {
    public class ValidationError{
        public String ErrorMessage { get; private set; }

        public ValidationError(string message) {
            ErrorMessage = message;
        }
    }
}
