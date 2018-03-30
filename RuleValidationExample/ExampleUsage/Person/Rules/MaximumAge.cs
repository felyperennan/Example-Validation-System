using System;
using System.Collections.Generic;
using System.Text;
using ValidationTools.Interfaces;

namespace ValidationTools.ExampleUsage.PersonModel.Rules
{
    public class MaximumAge : IRule<Person> {
        int Age = 0;
        public MaximumAge(int age) {
            this.Age = age;
        }
        public IEnumerable<ValidationError> Validate(Person obj) {
            if(obj.Age > Age) {
                yield return new ValidationError($"Person must be {Age} years old or younger");
            }
        }
    }
}
