using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestViews
{
    /// <summary>
    /// keys to be accepted as input
    /// </summary>
    public enum Keys
    {
        Enter, Up, Down, Left, Right
    }

    /// <summary>
    /// class that store the keys pressed by the user
    /// </summary>
    class Input
    {
        // load list of available keys
        private static Hashtable keyTable = new Hashtable();

        // perform a check to see if a particular key is pressed
        public static bool KeyPressed(Keys key)
        {
            if (keyTable[key] == null)
            {
                return false;
            }
            return (bool)keyTable[key];
        }

        // set state of a given key
        public static void ChangeState(Keys key, bool state)
        {
            keyTable[key] = state;
        }
    }
}