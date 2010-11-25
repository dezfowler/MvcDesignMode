using System;

namespace MvcDesignMode
{
    public static class GenericExtensions
    {
        public static TResult Convert<T, TResult>(this T source, Converter<T, TResult> converter)
        {
            return converter(source);
        }
    }
}
