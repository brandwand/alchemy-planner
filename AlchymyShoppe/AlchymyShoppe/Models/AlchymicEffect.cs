using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe
{
    [Flags()]
    enum AlchymicEffect : long
    {
        
        RestoreHealth =     0000000000000001,
        RestoreMana =       0000000000000010,
        RegenerateHealth =  0000000000000100,
        RegenerateMana =    0000000000001000,
        Speed =             0000000000010000,
        Strength =          0000000000100000,
        Insivibility =      0000000001000000,
        Charisma =          0000000010000000,
        Waterbreathing =    0000000100000000,
        Nightvision =       0000001000000000,
        DamageHealth =      0000010000000000,
        DamageMana =        0000100000000000,
        Slow =              0001000000000000,
        Sleep =             0010000000000000,
        Paralysis =         0100000000000000,
        None =              1000000000000000
    };

}
