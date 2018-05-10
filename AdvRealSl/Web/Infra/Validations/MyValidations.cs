using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Infra.Validations
{
    public static class MyValidations
    {
        public static bool AssertsIsNotNull<T>(T entity)
        {
            if (entity == null)
                return false;

            return true;
        }

        public static bool AssertsGuidIsNotEmpty(Guid value)
        {
            if (value == Guid.Empty)
                return false;

            return true;
        }

        public static bool AssertsIsNotNullOrEmpty(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            return true;
        }

    }
}
