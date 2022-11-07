using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCM.Common.Models
{
    public class ResultModel : IResultModel
    {
        internal ResultModel()
        {
            Errors = new string[] { };
        }
        internal ResultModel(bool succeeded, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
        }

        public bool Succeeded { get; set; }

        public string[] Errors { get; set; }

        public static ResultModel Success()
        {
            return new ResultModel(true, Array.Empty<string>());
        }
        public static Task<ResultModel> SuccessAsync()
        {
            return Task.FromResult(new ResultModel(true, Array.Empty<string>()));
        }
        public static ResultModel Failure(IEnumerable<string> errors)
        {
            return new ResultModel(false, errors);
        }
        public static Task<ResultModel> FailureAsync(IEnumerable<string> errors)
        {
            return Task.FromResult(new ResultModel(false, errors));
        }
    }


    public class ResultModel<T> : ResultModel, IResultModel<T>
    {

        public T Data { get; set; }

        public static new ResultModel<T> Failure(IEnumerable<string> errors)
        {
            return new ResultModel<T> { Succeeded = false, Errors = errors.ToArray() };
        }
        public static new async Task<ResultModel<T>> FailureAsync(IEnumerable<string> errors)
        {
            return await Task.FromResult(Failure(errors));
        }
        public static ResultModel<T> Success(T data)
        {
            return new ResultModel<T> { Succeeded = true, Data = data };
        }
        public static async Task<ResultModel<T>> SuccessAsync(T data)
        {
            return await Task.FromResult(Success(data));
        }
    }


    public interface IResultModel
    {
        string[] Errors { get; set; }

        bool Succeeded { get; set; }
    }
    public interface IResultModel<out T> : IResultModel
    {
        T Data { get; }
    }
}




