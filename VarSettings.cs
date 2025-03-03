using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Var
{
    public class FileName
    {
        public string FILE_BDD = "log_info.db";
        public string FILE_DATA = DateTime.Now.ToString("yyyyMMdd") + ".log";
        public string FINAL_FILE = "file_command_sql.txt";
    }

    public class ConstantVar
    {
        public Regex RECUP_TRAME_PATTERN = new Regex(@"(sql> (BEGIN|Replace|Update|COMMIT))");
        public string[] BANNED_CHAR = new string[] { "BEGIN TRANSACTION", "COMMIT TRANSACTION", "T_REMISE", "MagColl" };
        public string LOG_DIRECTORY = @"C:\Users\00048322\OneDrive - VINCI Autoroutes\Documents\C#\Lecture Log\Lecture Log\log";
    }

    public class TblChar
    {
        public static string[] SEARCH_CHAR = new string[]
        {
        @"^.* sql> ",
        "Replace into",
        "Update T_TRANS Set ",
        "Update T_TRANS set ",
        @" where rowid=\w{1,2}",
        "Collecte,Remise,Num,TDate,TTime,Pan,Approved,Amount",
        @"Prop='0;0'$",
        @"Prop='0;19'$",
        @"Prop='0;35'$",
        "Tags='FF0DFF0EFF0F008E9F0D9F0E9F0F9F339F34'",
        "Iso2=''",
        "Name=",
        @"Smact=0",
        @"Smact=2",
        "(Aid=|PanHash=|Emv=|Iso2=|Online=|Prop=|TACIAC=|Name=|Bank=|Tags=|Timings=|IdVoie=|Smact=)",
        @"(\d{3})\)$"
        };

        public static string[] REPLACE_CHAR = new string[]
        {
        "",
        "insert into",
        "",
        "",
        "",
        "Collecte,Remise,Num,TDate,TTime,Pan,Approved,Amount,Aid,PanHash,Emv,Iso2,Online,Prop,TACIAC,Name,Bank,Tags,Timings,IdVoie,Smact",
        @"Prop='0;0',",
        @"Prop='0;19',",
        @"Prop='0;35',",
        "Tags='FF0DFF0EFF0F008E9F0D9F0E9F0F9F339F34',",
        "Iso2='',",
        ",Name=",
        @"Smact=0)",
        @"Smact=2)",
        "",
        "$1,"
        };

        public static string CREATE_BDD = @"
        CREATE TABLE T_TRANS (
            TDate char(6),
            Remise integer,
            Num integer,
            TTime char(6),
            Approved integer,
            Collecte integer,
            Amount integer,
            Aid char(32),
            Pan char(19),
            Iso2 char(8),
            TacIac char(66),
            Online char(80),
            Emv text(400),
            Prop char(20),
            PanHash char(64),
            Name char(48),
            Bank char(64),
            Tags char(40),
            IdVoie char(40),
            Smact integer,
            Timings char(30),
            PRIMARY KEY( Remise, Num )
        );
    ";
    }
}
