﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Business.Abstract;
using Villa.DataAccess.Abstract;
using Villa.Entity.Entites;

namespace Villa.Business.Concrete
{
    public class MessageManager : GenericManager<Message>, IMessageService
    {
        public MessageManager(IGenericDal<Message> genericDal) : base(genericDal)
        {
        }

        public Task TCreateAsync(Microsoft.DotNet.Scaffolding.Shared.Messaging.Message newMessage)
        {
            throw new NotImplementedException();
        }
    }
}
