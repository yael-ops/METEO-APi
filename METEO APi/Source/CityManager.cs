using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;

namespace METEO_APi
{
    public class CityManager
    {
        private const string FileName = "cities.txt";
        private List<string> villes;


        public List<string> Villes
        {
            get { return villes; }
        }
        public bool CityExists(string city)
        {
            return villes.Contains(city);
        }
        public CityManager()
        {
            // Chargez les villes à partir du fichier lors de la création de l'instance
            villes = ReadCities();

            // Si la liste est vide (première exécution), ajoutez des villes par défaut
            if (villes.Count == 0)
            {
                villes.AddRange(new List<string> { "Annecy", "Lyon", "Paris" });
            }
        }

        public void AddCity(string newCity)
        {
            villes.Add(newCity);

            // Sauvegardez la liste mise à jour dans le fichier
            WriteCities(villes);
        }

        public void RemoveCity(string city)
        {
            villes.Remove(city);

            // Sauvegardez la liste mise à jour dans le fichier
            WriteCities(villes);
        }

        private List<string> ReadCities()
        {
            List<string> cities = new List<string>();

            try
            {
                if (File.Exists(FileName))
                {
                    cities.AddRange(File.ReadAllLines(FileName));
                }
            }
            catch
            {
                // Gérer l'exception, mais pour cet exemple, nous ignorons simplement les erreurs de lecture du fichier.
            }

            return cities;
        }

        private void WriteCities(List<string> cities)
        {
            try
            {
                File.WriteAllLines(FileName, cities);
            }
            catch
            {
                // Gérer l'exception, mais pour cet exemple, nous ignorons simplement les erreurs d'écriture dans le fichier.
            }
        }
    }
}