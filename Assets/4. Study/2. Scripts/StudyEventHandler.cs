using System;
using UnityEngine;

public class StudyEventHandler : MonoBehaviour
{
    public class CharacterData : EventArgs
    {
        public string name;
        public int level;
        public float hp;
        public float mp;
        public float damage;

        public CharacterData(string name,int level, float hp, float mp, float damage)
        {
            this.name = name;
            this.level = level;
            this.hp = hp;
            this.mp = mp;
            this.damage = damage;
        }
    }

    private event EventHandler handler;

    private void Start()
    {
        handler += createCharacter;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CharacterData data = new CharacterData("A", 1, 2, 3, 4);
            handler?.Invoke(this, data);
        }
    }

    private void createCharacter(object o, EventArgs e)
    {
        //GameObject character = Instantiate(characterPrefab);

        var data = (CharacterData)e;//형변환

        Debug.Log($"{data.name} / {data.level}데이터를 가진 캐릭터 생성");
    }
}
