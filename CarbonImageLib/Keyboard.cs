using System;
using System.IO;

namespace CarbonImageLib
{
    public class Keyboard
    {
        private FileStream keyboardPath; 
        public Keyboard(string path = "/dev/hidg0")
        {
            keyboardPath = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            
        }
    }
}