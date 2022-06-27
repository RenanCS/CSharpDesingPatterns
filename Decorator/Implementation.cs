using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public interface IMailService
    {
        bool SendMail(string message);
    }

    public class CloudMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Message: {message} sent via {nameof(CloudMailService)}");

            return true;
        }
    }

    public class OnPremiseMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Message: {message} sent via {nameof(OnPremiseMailService)}");

            return true;
        }
    }

    public class MailServiceDecoratorBase : IMailService
    {
        private readonly IMailService _mailService;

        public MailServiceDecoratorBase(IMailService mailService)
        {
            _mailService = mailService;
        }
        public virtual bool SendMail(string message)
        {
            return  _mailService.SendMail(message);
        }
    }

    public class StatisticsDacorator : MailServiceDecoratorBase
    {
        public StatisticsDacorator(IMailService mailService): base(mailService)
        {

        }

        public override bool SendMail(string message)
        {
            Console.WriteLine($"Collecting statistics in {nameof(StatisticsDacorator)}.");
            return base.SendMail(message);
        }

    }

    public class MessageDatabaseDacorator : MailServiceDecoratorBase
    {
        public List<string> SentMessages { get; private set; } = new List<string>();
        public MessageDatabaseDacorator(IMailService mailService) : base(mailService)
        {

        }

        public override bool SendMail(string message)
        {
            if (base.SendMail(message))
            {
                SentMessages.Add(message);
                return true;
            }
            return false;
        }

    }



}
