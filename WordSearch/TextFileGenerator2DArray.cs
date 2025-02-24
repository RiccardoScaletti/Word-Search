using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch
{
    internal class TextFileGenerator2DArray
    {
            public static void MakeFile()
        {
            // Array of brand names
            string[] brands = new string[]
            {
            "Ducati", "Ferrari", "Yamaha", "Suzuki", "Nissan",
            "Kawasaki", "BMW", "Lamborghini", "Honda", "Porsche"
            };

            // 2D array of models corresponding to each brand
            string[,] models = new string[,]
            {
            { "Panigale", "Monster", "Diavel", "Hypermotard", "Multistrada",
              "Scrambler", "Corse", "Evoluzione", "Desmosedici", "Supersport",
              "Motard", "Regolarita", "Cagiva", "Indiana", "Cucciolo" },
            { "Testarossa", "Enzo", "Roma", "Portofino", "Modena",
              "Maranello", "Scuderia", "Stradale", "GTO", "Monza",
              "Daytona", "Purosangue", "Challenge", "Dino", "California" },
            { "Raptor", "Tracer", "Tenere", "Bolt", "Fazer",
              "Warrior", "Dragstar", "Roadliner", "Virago", "Maxim",
              "Star", "Raider", "Venture", "Morphous", "Vino" },
            { "Hayabusa", "Katana", "VStrom", "Burgman", "Bandit",
              "Intruder", "Gladius", "Marauder", "Savage", "Tempter",
              "Hustler", "Freewind", "Madura", "Desperado", "Boulevard" },
            { "Skyline", "Silvia", "Fairlady", "Cedric", "Juke",
              "Altima", "Maxima", "Murano", "Pathfinder", "Patrol",
              "Navara", "Titan", "Rogue", "Armada", "Laurel" },
            { "Ninja", "Versys", "Concours", "Vulcan", "Zephyr",
              "Eliminator", "Kaze", "Brute", "Estrella", "Meguro",
              "Balius", "Voyager", "Spectre", "DTracker", "Zed" },
            { "Roadster", "Touring", "Classic", "Cruiser", "Stratos",
              "Avus", "Dakar", "Kompressor", "Isetta", "Mille",
              "Venture", "GranTurismo", "Speedster", "Cabrio", "Alpina" },
            { "Aventador", "Huracan", "Urus", "Gallardo", "Murcielago",
              "Diablo", "Reventon", "Veneno", "Countach", "Sian",
              "Miura", "Essenza", "Centenario", "Jarama", "Islero" },
            { "Civic", "Accord", "Prelude", "Fit", "Pilot",
              "Ridgeline", "Goldwing", "Fireblade", "Hornet", "Transalp",
              "Shadow", "Deauville", "Dominator", "Magna", "Rebel" },
            { "Cayman", "Boxster", "Taycan", "Macan", "Panamera",
              "Cayenne", "Carrera", "Spyder", "Speedster", "Targa",
              "MissionE", "Clubsport", "Sebring", "Martini", "Cisitalia" }
            };

            // Write the data to a file
            using (StreamWriter writer = new StreamWriter("words.txt"))
            {
                for (int i = 0; i < brands.Length; i++)
                {
                    writer.WriteLine(brands[i]); // Write the brand name
                    for (int j = 0; j < models.GetLength(1); j++)
                    {
                        writer.WriteLine(models[i, j]); // Write each model
                    }
                    writer.WriteLine(); // Add an empty line after each brand
                }
            }
        }
    }
}
