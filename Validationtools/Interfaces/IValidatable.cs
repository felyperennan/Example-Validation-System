using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationTools.Interfaces {
    public interface IValidatable<T> {
        IEnumerable<IRule<T>> ValidationRules { get; }
    }
}
