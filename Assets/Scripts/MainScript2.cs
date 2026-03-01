using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainScript2 : MonoBehaviour
{

    int play, strikes, nshape, score, hcount, showed, opened, lastshape, currentch, gameover, settime, same, startingvid;
    float defa, alpha, aspeed = 0.1f, gspeed = 2.0f, gspeed2 = 0.3f, time, fshape;
    GameObject maincamera, cover, pencil, pencil2, game, scores, oscore, hscore, ostrikes, strike, strike2, strike3, pen, sa, sb, sbs, scn, scn2, scn3, dclock, ctext, n1, n2, n3, n4, fail, pass, spass, sfail, sgameover, gameovern, end, cht, chtext, sn1, sn2, sn3, sn4, sn5, sn6, sn7, sn8, sn9, cacircle, beggining,
    penloc, penloc2;
    public GameObject shape, clone;
    AudioSource spass2, sfail2, sgameover2;
    Sprite newa, newb, newc, newc2, newc3;
    public int redraw, stage;
    Color lastcolor;


    // Use this for initialization
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

        ChaTitle();

        newa = Resources.Load("newa", typeof(Sprite)) as Sprite;
        newb = Resources.Load("newb", typeof(Sprite)) as Sprite;
        newc = Resources.Load("newc", typeof(Sprite)) as Sprite;
        newc2 = Resources.Load("newc2", typeof(Sprite)) as Sprite;
        newc3 = Resources.Load("newc3", typeof(Sprite)) as Sprite;

        Aspect();

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

    // Update is called once per frame
    void LateUpdate()
    {
        if (maincamera.transform.eulerAngles.x == 0)
        {
            if (maincamera.GetComponent<Camera>().fieldOfView > 6)
            {
                maincamera.GetComponent<Camera>().fieldOfView = maincamera.GetComponent<Camera>().fieldOfView - 0.6f;
            }
            else
            {
                //print(opened + " " + cover.transform.localEulerAngles.z);
                if (opened == 0 && cover.transform.localEulerAngles.z < 250 && cover.transform.localEulerAngles.z != 0)
                {
                    opened = 1;
                    game.transform.localScale = new Vector3(0, 0, 0);
                    ostrikes.transform.localScale = new Vector3(1, 1, 1);
                    stage = 1;
                    fshape = 0;
                    NewShape();
                    pencil2.transform.localScale = new Vector3(6, 6, 6);
                    pencil2.GetComponent<Animator>().enabled = true;
                    DrawLine script2 = (DrawLine)pen.GetComponent(typeof(DrawLine));
                    script2.draw = 0;
                }
                else if (opened == 1 && play == 4 && cover.transform.localEulerAngles.z < 8)
                {
                    //cover.GetComponent<Animator>().enabled = false;
                    opened = 0;
                    game.transform.localScale = new Vector3(1, 1, 1);
                    ostrikes.transform.localScale = new Vector3(0, 0, 0);
                    stage = 0;
                    pencil2.transform.localScale = new Vector3(0, 0, 0);
                    pencil2.GetComponent<Animator>().enabled = false;
                    showed = 0;
                    //cover.GetComponent<Animator>().SetFloat("Direction", 1);
                    play = 0;
                    fail.transform.localScale = new Vector3(0, 0, 0);
                    strikes = 0;
                    strike.GetComponent<Text>().color = new Color(strike.GetComponent<Text>().color.r, strike.GetComponent<Text>().color.g, strike.GetComponent<Text>().color.b, 0.2f);
                    strike2.GetComponent<Text>().color = new Color(strike2.GetComponent<Text>().color.r, strike2.GetComponent<Text>().color.g, strike2.GetComponent<Text>().color.b, 0.2f);
                    strike3.GetComponent<Text>().color = new Color(strike3.GetComponent<Text>().color.r, strike3.GetComponent<Text>().color.g, strike3.GetComponent<Text>().color.b, 0.2f);
                }
                if ((int)cover.transform.localEulerAngles.z == 156 && showed == 0)
                {
                    //cover.GetComponent<Animator>().enabled = false;
                    showed = 1;
                }
                if (play == 1)
                {
                    if (stage == 1)
                    {
                        if (fshape < 1)
                        {
                            fshape += 0.02f;
                            shape.GetComponent<SpriteRenderer>().color = new Color(shape.GetComponent<SpriteRenderer>().color.r, shape.GetComponent<SpriteRenderer>().color.g, shape.GetComponent<SpriteRenderer>().color.b, fshape);
                        }
                        else
                        {
                            stage = 2;
                            pen.transform.localScale = new Vector3(50, 50, 50);
                            cacircle.transform.localScale = new Vector3(2, 0.000000001f, 2);
                            DrawLine script = (DrawLine)pen.GetComponent(typeof(DrawLine));
                            script.StartCoroutine(script.Replay());
                            MouseDrag script2 = (MouseDrag)pen.GetComponent(typeof(MouseDrag));
                            script2.drag = 1;
                        }
                    }
                    else if (stage == 2)
                    {
                        if (time > 0)
                        {
                            ctext.GetComponent<Text>().text = GetTime((int)time);
                            time -= Time.deltaTime;
                        }
                        else
                        {
                            Strike();
                        }
                        if (TouchRelease())
                        {
                            if (currentch == 7 || currentch == 11 || currentch == 17 || currentch == 20)
                            {
                                strikes = 2;
                                Strike();
                            }
                        }
                    }
                    else if (stage == 3)
                    {
                        Color fc = fail.GetComponent<Text>().color;
                        float aa = fc.a;
                        //print("stage " + aa);
                        if (aa > 0)
                        {
                            fail.GetComponent<Text>().color = new Color(fc.r, fc.g, fc.b, aa - 0.1f);
                        }
                        else
                        {
                            fail.transform.localScale = new Vector3(0, 0, 0);
                            fc = fail.GetComponent<Text>().color;
                            fail.GetComponent<Text>().color = new Color(fc.r, fc.g, fc.b, 1);
                            fshape = 0;
                            stage = 1;
                        }
                    }
                    else if (stage == 4)
                    {

                    }
                    else if (stage == 5)
                    {
                        Color fc = pass.GetComponent<RawImage>().color;
                        float aa = fc.a;
                        //print("stage " + aa);
                        if (aa > 0)
                        {
                            pass.GetComponent<RawImage>().color = new Color(fc.r, fc.g, fc.b, aa - 0.1f);
                        }
                        else
                        {
                            pass.transform.localScale = new Vector3(0, 0, 0);
                            fc = pass.GetComponent<RawImage>().color;
                            pass.GetComponent<RawImage>().color = new Color(fc.r, fc.g, fc.b, 1);
                            fshape = 0;
                            stage = 1;
                        }
                    }
                }
                if (Input.GetMouseButtonDown(0))
                {
                    RaycastHit hit;
                    Ray ray;
                    ray = maincamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.name == "play2")
                        {
                            Play();
                        }
                        else if (hit.transform.name == "settings2")
                        {
                            Settings();
                        }
                        else if (hit.transform.name == "quit2")
                        {
                            Quit();
                        }
                    }
                }
            }
        }
    }

    void ChaTitle()
    {
        cht.GetComponent<Text>().text = "Challenge #" + currentch;
        if (currentch == 1)
        {
            chtext.GetComponent<Text>().text = "Achieve a score of 2";
        }
        else if (currentch == 2)
        {
            chtext.GetComponent<Text>().text = "Achieve a score of 2\nUnder 40 seconds";
        }
        else if (currentch == 3)
        {
            chtext.GetComponent<Text>().text = "Draw the same shape 2 times";
        }
        else if (currentch == 4)
        {
            chtext.GetComponent<Text>().text = "Achieve a score of 5";
        }
        else if (currentch == 5)
        {
            chtext.GetComponent<Text>().text = "Draw the same shape 5 times";
        }
        else if (currentch == 6)
        {
            chtext.GetComponent<Text>().text = "Achieve a score of 3\nWithout strikes";
        }
        else if (currentch == 7)
        {
            chtext.GetComponent<Text>().text = "Achieve a score of 2\nWithout lifting your finger";
        }
        else if (currentch == 8)
        {
            chtext.GetComponent<Text>().text = "Achieve a score of 10";
        }
        else if (currentch == 9)
        {
            chtext.GetComponent<Text>().text = "Achieve a score of 5\nWithout strikes";
        }
        else if (currentch == 10)
        {
            chtext.GetComponent<Text>().text = "Achieve a score of 12\nUnder 500 seconds";
        }
        else if (currentch == 11)
        {
            chtext.GetComponent<Text>().text = "Achieve a score of 8\nWithout lifting your finger";
        }
        else if (currentch == 12)
        {
            chtext.GetComponent<Text>().text = "Draw the same shape 10 times";
        }
        else if (currentch == 13)
        {
            chtext.GetComponent<Text>().text = "Achieve a score of 20";
        }
        else if (currentch == 14)
        {
            chtext.GetComponent<Text>().text = "Achieve a score of 20\nUnder 800 seconds";
        }
        else if (currentch == 15)
        {
            chtext.GetComponent<Text>().text = "Draw the same shape 15 times";
        }
        else if (currentch == 16)
        {
            chtext.GetComponent<Text>().text = "Achieve a score of 10\nWithout strikes";
        }
        else if (currentch == 17)
        {
            chtext.GetComponent<Text>().text = "Achieve a score of 12\nWithout lifting your finger";
        }
        else if (currentch == 18)
        {
            chtext.GetComponent<Text>().text = "Draw the same shape 20 times";
        }
        else if (currentch == 19)
        {
            chtext.GetComponent<Text>().text = "Achieve a score of 15\nWithout strikes";
        }
        else if (currentch == 20)
        {
            chtext.GetComponent<Text>().text = "Achieve a score of 15\nWithout lifting your finger";
        }
    }

    public void Strike()
    {
        MouseDrag script = (MouseDrag)pen.GetComponent(typeof(MouseDrag));
        script.drag = 0;
        script.pressed = 0;
        strikes++;
        Color sc = shape.GetComponent<SpriteRenderer>().color;
        cacircle.transform.localScale = new Vector3(0, 0, 0);
        if (strikes == 3 || currentch == 6 || currentch == 9 || currentch == 16 || currentch == 19)
        {
            GameOver();
            strike3.GetComponent<Text>().color = new Color(strike3.GetComponent<Text>().color.r, strike3.GetComponent<Text>().color.g, strike3.GetComponent<Text>().color.b, 1);
            stage = 4;
            shape.GetComponent<SpriteRenderer>().color = new Color(sc.r, sc.g, sc.b, 0);
        }
        else if (strikes == 1)
        {
            NewShape();
            strike.GetComponent<Text>().color = new Color(strike.GetComponent<Text>().color.r, strike.GetComponent<Text>().color.g, strike.GetComponent<Text>().color.b, 1);
            sfail2.Play();
            stage = 3;
            shape.GetComponent<SpriteRenderer>().color = new Color(sc.r, sc.g, sc.b, 0);
        }
        else if (strikes == 2)
        {
            NewShape();
            strike2.GetComponent<Text>().color = new Color(strike2.GetComponent<Text>().color.r, strike2.GetComponent<Text>().color.g, strike2.GetComponent<Text>().color.b, 1);
            sfail2.Play();
            stage = 3;
            shape.GetComponent<SpriteRenderer>().color = new Color(sc.r, sc.g, sc.b, 0);
        }
        pen.transform.localScale = new Vector3(0, 0, 0);
        fail.transform.localScale = new Vector3(1, 1, 1);
        nshape = 2;
        n1.GetComponent<Text>().text = "0";
        ctext.GetComponent<Text>().text = "";
    }

    public void GivePoints()
    {
        pass.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        cacircle.transform.localScale = new Vector3(0, 0, 0);
        score++;
        SetScore(score);
        ChallengeCheck();
        //shape.GetComponent<SpriteRenderer>().color = new Color32(23, 255, 140, 255);
        nshape = 2;
        stage = 5;
        spass2.Play();

        if (currentch != 2 && currentch != 10 && currentch != 14)
        {
            settime = 1;
        }

        same++;

        n1.GetComponent<Text>().text = "0";

        if (score == 5)
        {
            n2.GetComponent<Text>().text = "4";
            n2.GetComponent<Text>().text = "8";
            n2.GetComponent<Text>().text = "12";
        }
        else if (score == 20)
        {
            n2.GetComponent<Text>().text = "3";
            n2.GetComponent<Text>().text = "6";
            n2.GetComponent<Text>().text = "9";
        }
        else if (score == 40)
        {
            n2.GetComponent<Text>().text = "2";
            n2.GetComponent<Text>().text = "4";
            n2.GetComponent<Text>().text = "6";
        }

        pen.transform.localScale = new Vector3(0, 0, 0);
        NewShape();
        ctext.GetComponent<Text>().text = "";
    }

    void ChallengeCheck()
    {
        if (currentch == 1 || currentch == 2 || currentch == 3 || currentch == 7)
        {
            if (score >= 2)
            {
                currentch++;
                PlayerPrefs.SetInt("currentch", currentch);
            }
        }
        else if (currentch == 4 || currentch == 5 || currentch == 9)
        {
            if (score >= 5)
            {
                currentch++;
                PlayerPrefs.SetInt("currentch", currentch);
            }
        }
        else if (currentch == 6)
        {
            if (score >= 3)
            {
                currentch++;
                PlayerPrefs.SetInt("currentch", currentch);
            }
        }
        else if (currentch == 8 || currentch == 12 || currentch == 16)
        {
            if (score >= 10)
            {
                currentch++;
                PlayerPrefs.SetInt("currentch", currentch);
            }
        }
        else if (currentch == 10 || currentch == 17)
        {
            if (score >= 12)
            {
                currentch++;
                PlayerPrefs.SetInt("currentch", currentch);
            }
        }
        else if (currentch == 11)
        {
            if (score >= 8)
            {
                currentch++;
                PlayerPrefs.SetInt("currentch", currentch);
            }
        }
        else if (currentch == 13 || currentch == 14 || currentch == 18)
        {
            if (score >= 20)
            {
                currentch++;
                PlayerPrefs.SetInt("currentch", currentch);
            }
        }
        else if (currentch == 15 || currentch == 19 || currentch == 20)
        {
            if (score >= 15)
            {
                currentch++;
                PlayerPrefs.SetInt("currentch", currentch);
            }
        }
        ChaTitle();
    }

    public void GameOver()
    {
        cover.GetComponent<Animator>().SetFloat("Direction", -1.0f);
        cover.GetComponent<Animator>().Play(0, -1, 0);
        int hscore = PlayerPrefs.GetInt("highscore");
        if (score > hscore)
        {
            hscore = score;
            PlayerPrefs.SetInt("highscore", score);
        }
        SetScore(0);
        //shape.transform.localPosition = new Vector3(shape.transform.localPosition.x, 10f, 0);

        hcount = 0;
        play = 4;
        time = 0;
        gameover = 1;
        settime = 1;

        sgameover2.Play();

        MouseDrag script = (MouseDrag)pen.GetComponent(typeof(MouseDrag));
        script.drag = 0;
        script.pressed = 0;

        DrawLine script2 = (DrawLine)pen.GetComponent(typeof(DrawLine));
        script2.draw = 0;

        ctext.GetComponent<Text>().text = "";

        //print("gameover");
    }

    void NewShape()
    {
        if (clone != null)
        {
            Destroy(clone);
        }
        int random = Random.Range(0, 9);
        if (random + 1 == lastshape)
        {
            NewShape();
            return;
        }
        shape.transform.localScale = new Vector3(0, 0, 0);
        shape.SetActive(false);

        if (gameover == 0)
        {
            if (currentch == 3 || currentch == 5 || currentch == 12 || currentch == 15 || currentch == 18)
            {
                random = lastshape - 1;
            }
            else
            {
                same = 0;
            }
        }


        //print("scale " + ScreenScale.x + " " + ScreenScale.y);

        ShapeActive();

        int dir = 0;
        if (random == 0)
        {
            shape = sn1;
            //pattern.sprite = newa;
            dir = 1;
            lastshape = 1;
        }
        else if (random == 1)
        {
            shape = sn2;
            //pattern.sprite = newb;
            dir = 0;
            lastshape = 2;
        }
        else if (random == 2)
        {
            shape = sn3;
            //pattern.sprite = newc;
            dir = 0;
            lastshape = 3;
        }
        else if (random == 3)
        {
            shape = sn4;
            //pattern.sprite = newc2;
            dir = 2;
            lastshape = 4;
        }
        else if (random == 4)
        {
            shape = sn5;
            //pattern.sprite = newc3;
            dir = 0;
            lastshape = 5;
        }
        else if (random == 5)
        {
            shape = sn6;
            //pattern.sprite = newc3;
            dir = 0;
            lastshape = 6;
        }
        else if (random == 6)
        {
            shape = sn7;
            //pattern.sprite = newc3;
            dir = 0;
            lastshape = 7;
        }
        else if (random == 7)
        {
            shape = sn8;
            //pattern.sprite = newc3;
            dir = 1;
            lastshape = 8;
        }
        else if (random == 8)
        {
            shape = sn9;
            //pattern.sprite = newc3;
            dir = 0;
            lastshape = 9;
        }


        ShapeUnActive();

        //Destroy(shape.GetComponent<PolygonCollider2D>());
        //shape.AddComponent<SpriteRenderer>();
        //SpriteRenderer pattern = (SpriteRenderer)shape.GetComponent<SpriteRenderer>();
        shape.SetActive(true);
        shape.transform.localScale = new Vector3(1, 1, 1);

        shape.GetComponent<PolygonCollider2D>().enabled = false;
        shape.GetComponent<PolygonCollider2D>().enabled = true;
        pencil2.GetComponent<Animator>().Play(0, -1, 0);


        //clone = Instantiate(shape, new Vector3(241.4f, -64.60001f, -82.4f), Quaternion.identity);
        //clone.GetComponent<SpriteRenderer>().color = new Color(clone.GetComponent<SpriteRenderer>().color.r, clone.GetComponent<SpriteRenderer>().color.g, clone.GetComponent<SpriteRenderer>().color.b, 1);

        //shape.AddComponent<RectTransform>();
        //shape.transform.localScale = new Vector3(1, 1, 1);
        //Destroy(shape.GetComponent<PolygonCollider2D>());
        //shape.AddComponent<PolygonCollider2D>();
        nshape = 1;
        pen.transform.localScale = new Vector3(50, 50, 50);
        //print("dir " + dir);

        int checkw = 0;
        if (dir == 0)
        {
            pen.transform.localPosition = new Vector3((shape.transform.localPosition.x - shape.GetComponent<RectTransform>().sizeDelta.x / 2.3f) * ScreenScale.x, (shape.transform.localPosition.y + shape.GetComponent<RectTransform>().sizeDelta.y / 2.3f) * ScreenScale.y, pen.transform.localPosition.z);
            end.transform.localPosition = new Vector3((shape.transform.localPosition.x + shape.GetComponent<RectTransform>().sizeDelta.x / 2.2f) * ScreenScale.x, (shape.transform.localPosition.y - shape.GetComponent<RectTransform>().sizeDelta.y / 2.1f) * ScreenScale.y, pen.transform.localPosition.z);
        }
        else if (dir == 1)
        {
            pen.transform.localPosition = new Vector3((shape.transform.localPosition.x - shape.GetComponent<RectTransform>().sizeDelta.x / 2.2f) * ScreenScale.x, (shape.transform.localPosition.y - shape.GetComponent<RectTransform>().sizeDelta.y / 2.3f) * ScreenScale.y, pen.transform.localPosition.z);
            end.transform.localPosition = new Vector3((shape.transform.localPosition.x + shape.GetComponent<RectTransform>().sizeDelta.x / 2.2f) * ScreenScale.x, (shape.transform.localPosition.y - shape.GetComponent<RectTransform>().sizeDelta.y / 2.3f) * ScreenScale.y, pen.transform.localPosition.z);
        }
        else if (dir == 2)
        {
            pen.transform.localPosition = new Vector3((shape.transform.localPosition.x + shape.GetComponent<RectTransform>().sizeDelta.x / 2.2f) * ScreenScale.x, (shape.transform.localPosition.y + shape.GetComponent<RectTransform>().sizeDelta.y / 2.3f) * ScreenScale.y, pen.transform.localPosition.z);
            end.transform.localPosition = new Vector3((shape.transform.localPosition.x + shape.GetComponent<RectTransform>().sizeDelta.x / 2.2f) * ScreenScale.x, (shape.transform.localPosition.y - shape.GetComponent<RectTransform>().sizeDelta.y / 2.1f) * ScreenScale.y, pen.transform.localPosition.z);
        }
        else if (dir == 3)
        {
            pen.transform.localPosition = new Vector3((shape.transform.localPosition.x + shape.GetComponent<RectTransform>().sizeDelta.x / 2.2f) * ScreenScale.x, (shape.transform.localPosition.y - shape.GetComponent<RectTransform>().sizeDelta.y / 2.1f) * ScreenScale.y, pen.transform.localPosition.z);
            end.transform.localPosition = new Vector3((shape.transform.localPosition.x - shape.GetComponent<RectTransform>().sizeDelta.x / 2.3f) * ScreenScale.x, (shape.transform.localPosition.y + shape.GetComponent<RectTransform>().sizeDelta.y / 2.3f) * ScreenScale.y, pen.transform.localPosition.z);
        }
        if (dir < 2)
        {
            for (float i = 0.2f; i < shape.GetComponent<RectTransform>().sizeDelta.x * ScreenScale.x; i += 0.2f)
            {
                if (checkw == 0)
                {
                    if (dir == 0)
                    {
                        RaycastHit2D hit = Physics2D.Raycast(new Vector3((shape.transform.localPosition.x - shape.GetComponent<RectTransform>().sizeDelta.x / 2) * ScreenScale.x + i, (shape.transform.localPosition.y + shape.GetComponent<RectTransform>().sizeDelta.y / 2.1f) * ScreenScale.y, shape.transform.localPosition.z), Vector2.zero);
                        //print("try " + +i);
                        if (hit)
                        {
                            checkw = 1;
                            pen.transform.localPosition = new Vector3((shape.transform.localPosition.x - shape.GetComponent<RectTransform>().sizeDelta.x / 2) * ScreenScale.x + i, (shape.transform.localPosition.y + shape.GetComponent<RectTransform>().sizeDelta.y / 2.1f) * ScreenScale.y, pen.transform.localPosition.z);

                            print("ok");
                        }
                    }
                    else if (dir == 1)
                    {
                        RaycastHit2D hit = Physics2D.Raycast(new Vector3((shape.transform.localPosition.x - shape.GetComponent<RectTransform>().sizeDelta.x / 2) * ScreenScale.x + i, (shape.transform.localPosition.y - shape.GetComponent<RectTransform>().sizeDelta.y / 2.2f) * ScreenScale.y, shape.transform.localPosition.z), Vector2.zero);
                        //print("try2 " + +i);
                        if (hit)
                        {
                            checkw = 1;
                            pen.transform.localPosition = new Vector3((shape.transform.localPosition.x - shape.GetComponent<RectTransform>().sizeDelta.x / 2) * ScreenScale.x + i, (shape.transform.localPosition.y - shape.GetComponent<RectTransform>().sizeDelta.y / 2.2f) * ScreenScale.y, pen.transform.localPosition.z);

                            print("ok2");
                        }
                    }

                }
            }
        }
        else
        {
            for (float i = shape.GetComponent<RectTransform>().sizeDelta.x * ScreenScale.x; i > 0.2f; i -= 0.2f)
            {
                if (checkw == 0)
                {
                    if (dir == 2)
                    {
                        RaycastHit2D hit = Physics2D.Raycast(new Vector3((shape.transform.position.x + shape.GetComponent<RectTransform>().sizeDelta.x / 2) * ScreenScale.x - i, (shape.transform.position.y + shape.GetComponent<RectTransform>().sizeDelta.y / 2.1f) * ScreenScale.y, shape.transform.position.z), Vector2.zero);
                        //print("try3 " + +i);
                        if (hit)
                        {
                            checkw = 1;
                            pen.transform.position = new Vector3((shape.transform.position.x + shape.GetComponent<RectTransform>().sizeDelta.x / 2) * ScreenScale.x - i, (shape.transform.position.y + shape.GetComponent<RectTransform>().sizeDelta.y / 2.1f) * ScreenScale.y, pen.transform.position.z);

                            print("ok3");
                        }
                    }
                    else if (dir == 3)
                    {
                        RaycastHit2D hit = Physics2D.Raycast(new Vector3((shape.transform.position.x + shape.GetComponent<RectTransform>().sizeDelta.x / 2) * ScreenScale.x - i, (shape.transform.position.y - shape.GetComponent<RectTransform>().sizeDelta.y / 2.2f) * ScreenScale.y, shape.transform.position.z), Vector2.zero);
                        //print("try4 " + +i);
                        if (hit)
                        {
                            checkw = 1;
                            pen.transform.position = new Vector3((shape.transform.position.x + shape.GetComponent<RectTransform>().sizeDelta.x / 2) * ScreenScale.x - i, (shape.transform.position.y - shape.GetComponent<RectTransform>().sizeDelta.y / 2.2f) * ScreenScale.y, pen.transform.position.z);

                            print("ok4");
                        }
                    }

                }
            }
        }

        penloc = GameObject.Find("penloc");
        pen.transform.position = new Vector3(penloc.transform.position.x, penloc.transform.position.y, pen.transform.position.z);

        penloc2 = GameObject.Find("penloc2");
        penloc2.transform.GetComponent<BoxCollider>().enabled = false;
        penloc2.transform.GetComponent<BoxCollider>().enabled = true;

        MouseDrag script = (MouseDrag)pen.GetComponent(typeof(MouseDrag));
        script.drag = 1;

        if (redraw == 0)
        {
            DrawLine script2 = (DrawLine)pen.GetComponent(typeof(DrawLine));
            script2.StartCoroutine(script2.Replay());
            redraw = 1;
        }

        if (currentch != 2 && currentch != 10 && currentch != 14)
        {
            time = 31;
        }
        else if (currentch == 2 && settime == 1)
        {
            time = 41;
        }
        else if (currentch == 10 && settime == 1)
        {
            time = 501;
        }
        else if (currentch == 14 && settime == 1)
        {
            time = 801;
        }

        settime = 0;
        gameover = 0;
    }

    void ShapeActive()
    {
        sn1.SetActive(true);
        sn2.SetActive(true);
        sn3.SetActive(true);
        sn4.SetActive(true);
        sn5.SetActive(true);
        sn6.SetActive(true);
        sn7.SetActive(true);
        sn8.SetActive(true);
        sn9.SetActive(true);
    }

    void ShapeUnActive()
    {
        if (sn1 != shape)
        {
            sn1.SetActive(false);
        }
        if (sn2 != shape)
        {
            sn2.SetActive(false);
        }
        if (sn3 != shape)
        {
            sn3.SetActive(false);
        }
        if (sn4 != shape)
        {
            sn4.SetActive(false);
        }
        if (sn5 != shape)
        {
            sn5.SetActive(false);
        }
        if (sn6 != shape)
        {
            sn6.SetActive(false);
        }
        if (sn7 != shape)
        {
            sn7.SetActive(false);
        }
        if (sn8 != shape)
        {
            sn8.SetActive(false);
        }
        if (sn9 != shape)
        {
            sn9.SetActive(false);
        }
    }

    void SetScore(int sc)
    {
        oscore.GetComponent<Text>().text = sc + "";
        int best = PlayerPrefs.GetInt("best");
        if (sc > best)
        {
            best = sc;
            hscore.GetComponent<Text>().text = best + "";
            PlayerPrefs.SetInt("best", best);
        }
    }

    public void Play()
    {
        cover.GetComponent<Animator>().SetBool("replay", true);
        cover.GetComponent<Animator>().SetFloat("Direction", 1);
        cover.GetComponent<Animator>().Play(0, -1, 0);
        //print("play");
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

    string GetTime(int sec)
    {
        if (sec < 60)
        {
            if (sec < 10)
            {
                return "00:0" + sec;
            }
            else
            {
                return "00:" + sec;
            }
        }
        else if (sec > 60)
        {
            int hm = sec / 60;
            return "0" + hm + ":" + (int)(sec - 60 * hm);
        }
        return "00:" + sec;
    }

    void Aspect()
    {
        // set the desired aspect ratio (the values in this example are
        // hard-coded for 16:9, but you could make them into public
        // variables instead so you can set them at design time)
        float targetaspect = 16.0f / 9.0f;

        // determine the game window's current aspect ratio
        float windowaspect = (float)Screen.width / (float)Screen.height;

        // current viewport height should be scaled by this amount
        float scaleheight = windowaspect / targetaspect;

        // obtain camera component so we can modify its viewport
        Camera camera = maincamera.GetComponent<Camera>();

        // if scaled height is less than current height, add letterbox
        if (scaleheight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            camera.rect = rect;
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }

    public static bool TouchRelease()
    {
        bool b = false;
        for (int i = 0; i < Input.touches.Length; i++)
        {
            b = Input.touches[i].phase == TouchPhase.Ended;
            if (b)
                break;
        }
        if(Input.GetMouseButtonUp(0))
        {
            b = true;
        }
        return b;
    }

    CanvasScaler canvasScaler;
    Vector2 ScreenScale
    {
        get
        {
            if (canvasScaler == null)
            {
                canvasScaler = GetComponentInParent<CanvasScaler>();
            }

            if (canvasScaler)
            {
                return new Vector2(canvasScaler.referenceResolution.x / Screen.width, canvasScaler.referenceResolution.y / Screen.height);
            }
            else
            {
                return Vector2.one;
            }
        }
    }

    public static string colorToHex(Color32 color)
    {
        string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
        return hex;
    }

}