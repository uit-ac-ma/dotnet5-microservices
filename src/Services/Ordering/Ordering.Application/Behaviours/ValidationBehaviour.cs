using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = Ordering.Application.Exceptions.ValidationException;


namespace Ordering.Application.Behaviours
{
    /// <summary>
    /// Gathering fluent.validation errors through MediatR Pipelines using fluent Validation reflexion
    /// In this case from UpdateOrderCommandValidator and CheckoutOrderCommandValidator
    /// Before performing any request
    /// Basically, it seems like a wrapper of Handlers to avoid errors while the execution of handlers
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : MediatR.IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly ILogger _logger;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators, ILogger logger)
        {
            _validators = validators;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                var a = $"Error: {string.Join(',', failures)}";

                if (failures.Count != 0)
                    throw new ValidationException(failures);
            }

            // If nothing, move to next request
            return await next();
        }
    }
}