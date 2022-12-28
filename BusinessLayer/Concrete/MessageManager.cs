using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;
        public MessageManager(IMessageDal message2Dal)
        {
            _messageDal = message2Dal;
        }

        public List<Message> GetInboxByWriter(int id)
        {
            return _messageDal.GetListWithMessageByWriter(id);
        }

        public List<Message> GetSendboxByWriter(int id)
        {
            return _messageDal.GetListWithMessageByWriterSendbox(id);
        }

        public void TAdd(Message t)
        {
            _messageDal.Insert(t);
        }

        public void TDelete(Message t)
        {
            _messageDal.Delete(t);
        }

        public Message TGetByID(int id)
        {
            return _messageDal.GetById(id);
        }

        public List<Message> TGetListAll(Message t)
        {
            return _messageDal.GetListAlll();
        }

        public void TUpdate(Message t)
        {
            _messageDal.Update(t);
        }
    }
}
