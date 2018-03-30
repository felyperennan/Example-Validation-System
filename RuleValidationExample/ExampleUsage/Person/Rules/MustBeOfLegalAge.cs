﻿using System;
using System.Collections.Generic;
using System.Text;
using ValidationTools.Interfaces;

namespace ValidationTools.ExampleUsage.PersonModel.Rules
{
    public class MustBeOfLegalAge : IRule<Person> {


        public IEnumerable<ValidationError> Validate(Person obj) {
            if(obj.Age < 18) {
                yield return new ValidationError("Person must be at least 18 years old");
            }
        }
    }
}
