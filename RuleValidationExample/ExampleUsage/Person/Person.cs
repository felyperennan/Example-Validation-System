using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ValidationTools.ExampleUsage.PersonModel.Rules;
using ValidationTools.Interfaces;

namespace ValidationTools.ExampleUsage.PersonModel
{
    public class Person : IValidatable<Person> {
        // Example validation with Attributes
        [MinLength(3)]
        [MaxLength(12)]
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsLicencedToDrive { get; set; }

        public IEnumerable<IRule<Person>> ValidationRules {
            get {
                // Example validation with external class
                yield return new MustBeOfLegalAge();
                yield return new MaximumAge(65);
                // Example inline validation rule
                yield return new InlineRule<Person>(
                    (p) => !p.IsLicencedToDrive,
                    new ValidationError("Person must have a licence to drive"));
            }
        }
    }
}
