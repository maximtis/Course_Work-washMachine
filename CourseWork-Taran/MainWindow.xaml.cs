using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace CourseWork_Taran
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Loot MachineLoot = new Loot();
        Machine MyMachine = new Machine();
        State NowStateData = new State();
        State PoroshokStateData = new State(Load.Poroshok,70,1800,3,30);
        State GelStateData = new State(Load.Gel,40,1080,3,25);
        State Gel_PoroshokStateData = new State(Load.Poroshok_Gel,50,3600,3,55);
        SystemMedia Sounds = new SystemMedia();
        public MainWindow()
        {
            InitializeComponent();
            Grid_Machine.Background = new ImageBrush(new BitmapImage(new Uri("Machine.jpg", UriKind.Relative)));
            Button_Rorarte_Door.Background = new ImageBrush(new BitmapImage(new Uri("Load.jpg", UriKind.Relative)));

            MyMachine.Ticks += Rotate_Ticks;

            MyMachine.ChangeRotateTimeUp += Rotate_Right_Run;

            Button_Open_Door.Background = new ImageBrush(new BitmapImage(new Uri("OpenDoor.jpg", UriKind.Relative)));
        }

        private void Button_Into_Control_Panel_Click(object sender, RoutedEventArgs e)
        {
            SplashGrid.Visibility = Visibility.Visible;
            Grid_Control_Panel.Visibility = Visibility.Visible;
            WorkSpace.Visibility = Visibility.Hidden;
        }

        private void SplashGrid_Click(object sender, RoutedEventArgs e)
        {
            SplashGrid.Visibility = Visibility.Hidden;
            Grid_Control_Panel.Visibility = Visibility.Hidden;
            Grid_Loot_Door.Visibility = Visibility.Hidden;
            WorkSpace.Visibility = Visibility.Visible;

        }

        private void Button_Into_Loot_Click(object sender, RoutedEventArgs e)
        {
            SplashGrid.Visibility = Visibility.Visible;
            Grid_Loot_Door.Visibility = Visibility.Visible;
            WorkSpace.Visibility = Visibility.Hidden;
        }

        private void Rotate_Right_Run(object sender, EventArgs e)
        {
            if (MyMachine.RotateTo)
            {
                RotateTransform rt = new RotateTransform() { CenterX = 180, CenterY = 180 };
                Button_Rorarte_Door.RenderTransform = rt;
                rt.BeginAnimation(RotateTransform.AngleProperty, new DoubleAnimation(0, NowStateData.Frecuency, TimeSpan.FromSeconds(NowStateData.RotateTime)));
            }else
            {
                RotateTransform rt = new RotateTransform() { CenterX = 180, CenterY = 180 };
                Button_Rorarte_Door.RenderTransform = rt;
                rt.BeginAnimation(RotateTransform.AngleProperty, new DoubleAnimation(NowStateData.Frecuency, 0, TimeSpan.FromSeconds(NowStateData.RotateTime)));
            }
        }

         private void Rotate_Ticks(object sender, EventArgs e)
        {
            MyMachine.Rotate();
        }

         private void Button_State_1_Click(object sender, RoutedEventArgs e)
         {
             NowStateData.Initialize(PoroshokStateData);
             Text_Temperature_Info.Text = NowStateData.Temperature.ToString();
             Text_Time_Info.Text = NowStateData.WorkTime.ToString() + "м";
         }
         private void Button_State_2_Click(object sender, RoutedEventArgs e)
         {
             NowStateData.Initialize(GelStateData);
             Text_Temperature_Info.Text = NowStateData.Temperature.ToString();
             Text_Time_Info.Text = NowStateData.WorkTime.ToString() + "м";
         }
         private void Button_State_3_Click(object sender, RoutedEventArgs e)
         {
             NowStateData.Initialize(Gel_PoroshokStateData);
             Text_Temperature_Info.Text = NowStateData.Temperature.ToString();
             Text_Time_Info.Text = NowStateData.WorkTime.ToString()+"м";
         }
         private void Button_Closed_Door_Click(object sender, RoutedEventArgs e)
         {
             if (!MyMachine.OpenDoor)
             {
                 MyMachine.OpenDoor = true;
                 Sounds.OpenDoor.controls.play();
                 Button_Open_Door.Visibility = Visibility.Visible;
                 Button_Closed_Door.Visibility = Visibility.Hidden;
             }
         }

         private void Button_Open_Door_Click(object sender, RoutedEventArgs e)
         {
             if(MyMachine.OpenDoor)
             {
                 MyMachine.OpenDoor = false;
                 Sounds.CloseDoor.controls.play();
                 Button_Open_Door.Visibility = Visibility.Hidden;
                 Button_Rorarte_Door.Visibility = Visibility.Visible;
             }
         }

         private void Button_Start_Click(object sender, RoutedEventArgs e)
         {
             if (MyMachine.OpenDoor)
             {
                 Sounds.Error.controls.play();
                 Info.Text = State.StateInfo[4];
             }
             else if (!(MachineLoot.Poroshok_Gel||MachineLoot.Gel||MachineLoot.Poroshok))
             {
                 Sounds.Error.controls.play();
                 Info.Text = State.StateInfo[5];
             }else{
                 Info.Text = "Ok";
                 Text_Status_Info.Text = "Стирка";
                 Indecator.Background = Brushes.Green;
                 MyMachine.Start();
             }
         }

         private void Button_Stop_Click(object sender, RoutedEventArgs e)
         {
             Text_Status_Info.Text = "Ожидание";
             Indecator.Background = Brushes.Red;
             MyMachine.Stop();
         }

         private void Button_Click(object sender, RoutedEventArgs e)
         {
             MachineLoot.Poroshok_Gel = true;
             MachineLoot.Poroshok = false;
             MachineLoot.Gel = false;
         }

         private void Button_Click_1(object sender, RoutedEventArgs e)
         {
             MachineLoot.Poroshok_Gel = false;
             MachineLoot.Poroshok = true;
             MachineLoot.Gel = false;
         }

         private void Button_Click_2(object sender, RoutedEventArgs e)
         {
             MachineLoot.Poroshok_Gel = false;
             MachineLoot.Poroshok = false;
             MachineLoot.Gel = true;
         }


    }
}
