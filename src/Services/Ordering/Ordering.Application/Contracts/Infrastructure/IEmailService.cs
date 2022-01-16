using Ordering.Application.Models;
using System.Threading.Tasks;

namespace Ordering.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        /// <summary>
        /// Send Email Async
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<bool> SendEmailAsync(Email email);
    }
}