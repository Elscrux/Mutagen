using Mutagen.Bethesda.Plugins;

namespace Mutagen.Bethesda.Oblivion.Internals
{
    public partial class RecordTypes
    {
        public static readonly RecordType ACBS = new(0x53424341);
        public static readonly RecordType ACHR = new(0x52484341);
        public static readonly RecordType ACRE = new(0x45524341);
        public static readonly RecordType ACTI = new(0x49544341);
        public static readonly RecordType AIDT = new(0x54444941);
        public static readonly RecordType ALCH = new(0x48434C41);
        public static readonly RecordType AMMO = new(0x4F4D4D41);
        public static readonly RecordType ANAM = new(0x4D414E41);
        public static readonly RecordType ANIO = new(0x4F494E41);
        public static readonly RecordType APPA = new(0x41505041);
        public static readonly RecordType ARMO = new(0x4F4D5241);
        public static readonly RecordType ATTR = new(0x52545441);
        public static readonly RecordType ATXT = new(0x54585441);
        public static readonly RecordType BMDT = new(0x54444D42);
        public static readonly RecordType BNAM = new(0x4D414E42);
        public static readonly RecordType BOOK = new(0x4B4F4F42);
        public static readonly RecordType BSGN = new(0x4E475342);
        public static readonly RecordType BTXT = new(0x54585442);
        public static readonly RecordType CELL = new(0x4C4C4543);
        public static readonly RecordType CLAS = new(0x53414C43);
        public static readonly RecordType CLMT = new(0x544D4C43);
        public static readonly RecordType CLOT = new(0x544F4C43);
        public static readonly RecordType CNAM = new(0x4D414E43);
        public static readonly RecordType CNTO = new(0x4F544E43);
        public static readonly RecordType CONT = new(0x544E4F43);
        public static readonly RecordType CREA = new(0x41455243);
        public static readonly RecordType CSAD = new(0x44415343);
        public static readonly RecordType CSCR = new(0x52435343);
        public static readonly RecordType CSDC = new(0x43445343);
        public static readonly RecordType CSDI = new(0x49445343);
        public static readonly RecordType CSDT = new(0x54445343);
        public static readonly RecordType CSTD = new(0x44545343);
        public static readonly RecordType CSTY = new(0x59545343);
        public static readonly RecordType CTDA = new(0x41445443);
        public static readonly RecordType CTDT = new(0x54445443);
        public static readonly RecordType DATA = new(0x41544144);
        public static readonly RecordType DELE = new(0x454C4544);
        public static readonly RecordType DESC = new(0x43534544);
        public static readonly RecordType DIAL = new(0x4C414944);
        public static readonly RecordType DNAM = new(0x4D414E44);
        public static readonly RecordType DOOR = new(0x524F4F44);
        public static readonly RecordType EFID = new(0x44494645);
        public static readonly RecordType EFIT = new(0x54494645);
        public static readonly RecordType EFSH = new(0x48534645);
        public static readonly RecordType ENAM = new(0x4D414E45);
        public static readonly RecordType ENCH = new(0x48434E45);
        public static readonly RecordType ENIT = new(0x54494E45);
        public static readonly RecordType ESCE = new(0x45435345);
        public static readonly RecordType EYES = new(0x53455945);
        public static readonly RecordType FACT = new(0x54434146);
        public static readonly RecordType FGGA = new(0x41474746);
        public static readonly RecordType FGGS = new(0x53474746);
        public static readonly RecordType FGTS = new(0x53544746);
        public static readonly RecordType FLOR = new(0x524F4C46);
        public static readonly RecordType FLTV = new(0x56544C46);
        public static readonly RecordType FNAM = new(0x4D414E46);
        public static readonly RecordType FULL = new(0x4C4C5546);
        public static readonly RecordType FURN = new(0x4E525546);
        public static readonly RecordType GLOB = new(0x424F4C47);
        public static readonly RecordType GMST = new(0x54534D47);
        public static readonly RecordType GNAM = new(0x4D414E47);
        public static readonly RecordType GRAS = new(0x53415247);
        public static readonly RecordType GRUP = new(0x50555247);
        public static readonly RecordType HAIR = new(0x52494148);
        public static readonly RecordType HCLR = new(0x524C4348);
        public static readonly RecordType HEDR = new(0x52444548);
        public static readonly RecordType HNAM = new(0x4D414E48);
        public static readonly RecordType ICO2 = new(0x324F4349);
        public static readonly RecordType ICON = new(0x4E4F4349);
        public static readonly RecordType IDLE = new(0x454C4449);
        public static readonly RecordType INAM = new(0x4D414E49);
        public static readonly RecordType INDX = new(0x58444E49);
        public static readonly RecordType INFO = new(0x4F464E49);
        public static readonly RecordType INGR = new(0x52474E49);
        public static readonly RecordType JNAM = new(0x4D414E4A);
        public static readonly RecordType KEYM = new(0x4D59454B);
        public static readonly RecordType KFFZ = new(0x5A46464B);
        public static readonly RecordType LAND = new(0x444E414C);
        public static readonly RecordType LIGH = new(0x4847494C);
        public static readonly RecordType LNAM = new(0x4D414E4C);
        public static readonly RecordType LSCR = new(0x5243534C);
        public static readonly RecordType LTEX = new(0x5845544C);
        public static readonly RecordType LVLC = new(0x434C564C);
        public static readonly RecordType LVLD = new(0x444C564C);
        public static readonly RecordType LVLF = new(0x464C564C);
        public static readonly RecordType LVLI = new(0x494C564C);
        public static readonly RecordType LVLO = new(0x4F4C564C);
        public static readonly RecordType LVSP = new(0x5053564C);
        public static readonly RecordType MAST = new(0x5453414D);
        public static readonly RecordType MGEF = new(0x4645474D);
        public static readonly RecordType MISC = new(0x4353494D);
        public static readonly RecordType MNAM = new(0x4D414E4D);
        public static readonly RecordType MOD2 = new(0x32444F4D);
        public static readonly RecordType MOD3 = new(0x33444F4D);
        public static readonly RecordType MOD4 = new(0x34444F4D);
        public static readonly RecordType MODB = new(0x42444F4D);
        public static readonly RecordType MODL = new(0x4C444F4D);
        public static readonly RecordType MODT = new(0x54444F4D);
        public static readonly RecordType NAM0 = new(0x304D414E);
        public static readonly RecordType NAM1 = new(0x314D414E);
        public static readonly RecordType NAM2 = new(0x324D414E);
        public static readonly RecordType NAM9 = new(0x394D414E);
        public static readonly RecordType NAME = new(0x454D414E);
        public static readonly RecordType NIFT = new(0x5446494E);
        public static readonly RecordType NIFZ = new(0x5A46494E);
        public static readonly RecordType NPC_ = new(0x5F43504E);
        public static readonly RecordType OFST = new(0x5453464F);
        public static readonly RecordType ONAM = new(0x4D414E4F);
        public static readonly RecordType PACK = new(0x4B434150);
        public static readonly RecordType PFIG = new(0x47494650);
        public static readonly RecordType PFPC = new(0x43504650);
        public static readonly RecordType PGAG = new(0x47414750);
        public static readonly RecordType PGRD = new(0x44524750);
        public static readonly RecordType PGRI = new(0x49524750);
        public static readonly RecordType PGRL = new(0x4C524750);
        public static readonly RecordType PGRP = new(0x50524750);
        public static readonly RecordType PKDT = new(0x54444B50);
        public static readonly RecordType PKID = new(0x44494B50);
        public static readonly RecordType PLDT = new(0x54444C50);
        public static readonly RecordType PNAM = new(0x4D414E50);
        public static readonly RecordType PSDT = new(0x54445350);
        public static readonly RecordType PTDT = new(0x54445450);
        public static readonly RecordType QNAM = new(0x4D414E51);
        public static readonly RecordType QSDT = new(0x54445351);
        public static readonly RecordType QSTA = new(0x41545351);
        public static readonly RecordType QSTI = new(0x49545351);
        public static readonly RecordType QUST = new(0x54535551);
        public static readonly RecordType RACE = new(0x45434152);
        public static readonly RecordType RCLR = new(0x524C4352);
        public static readonly RecordType RDAT = new(0x54414452);
        public static readonly RecordType RDGS = new(0x53474452);
        public static readonly RecordType RDMD = new(0x444D4452);
        public static readonly RecordType RDMP = new(0x504D4452);
        public static readonly RecordType RDOT = new(0x544F4452);
        public static readonly RecordType RDSD = new(0x44534452);
        public static readonly RecordType RDWT = new(0x54574452);
        public static readonly RecordType REFR = new(0x52464552);
        public static readonly RecordType REGN = new(0x4E474552);
        public static readonly RecordType RNAM = new(0x4D414E52);
        public static readonly RecordType ROAD = new(0x44414F52);
        public static readonly RecordType RPLD = new(0x444C5052);
        public static readonly RecordType RPLI = new(0x494C5052);
        public static readonly RecordType SBSP = new(0x50534253);
        public static readonly RecordType SCDA = new(0x41444353);
        public static readonly RecordType SCHD = new(0x44484353);
        public static readonly RecordType SCHR = new(0x52484353);
        public static readonly RecordType SCIT = new(0x54494353);
        public static readonly RecordType SCPT = new(0x54504353);
        public static readonly RecordType SCRI = new(0x49524353);
        public static readonly RecordType SCRO = new(0x4F524353);
        public static readonly RecordType SCRV = new(0x56524353);
        public static readonly RecordType SCTX = new(0x58544353);
        public static readonly RecordType SCVR = new(0x52564353);
        public static readonly RecordType SGST = new(0x54534753);
        public static readonly RecordType SKIL = new(0x4C494B53);
        public static readonly RecordType SLCP = new(0x50434C53);
        public static readonly RecordType SLGM = new(0x4D474C53);
        public static readonly RecordType SLSD = new(0x44534C53);
        public static readonly RecordType SNAM = new(0x4D414E53);
        public static readonly RecordType SNDD = new(0x44444E53);
        public static readonly RecordType SNDX = new(0x58444E53);
        public static readonly RecordType SOUL = new(0x4C554F53);
        public static readonly RecordType SOUN = new(0x4E554F53);
        public static readonly RecordType SPEL = new(0x4C455053);
        public static readonly RecordType SPIT = new(0x54495053);
        public static readonly RecordType SPLO = new(0x4F4C5053);
        public static readonly RecordType STAT = new(0x54415453);
        public static readonly RecordType TCLF = new(0x464C4354);
        public static readonly RecordType TCLT = new(0x544C4354);
        public static readonly RecordType TES4 = new(0x34534554);
        public static readonly RecordType TNAM = new(0x4D414E54);
        public static readonly RecordType TRDT = new(0x54445254);
        public static readonly RecordType TREE = new(0x45455254);
        public static readonly RecordType UNAM = new(0x4D414E55);
        public static readonly RecordType VCLR = new(0x524C4356);
        public static readonly RecordType VHGT = new(0x54474856);
        public static readonly RecordType VNAM = new(0x4D414E56);
        public static readonly RecordType VNML = new(0x4C4D4E56);
        public static readonly RecordType VTEX = new(0x58455456);
        public static readonly RecordType VTXT = new(0x54585456);
        public static readonly RecordType WATR = new(0x52544157);
        public static readonly RecordType WEAP = new(0x50414557);
        public static readonly RecordType WLST = new(0x54534C57);
        public static readonly RecordType WNAM = new(0x4D414E57);
        public static readonly RecordType WRLD = new(0x444C5257);
        public static readonly RecordType WTHR = new(0x52485457);
        public static readonly RecordType XACT = new(0x54434158);
        public static readonly RecordType XCCM = new(0x4D434358);
        public static readonly RecordType XCHG = new(0x47484358);
        public static readonly RecordType XCLC = new(0x434C4358);
        public static readonly RecordType XCLL = new(0x4C4C4358);
        public static readonly RecordType XCLR = new(0x524C4358);
        public static readonly RecordType XCLW = new(0x574C4358);
        public static readonly RecordType XCMT = new(0x544D4358);
        public static readonly RecordType XCNT = new(0x544E4358);
        public static readonly RecordType XCWT = new(0x54574358);
        public static readonly RecordType XESP = new(0x50534558);
        public static readonly RecordType XGLB = new(0x424C4758);
        public static readonly RecordType XHLT = new(0x544C4858);
        public static readonly RecordType XHRS = new(0x53524858);
        public static readonly RecordType XLCM = new(0x4D434C58);
        public static readonly RecordType XLOC = new(0x434F4C58);
        public static readonly RecordType XLOD = new(0x444F4C58);
        public static readonly RecordType XMRC = new(0x43524D58);
        public static readonly RecordType XMRK = new(0x4B524D58);
        public static readonly RecordType XNAM = new(0x4D414E58);
        public static readonly RecordType XOWN = new(0x4E574F58);
        public static readonly RecordType XPCI = new(0x49435058);
        public static readonly RecordType XRGD = new(0x44475258);
        public static readonly RecordType XRNK = new(0x4B4E5258);
        public static readonly RecordType XRTM = new(0x4D545258);
        public static readonly RecordType XSCL = new(0x4C435358);
        public static readonly RecordType XSED = new(0x44455358);
        public static readonly RecordType XSOL = new(0x4C4F5358);
        public static readonly RecordType XTEL = new(0x4C455458);
        public static readonly RecordType XTRG = new(0x47525458);
        public static readonly RecordType XXXX = new(0x58585858);
        public static readonly RecordType ZNAM = new(0x4D414E5A);
    }
}
