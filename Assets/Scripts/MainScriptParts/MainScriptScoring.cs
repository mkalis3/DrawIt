using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public partial class MainScript2
{
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
}
