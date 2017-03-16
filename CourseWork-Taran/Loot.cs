using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Taran
{
    class Loot
    {
        public System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        public bool Poroshok { get; set; }
        public bool Gel { get; set; }
        public bool Poroshok_Gel { get; set; }

        public MainWindow MainWindow
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        public event EventHandler Ticks; // Событие секунды
        public void Start()
        {
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
            Timer.Tick -= Timer_Ticks;
            Timer.Tick += Timer_Ticks;

        }
        public void Stop()
        {
            Timer.Stop();
        }

        private void Timer_Ticks(object sender, EventArgs e)
        {
            if (Ticks != null)
                Ticks(this, new EventArgs());
        }

    }
}
