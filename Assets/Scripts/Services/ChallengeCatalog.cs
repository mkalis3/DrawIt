public struct ChallengeDefinition
{
    public readonly int Id;
    public readonly int TargetScore;
    public readonly string Description;

    public ChallengeDefinition(int id, int targetScore, string description)
    {
        Id = id;
        TargetScore = targetScore;
        Description = description;
    }
}

public static class ChallengeCatalog
{
    private static readonly ChallengeDefinition[] Challenges =
    {
        new ChallengeDefinition(1, 2, "Achieve a score of 2"),
        new ChallengeDefinition(2, 2, "Achieve a score of 2\nUnder 40 seconds"),
        new ChallengeDefinition(3, 2, "Draw the same shape 2 times"),
        new ChallengeDefinition(4, 5, "Achieve a score of 5"),
        new ChallengeDefinition(5, 5, "Draw the same shape 5 times"),
        new ChallengeDefinition(6, 3, "Achieve a score of 3\nWithout strikes"),
        new ChallengeDefinition(7, 2, "Achieve a score of 2\nWithout lifting your finger"),
        new ChallengeDefinition(8, 10, "Achieve a score of 10"),
        new ChallengeDefinition(9, 5, "Achieve a score of 5\nWithout strikes"),
        new ChallengeDefinition(10, 12, "Achieve a score of 12\nUnder 500 seconds"),
        new ChallengeDefinition(11, 8, "Achieve a score of 8\nWithout lifting your finger"),
        new ChallengeDefinition(12, 10, "Draw the same shape 10 times"),
        new ChallengeDefinition(13, 20, "Achieve a score of 20"),
        new ChallengeDefinition(14, 20, "Achieve a score of 20\nUnder 800 seconds"),
        new ChallengeDefinition(15, 15, "Draw the same shape 15 times"),
        new ChallengeDefinition(16, 10, "Achieve a score of 10\nWithout strikes"),
        new ChallengeDefinition(17, 12, "Achieve a score of 12\nWithout lifting your finger"),
        new ChallengeDefinition(18, 20, "Draw the same shape 20 times"),
        new ChallengeDefinition(19, 15, "Achieve a score of 15\nWithout strikes"),
        new ChallengeDefinition(20, 15, "Achieve a score of 15\nWithout lifting your finger")
    };

    public static ChallengeDefinition[] GetAll()
    {
        ChallengeDefinition[] copy = new ChallengeDefinition[Challenges.Length];
        System.Array.Copy(Challenges, copy, Challenges.Length);
        return copy;
    }

    public static bool TryGet(int id, out ChallengeDefinition definition)
    {
        for (int i = 0; i < Challenges.Length; i++)
        {
            if (Challenges[i].Id == id)
            {
                definition = Challenges[i];
                return true;
            }
        }

        definition = default(ChallengeDefinition);
        return false;
    }

    public static bool IsCompleted(int id, int score)
    {
        ChallengeDefinition definition;
        return TryGet(id, out definition) && score >= definition.TargetScore;
    }
}
