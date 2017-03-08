using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchymyShoppe.Models
{
    [Flags()]
    public enum AlchymicEffect : int
    {
        
        RestoreHealth =     1,//0000000000000001,
        RestoreMana =       2,// 0000000000000010,
        RegenerateHealth =  4,// 0000000000000100,
        RegenerateMana =    8,// 0000000000001000,
        Speed =             16,//  0000000000010000,
        Strength =          32,// 0000000000100000,
        Insivibility =      64,// 0000000001000000,
        Charisma =          128,//0000000010000000,
        Waterbreathing =    256,// 0000000100000000,
        Nightvision =       512,//   0000001000000000,
        DamageHealth =      1024,//   0000010000000000,
        DamageMana =        2048,//   0000100000000000,
        Slow =              4096,//   0001000000000000,
        Sleep =             8192,// 0010000000000000,
        Paralysis =         16384,//   0100000000000000,
        None =              32768// 1000000000000000
    };

}