﻿namespace Mutagen.Bethesda.Starfield;

partial class StoryManagerQuestNode
{
    [Flags]
    public enum QuestFlag
    {
        DoAllBeforeRepeating = 0x0001,
        SharesEvent = 0x0002,
        NumQuestsToRun = 0x0004,
    }
}
