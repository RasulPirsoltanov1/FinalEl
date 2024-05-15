using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entites;

namespace Villa.Business.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        Task TCreateAsync(Microsoft.DotNet.Scaffolding.Shared.Messaging.Message newMessage);
    }
}
