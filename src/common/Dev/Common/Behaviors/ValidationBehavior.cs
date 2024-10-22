using Dev.Common.Exceptions;
using FluentValidation;
using MediatR;

namespace Dev.Common.Behaviors;

public class ValidationBehavior<TRequest, TReponse> : IPipelineBehavior<TRequest, TReponse>
    where TRequest : IRequest<TReponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TReponse> Handle(TRequest request, RequestHandlerDelegate<TReponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }
        var context = new ValidationContext<TRequest>(request);
        var errorsDictionary = _validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(failure => failure != null)
            .GroupBy(
                x => x.PropertyName.Substring(x.PropertyName.IndexOf('.') + 1),
                x => x.ErrorMessage, (propertyName, errorMessages) => new
                {
                    Key = propertyName,
                    Values = errorMessages.Distinct().ToArray()
                })
            .ToDictionary(x => x.Key, x => x.Values);
        
        if (errorsDictionary.Any())
        {
            throw new ValidationAppException(errorsDictionary);
        }

        return await next();
    }
}