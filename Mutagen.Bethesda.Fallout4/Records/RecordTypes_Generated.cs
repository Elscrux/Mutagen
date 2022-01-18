using Mutagen.Bethesda.Plugins;

namespace Mutagen.Bethesda.Fallout4.Internals
{
    public class RecordTypes
    {
        public static readonly RecordType AACT = new(0x54434141);
        public static readonly RecordType ACTI = new(0x49544341);
        public static readonly RecordType ALCH = new(0x48434C41);
        public static readonly RecordType ANAM = new(0x4D414E41);
        public static readonly RecordType AORU = new(0x55524F41);
        public static readonly RecordType APPR = new(0x52505041);
        public static readonly RecordType ARMA = new(0x414D5241);
        public static readonly RecordType ARMO = new(0x4F4D5241);
        public static readonly RecordType ARTO = new(0x4F545241);
        public static readonly RecordType ASPC = new(0x43505341);
        public static readonly RecordType ATTX = new(0x58545441);
        public static readonly RecordType AVIF = new(0x46495641);
        public static readonly RecordType BAMT = new(0x544D4142);
        public static readonly RecordType BIDS = new(0x53444942);
        public static readonly RecordType BNAM = new(0x4D414E42);
        public static readonly RecordType BOD2 = new(0x32444F42);
        public static readonly RecordType BODT = new(0x54444F42);
        public static readonly RecordType BOOK = new(0x4B4F4F42);
        public static readonly RecordType CDIX = new(0x58494443);
        public static readonly RecordType CELL = new(0x4C4C4543);
        public static readonly RecordType CITC = new(0x43544943);
        public static readonly RecordType CLAS = new(0x53414C43);
        public static readonly RecordType CLFM = new(0x4D464C43);
        public static readonly RecordType CMPO = new(0x4F504D43);
        public static readonly RecordType CNAM = new(0x4D414E43);
        public static readonly RecordType CNTO = new(0x4F544E43);
        public static readonly RecordType COCT = new(0x54434F43);
        public static readonly RecordType COED = new(0x44454F43);
        public static readonly RecordType CONT = new(0x544E4F43);
        public static readonly RecordType CRGR = new(0x52475243);
        public static readonly RecordType CRVA = new(0x41565243);
        public static readonly RecordType CTDA = new(0x41445443);
        public static readonly RecordType CUSD = new(0x44535543);
        public static readonly RecordType CVPA = new(0x41505643);
        public static readonly RecordType DAMA = new(0x414D4144);
        public static readonly RecordType DAMC = new(0x434D4144);
        public static readonly RecordType DATA = new(0x41544144);
        public static readonly RecordType DEBR = new(0x52424544);
        public static readonly RecordType DELE = new(0x454C4544);
        public static readonly RecordType DESC = new(0x43534544);
        public static readonly RecordType DEST = new(0x54534544);
        public static readonly RecordType DMDL = new(0x4C444D44);
        public static readonly RecordType DMGT = new(0x54474D44);
        public static readonly RecordType DNAM = new(0x4D414E44);
        public static readonly RecordType DODT = new(0x54444F44);
        public static readonly RecordType DOOR = new(0x524F4F44);
        public static readonly RecordType DSTA = new(0x41545344);
        public static readonly RecordType DSTD = new(0x44545344);
        public static readonly RecordType DSTF = new(0x46545344);
        public static readonly RecordType EFID = new(0x44494645);
        public static readonly RecordType EFIT = new(0x54494645);
        public static readonly RecordType EITM = new(0x4D544945);
        public static readonly RecordType ENAM = new(0x4D414E45);
        public static readonly RecordType ENCH = new(0x48434E45);
        public static readonly RecordType ENIT = new(0x54494E45);
        public static readonly RecordType EQUP = new(0x50555145);
        public static readonly RecordType ETYP = new(0x50595445);
        public static readonly RecordType EXPL = new(0x4C505845);
        public static readonly RecordType FACT = new(0x54434146);
        public static readonly RecordType FIMD = new(0x444D4946);
        public static readonly RecordType FLOR = new(0x524F4C46);
        public static readonly RecordType FLST = new(0x54534C46);
        public static readonly RecordType FLTV = new(0x56544C46);
        public static readonly RecordType FNAM = new(0x4D414E46);
        public static readonly RecordType FNPR = new(0x52504E46);
        public static readonly RecordType FSTP = new(0x50545346);
        public static readonly RecordType FSTS = new(0x53545346);
        public static readonly RecordType FTYP = new(0x50595446);
        public static readonly RecordType FULL = new(0x4C4C5546);
        public static readonly RecordType FURN = new(0x4E525546);
        public static readonly RecordType GDRY = new(0x59524447);
        public static readonly RecordType GLOB = new(0x424F4C47);
        public static readonly RecordType GMST = new(0x54534D47);
        public static readonly RecordType GNAM = new(0x4D414E47);
        public static readonly RecordType GRAS = new(0x53415247);
        public static readonly RecordType GRUP = new(0x50555247);
        public static readonly RecordType HDPT = new(0x54504448);
        public static readonly RecordType HEDR = new(0x52444548);
        public static readonly RecordType HNAM = new(0x4D414E48);
        public static readonly RecordType ICO2 = new(0x324F4349);
        public static readonly RecordType ICON = new(0x4E4F4349);
        public static readonly RecordType INAM = new(0x4D414E49);
        public static readonly RecordType INCC = new(0x43434E49);
        public static readonly RecordType INDX = new(0x58444E49);
        public static readonly RecordType INGR = new(0x52474E49);
        public static readonly RecordType INNR = new(0x524E4E49);
        public static readonly RecordType INRD = new(0x44524E49);
        public static readonly RecordType INTV = new(0x56544E49);
        public static readonly RecordType IPDS = new(0x53445049);
        public static readonly RecordType ITXT = new(0x54585449);
        public static readonly RecordType JAIL = new(0x4C49414A);
        public static readonly RecordType JOUT = new(0x54554F4A);
        public static readonly RecordType KEYM = new(0x4D59454B);
        public static readonly RecordType KNAM = new(0x4D414E4B);
        public static readonly RecordType KSIZ = new(0x5A49534B);
        public static readonly RecordType KWDA = new(0x4144574B);
        public static readonly RecordType KYWD = new(0x4457594B);
        public static readonly RecordType LCRT = new(0x5452434C);
        public static readonly RecordType LENS = new(0x534E454C);
        public static readonly RecordType LIGH = new(0x4847494C);
        public static readonly RecordType LLCT = new(0x54434C4C);
        public static readonly RecordType LLKC = new(0x434B4C4C);
        public static readonly RecordType LNAM = new(0x4D414E4C);
        public static readonly RecordType LTEX = new(0x5845544C);
        public static readonly RecordType LVLD = new(0x444C564C);
        public static readonly RecordType LVLF = new(0x464C564C);
        public static readonly RecordType LVLG = new(0x474C564C);
        public static readonly RecordType LVLI = new(0x494C564C);
        public static readonly RecordType LVLM = new(0x4D4C564C);
        public static readonly RecordType LVLN = new(0x4E4C564C);
        public static readonly RecordType LVLO = new(0x4F4C564C);
        public static readonly RecordType LVSG = new(0x4753564C);
        public static readonly RecordType LVSP = new(0x5053564C);
        public static readonly RecordType MAST = new(0x5453414D);
        public static readonly RecordType MATT = new(0x5454414D);
        public static readonly RecordType MESG = new(0x4753454D);
        public static readonly RecordType MGEF = new(0x4645474D);
        public static readonly RecordType MICO = new(0x4F43494D);
        public static readonly RecordType MISC = new(0x4353494D);
        public static readonly RecordType MNAM = new(0x4D414E4D);
        public static readonly RecordType MOD2 = new(0x32444F4D);
        public static readonly RecordType MOD3 = new(0x33444F4D);
        public static readonly RecordType MOD4 = new(0x34444F4D);
        public static readonly RecordType MOD5 = new(0x35444F4D);
        public static readonly RecordType MODC = new(0x43444F4D);
        public static readonly RecordType MODF = new(0x46444F4D);
        public static readonly RecordType MODL = new(0x4C444F4D);
        public static readonly RecordType MODS = new(0x53444F4D);
        public static readonly RecordType MODT = new(0x54444F4D);
        public static readonly RecordType MSTT = new(0x5454534D);
        public static readonly RecordType MSWP = new(0x5057534D);
        public static readonly RecordType MUSC = new(0x4353554D);
        public static readonly RecordType MUST = new(0x5453554D);
        public static readonly RecordType NAM0 = new(0x304D414E);
        public static readonly RecordType NAM1 = new(0x314D414E);
        public static readonly RecordType NAM2 = new(0x324D414E);
        public static readonly RecordType NAM3 = new(0x334D414E);
        public static readonly RecordType NAVM = new(0x4D56414E);
        public static readonly RecordType NNAM = new(0x4D414E4E);
        public static readonly RecordType NPC_ = new(0x5F43504E);
        public static readonly RecordType NTRM = new(0x4D52544E);
        public static readonly RecordType OBND = new(0x444E424F);
        public static readonly RecordType OBTE = new(0x4554424F);
        public static readonly RecordType OBTF = new(0x4654424F);
        public static readonly RecordType OBTS = new(0x5354424F);
        public static readonly RecordType OFST = new(0x5453464F);
        public static readonly RecordType OMOD = new(0x444F4D4F);
        public static readonly RecordType ONAM = new(0x4D414E4F);
        public static readonly RecordType OTFT = new(0x5446544F);
        public static readonly RecordType PERK = new(0x4B524550);
        public static readonly RecordType PFIG = new(0x47494650);
        public static readonly RecordType PFPC = new(0x43504650);
        public static readonly RecordType PLCN = new(0x4E434C50);
        public static readonly RecordType PLVD = new(0x44564C50);
        public static readonly RecordType PNAM = new(0x4D414E50);
        public static readonly RecordType PRPS = new(0x53505250);
        public static readonly RecordType PTRN = new(0x4E525450);
        public static readonly RecordType QNAM = new(0x4D414E51);
        public static readonly RecordType QUST = new(0x54535551);
        public static readonly RecordType RACE = new(0x45434152);
        public static readonly RecordType RADR = new(0x52444152);
        public static readonly RecordType RCLR = new(0x524C4352);
        public static readonly RecordType RDAT = new(0x54414452);
        public static readonly RecordType RDGS = new(0x53474452);
        public static readonly RecordType RDMO = new(0x4F4D4452);
        public static readonly RecordType RDMP = new(0x504D4452);
        public static readonly RecordType RDOT = new(0x544F4452);
        public static readonly RecordType RDSA = new(0x41534452);
        public static readonly RecordType RDWT = new(0x54574452);
        public static readonly RecordType REFR = new(0x52464552);
        public static readonly RecordType REGN = new(0x4E474552);
        public static readonly RecordType REPT = new(0x54504552);
        public static readonly RecordType REVB = new(0x42564552);
        public static readonly RecordType RLDM = new(0x4D444C52);
        public static readonly RecordType RNAM = new(0x4D414E52);
        public static readonly RecordType RPLD = new(0x444C5052);
        public static readonly RecordType RPLI = new(0x494C5052);
        public static readonly RecordType SCOL = new(0x4C4F4353);
        public static readonly RecordType SCRN = new(0x4E524353);
        public static readonly RecordType SDSC = new(0x43534453);
        public static readonly RecordType SNAM = new(0x4D414E53);
        public static readonly RecordType SNDD = new(0x44444E53);
        public static readonly RecordType SNDR = new(0x52444E53);
        public static readonly RecordType SOPM = new(0x4D504F53);
        public static readonly RecordType SOUN = new(0x4E554F53);
        public static readonly RecordType SPCT = new(0x54435053);
        public static readonly RecordType SPEL = new(0x4C455053);
        public static readonly RecordType SPIT = new(0x54495053);
        public static readonly RecordType SPLO = new(0x4F4C5053);
        public static readonly RecordType STAG = new(0x47415453);
        public static readonly RecordType STAT = new(0x54415453);
        public static readonly RecordType STCP = new(0x50435453);
        public static readonly RecordType STOL = new(0x4C4F5453);
        public static readonly RecordType STOP = new(0x504F5453);
        public static readonly RecordType TACT = new(0x54434154);
        public static readonly RecordType TERM = new(0x4D524554);
        public static readonly RecordType TES4 = new(0x34534554);
        public static readonly RecordType TNAM = new(0x4D414E54);
        public static readonly RecordType TREE = new(0x45455254);
        public static readonly RecordType TRNS = new(0x534E5254);
        public static readonly RecordType TX00 = new(0x30305854);
        public static readonly RecordType TX01 = new(0x31305854);
        public static readonly RecordType TX02 = new(0x32305854);
        public static readonly RecordType TX03 = new(0x33305854);
        public static readonly RecordType TX04 = new(0x34305854);
        public static readonly RecordType TX05 = new(0x35305854);
        public static readonly RecordType TX06 = new(0x36305854);
        public static readonly RecordType TX07 = new(0x37305854);
        public static readonly RecordType TXST = new(0x54535854);
        public static readonly RecordType VENC = new(0x434E4556);
        public static readonly RecordType VEND = new(0x444E4556);
        public static readonly RecordType VENV = new(0x564E4556);
        public static readonly RecordType VMAD = new(0x44414D56);
        public static readonly RecordType VNAM = new(0x4D414E56);
        public static readonly RecordType VTYP = new(0x50595456);
        public static readonly RecordType WAIT = new(0x54494157);
        public static readonly RecordType WATR = new(0x52544157);
        public static readonly RecordType WBDT = new(0x54444257);
        public static readonly RecordType WGDR = new(0x52444757);
        public static readonly RecordType WNAM = new(0x4D414E57);
        public static readonly RecordType WRLD = new(0x444C5257);
        public static readonly RecordType WTHR = new(0x52485457);
        public static readonly RecordType XCNT = new(0x544E4358);
        public static readonly RecordType XMRK = new(0x4B524D58);
        public static readonly RecordType XNAM = new(0x4D414E58);
        public static readonly RecordType XTRI = new(0x49525458);
        public static readonly RecordType XXXX = new(0x58585858);
        public static readonly RecordType YNAM = new(0x4D414E59);
        public static readonly RecordType ZNAM = new(0x4D414E5A);
    }
}
