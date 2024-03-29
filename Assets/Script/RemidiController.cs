﻿using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RemidiController : MonoBehaviour
{
    public GameObject contentSoal, soalTemplate;
    private int secTime = 0;
    private readonly int jumlahSoal = 5;

    public GameObject[] materi;

    public Text timeText;

    private int idMateri;

    // Start is called before the first frame update
    void Start()
    {
        idMateri = int.Parse(PlayerPrefs.GetString("Materi"+ PlayerPrefs.GetString("Remidi").Substring(int.Parse(SceneManager.GetActiveScene().name.Substring(8, 1)) - 1, 1)))-1;
        StartCoroutine(TimeRun());
        generateSoal();
        contentSoal.SetActive(false);
        for (int i=0; i < 5; i++)
        {
            if (i == idMateri)
            {
                materi[i].SetActive(true);
                if (PlayerPrefs.GetInt("part1") == 1)
                {
                    materi[i].transform.GetChild(1).gameObject.SetActive(false);
                    materi[i].transform.GetChild(0).gameObject.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(delegate { toPart2(); });
                }
                else
                {
                    materi[i].transform.GetChild(0).gameObject.SetActive(false);
                    materi[i].transform.GetChild(1).gameObject.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(delegate { toPart1(); });
                    materi[i].transform.GetChild(1).gameObject.transform.GetChild(5).GetComponent<Button>().onClick.AddListener(delegate { toEvaluasi(); });
                }
            }
            else
                materi[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        string tempTime = string.Format("{0:00}:{1:00}", (int)(secTime / 60), (int)(secTime % 60));
        timeText.GetComponent<Text>().text = tempTime;
        if (secTime > 60 && contentSoal.activeSelf == true)
        {
            OnClickGotoNextQuestion(SceneManager.GetActiveScene().name.Substring(8, 1).ToString());
            PlayerPrefs.SetString("Ans" + SceneManager.GetActiveScene().name.Substring(8, 1), "E");
        }
    }

    private void generateSoal()
    {
        int idSoal = int.Parse(PlayerPrefs.GetString("Remidi").Substring(int.Parse(SceneManager.GetActiveScene().name.Substring(8, 1)) - 1, 1));
        PlayerPrefs.SetString("Question" + SceneManager.GetActiveScene().name.Substring(8, 1), idSoal.ToString());
        //string conn = "URI=file:" + Application.dataPath + "/StreamingAssets/pancasila.db";
        string conn = PlayerPrefs.GetString("dbku");
        IDbConnection dbconn = new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "SELECT * FROM tbl_pancasila_soal WHERE id=" + idSoal.ToString();
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            string id = reader[0].ToString();
            string q = reader[1].ToString();
            string gbrQ = reader[2].ToString();
            string textA = reader[3].ToString();
            string textB = reader[4].ToString();
            string textC = reader[5].ToString();
            string textD = reader[6].ToString();
            string gbrA = reader[7].ToString();
            string gbrB = reader[8].ToString();
            string gbrC = reader[9].ToString();
            string gbrD = reader[10].ToString();
            string answer = reader[11].ToString();
            string idMateri = reader[12].ToString();
            PlayerPrefs.SetString("Materi" + SceneManager.GetActiveScene().name.Substring(8, 1), idMateri.ToString());
            GameObject tempSoal = Instantiate(soalTemplate) as GameObject;
            tempSoal.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "SOAL " + idSoal.ToString();
            if ("XXX" + gbrQ + "XXX" == "XXXXXX")
                tempSoal.transform.GetChild(1).gameObject.SetActive(false);
            tempSoal.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>(gbrQ);
            tempSoal.transform.GetChild(2).GetComponent<Text>().text = q;
            tempSoal.transform.GetChild(3).GetComponent<Text>().text = q;
            //tempSoal.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(delegate { GotoNextQuestion(i + 1); });
            tempSoal.transform.GetChild(5).gameObject.GetComponent<Button>().onClick.AddListener(delegate { OnClickGotoNextQuestion((idSoal+1).ToString()); });
            if (idSoal < 1)
                tempSoal.transform.GetChild(4).gameObject.SetActive(false);
            else if (idSoal > 4)
                tempSoal.transform.GetChild(5).gameObject.SetActive(false);
            tempSoal.transform.GetChild(6).transform.GetChild(2).GetComponent<Text>().text = textA;
            tempSoal.transform.GetChild(7).transform.GetChild(2).GetComponent<Text>().text = textB;
            tempSoal.transform.GetChild(8).transform.GetChild(2).GetComponent<Text>().text = textC;
            tempSoal.transform.GetChild(9).transform.GetChild(2).GetComponent<Text>().text = textD;
            if ("XXX" + textA + "XXX" == "XXXXXX")
            {
                tempSoal.transform.GetChild(6).transform.GetChild(2).gameObject.SetActive(false);
            }
            if ("XXX" + textB + "XXX" == "XXXXXX")
            {
                tempSoal.transform.GetChild(7).transform.GetChild(2).gameObject.SetActive(false);
            }
            if ("XXX" + textC + "XXX" == "XXXXXX")
            {
                tempSoal.transform.GetChild(8).transform.GetChild(2).gameObject.SetActive(false);
            }
            if ("XXX" + textD + "XXX" == "XXXXXX")
            {
                tempSoal.transform.GetChild(9).transform.GetChild(2).gameObject.SetActive(false);
            }

            tempSoal.transform.GetChild(6).transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>(gbrA);
            tempSoal.transform.GetChild(7).transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>(gbrB);
            tempSoal.transform.GetChild(8).transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>(gbrC);
            tempSoal.transform.GetChild(9).transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>(gbrD);
            if ("XXX" + gbrA + "XXX" == "XXXXXX")
            {
                tempSoal.transform.GetChild(6).transform.GetChild(1).gameObject.SetActive(false);
            }
            if ("XXX" + gbrB + "XXX" == "XXXXXX")
            {
                tempSoal.transform.GetChild(7).transform.GetChild(1).gameObject.SetActive(false);
            }
            if ("XXX" + gbrC + "XXX" == "XXXXXX")
            {
                tempSoal.transform.GetChild(8).transform.GetChild(1).gameObject.SetActive(false);
            }
            if ("XXX" + gbrD + "XXX" == "XXXXXX")
            {
                tempSoal.transform.GetChild(9).transform.GetChild(1).gameObject.SetActive(false);
            }
            tempSoal.transform.GetChild(6).transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate { OnPilih("A", tempSoal, 6); });
            tempSoal.transform.GetChild(7).transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate { OnPilih("B", tempSoal, 7); });
            tempSoal.transform.GetChild(8).transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate { OnPilih("C", tempSoal, 8); });
            tempSoal.transform.GetChild(9).transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate { OnPilih("D", tempSoal, 9); });

            if (SceneManager.GetActiveScene().name.Substring(8, 1) == (PlayerPrefs.GetString("Remidi").Length).ToString())
            {
                tempSoal.transform.GetChild(10).gameObject.GetComponent<Button>().onClick.AddListener(delegate { OnClickGotoNextQuestion((idSoal + 1).ToString()); });
                tempSoal.transform.GetChild(10).gameObject.SetActive(true);
            }
            tempSoal.transform.SetParent(contentSoal.transform, false);
            tempSoal.gameObject.SetActive(true);
            tempSoal.gameObject.name = idSoal.ToString() + " Soal";
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    private void OnPilih(string huruf, GameObject tempSoal, int btn)
    {
        PlayerPrefs.SetString("Ans" + SceneManager.GetActiveScene().name.Substring(8, 1), huruf);
        for (int i = 6; i <= 9; i++)
        {
            tempSoal.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().color = Color.white;
        }
        tempSoal.transform.GetChild(btn).transform.GetChild(0).GetComponent<Image>().color = Color.green;

    }

    private void OnClickGotoNextQuestion(string noSoal)
    {
        PlayerPrefs.SetInt("part1", 1);
        if (noSoal == (PlayerPrefs.GetString("Remidi").Length + 1).ToString())
            SceneManager.LoadScene("ScoreAkhir");
        else
            SceneManager.LoadScene("Remidi (" + noSoal.ToString() + ")");
    }

    private int GetRandSoal()
    {
        int rand = UnityEngine.Random.Range(0, jumlahSoal);
        return rand;
    }

    private IEnumerator TimeRun()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            secTime++;
        }
    }

    private void toEvaluasi()
    {
        contentSoal.SetActive(true);
        secTime = 0;
    }

    private void toPart1()
    {
        PlayerPrefs.SetInt("part1", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void toPart2()
    {
        PlayerPrefs.SetInt("part1", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void ToMenu()
    {
        SceneManager.LoadScene("Begin");
    }
}
