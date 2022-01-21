using System.Threading.Tasks;
using System.Xml.Linq;
using Loqui.Generation;
using Noggog;

namespace Mutagen.Bethesda.Generation.Fields;

public class GroupType : LoquiType
{
    public override Task Load(XElement node, bool requireName = true)
    {
        XElement convert = new XElement(XName.Get("Ref", LoquiGenerator.Namespace));
        convert.Add(node.Attribute("name"));
        var dir = new XElement(XName.Get("Direct", LoquiGenerator.Namespace));
        dir.Add(new XAttribute("refName", $"{ProtoGen.Protocol.Namespace}Group"));
        convert.Add(dir);
        var gen = new XElement(XName.Get("GenericSpecification", LoquiGenerator.Namespace));
        var nameKey = ObjectNamedKey.Factory(node.GetAttribute("refName"), this.ObjectGen.ProtoGen.Protocol);
        gen.Add(new XAttribute("Definition", nameKey.ToString()));
        gen.Add(new XAttribute("TypeToSpecify", "T"));
        dir.Add(gen);
        this.ThisConstruction = true;
        this.CustomData[Plugins.Internals.Constants.EdidLinked] =
            node.GetAttribute<bool>(Plugins.Internals.Constants.EdidLinked, false);
        return base.Load(convert, requireName);
    }
}