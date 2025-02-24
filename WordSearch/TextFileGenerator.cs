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
            //string[,] database = new string[10,15];
            {
            { "Ducati", new string[] 
                {
                    "Panigale", "Monster", "Diavel", "Hypermotard", "Multistrada", "Scrambler", "Corse", "Evoluzione", "Desmosedici", "Supersport", "Motard", "Regolarita", "Cagiva", "Indiana", "Cucciolo"
                }
            },
            { "Ferrari", new string[]
                {
                    "Testarossa", "Enzo", "Roma", "Portofino", "Modena", "Maranello", "Scuderia", "Stradale", "GTO", "Monza", "Daytona", "Purosangue", "Challenge", "Dino", "California"
                }
            },
            { "Yamaha", new string[]
                {
                   "Raptor", "Tracer", "Tenere", "Bolt", "Fazer", "Warrior", "Dragstar", "Roadliner", "Virago", "Maxim", "Star", "Raider", "Venture", "Morphous", "Vino"
                }
            },
            { "Suzuki", new string[]
                {
                    "Hayabusa", "Katana", "VStrom", "Burgman", "Bandit", "Intruder", "Gladius", "Marauder", "Savage", "Tempter", "Hustler", "Freewind", "Madura", "Desperado", "Boulevard"
                }
            },
            { "Nissan", new string[]
                {
                    "Skyline", "Silvia", "Fairlady", "Cedric", "Juke", "Altima", "Maxima", "Murano", "Pathfinder", "Patrol", "Navara", "Titan", "Rogue", "Armada", "Laurel"
                }
            },
            { "Kawasaki", new string[]
                {
                   "Ninja", "Versys", "Concours", "Vulcan", "Zephyr", "Eliminator", "Kaze", "Brute", "Estrella", "Meguro", "Balius", "Voyager", "Spectre", "DTracker", "Zed"
                }
            },
            { "BMW", new string[]
                {
                  "Roadster", "Touring", "Classic", "Cruiser", "Stratos", "Avus", "Dakar", "Kompressor", "Isetta", "Mille", "Venture", "GranTurismo", "Speedster", "Cabrio", "Alpina"
                }
            },
            { "Lamborghini", new string[]
                {
                  "Aventador", "Huracan", "Urus", "Gallardo", "Murcielago", "Diablo", "Reventon", "Veneno", "Countach", "Sian", "Miura", "Essenza", "Centenario", "Jarama", "Islero"
                }
            },
            { "Honda", new string[]
                {
                   "Civic", "Accord", "Prelude", "Fit", "Pilot", "Ridgeline", "Goldwing", "Fireblade", "Hornet", "Transalp", "Shadow", "Deauville", "Dominator", "Magna", "Rebel"
                }
            },
            { "Porsche", new string[]
                {
                  "Cayman", "Boxster", "Taycan", "Macan", "Panamera", "Cayenne", "Carrera", "Spyder", "Speedster", "Targa", "MissionE", "Clubsport", "Sebring", "Martini", "Cisitalia"
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

