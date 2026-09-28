namespace Mission1_EchoppeAlchimie;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Mission 1 : L'Échoppe d'Alchimie (Commandes de Raid en Gros) ---");

        // --- Saisie de la commande ---
        Console.Write("Nom de la guilde : ");
        string guilde = LireTexte();

        Console.WriteLine("Type d'élixir : 1) Soin  2) Mana");
        string elixir = LireChoix(1, 2) == 1 ? "Élixir de soin" : "Élixir de mana";

        Console.WriteLine("Calibre du flacon : 1) Standard  2) Grand Calibre");
        bool grandCalibre = LireChoix(1, 2) == 2;

        Console.Write("Quantité de flacons : ");
        int quantite = LireEntierPositif();

        // --- Option 1 : matériau de la fiole ---
        Console.WriteLine("Matériau de la fiole : 1) Basique  2) Verre arcanique  3) Cristal pur");
        int choixMateriau = LireChoix(1, 3);

        string materiau;
        decimal supplementMateriau;

        if (choixMateriau == 2)
        {
            materiau = "Verre arcanique";
            supplementMateriau = grandCalibre ? 0.60m : 0.30m;
        }
        else if (choixMateriau == 3)
        {
            materiau = "Cristal pur";
            supplementMateriau = grandCalibre ? 3.20m : 1.60m;
        }
        else
        {
            materiau = "Basique";
            supplementMateriau = 0;
        }

        // --- Option 2 : pureté (réservée aux flacons basiques) ---
        int purete = 0;
        decimal supplementPurete = 0;

        if (choixMateriau == 1)
        {
            Console.WriteLine("Degré de pureté : 0) Aucun  1) I  2) II  3) III  4) IV");
            purete = LireChoix(0, 4);

            if (purete == 1)
            {
                supplementPurete = 0.50m;
            }
            else if (purete == 2)
            {
                supplementPurete = 1.00m;
            }
            else if (purete == 3)
            {
                supplementPurete = 2.00m;
            }
            else if (purete == 4)
            {
                supplementPurete = 3.00m;
            }

            if (grandCalibre)
            {
                supplementPurete *= 2;
            }
        }

        // --- Calculs ---
        decimal prixBase = PrixUnitaireBase(quantite, grandCalibre);
        decimal prixUnitaire = prixBase + supplementMateriau + supplementPurete;
        decimal total = prixUnitaire * quantite;

        // --- Devis ---
        Console.WriteLine();
        Console.WriteLine("==================== DEVIS ====================");
        Console.WriteLine($"Guilde               : {guilde}");
        Console.WriteLine($"Produit              : {elixir}");
        Console.WriteLine($"Calibre              : {(grandCalibre ? "Grand Calibre" : "Standard")}");
        Console.WriteLine($"Quantité             : {quantite} flacon(s)");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine($"Prix unitaire de base: {prixBase,8:0.00} PO");
        Console.WriteLine($"Fiole ({materiau,-15}): {supplementMateriau,8:+0.00;-0.00;+0.00} PO");

        if (choixMateriau == 1)
        {
            string libellePurete = purete == 0 ? "aucune" : "degré " + new[] { "", "I", "II", "III", "IV" }[purete];
            Console.WriteLine($"Pureté ({libellePurete,-14}): {supplementPurete,8:+0.00;-0.00;+0.00} PO");
        }

        Console.WriteLine($"Prix unitaire total  : {prixUnitaire,8:0.00} PO");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine($"TOTAL ({quantite} x {prixUnitaire:0.00} PO) : {total:0.00} PO");
        Console.WriteLine("===============================================");
    }

    // Prix unitaire dégressif selon la quantité (valeurs reprises telles quelles de l'énoncé).
    static decimal PrixUnitaireBase(int quantite, bool grandCalibre)
    {
        if (quantite <= 25)
        {
            return grandCalibre ? 3.00m : 1.50m;
        }
        else if (quantite <= 50)
        {
            return grandCalibre ? 2.00m : 1.00m;
        }
        else if (quantite <= 100)
        {
            return grandCalibre ? 1.80m : 0.90m;
        }
        else if (quantite <= 250)
        {
            return grandCalibre ? 1.60m : 0.80m;
        }
        else if (quantite <= 500)
        {
            return grandCalibre ? 1.40m : 0.70m;
        }
        else if (quantite <= 1000)
        {
            return grandCalibre ? 1.20m : 0.60m;
        }
        else if (quantite <= 3000)
        {
            return grandCalibre ? 1.20m : 0.50m;
        }
        else if (quantite <= 4000)
        {
            return grandCalibre ? 0.40m : 0.80m;
        }
        else
        {
            return grandCalibre ? 0.60m : 0.30m;
        }
    }

    static int LireChoix(int min, int max)
    {
        Console.Write("Votre choix : ");
        int choix;

        while (!int.TryParse(Console.ReadLine(), out choix) || choix < min || choix > max)
        {
            Console.Write($"Choix invalide ({min} à {max}), recommencez : ");
        }

        return choix;
    }

    static int LireEntierPositif()
    {
        int valeur;

        while (!int.TryParse(Console.ReadLine(), out valeur) || valeur <= 0)
        {
            Console.Write("Saisie invalide (nombre > 0), recommencez : ");
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
