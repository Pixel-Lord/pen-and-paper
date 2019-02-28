using System;

namespace PenAndPaper.Flags
{
  [Flags]
  public enum LayoutFlags
  {
    //power of two allowes for fast callculation
    NONE = 0,
    DND5E = 1 << 0, //0x1
    STARWARS = 1 << 1, //0x2
    DSA = 1 << 2, //0x4
    SHADOWRUN = 1 << 3 //0x8
  }
}
