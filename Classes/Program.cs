using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MySql.Data.MySqlClient;
using System.IO;

namespace FilRouge
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Create an AutoResetEvent to signal the timeout threshold in the
            // timer callback has been reached.
            var autoEvent = new AutoResetEvent(false);

            var statusChecker = new StatusChecker(2);


            var stateTimer = new Timer(statusChecker.CheckStatus,
                                       autoEvent, 0, 200);

            Console.WriteLine("Chargement du CSV");
            autoEvent.WaitOne();

            string path = "Listing.csv";
            List<string[]> data = new List<string[]>();
            data = LectureFichier(path);
            autoEvent.WaitOne();
            List<Personnel> listePersonnel = new List<Personnel>();
            List<Attraction> listeAttractions = new List<Attraction>();
            Administration administration = new Administration(listeAttractions, listePersonnel);
            autoEvent.WaitOne();
            
            administration.CSVToAdmin(data);

            Console.WriteLine("Affichage de la liste du personnel");
            autoEvent.WaitOne();
            administration.listePersonnel.ForEach(Console.WriteLine);

            autoEvent.WaitOne();
            Console.WriteLine("Affichage de la liste de demons");
            autoEvent.WaitOne();
            administration.ListeDemons().ForEach(Console.WriteLine);
            autoEvent.WaitOne();
            Console.WriteLine("Affichage du demon au matricule egal a 66754 ");
            autoEvent.WaitOne();
            Console.WriteLine(administration.ListeDemons().Find(element => element.matricule==66754));
            autoEvent.WaitOne();
            Console.WriteLine("Affichage du meme demon apres perte de 40 points et affecte a la boutique barbe a papa automatiquement");
            autoEvent.WaitOne();
            administration.ChangerCagnotte(-40, administration.ListeDemons().Find(element => element.matricule == 66754));
            Console.WriteLine(administration.ListeDemons().Find(element => element.matricule == 66754));
            autoEvent.WaitOne();
            Console.WriteLine("Affichage de la liste d'attractions triée par nom");
            autoEvent.WaitOne();
            administration.AttractionTriNom(true);
            administration.listeAttractions.ForEach(Console.WriteLine);
            autoEvent.WaitOne();
            Console.WriteLine("Affichage de la liste de monstres triée par cagnotte");
            autoEvent.WaitOne();
            administration.MonstreTriCagnotte(true).ForEach(Console.WriteLine);
            autoEvent.WaitOne();
            Console.WriteLine("Affichage de la liste du personnel triée par matricule");
            autoEvent.WaitOne();
            administration.PersonnelTriMatricule(true);
            administration.listePersonnel.ForEach(Console.WriteLine);
            autoEvent.WaitOne();
            Console.WriteLine("Affichage de la meme liste avec ajout d'un sorcier");
            autoEvent.WaitOne();
            List<string> listepouvoirs = new List<string>();
            administration.AjouterSorcier(listepouvoirs, Grade.giga, 42, "Sanchez", "Rick", TypeSexe.male, "Recherche");
            administration.listePersonnel.ForEach(Console.WriteLine);
            autoEvent.WaitOne();
            Console.WriteLine("Affichage de la liste d'attractions avec ajout d'une boutique");
            autoEvent.WaitOne();
            administration.AjouterBoutique(TypeBoutique.nourriture, false, 7, 1, "McDonalds", "");
            administration.listeAttractions.ForEach(Console.WriteLine);
            autoEvent.WaitOne();
            Console.WriteLine("");
            autoEvent.WaitOne();
            Console.WriteLine("Sauvegarde du nouveau fichier CSV");
            autoEvent.WaitOne();
            administration.SauvegarderFichier();
            stateTimer.Dispose();
            Console.WriteLine("\nDestroying timer.");


            Console.ReadKey();
        }

        class StatusChecker
        {
            private int invokeCount;
            private int maxCount;

            public StatusChecker(int count)
            {
                invokeCount = 0;
                maxCount = count;
            }

            
            public void CheckStatus(Object stateInfo)
            {
                AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
                Console.WriteLine("");
                ++invokeCount;

                if (invokeCount == maxCount)
                {
                    
                    invokeCount = 0;
                    autoEvent.Set();
                }
            }
        }



        static List<string[]> LectureFichier(string path)
        {
            StreamReader lecture = new StreamReader(path);

            List<string[]> data = new List<string[]>();

            int Row = 0;

            while (!lecture.EndOfStream)
            {
                string[] Line = lecture.ReadLine().Split(';');
                data.Add(Line);
                Row++;
                Console.WriteLine(Row);
            }

            lecture.Close();
            //Partie débogage
            foreach (var array in data)
            {
                Console.WriteLine();

                foreach (var item in array)
                {
                    Console.Write(" ");
                    Console.Write(item);
                }
            }
            return data;
        }
    }
}
