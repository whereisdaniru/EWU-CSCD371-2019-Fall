using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public static class ActorExtension
    {
        public static String Speak(this Actor actor)
        {
            string line = "";

            if(actor is Penny)
            {
                Penny penny = (Penny) actor;
                line = penny.getSpeak();
            }
            if(actor is Sheldon)
            {
                Sheldon sheldon = (Sheldon) actor;
                line = sheldon.getSpeak();
            }
            if(actor is Raj)
            {
                Raj raj = (Raj) actor;
                if(raj.womenArePresent == true)
                {
                    line = raj.getSpeakWomen();
                }
                else if(raj.womenArePresent == false)
                {
                    line = raj.getSpeakNoWomen();
                }
            }

            return line;
        }
    }
}
