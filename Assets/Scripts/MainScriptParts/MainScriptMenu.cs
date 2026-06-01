using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public partial class MainScript2
{
    public void Play()
    {
        cover.GetComponent<Animator>().SetBool("replay", true);
        cover.GetComponent<Animator>().SetFloat("Direction", 1);
        cover.GetComponent<Animator>().Play(0, -1, 0);
        pencil.GetComponent<Animator>().enabled = true;

        scores.transform.localScale = new Vector3(1, 1, 1);
        dclock.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        ctext.transform.localScale = new Vector3(1, 1, 1);

        score = 0;
        play = 1;
    }

    public void Settings()
    {
        cover.GetComponent<Animator>().SetFloat("Direction", 1);
        cover.GetComponent<Animator>().Play(1, -1, 0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
