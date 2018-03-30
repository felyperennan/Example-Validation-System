using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationTools.Attributes
{
    public class MaxLengthAttribute : AbstractValidationAttribute {
        int maxLength = 0;
        public MaxLengthAttribute(int maxLength) {
            this.maxLength = maxLength;
        }

        public override IEnumerable<ValidationError> Validate(object obj) {
            var str = obj as String;
            if(str == null || str.Length > this.maxLength) {
                yield return new ValidationError($"Field {AttributtedMember.Name} can only have a maximum of {maxLength} characters");
            }
        }
    }
}
