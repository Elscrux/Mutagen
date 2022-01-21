using System.Threading.Tasks;
using System.Xml.Linq;
using Noggog;

namespace Mutagen.Bethesda.Generation.Fields;

public class DictType : Loqui.Generation.DictType
{
    /// <summary>
    /// This parameter is necessessary if the enums are not accessible at generation time by the generation program.
    /// If they are, this parameter can be removed in favor of reflection
    /// </summary>
    public byte? NumEnumKeys;

    public override async Task Load(XElement node, bool requireName = true)
    {
        await base.Load(node, requireName);
        if (node.TryGetAttribute("numEnumKeys", out byte num))
        {
            NumEnumKeys = num;
        }
    }
}