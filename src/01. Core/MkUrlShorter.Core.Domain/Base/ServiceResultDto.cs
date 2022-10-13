using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkUrlShorter.Core.Domain.Base
{
    public class ServiceResultDto<T>
    {
        public bool isSuccess { get => this.error == null || !this.error.Any(); }
        public IEnumerable<string> error { get; set; }
        public T data { get; set; }

        private ServiceResultDto(IEnumerable<string> errors) => this.error = errors;
        private ServiceResultDto(string error) : this(new List<string> { error }) { this.data = default; }
        private ServiceResultDto(T data) { this.data = data; }

        public static ServiceResultDto<T> Ok(T data) => new ServiceResultDto<T>(data) { };
        public static ServiceResultDto<T> NotOk(string error) => new ServiceResultDto<T>(error);
        public static ServiceResultDto<T> NotOk(params string[] error) => new ServiceResultDto<T>(error);
    }
}
