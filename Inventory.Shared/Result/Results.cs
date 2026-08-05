using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Shared.Result
{
    public class Results
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public string Error { get; }
        protected Results(
            bool isSuccess,
            string error
        )
        {
            if (isSuccess && !string.IsNullOrWhiteSpace(error))
                throw new ArgumentException("A successful result cannot contain an error.");

            if (!isSuccess && string.IsNullOrWhiteSpace(error))
                throw new ArgumentException("A failed result must contain an error.");

            IsSuccess = isSuccess;
            Error = error;
        }

        public static Results Success()
            => new(true, string.Empty);

        public static Results Failure(string error)
            => new(false, error);
    }
}
