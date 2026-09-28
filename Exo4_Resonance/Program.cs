namespace Exo4_Resonance;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Exercice 4 : La Résonance des Cristaux Élémentaires ---");

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
        int valeur;

        while (!int.TryParse(Console.ReadLine(), out valeur))
        {
            Console.Write("Saisie invalide, recommencez : ");
        }

        return valeur;
    }
}
