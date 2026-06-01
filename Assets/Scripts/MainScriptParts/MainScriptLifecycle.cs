using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public partial class MainScript2
{
    void Start()
    {
        maincamera = GameObject.Find("Main Camera2");
        cover = GameObject.Find("cover");
        pencil = GameObject.Find("pencil");
        pencil2 = GameObject.Find("pencil2");
        game = GameObject.FindGameObjectWithTag("game");
        scores = GameObject.Find("scores");
        oscore = GameObject.Find("score");
        hscore = GameObject.Find("hscore");
        ostrikes = GameObject.Find("strikes");
        strike = GameObject.Find("strike");
        strike2 = GameObject.Find("strike2");
        strike3 = GameObject.Find("strike3");
        pen = GameObject.Find("pen");
        sa = GameObject.Find("ashape");
        sb = GameObject.Find("bshape");
        sbs = GameObject.Find("bsmall");
        scn = GameObject.Find("newc");
        scn2 = GameObject.Find("newc2");
        scn3 = GameObject.Find("newc3");
        dclock = GameObject.Find("dclock");
        ctext = GameObject.Find("ctext");
        n1 = GameObject.Find("n1");
        n2 = GameObject.Find("n2");
        n3 = GameObject.Find("n3");
        n4 = GameObject.Find("n4");
        fail = GameObject.Find("fail");
        pass = GameObject.Find("pass");
        spass = GameObject.Find("spass");
        sfail = GameObject.Find("sfail");
        sgameover = GameObject.Find("sgameover");
        end = GameObject.Find("end");
        cht = GameObject.Find("cht");
        chtext = GameObject.Find("chtext");
        sn1 = GameObject.Find("sn1");
        sn2 = GameObject.Find("sn2");
        sn3 = GameObject.Find("sn3");
        sn4 = GameObject.Find("sn4");
        sn5 = GameObject.Find("sn5");
        sn6 = GameObject.Find("sn6");
        sn7 = GameObject.Find("sn7");
        sn8 = GameObject.Find("sn8");
        sn9 = GameObject.Find("sn9");
        cacircle = GameObject.Find("cacircle");
        beggining = GameObject.Find("beggining");
        penloc = GameObject.Find("penloc");
        penloc2 = GameObject.Find("penloc2");

        shape = sa;

        int best = PlayerPrefs.GetInt("best");
        currentch = PlayerPrefs.GetInt("currentch");
        hscore.GetComponent<Text>().text = best + "";

        UpdateChallengeTitle();

        newa = Resources.Load("newa", typeof(Sprite)) as Sprite;
        newb = Resources.Load("newb", typeof(Sprite)) as Sprite;
        newc = Resources.Load("newc", typeof(Sprite)) as Sprite;
        newc2 = Resources.Load("newc2", typeof(Sprite)) as Sprite;
        newc3 = Resources.Load("newc3", typeof(Sprite)) as Sprite;

        ApplyCameraAspect();

        pen.transform.position = new Vector3(sa.transform.position.x - sa.GetComponent<RectTransform>().sizeDelta.x / 2.3f, sa.transform.position.y + sa.GetComponent<RectTransform>().sizeDelta.x / 2.1f, pen.transform.position.z);

        spass2 = spass.GetComponent<AudioSource>();
        sfail2 = sfail.GetComponent<AudioSource>();
        sgameover2 = sgameover.GetComponent<AudioSource>();

        if (currentch == 0)
        {
            currentch = 1;
            PlayerPrefs.SetInt("currentch", currentch);
        }

        settime = 1;

        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.BlackBerryPlayer || Application.platform == RuntimePlatform.WP8Player || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            if (startingvid == 0)
            {
                maincamera.GetComponent<UnityEngine.Video.VideoPlayer>().Play();
                maincamera.GetComponent<UnityEngine.Video.VideoPlayer>().loopPointReached += EndReached;
                startingvid = 1;
            }
        }
        else
        {
            StartGame();
        }

        ShapeUnActive();
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.enabled = false;
        StartGame();
    }

    void StartGame()
    {
        beggining.transform.localScale = new Vector3(0, 0, 0);
        maincamera.GetComponent<Animator>().enabled = true;
    }

}
