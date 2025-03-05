using System;
using System.Collections.Generic;
using System.IO;

namespace WordSearch
{
    internal class TextFileGenerator
    {
        public static Dictionary<string, string[]> wordsDictionary; 
        public static void MakeFile()
        {
            StreamWriter writer = new StreamWriter("words.txt");

            wordsDictionary = new Dictionary<string, string[]>
    {
        { "Ducati", new string[]
            {
                "PANIGALE", "MONSTER", "DIAVEL", "HYPERMOTARD", "MULTISTRADA", "SCRAMBLER", "CORSE", "EVOLUZIONE", "DESMOSEDICI", "SUPERSPORT", "MOTARD", "REGOLARITA", "CAGIVA", "INDIANA", "CUCCIOLO"
            }
        },
        { "Ferrari", new string[]
            {
                "TESTAROSSA", "ENZO", "ROMA", "PORTOFINO", "MODENA", "MARANELLO", "SCUDERIA", "STRADALE", "GTO", "MONZA", "DAYTONA", "PUROSANGUE", "CHALLENGE", "DINO", "CALIFORNIA"
            }
        },
        { "Yamaha", new string[]
            {
                "RAPTOR", "TRACER", "TENERE", "BOLT", "FAZER", "WARRIOR", "DRAGSTAR", "ROADLINER", "VIRAGO", "MAXIM", "STAR", "RAIDER", "VENTURE", "MORPHOUS", "VINO"
            }
        },
        { "Suzuki", new string[]
            {
                "HAYABUSA", "KATANA", "VSTROM", "BURGMAN", "BANDIT", "INTRUDER", "GLADIUS", "MARAUDER", "SAVAGE", "TEMPTER", "HUSTLER", "FREEWIND", "MADURA", "DESPERADO", "BOULEVARD"
            }
        },
        { "Nissan", new string[]
            {
                "SKYLINE", "SILVIA", "FAIRLADY", "CEDRIC", "JUKE", "ALTIMA", "MAXIMA", "MURANO", "PATHFINDER", "PATROL", "NAVARA", "TITAN", "ROGUE", "ARMADA", "LAUREL"
            }
        },
        { "Kawasaki", new string[]
            {
                "NINJA", "VERSYS", "CONCOURS", "VULCAN", "ZEPHYR", "ELIMINATOR", "KAZE", "BRUTE", "ESTRELLA", "MEGURO", "BALIUS", "VOYAGER", "SPECTRE", "DTRACKER", "ZED"
            }
        },
        { "BMW", new string[]
            {
                "ROADSTER", "TOURING", "CLASSIC", "CRUISER", "STRATOS", "AVUS", "DAKAR", "KOMPRESSOR", "ISETTA", "MILLE", "VENTURE", "GRANTURISMO", "SPEEDSTER", "CABRIO", "ALPINA"
            }
        },
        { "Lamborghini", new string[]
            {
                "AVENTADOR", "HURACAN", "URUS", "GALLARDO", "MURCIELAGO", "DIABLO", "REVENTON", "VENENO", "COUNTACH", "SIAN", "MIURA", "ESSENZA", "CENTENARIO", "JARAMA", "ISLERO"
            }
        },
        { "Honda", new string[]
            {
                "CIVIC", "ACCORD", "PRELUDE", "FIT", "PILOT", "RIDGELINE", "GOLDWING", "FIREBLADE", "HORNET", "TRANSALP", "SHADOW", "DEAUVILLE", "DOMINATOR", "MAGNA", "REBEL"
            }
        },
        { "Porsche", new string[]
            {
                "CAYMAN", "BOXSTER", "TAYCAN", "MACAN", "PANAMERA", "CAYENNE", "CARRERA", "SPYDER", "SPEEDSTER", "TARGA", "MISSIONE", "CLUBSPORT", "SEBRING", "MARTINI", "CISITALIA"
            }
        },
    };

            foreach (KeyValuePair<string, string[]> category in wordsDictionary)
            {
                writer.WriteLine(category.Key);
                foreach (string word in category.Value)
                {
                    writer.WriteLine(word);
                }
                writer.WriteLine(" ");

            }
            writer.Close();
        }
    }
}

