using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Domain.Abstractions.Result
{
    public class Result
    {
        public bool IsSucceeded { get; private set; }
        public bool IsFailure => !IsSucceeded;
        public Error Error { get; private set; }
        protected Result(bool isSucceeded, Error error)
        {
            if (isSucceeded && error != Error.None ||
                !isSucceeded && error == Error.None)
            {
                throw new ArgumentException("Invalid error", nameof(Result));
            }

            IsSucceeded = isSucceeded;
            Error = error;
        }

        public static Result Failure(Error error)
        {
            return new Result(false, error);
        }

        public static Result Succeeded()
        {
            return new Result(true, Error.None);
        }
    }

    public sealed class Result<TBody>
        : Result
        where TBody : class
    {

        public TBody? Body { get; private set; }
        private Result(bool isSucceeded, Error error, TBody? body)
            : base(isSucceeded, error)
        {
            Body = body;
        }

        public new static Result<TBody> Failure(Error error)
        {
            return new Result<TBody>(false, error, null);
        }

        public static Result<TBody> Succeeded(TBody body)
        {
            return new(true, Error.None, body);
        }
    }
}
