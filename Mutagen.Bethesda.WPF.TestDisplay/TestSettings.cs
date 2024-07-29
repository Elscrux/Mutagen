using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace Mutagen.Bethesda.WPF.TestDisplay;

public class TestSettings
{
    [Tooltip("This is my bool")]
    public bool MyBool;
        
    [Tooltip("This is my string")]
    public string MyString = "Hello world";
        
    [Tooltip("This is my FormKey")]
    public FormKey MyFormKey;
        
    [Tooltip("This is my Armor")]
    public IFormLinkGetter<IArmorGetter> MyArmor = FormLink<IArmorGetter>.Null;
        
    [Tooltip("This is my Item")]
    public IFormLinkGetter<IItemGetter> MyItem = FormLink<IItemGetter>.Null;

    [Tooltip("This is an enum")]
    public MyEnum MyEnum = MyEnum.EnumValue2;

    public SubClass SubObject = new();

    public List<int> PrimitiveList = new()
    {
        1, 2, 3
    };

    public List<SubClass> ObjectList = new()
    {
        new SubClass()
        {
            MyInt = 23,
        }
    };

    public List<IFormLinkGetter<IItemGetter>> MyItems = new()
    {
        new FormLink<IItemGetter>(FormKey.Factory("123456:Skyrim.esm")),
        new FormLink<IItemGetter>(FormKey.Factory("123457:Skyrim.esm")),
    };

    public Dictionary<int, SubClass> Dictionary = new();

    public Dictionary<MyEnum, SubClass> DictionaryWithEnumKey = new();

    public Dictionary<SubClass, SubClass> DictionaryWithComplexKey = new();

    public Dictionary<IFormLinkGetter<IArmorGetter>, SubClass> DictionaryWithLinkKey = new();
}

public enum MyEnum
{
    EnumValue1,
    EnumValue2,
    EnumValue3,
}

public class SubClass
{
    public int MyInt { get; set; } = 23;
}