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

            if (actor is null)
            {
                throw new ArgumentNullException("Actor unknown");
            }
            else
            {
                switch (actor)
                {
                    case Penny penny:
                        line = penny.getSpeak();
                        break;

                    case Sheldon sheldon:
                        line = sheldon.getSpeak();
                        break;

                    case Raj raj when raj.womenArePresent == true:
                        line = raj.getSpeakWomen();
                        break;

                    case Raj raj when raj.womenArePresent == false:
                        line = raj.getSpeakNoWomen();
                        break;
                }
            }
            return line;
        }
    }
}
