using System;

namespace CatAclysm.Events
{
    public class IntEventArgs : EventArgs
    { 
        public int Value { get; }
        public IntEventArgs(int value) 
        {  
            Value = value; 
        }
    }
}