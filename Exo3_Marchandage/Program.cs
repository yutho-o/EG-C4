namespace Exo3_Marchandage;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Exercice 3 : Le Marchandage de l'Échoppe Obscure ---");

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

    static double LireNombre()
    {
        double valeur;

        while (!double.TryParse(Console.ReadLine(), out valeur))
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
