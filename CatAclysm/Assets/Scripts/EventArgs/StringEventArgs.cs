using System;

namespace CatAclysm.Events
{
    public class StringEventArgs : EventArgs
    { 
        public string Text { get; }
        public StringEventArgs(string text) 
        {  
            Text = text; 
        }
    }
}