using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    // Inisialisasi Objek
    public GameObject menuAwal, menuKD, menuMateri, materi, skor, menuSetting, petunjuk, inputNama;

    //SCore Board
    public GameObject scoreTemplate, contentScore;

    //Input Nama
    public InputField namaInput;

    public Text onOffText;

    public GameObject bgm;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
        inputNama.SetActive(true);
        menuAwal.SetActive(false);
        menuKD.SetActive(false);
        menuMateri.SetActive(false);
        materi.SetActive(false);
        menuSetting.SetActive(false);
        petunjuk.SetActive(false);
        skor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backToMenu()
    {
        menuAwal.SetActive(true);
        menuKD.SetActive(false);
        menuMateri.SetActive(false);
        materi.SetActive(false);
        menuSetting.SetActive(false);
        petunjuk.SetActive(false);
        skor.SetActive(false);
    }

    public void toKD()
    {
        menuAwal.SetActive(false);
        menuKD.SetActive(true);
        menuMateri.SetActive(false);
        materi.SetActive(false);
        menuSetting.SetActive(false);
        petunjuk.SetActive(false);
        skor.SetActive(false);
    }

    public void toMenuMateri()
    {
        menuAwal.SetActive(false);
        menuKD.SetActive(false);
        menuMateri.SetActive(true);
        materi.SetActive(false);
        menuSetting.SetActive(false);
        petunjuk.SetActive(false);
        skor.SetActive(false);
    }

    public void toMateri1()
    {
        menuAwal.SetActive(false);
        menuKD.SetActive(false);
        menuMateri.SetActive(false);
        skor.SetActive(false);
        menuSetting.SetActive(false);
        petunjuk.SetActive(false);
        materi.SetActive(true);
        materi.transform.GetChild(1).gameObject.SetActive(true);
        materi.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
        materi.transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(false);
        materi.transform.GetChild(2).gameObject.SetActive(false);
        materi.transform.GetChild(3).gameObject.SetActive(false);
        materi.transform.GetChild(4).gameObject.SetActive(false);
        materi.transform.GetChild(5).gameObject.SetActive(false);
    }

    public void toMateri2()
    {
        menuAwal.SetActive(false);
        menuKD.SetActive(false);
        menuMateri.SetActive(false);
        menuSetting.SetActive(false);
        petunjuk.SetActive(false);
        skor.SetActive(false);
        materi.SetActive(true);
        materi.transform.GetChild(1).gameObject.SetActive(false);
        materi.transform.GetChild(2).gameObject.SetActive(true);
        materi.transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(true);
        materi.transform.GetChild(2).transform.GetChild(1).gameObject.SetActive(false);
        materi.transform.GetChild(3).gameObject.SetActive(false);
        materi.transform.GetChild(4).gameObject.SetActive(false);
        materi.transform.GetChild(5).gameObject.SetActive(false);
    }

    public void toMateri3()
    {
        menuAwal.SetActive(false);
        menuKD.SetActive(false);
        menuMateri.SetActive(false);
        menuSetting.SetActive(false);
        petunjuk.SetActive(false);
        skor.SetActive(false);
        materi.SetActive(true);
        materi.transform.GetChild(1).gameObject.SetActive(false);
        materi.transform.GetChild(2).gameObject.SetActive(false);
        materi.transform.GetChild(3).gameObject.SetActive(true);
        materi.transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(true);
        materi.transform.GetChild(3).transform.GetChild(1).gameObject.SetActive(false);
        materi.transform.GetChild(4).gameObject.SetActive(false);
        materi.transform.GetChild(5).gameObject.SetActive(false);
    }

    public void toMateri4()
    {
        menuAwal.SetActive(false);
        menuKD.SetActive(false);
        menuMateri.SetActive(false);
        menuSetting.SetActive(false);
        petunjuk.SetActive(false);
        skor.SetActive(false);
        materi.SetActive(true);
        materi.transform.GetChild(1).gameObject.SetActive(false);
        materi.transform.GetChild(2).gameObject.SetActive(false);
        materi.transform.GetChild(3).gameObject.SetActive(false);
        materi.transform.GetChild(4).gameObject.SetActive(true);
        materi.transform.GetChild(4).transform.GetChild(0).gameObject.SetActive(true);
        materi.transform.GetChild(4).transform.GetChild(1).gameObject.SetActive(false);
        materi.transform.GetChild(5).gameObject.SetActive(false);
    }

    public void toMateri5()
    {
        menuAwal.SetActive(false);
        menuKD.SetActive(false);
        menuMateri.SetActive(false);
        menuSetting.SetActive(false);
        petunjuk.SetActive(false);
        skor.SetActive(false);
        materi.SetActive(true);
        materi.transform.GetChild(1).gameObject.SetActive(false);
        materi.transform.GetChild(2).gameObject.SetActive(false);
        materi.transform.GetChild(3).gameObject.SetActive(false);
        materi.transform.GetChild(4).gameObject.SetActive(false);
        materi.transform.GetChild(5).gameObject.SetActive(true);
        materi.transform.GetChild(5).transform.GetChild(0).gameObject.SetActive(true);
        materi.transform.GetChild(5).transform.GetChild(1).gameObject.SetActive(false);
    }

    public void toPart2M1()
    {
        materi.transform.GetChild(1).gameObject.SetActive(true);
        materi.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
        materi.transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(true);
    }

    public void toPart2M2()
    {
        materi.transform.GetChild(2).gameObject.SetActive(true);
        materi.transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(false);
        materi.transform.GetChild(2).transform.GetChild(1).gameObject.SetActive(true);
    }

    public void toPart2M3()
    {
        materi.transform.GetChild(3).gameObject.SetActive(true);
        materi.transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(false);
        materi.transform.GetChild(3).transform.GetChild(1).gameObject.SetActive(true);
    }

    public void toPart2M4()
    {
        materi.transform.GetChild(4).gameObject.SetActive(true);
        materi.transform.GetChild(4).transform.GetChild(0).gameObject.SetActive(false);
        materi.transform.GetChild(4).transform.GetChild(1).gameObject.SetActive(true);
    }

    public void toPart2M5()
    {
        materi.transform.GetChild(5).gameObject.SetActive(true);
        materi.transform.GetChild(5).transform.GetChild(0).gameObject.SetActive(false);
        materi.transform.GetChild(5).transform.GetChild(1).gameObject.SetActive(true);
    }

    public void toEvaluasi()
    {
        SceneManager.LoadScene("Evaluasi  (1)");
    }

    public void toScore()
    {
        this.ViewScore();
        menuAwal.SetActive(false);
        menuKD.SetActive(false);
        menuMateri.SetActive(false);
        menuSetting.SetActive(false);
        petunjuk.SetActive(false);
        materi.SetActive(false);
        skor.SetActive(true);
    }

    public void toSetting()
    {
        menuAwal.SetActive(false);
        menuKD.SetActive(false);
        menuMateri.SetActive(false);
        menuSetting.SetActive(true);
        petunjuk.SetActive(false);
        materi.SetActive(false);
        skor.SetActive(false);
    }

    public void toPetunjuk()
    {
        menuAwal.SetActive(false);
        menuKD.SetActive(false);
        menuMateri.SetActive(false);
        menuSetting.SetActive(false);
        petunjuk.SetActive(true);
        materi.SetActive(false);
        skor.SetActive(false);
    }

    public void closeApp()
    {
        Application.Quit();
    }

    public void SubmitNama()
    {
        inputNama.SetActive(false);
        menuAwal.SetActive(true);
        menuKD.SetActive(false);
        menuMateri.SetActive(false);
        materi.SetActive(false);
        menuSetting.SetActive(false);
        petunjuk.SetActive(false);
        skor.SetActive(false);
        Debug.Log(namaInput.text);
        PlayerPrefs.SetString("nama", namaInput.text);
    }

    private void ViewScore()
    {
        foreach (Transform child in contentScore.transform)
        {
            if (child.gameObject.name != "ScorTemplate")
                GameObject.Destroy(child.gameObject);
        }

        string conn = "URI=file:" + Application.dataPath + "/StreamingAssets/pancasila.db";
        IDbConnection dbconn = new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT * FROM tbl_user ORDER BY score DESC";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        int i = 0;
        while (reader.Read())
        {
            Debug.Log(i);
            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            int score = reader.GetInt32(2);
            int waktu = reader.GetInt32(3);
            Vector3 position = new Vector3(0, -75 * i, 0);
            GameObject tempScore = Instantiate(scoreTemplate, position, Quaternion.identity) as GameObject;
            tempScore.transform.GetChild(0).gameObject.GetComponent<Text>().text = (i + 1).ToString();
            tempScore.transform.GetChild(1).gameObject.GetComponent<Text>().text = name;
            tempScore.transform.GetChild(2).gameObject.GetComponent<Text>().text = score.ToString();
            tempScore.transform.SetParent(contentScore.transform, false);
            tempScore.name = i.ToString()+" ScoreTemplate";
            tempScore.SetActive(true);
            i++;
        }
        contentScore.GetComponent<RectTransform>().sizeDelta = new Vector2(contentScore.GetComponent<RectTransform>().sizeDelta.x, 75 * i + 10);

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }


    public void onOffMusic()
    {

        if (PlayerPrefs.GetString("BGM") == "ON" || PlayerPrefs.GetString("BGM") == "")
        {
            PlayerPrefs.SetString("BGM", "OFF");
            onOffText.text = "OFF";
            bgm.GetComponent<AudioSource>().Stop();
        }
        else
        {
            PlayerPrefs.SetString("BGM", "ON");
            onOffText.text = "ON";
            bgm.GetComponent<AudioSource>().Play();
        }
    }
}
