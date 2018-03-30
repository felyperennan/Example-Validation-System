using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationTools.Attributes
{
    public class MinLengthAttribute : AbstractValidationAttribute {
        int minLength = 0;
        public MinLengthAttribute(int minLength) {
            this.minLength = minLength;
        }

        public override IEnumerable<ValidationError> Validate(object obj) {
            var str = obj as String;
            if(str == null || str.Length < this.minLength) {
                yield return new ValidationError($"Field {AttributtedMember.Name} must have at least {minLength} characters");
            }
        }
    }
}
