using System;
using System.Collections.Generic;

namespace ValidationTools.Interfaces {

    public interface IRule<T> {
        IEnumerable<ValidationError> Validate(T obj) ;
    }
}
