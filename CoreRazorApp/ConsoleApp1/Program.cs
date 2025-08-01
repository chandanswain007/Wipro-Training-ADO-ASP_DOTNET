using ConsoleApp1;

Publisher p = new Publisher();
Subscriber s = new Subscriber();
p.MyEvent += s.SubscriberMethod;
p.EventMethod("Method parameter");