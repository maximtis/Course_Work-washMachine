using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Taran
{
    class SystemMedia
    {
        public SystemMedia()
        {
            OpenDoor.URL = "OpenDoor.mp3";
            OpenDoor.controls.stop();
            CloseDoor.URL = "CloseDoor.mp3";
            CloseDoor.controls.stop();
            Error.URL = "Error.mp3";
            Error.controls.stop();
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
    
        public WMPLib.WindowsMediaPlayer OpenDoor = new WMPLib.WindowsMediaPlayer();
        public WMPLib.WindowsMediaPlayer CloseDoor = new WMPLib.WindowsMediaPlayer();
        public WMPLib.WindowsMediaPlayer Error = new WMPLib.WindowsMediaPlayer();
        
    }
}
