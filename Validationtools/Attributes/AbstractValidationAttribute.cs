using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ValidationTools.Interfaces;

namespace ValidationTools.Attributes {
    public class AbstractValidationAttribute : Attribute, IRule<object> {

        public MemberInfo AttributtedMember { get; set; }

        public virtual IEnumerable<ValidationError> Validate(object obj) {
            return new ValidationError[0];
        }
    }
}
