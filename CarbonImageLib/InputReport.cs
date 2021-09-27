using System;
using System.Collections;
using System.Collections.Generic;

namespace CarbonImageLib
{
    public class InputReport
    {
        private const int MaxKeyPresses = 6;
        private byte ModifierKey = 0x00;
        private List<Keycode> ReportKeys = new List<Keycode>(6);

        public byte GetModifier(Keycode keycode)
        {
            if (Keycode.LEFT_CONTROL <= keycode && keycode <= Keycode.RIGHT_GUI)
            {
                return (byte)(1 << (int)(keycode - 0xE0));
            }
            else
            {
                return 0;
            }
        }
        public void AddKeycodeToReport(Keycode keycode)
        {
            //"""Add a single keycode to the USB HID report."""
            byte modifier = GetModifier(keycode);
            if (modifier != 0)
            {
                // Set bit for this modifier.
                ModifierKey = modifier;
            }
            else
            {
                // Don't press twice.
                // (I'd like to use 'not in self.report_keys' here, but that's not implemented.)
                for (int i = 0; i < MaxKeyPresses; i++)
                {
                    if (ReportKeys[i] == keycode)
                    {
                        // Already pressed.
                        return;
                    }
                }
                
                // Put keycode in first empty slot.
                for (int i = 0; i < MaxKeyPresses; i++)
                {
                    if (ReportKeys[i] != 0) continue;
                    ReportKeys[i] = keycode;
                    return;
                }

                Console.WriteLine("Trying to press more than six keys at once.");
            }

        }

        public void RemoveKeycodeFromReport(Keycode keycode)
        {
            int modifier = GetModifier(keycode);
            if (modifier != 0)
            {
                //Turn off the bit for this modifier.
                
            }
        }

    }
}