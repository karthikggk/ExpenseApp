using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonEntities.Response
{
    public class Result<T> : Result
    {
        public T Value { get; set; } = default(T);

        public Result() { }

        public Result(T value, bool isSuccessed, string errorMessage) : base(isSuccessed, errorMessage)
        {
            this.Value = value;
        }
    }

    public class Result
    {
        public bool IsSuccessed { get; set; } = false;
        public List<Error> Errors { get; set; } = new List<Error>();
        public Result()
        {

        }

        /// <summary>
        /// Returns message with successful status.
        /// </summary>
        /// <param name="isSuccessed">If its successful.</param>
        /// <param name="errorMessage">Message that you want to show.</param>
        public Result(bool isSuccessed, string errorMessage)
        {
            this.IsSuccessed = isSuccessed;
            this.Errors.Add(new Error { ErrorMessage = errorMessage });
        }
        /// <summary>
        /// Used when error has to be returned
        /// </summary>
        /// <param name="errorMessage"></param>
        public void AddErrorMessage(string errorMessage)
        {
            this.Errors.Add(new Error { ErrorMessage = errorMessage });
        }
        /// <summary>
        /// Returns Result with succeded status
        /// </summary>
        /// <returns></returns>
        public static Result Ok()
        {
            return new Result(true, string.Empty);
        }

        /// <summary>
        /// Returns result with error response.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static Result Fail(string errorMessage)
        {
            return new Result(false, errorMessage);
        }

        /// <summary>
        /// Returns Result with Success.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value, true, string.Empty);
        }

        /// <summary>
        /// Returns Failure message.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static Result<T> Fail<T>(string errorMessage)
        {
            return new Result<T>(default(T), false, errorMessage);
        }

        public string GetErrorString()
        {
            return string.Join(Environment.NewLine, this.Errors.Select(x => x.ErrorMessage).ToArray());
        }
    }
}
