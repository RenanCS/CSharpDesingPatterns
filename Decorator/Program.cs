using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var cloudMailService = new CloudMailService();
            cloudMailService.SendMail("hi there.");

            var onPremiseMailService = new OnPremiseMailService();
            onPremiseMailService.SendMail("hi there");

            var statisticsDecorator = new StatisticsDacorator(cloudMailService);
            statisticsDecorator.SendMail($"Hi there via {nameof(StatisticsDacorator)} wrapper.");

            var messageDatabaseDecorator = new MessageDatabaseDacorator(onPremiseMailService);
            messageDatabaseDecorator.SendMail($"Hi there via {nameof(MessageDatabaseDacorator)} wrapper 1");
           
            messageDatabaseDecorator = new MessageDatabaseDacorator(onPremiseMailService);
            messageDatabaseDecorator.SendMail($"Hi there via {nameof(MessageDatabaseDacorator)} wrapper 2");

            foreach (var message in messageDatabaseDecorator.SentMessages)
            {
                Console.WriteLine($"Stored message: {message} ");
            }

            Console.ReadKey();
        }
    }
}
