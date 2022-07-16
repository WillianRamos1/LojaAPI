using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application.Service
{
    public class ResultService
    {
        public bool IsSuccess { get; set; }
        public string Mensagem { get; set; }
        public ICollection<ErrorValidation> Errors { get; set; }


        public static ResultService RequestError(string message, ValidationResult validationResult)
        {
            return new ResultService
            {
                IsSuccess = false,
                Mensagem = message,
                Errors = validationResult.Errors.Select(x => new ErrorValidation { Campo = x.PropertyName, Mensagem = x.ErrorMessage }).ToList()
            };
        }


        public static ResultService<T> RequestError<T>(string message, ValidationResult validationResult)
        {
            return new ResultService<T>
            {
                IsSuccess = false,
                Mensagem = message,
                Errors = validationResult.Errors.Select(x => new ErrorValidation { Campo = x.PropertyName, Mensagem = x.ErrorMessage }).ToList()
            };
        }


        public static ResultService Fail(string message) => new ResultService { IsSuccess = false, Mensagem = message };
        public static ResultService<T> Fail<T>(string message) => new ResultService<T> { IsSuccess = false, Mensagem = message };

        public static ResultService OK(string message) => new ResultService { IsSuccess = true, Mensagem = message };
        public static ResultService<T> OK<T>(T data) => new ResultService<T> { IsSuccess = true, Data = data };
    }

    public class ResultService<T> : ResultService
    {
        public T Data { get; set; }
    }
}
