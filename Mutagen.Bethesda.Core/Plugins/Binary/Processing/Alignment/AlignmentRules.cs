﻿using System.Collections.Generic;
using Noggog;

namespace Mutagen.Bethesda.Plugins.Binary.Processing.Alignment;

public class AlignmentRules
{
    public Dictionary<RecordType, Dictionary<RecordType, AlignmentRule>> Alignments = new();
    public Dictionary<RecordType, IEnumerable<RecordType>> StartMarkers = new();
    public Dictionary<RecordType, IEnumerable<RecordType>> StopMarkers = new();
    public Dictionary<int, List<RecordType>> GroupAlignment = new();

    public void AddAlignments(RecordType type, params RecordType[] recTypes)
    {
        var subList = new Dictionary<RecordType, AlignmentRule>();
        foreach (var t in recTypes)
        {
            subList[t] = new AlignmentStraightRecord(t.Type);
        }

        this.Alignments.Add(
            type,
            subList);
    }

    public void AddAlignments(RecordType type, params AlignmentRule[] rules)
    {
        var dict = Alignments.GetOrAdd(type);
        foreach (var rule in rules)
        {
            dict[rule.RecordType] = rule;
        }
    }

    public void SetGroupAlignment(int group, params RecordType[] recTypes)
    {
        GroupAlignment.GetOrAdd(group).SetTo(recTypes);
    }
}