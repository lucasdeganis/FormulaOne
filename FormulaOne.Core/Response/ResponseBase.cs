using FluentValidation.Results;

namespace FormulaOne.Core.Response
{
    public class ResponseBase<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public IEnumerable<ValidationFailure>? Errors { get; set; }
    }
}
