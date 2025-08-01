using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public delegate void MyDelegate(string msg);
    internal class Publisher
    {
        public event MyDelegate MyEvent;
        public void EventMethod(string m)
        {
          
            MyEvent?.Invoke("Publisher event Invoked with message" + m);
        }
    }
    public class Subscriber
    {
        public void SubscriberMethod(string m)
        {
            Console.WriteLine("Subscriber method called with same message: " + m);
        }
    }
}
