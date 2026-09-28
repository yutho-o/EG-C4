namespace ClassesAndRankExo2;

class Program
{
    static void Main(string[] args)
    {
        Exercice2();
        Exercice3();
        Exercice4();
    }

    static void Exercice2()
    {
        Console.WriteLine("\n--- Exercice 2 : Le Conseil des Classes et des Rangs ---");

        Console.Write("Niveau du personnage : ");
        int niveau = LireEntier();

        Console.Write("Classe principale (G, M ou R) : ");
        char classe = char.ToUpper(LireTexte()[0]);

        Console.Write("Nombre de Quêtes Héroïques accomplies : ");
        int quetes = LireEntier();

        string titre;

        if (niveau < 10)
        {
            titre = "Novice";
        }
        else if (niveau >= 30 && quetes > 20 && (classe == 'G' || classe == 'M'))
        {
            titre = "Maître de Guilde";
        }
        else if (niveau >= 10 && niveau <= 20)
        {
            titre = quetes >= 5 ? "Adepte" : "Apprenti assermenté";
        }
        else if ((niveau > 20 && niveau < 30) || (classe == 'M' && niveau >= 25))
        {
            titre = "Vétéran";
        }
        else
        {
            titre = "Statut Indéterminé / Hors-la-loi";
        }

        Console.WriteLine($"Titre officiel : {titre}");
    }

    static void Exercice3()
    {
        Console.WriteLine("\n--- Exercice 3 : Le Marchandage de l'Échoppe Obscure ---");

        Console.Write("Prix de base de l'artefact : ");
        double prix = LireNombre();

        Console.Write("Êtes-vous membre de la Guilde des Marchands ? (oui/non) : ");
        bool membre = LireTexte().Equals("oui", StringComparison.OrdinalIgnoreCase);

        double reduction = 0;

        if (membre)
        {
            reduction = 0.20;
        }
        else
        {
            Console.Write("Possédez-vous un Sceau des Ombres ? (oui/non) : ");
            bool possedeSceau = LireTexte().Equals("oui", StringComparison.OrdinalIgnoreCase);

            if (possedeSceau)
            {
                reduction = prix >= 100 ? 0.15 : 0.10;
            }
        }

        double prixFinal = prix * (1 - reduction);
        Console.WriteLine($"Prix final : {prixFinal:0.00} pièces d'or");
    }

    static void Exercice4()
    {
        Console.WriteLine("\n--- Exercice 4 : La Résonance des Cristaux Élémentaires ---");

        Console.Write("Numéro du tour actuel : ");
        int tour = LireEntier();

        if (tour % 3 == 0)
        {
            Console.WriteLine("Résonance parfaite ! Le sort déclenche une onde de choc élémentaire critique !");
        }
        else
        {
            Console.WriteLine("Incantation normale... Le cristal accumule de l'énergie.");
        }

        int toursAvantResonance = 3 - tour % 3;
        Console.WriteLine($"Prochaine résonance dans {toursAvantResonance} tour(s).");
    }

    static int LireEntier()
    {
        while (!int.TryParse(Console.ReadLine(), out int valeur))
        {
            Console.Write("Saisie invalide, recommencez : ");
        }

        return valeur;
    }

    static double LireNombre()
    {
        while (!double.TryParse(Console.ReadLine(), out double valeur))
        {
            Console.Write("Saisie invalide, recommencez : ");
        }

        return valeur;
    }

    static string LireTexte()
    {
        string? texte;

        do
        {
            texte = Console.ReadLine()?.Trim();
        } while (string.IsNullOrEmpty(texte));

        return texte!;
    }
}
