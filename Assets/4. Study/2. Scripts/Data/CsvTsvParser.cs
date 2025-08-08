using System.Collections.Generic;
using UnityEngine;

public class CsvTsvParser : MonoBehaviour
{
    [System.Serializable]
    public class CharacterData
    {
        public string charID;
        public string name;
        public int hp;
        public int attack;


        public CharacterData(string charID, string name, int hp, int attack)
        {
            this.charID = charID;
            this.name = name;
            this.hp = hp;
            this.attack = attack;
        }
    }

    public List<CharacterData> characters = new List<CharacterData>();

    private void Start()
    {
        var dataFile = Resources.Load<TextAsset>("CsvData");
        string data = dataFile.text;

        ParsingCharacterData(data);
    }

    private void ParsingCharacterData(string Data)
    {
        Debug.Log(Data);
        string[] rows = Data.Split('\n'); // 줄 나눔
        for(int i = 1; i < rows.Length; i++)
        {
            string[] cols = rows[i].Split(','); // 콤마로 나눠서 col 나눔

            CharacterData characterData = new CharacterData(cols[0], cols[1], int.Parse(cols[2]), int.Parse(cols[3])); // string to int 

            characters.Add(characterData);
        }
    }
}
