using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Taran
{
    class Machine
    {
        public System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        public int rotate_;
        public bool RotateTo { get; set; }
        public bool OpenDoor { get; set; }

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
    
        public event EventHandler ChangeRotateTimeUp; // Событие смены вращения
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

        public void Rotate()
        {
            if (rotate_ == 6)
            {
                if (ChangeRotateTimeUp != null)
                {
                    ChangeRotateTimeUp(this, new EventArgs());
                    rotate_ = 0;
                    if (RotateTo)
                    {
                        RotateTo = false;
                        return;
                    }
                    if (!RotateTo)
                        RotateTo = true;
                }
                
            }
            else
                rotate_++;
        }
    }
}
