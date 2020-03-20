using System.Collections.Generic;

namespace middleware
{
    public static class Validation
    {
        public static bool ObjectIsNull(object obj)
            => obj is null ? true : false;

        public static bool ListIsGreateThanValue<T>(IList<T> list, int count)
            => list.Count > count ? true : false;

    }
}