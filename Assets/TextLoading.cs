using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLoading : MonoBehaviour {
    [SerializeField]
    private Text dataText;
    private int type;
    [SerializeField]
    public string[] textMessage; //テキストの加工前の一行を入れる用
    public string[,] textWords; //テキストの複数列を入れる用 

    private int rowLength; //テキスト内の行数を取得用
    private int columnLength; //テキスト内の列数を取得用
    private int counter=0;
    public GameObject sky;
    public GameObject stone;

    private void Start()
    {
        TextAsset textasset = new TextAsset(); //テキストファイルのデータを取得するインスタンス(ファイルの読み込み)
        textasset = Resources.Load("Test", typeof(TextAsset)) as TextAsset; //Resourcesフォルダから対象テキストを取得
        string TextLines = textasset.text; //テキスト全体をstring型で入れる変数を用意して入れる(string型に変換後)

        //Splitで一行づつを代入した1次配列を作成
        textMessage = TextLines.Split('\n'); //

        //行数と列数を取得
        rowLength = textMessage.Length;
        columnLength = textMessage[0].Split('\t').Length;
        

        //配列を定義
        textWords = new string[rowLength, columnLength];

        for (int i = 0; i < rowLength; i++)
        {

            string[] tmpWords = textMessage[i].Split('\t'); //textMessageをカンマごとに分けたものを一時的にtmpWordsに代入

            for (int n = 0; n < columnLength; n++)
            {
                textWords[i, n] = tmpWords[n]; //2次配列textWordsにカンマごとに分けたtmpWordsを代入していく
                Debug.Log(textWords[i, n]);
            }
        }
        dataText.text = "右クリックで次";
    }
    private void Update()
    {
        loadText();

    }

    public void loadText()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (counter < rowLength)
            {

                if (transform.tag == "Name")
                {
                    type = 0;
                }
                else if (transform.tag == "talk")
                {
                    type = 1;
                }
                else if(transform.tag == "system")
                {
                    type = 3;
                }
                if (type <= 2)
                {
                    dataText.text = textWords[counter, type];
                }
                else if (type == 3)
                {
                    Instantiate(/*textWords[counter, type]*/sky, transform.position, Quaternion.identity);
                }
                counter++;
            }
            else
            {
                dataText.text = "本文終わり";
            }
        }
    }

}
