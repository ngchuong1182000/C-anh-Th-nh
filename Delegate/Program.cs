using System;

namespace Delegate
{
    // delegate void UpdateTime(string name);
    class Program
    {
        // delegate string CurrentTime();
        static void Main(string[] args)
        {

            ClockPublisher clockPublisher = new ClockPublisher();
            ClockSubcriber clockSubscriber = new ClockSubcriber();
            clockSubscriber.Subscribe(clockPublisher);

            clockPublisher.Run();
            // Clock c = new Clock();
            // c.TimeChanged += (time) =>
            // {
            //     Console.WriteLine(" current time  up-to-dated : " + time);
            // };
            // CurrentTime time = new CurrentTime(getCurrentTime);

            // while (true)
            // {
            //     time = new CurrentTime(getCurrentTime);
            //     c.Time = time();
            // }
        }
        // static string getCurrentTime()
        // {
        //     return DateTime.Now.ToString("HH:mm:ss tt");
        // }
    }
    // class Clock
    // {
    //     public event UpdateTime TimeChanged;
    //     private string _Time;

    //     public string Time
    //     {
    //         get => _Time;
    //         set
    //         {
    //             _Time = value;
    //             if (TimeChanged != null)
    //             {
    //                 TimeChanged(Time);
    //             }
    //         }
    //     }
    // }
}
