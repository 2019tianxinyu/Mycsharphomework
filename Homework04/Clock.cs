using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace clock
{//建立委托
    public delegate void TickHandle(object sender, Tick args);
    public delegate void AlarmHandle(object sender, Alarm args);
    public class Tick
    {
        public Tick() { }//创建滴答
    }
    public class Alarm
    {
        public Alarm() { }//创建响铃
    }
    public class AlarmClock
    {
        public event TickHandle ATick;
        public event AlarmHandle AAlarm;
        public int count;//响铃间隔
        public void setAlarm(int a)
        {
            this.count = a;
        }
        //启动闹钟
        public void start()
        {
            for (int i = 1; ; i++)
            {
                Thread.Sleep(1000);
                ClockTick();
                if (i % count == 0)
                {
                    ClockAlarm();
                }
            }
        }
          public void ClockAlarm()
             {
                 Alarm args = new Alarm();
                AAlarm(this, args);
              }  
          public void ClockTick()
             {
                 Tick args = new Tick();
                 ATick(this, args);
             }
    }
 

    public  class Manager
{
    public AlarmClock Clock1 = new AlarmClock();
    public Manager()
    {
        Clock1.ATick += new TickHandle(Clock_Tick);
        Clock1.AAlarm += new AlarmHandle(Clock_Alarm);

    }
    void Clock_Tick(object sender,Tick args)
    {
        Console.WriteLine("滴答");

    }
    void Clock_Alarm(object sender,Alarm args)
    {
        Console.WriteLine("响铃");
    }
}
     
    class Program
    {
        static void Main(string[] args)
        {
        Manager demo = new Manager();
        demo.Clock1.setAlarm(60);
        demo.Clock1.start();
        }
    }
}
