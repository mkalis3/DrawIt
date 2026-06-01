using NUnit.Framework;

public class ChallengeCatalogTests
{
    [Test]
    public void CatalogContainsTwentyChallenges()
    {
        Assert.AreEqual(20, ChallengeCatalog.GetAll().Length);
    }

    [Test]
    public void TimedChallengeKeepsConfiguredTarget()
    {
        ChallengeDefinition challenge;

        bool found = ChallengeCatalog.TryGet(10, out challenge);

        Assert.IsTrue(found);
        Assert.AreEqual(12, challenge.TargetScore);
        Assert.AreEqual("Achieve a score of 12\nUnder 500 seconds", challenge.Description);
    }

    [Test]
    public void CompletionUsesChallengeTargetScore()
    {
        Assert.IsFalse(ChallengeCatalog.IsCompleted(13, 19));
        Assert.IsTrue(ChallengeCatalog.IsCompleted(13, 20));
    }
}
