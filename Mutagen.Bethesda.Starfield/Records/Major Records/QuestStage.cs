﻿namespace Mutagen.Bethesda.Starfield;

public partial class QuestStage
{
    [Flags]
    public enum Flag
    {
        RunOnStart = 0x02,
        RunOnStop = 0x04,
        KeepInstanceDataFromHereOn = 0x08,
    }
}