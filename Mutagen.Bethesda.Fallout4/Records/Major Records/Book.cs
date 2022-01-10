using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Plugins.Binary.Translations;
using Noggog;
using System;
using System.Buffers.Binary;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class Book
    {
        [Flags]
        public enum Flag
        {
            AdvanceActorValue = 0x01,
            CantBeTaken = 0x02,
            AddSpell = 0x04,
            AddPerk = 0x10
        }
    }

    namespace Internals
    {
        public partial class BookBinaryCreateTranslation
        {
            public const byte PerkFlag = 0x01;
            public const byte SpellFlag = 0x04;

            public static partial void FillBinaryFlagsCustom(MutagenFrame frame, IBookInternal item)
            {
                item.Flags = (Book.Flag)frame.ReadUInt8();
            }

            public static partial void FillBinaryTeachesCustom(MutagenFrame frame, IBookInternal item)
            {
                if ((((int)item.Flags) & SpellFlag) > 0)
                {
                    item.Teaches = new BookSpell()
                    {
                        Spell = new FormLink<ISpellGetter>(FormLinkBinaryTranslation.Instance.Parse(frame))
                    };
                }
                else if ((((int)item.Flags) & PerkFlag) > 0)
                {
                    item.Teaches = new BookPerk
                    {
                        Perk = (Perk)frame.ReadInt32()
                    };
                }
                else
                {
                    item.Teaches = new BookTeachesNothing()
                    {
                        RawContent = frame.ReadUInt32()
                    };
                }
            }
        }

        public partial class BookBinaryWriteTranslation
        {
            public static partial void WriteBinaryFlagsCustom(MutagenWriter writer, IBookGetter item)
            {
                byte flags = (byte)item.Flags;
                switch (item.Teaches)
                {
                    case BookSpell _:
                        flags = (byte)EnumExt.SetFlag(flags, BookBinaryCreateTranslation.PerkFlag, false);
                        flags = (byte)EnumExt.SetFlag(flags, BookBinaryCreateTranslation.SpellFlag, true);
                        break;
                    case BookPerk _:
                        flags = (byte)EnumExt.SetFlag(flags, BookBinaryCreateTranslation.PerkFlag, true);
                        flags = (byte)EnumExt.SetFlag(flags, BookBinaryCreateTranslation.SpellFlag, false);
                        break;
                    default:
                        break;
                }
                writer.Write(flags);
            }

            public static partial void WriteBinaryTeachesCustom(MutagenWriter writer, IBookGetter item)
            {
                switch (item.Teaches)
                {
                    case BookSpell spell:
                        FormLinkBinaryTranslation.Instance.Write(writer, spell.Spell);
                        break;
                    case BookPerk skill:
                        var skillVal = skill.Perk;
                        if (skillVal == null)
                        {
                            writer.Write(-1);
                        }
                        else
                        {
                            writer.Write((int)skillVal);
                        }
                        break;
                    case BookTeachesNothing nothing:
                        writer.Write(nothing.RawContent);
                        break;
                    default:
                        writer.WriteZeros(4);
                        break;
                }
            }
        }

        public partial class BookBinaryOverlay
        {
            public Book.Flag GetFlagsCustom()
            {
                if (!_DATALocation.HasValue) return default;
                return (Book.Flag)_data[_FlagsLocation];
            }

            public IBookTeachTargetGetter? GetTeachesCustom()
            {
                if (!_DATALocation.HasValue) return default;
                int flags = (int)this.Flags;
                if ((flags & BookBinaryCreateTranslation.SpellFlag) > 0)
                {
                    return new BookSpell()
                    {
                        Spell = new FormLink<ISpellGetter>(FormKeyBinaryTranslation.Instance.Parse(_data.Slice(_TeachesLocation, 4), _package.MetaData.MasterReferences!))
                    };
                }
                else if ((flags & BookBinaryCreateTranslation.PerkFlag) > 0)
                {
                    return new BookPerk
                    {
                        Perk = (Perk)BinaryPrimitives.ReadInt32LittleEndian(_data.Slice(_TeachesLocation, 4))
                    };
                }
                else
                {
                    return new BookTeachesNothing()
                    {
                        RawContent = BinaryPrimitives.ReadUInt32LittleEndian(_data.Slice(_TeachesLocation, 4))
                    };
                }
            }
        }
    }
}
