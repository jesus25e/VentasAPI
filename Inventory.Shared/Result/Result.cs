using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Shared.Result
{
    public class Result<T>:Results
    {
        public T? Value { get; }

        protected Result(
            T? value,
            bool isSuccess,
            string error)
            : base(isSuccess, error)
        {
            Value = value;
        }

        public static Result<T> Success(T value)
            => new(value, true, string.Empty);

        public new static Result<T> Failure(string error)
            => new(default, false, error);
    }
}
