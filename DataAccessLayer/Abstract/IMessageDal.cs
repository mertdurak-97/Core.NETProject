using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMessageDal : IGenericDal<Message>
    {
        List<Message> GetListWithMessageByWriter(int id);
        List<Message> GetListWithMessageByWriterSendbox(int id);
    }
}
