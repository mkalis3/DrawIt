using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public partial class MainScript2
{
    void UpdateChallengeTitle()
    {
        cht.GetComponent<Text>().text = "Challenge #" + currentch;
        ChallengeDefinition challenge;
        if (ChallengeCatalog.TryGet(currentch, out challenge))
        {
            chtext.GetComponent<Text>().text = challenge.Description;
        }
    }

    void ChallengeCheck()
    {
        if (ChallengeCatalog.IsCompleted(currentch, score))
        {
            currentch++;
            PlayerPrefs.SetInt("currentch", currentch);
        }

        UpdateChallengeTitle();
    }
}
