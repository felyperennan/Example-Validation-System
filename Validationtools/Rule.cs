using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValidationTools.Interfaces;

namespace ValidationTools {
    public class InlineRule<T> : IRule<T> {
        Func<T, bool> ValidationCheck;
        ValidationError Error;
        public InlineRule(Func<T, bool> validationCheck, ValidationError error) {
            this.ValidationCheck = validationCheck;
            this.Error = error;
        }

        public IEnumerable<ValidationError> Validate(T obj) {
            if (ValidationCheck?.Invoke(obj) ?? false) {
                return new ValidationError[] { this.Error };
            }
            return new ValidationError[0];
        }
    }
}
