using AspnetRunBasics.Entities;
using System.Threading.Tasks;

namespace AspnetRunBasics.Repositories
{
    public interface IContactRepository
    {
        /// <summary>
        /// Send message Async
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        Task<Contact> SendMessageAsync(Contact contact);

        /// <summary>
        /// Subscribe Async
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        Task<Contact> SubscribeAsync(string address);
    }
}
