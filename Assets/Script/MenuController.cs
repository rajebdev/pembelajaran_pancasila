using Mono.Data.Sqlite;
using System.Data;
using System.IO;
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
        //SiapinDatabase("pancasila.db");
        PlayerPrefs.SetString("dbku", "URI=file:" + Application.dataPath + "/StreamingAssets/pancasila.db");
        Debug.Log(PlayerPrefs.GetString("dbku"));
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

    private void SiapinDatabase(string p)
    {
        Debug.Log("Call to OpenDB:" + p);
        // check if file exists in Application.persistentDataPath
        string filepath = Application.persistentDataPath + "/" + p;
        if (!File.Exists(filepath))
        {
            Debug.LogWarning("File \"" + filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/" + p);
            // if it doesn't ->
            // open StreamingAssets directory and load the db -> 
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + p);
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);
        }
        string connection = "URI=file:" + filepath;
        Debug.Log("Stablishing connection to: " + connection);
        PlayerPrefs.SetString("dbku", connection);

        string conn = PlayerPrefs.GetString("dbku");
        IDbConnection dbconn = new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string crt_tbl = "DROP TABLE IF EXISTS tbl_pancasila_soal; CREATE TABLE tbl_pancasila_soal(id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, soal varchar(1000) NOT NULL, gambarQ varchar(255) NOT NULL, textA varchar(1000) NOT NULL, textB varchar(1000) NOT NULL, textC varchar(1000) NOT NULL, textD varchar(1000) NOT NULL, gambarA varchar(255) NOT NULL, gambarB varchar(255) NOT NULL, gambarC varchar(255) NOT NULL, gambarD varchar(255) NOT NULL, answer varchar(1) NOT NULL, idMateri INTEGER); DROP TABLE IF EXISTS tbl_user; CREATE TABLE tbl_user(id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, nama TEXT, score INTEGER, waktu INTEGER);";
        dbcmd.CommandText = crt_tbl;
        dbcmd.ExecuteNonQuery();

        string query = "INSERT INTO tbl_pancasila_soal(id, soal, gambarQ, textA, textB, textC, textD, gambarA, gambarB, gambarC, gambarD, answer, idMateri) VALUES(1, 'Di sekolah Andi memiliki banyak teman dari berbagai suku bangsa. Teman-teman Andi berasal dari suku Jawa, Sunda, Batak, Minang, dan Dayak. Dari banyaknya suku tersebut menjadikan Indonesia bersatu. Simbol pancasila yang tepat untuk kalimat yang digaris bawahi adalah...', 'q1', '', '', '', '', '2', '3', '1', '5', 'B', 3); INSERT INTO tbl_pancasila_soal(id, soal, gambarQ, textA, textB, textC, textD, gambarA, gambarB, gambarC, gambarD, answer, idMateri) VALUES(2, 'Pada tanggal 17 Agustus selalu diadakan lomba di setiap desa. Lomba yang sering diadakan adalah tarik tambang. Untuk memenangkan setiap kelompok harus saling bekerja sama, bersatu, dan kompak. Sila yang tepat untuk kalimat yang dicetak miring pada pancasila adalah...', 'q2', 'Sila ke-4', 'Sila ke-1', 'Sila ke-3', 'Sila ke-5', '', '', '', '', 'C', 3); INSERT INTO tbl_pancasila_soal(id, soal, gambarQ, textA, textB, textC, textD, gambarA, gambarB, gambarC, gambarD, answer, idMateri) VALUES(3, 'Arti lambang rantai pada simbol sila kedua Pancasila adalah...', '', 'Setiap manusia dengan satu sama lain memiliki kedudukan yang berbeda', 'Setiap manusia membutuhkan satu sama lain dan perlu bersatu', 'Setiap manusia tidak membutuhkan satu sama lain', 'Setiap manusia harus mengenal satu sama lain', '', '', '', '', 'B', 2); INSERT INTO tbl_pancasila_soal(id, soal, gambarQ, textA, textB, textC, textD, gambarA, gambarB, gambarC, gambarD, answer, idMateri) VALUES(4, 'Contoh sikap berikut yang sesuai dengan Pancasila sila kedua adalah...', '', 'Tidak memilih-milih teman', 'Rajin beribadah sesuai ajarannya', 'Memecahkan masalah dengan musyawarah', 'Suka menabung dan tidak menghamburkan uang', '', '', '', '', 'A', 2); INSERT INTO tbl_pancasila_soal(id, soal, gambarQ, textA, textB, textC, textD, gambarA, gambarB, gambarC, gambarD, answer, idMateri) VALUES(5, 'a. Menghormati hak orang lain denan bersikap tertib saat belajar di kelas.\r\nb. Suka menjahili teman saat pelajaran.\r\nc. Ikut serta dalam kegiatan gotong royong di lingkungan rumah.\r\nd. memanggil dengan sebutan �HITAM� pada teman sekelas.\r\nManakah contoh perilaku yang menunjukkan sila ke 5?', '', 'a dan b', 'b dan d', 'c dan d', 'a dan c', '', '', '', '', 'D', 5); INSERT INTO tbl_pancasila_soal(id, soal, gambarQ, textA, textB, textC, textD, gambarA, gambarB, gambarC, gambarD, answer, idMateri) VALUES(6, 'Makna dari sila ke 5 adalah...', '', 'Membeda-bedakan suku dan agama', 'Warga harus diperlakukan secara adil', 'Tidak melakukan gotong royong di lingkungan rumah', 'Mengejek teman yang berbeda dari kita ', '', '', '', '', 'B', 5); INSERT INTO tbl_pancasila_soal(id, soal, gambarQ, textA, textB, textC, textD, gambarA, gambarB, gambarC, gambarD, answer, idMateri) VALUES(7, 'Sila ke 4 pancasila berbunyi...', '', 'Ketuhanan Yang Maha Esa ', 'Kerakyatan yang dipimpin oleh hikmat kebijaksanaan dalam permusyawaratan perwakilan. ', 'Persatuan indonesia ', 'Keadilan sosial bagi seluruh rakyat indonesia ', '', '', '', '', 'B', 4); INSERT INTO tbl_pancasila_soal(id, soal, gambarQ, textA, textB, textC, textD, gambarA, gambarB, gambarC, gambarD, answer, idMateri) VALUES(8, 'Persatuan indonesia adalah bunyi teks pancasila yaitu...', '', 'Sila Kesatu', 'Sila Keempat', 'Sila Kedua', 'Sila Ketiga', '', '', '', '', 'D', 3); INSERT INTO tbl_user (id, nama, score, waktu) VALUES (1, 'Wijanarko', 100, 100); INSERT INTO tbl_user(id, nama, score, waktu) VALUES(2, 'Rajeb', 90, 85); INSERT INTO tbl_user(id, nama, score, waktu) VALUES(3, 'Narko', 10, 100); ";
        dbcmd.CommandText = query;
        dbcmd.ExecuteNonQuery();
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

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

        //string conn = "URI=file:" + Application.dataPath + "/StreamingAssets/pancasila.db";
        string conn = PlayerPrefs.GetString("dbku");
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
            bgm.GetComponent<AudioSource>().Pause();
        }
        else
        {
            PlayerPrefs.SetString("BGM", "ON");
            onOffText.text = "ON";
            bgm.GetComponent<AudioSource>().Play();
        }
    }
}
