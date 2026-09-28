namespace Exo2_ClassesEtRangs;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Exercice 2 : Le Conseil des Classes et des Rangs ---");

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

    static int LireEntier()
    {
        int valeur;

        while (!int.TryParse(Console.ReadLine(), out valeur))
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
