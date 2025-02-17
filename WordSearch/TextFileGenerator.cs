using System.Security.Claims;
using System;
using System.IO;

namespace WordSearch
{
    internal class TextFileGenerator
    {
        static void Main(string[] args)
        {
            StreamWriter writer = new StreamWriter("words.txt");

            var wordsDictionary = new Dictionary<string, string[]>
        {
            { "Ducati", new string[15] //15 is not necessary, just a check to be sure that the words are actually 15
                {
                    "Panigale", "Monster", "Diavel", "Hypermotard", "Multistrada", "Scrambler", "Corse", "Evoluzione", "Desmosedici", "Supersport", "Motard", "Regolarita", "Cagiva", "Indiana", "Cucciolo"
                }
            },
            { "Ferrari", new string[15] 
                {
                    "Testarossa", "Enzo", "Roma", "Portofino", "Modena", "Maranello", "Scuderia", "Stradale", "GTO", "Monza", "Daytona", "Purosangue", "Challenge", "Dino", "California"
                }
            },
            { "Yamaha", new string[15]
                {
                   "Raptor", "Tracer", "Tenere", "Bolt", "Fazer", "Warrior", "Dragstar", "Roadliner", "Virago", "Maxim", "Star", "Raider", "Venture", "Morphous", "Vino"
                }
            },
            { "Suzuki", new string[15]
                {
                    "Hayabusa", "Katana", "VStrom", "Burgman", "Bandit", "Intruder", "Gladius", "Marauder", "Savage", "Tempter", "Hustler", "Freewind", "Madura", "Desperado", "Boulevard"
                }
            },
            { "Nissan", new string[15]
                {
                    "Skyline", "Silvia", "Fairlady", "Cedric", "Juke", "Altima", "Maxima", "Murano", "Pathfinder", "Patrol", "Navara", "Titan", "Rogue", "Armada", "Laurel"
                }
            },
            { "Kawasaki", new string[15]
                {
                   "Ninja", "Versys", "Concours", "Vulcan", "Zephyr", "Eliminator", "Kaze", "Brute", "Estrella", "Meguro", "Balius", "Voyager", "Spectre", "DTracker", "Zed"
                }
            },
            { "BMW", new string[15]
                {
                  "Roadster", "Touring", "Classic", "Cruiser", "Stratos", "Avus", "Dakar", "Kompressor", "Isetta", "Mille", "Venture", "GranTurismo", "Speedster", "Cabrio", "Alpina"
                }
            },
            { "Lamborghini", new string[15]
                {
                  "Aventador", "Huracan", "Urus", "Gallardo", "Murcielago", "Diablo", "Reventon", "Veneno", "Countach", "Sian", "Miura", "Essenza", "Centenario", "Jarama", "Islero"
                }
            },
            { "Honda", new string[15]
                {
                   "Civic", "Accord", "Prelude", "Fit", "Pilot", "Ridgeline", "Goldwing", "Fireblade", "Hornet", "Transalp", "Shadow", "Deauville", "Dominator", "Magna", "Rebel"
                }
            },
            { "Porsche", new string[15]
                {
                  "Cayman", "Boxster", "Taycan", "Macan", "Panamera", "Cayenne", "Carrera", "Spyder", "Speedster", "Targa", "MissionE", "Clubsport", "Sebring", "Martini", "Cisitalia"
                }
            },
        };

            foreach (var category in wordsDictionary)
            {
                writer.WriteLine(category.Key); 
                foreach (var word in category.Value)
                {
                    writer.WriteLine(word); 
                }
                writer.WriteLine("\n"); 
                
            }
            writer.Close();
        }
    }
}

