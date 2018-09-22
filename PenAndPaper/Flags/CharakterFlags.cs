using System;

namespace PenAndPaper.Flags
{
    [Flags]
    public enum CharakterFlags
    {
        //power of two allowes for fast callculation
        NONE = 0,
        PC = 1 << 0, //0x1
        NPC = 1 << 1, //0x2
        NPPC = 1 << 2, //0x4
        MONSTER = 1 << 3 //0x8
    }
}
