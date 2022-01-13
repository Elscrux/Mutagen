using System.Collections.Generic;
using System.Linq;
using Mutagen.Bethesda.Plugins.Records.Internals;

namespace Mutagen.Bethesda.Plugins.Meta
{
    public record GroupCellConstants(int TopGroupType, int[] SubTypes);
    public record GroupWorldConstants(int TopGroupType, int[] CellGroupTypes, int[] CellSubGroupTypes);
    public record GroupTopicConstants(int TopGroupType);
    public record GroupQuestConstants(int TopGroupType);

    public record GroupConstants : RecordHeaderConstants
    {
        public GroupCellConstants Cell { get; init; }
        public GroupWorldConstants World { get; init; }
        public GroupTopicConstants? Topic { get; init; }
        public GroupQuestConstants? Quest { get; init; }
        public IReadOnlyCollection<int> HasSubGroups { get; }

        public GroupConstants(
            ObjectType type, 
            byte headerLength,
            byte lengthLength,
            GroupCellConstants cell,
            GroupWorldConstants world,
            GroupTopicConstants? topic,
            int[] hasSubGroups) 
            : base(type, headerLength, lengthLength)
        {
            Cell = cell;
            World = world;
            Topic = topic;
            HasSubGroups = hasSubGroups.ToHashSet();
        }
    }
}
