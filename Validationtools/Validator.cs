using ValidationTools.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ValidationTools.Interfaces;

namespace ValidationTools {
    public class Validator {

        static object GetValueOf(MemberInfo m, object o) {
            if (m is PropertyInfo pi) {
                return pi.GetValue(o);
            }
            if (m is FieldInfo fi) {
                return fi.GetValue(o);
            }
            return null;
        }

        public static bool IsValid(IEnumerable<ValidationError> errs) {
            return !errs.Any();
        }
        public static bool IsValid<T>(T obj) where T : IValidatable<T> {
            return !RunFor(obj).Any();
        }

        public static IEnumerable<ValidationError> RunFor<T>(T obj) where T : IValidatable<T> {
            var members = new List<MemberInfo>();
            members.AddRange(typeof(T).GetFields().Where(f=> f.IsPublic));
            members.AddRange(typeof(T).GetProperties().Where(f => f.GetAccessors().FirstOrDefault(a=> a.Name.StartsWith("get_"))?.IsPublic??false));

            foreach(var m in members) {
                foreach(var att in m.GetCustomAttributes().Where(a=> a is AbstractValidationAttribute)) {
                    var vAtt = att as AbstractValidationAttribute;
                    vAtt.AttributtedMember = m;
                    var fieldVal = GetValueOf(m, obj);
                    foreach(var err in vAtt.Validate(fieldVal)) {
                        yield return err;
                    }
                }
            }

            foreach (var rule in obj.ValidationRules) {
                foreach(var error in rule.Validate(obj)) {
                    yield return error;
                }
            }
        }
    }
}
