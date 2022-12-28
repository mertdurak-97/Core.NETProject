using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFMessageRepository : GenericRepository<Message>, IMessageDal
    {
        Context c = new Context();
        public List<Message> GetListWithMessageByWriter(int id)
        {
            return c.Messages.Include(y => y.SenderUser).Where(x => x.ReceiverID == id).ToList();
        }

        public List<Message> GetListWithMessageByWriterSendbox(int id)
        {
            return c.Messages.Include(y => y.ReceiverUser).Where(x => x.SenderID == id).ToList();
        }
    }
}
