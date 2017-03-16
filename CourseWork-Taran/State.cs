using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Taran
{
    enum Load { Gel = 1, Poroshok = 2, Poroshok_Gel = 3 };
    class State
    {
        public State()
        {
            Into = Load.Poroshok;
            Temperature = 0;
            Frecuency = 0;
            RotateTime = 0;
            WorkTime = 0;
        }
        public State(Load Into1, int Temperature1, int Frecuency1, int RotateTime1, int WorkTime1)
        {
            Into = Into1;
            Temperature = Temperature1;
            Frecuency = Frecuency1;
            RotateTime = RotateTime1;
            WorkTime = WorkTime1;
        }
        public int WorkTime { get; set; }
        public Load Into { get; set; }
        public int Temperature { get; set; }
        public int RotateTime { get; set; }
        public static string[] StateInfo = 
        {
            "Ожидание"
            ,"Режим-1"
            ,"Режим-2"
            ,"Режим-3"
            ,"Открыта дверь!"
            ,"Нету моющего!"
        };
        public int Frecuency { get; set; }

        public void Initialize(State Source)
        {
            Into = Source.Into;
            Temperature = Source.Temperature;
            Frecuency = Source.Frecuency;
            RotateTime = Source.RotateTime;
            WorkTime = Source.WorkTime;
        }

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
    }
}
