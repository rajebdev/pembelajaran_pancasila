using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    // Inisialisasi
    public GameObject remidiButton, finishButton;

    public Text namaText, scoreText;

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        remidiButton.SetActive(false);
        finishButton.SetActive(false);
        string conn = "URI=file:" + Application.dataPath + "/StreamingAssets/pancasila.db";
        IDbConnection dbconn = new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();

        for (int i = 1; i <= 5; i++)
        {
            string answer = PlayerPrefs.GetString("Ans" + i.ToString());
            string idSoal = PlayerPrefs.GetString("Question" + i.ToString());
            string kunci = "E";

            string sqlQuery = "SELECT answer FROM tbl_pancasila_soal WHERE id=" + idSoal.ToString();
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                kunci = reader[0].ToString();
            }
            reader.Close();
            reader = null;
            if (answer == kunci)
                score += 20;
            else
                PlayerPrefs.SetString("Remidi", PlayerPrefs.GetString("Remidi")+idSoal.ToString());
        }

        namaText.text = PlayerPrefs.GetString("nama");
        scoreText.text = score.ToString();

        if (score < 80)
            remidiButton.SetActive(true);
        else
            finishButton.SetActive(true);
        PlayerPrefs.SetInt("score", score);
        string sqlQuery2 = "INSERT INTO tbl_user VALUES (null, '" + PlayerPrefs.GetString("nama") + "', " + score.ToString() + ", 100)";
        dbcmd.CommandText = sqlQuery2;
        dbcmd.ExecuteNonQuery();

        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

        // Update is called once per frame
        void Update()
    {
        
    }

    public void ToRemidi()
    {
        PlayerPrefs.SetInt("part1", 1);
        SceneManager.LoadScene("Remidi (1)");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Begin");
    }
}
