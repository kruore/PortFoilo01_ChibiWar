using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_SkillPool : MonoBehaviour
{
    //Skill pool singleton
    public static U_SkillPool instance;

    [SerializeField]
    private GameObject m_skillObjectPrefab;

    Queue<Skill> poolingObjectQueue = new Queue<Skill>();

    private void Awake()
    {
        instance = this;
    }
    public void Initialize(int initCount, Skill skill)
    {
        for (int i = 0; i < initCount; i++)
        {
            poolingObjectQueue.Enqueue(CreateSkillObject(skill));
        }
    }
    private Skill CreateSkillObject(Skill skill)
    {
        var newObj = Instantiate(skill);
        m_skillObjectPrefab = newObj.gameObject;
        newObj.skillEffect = newObj.gameObject;
        newObj.gameObject.name = m_skillObjectPrefab.GetComponent<Skill>().name;
        newObj.gameObject.SetActive(false);
        newObj.gameObject.transform.SetParent(this.gameObject.transform, false);
        return newObj.GetComponent<PS_FireBall>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public static Skill GetObject(Skill skill)
    {
        if (instance.poolingObjectQueue.Count > 0)
        {
            var obj = instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = instance.CreateSkillObject(skill);
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }

    public static void ReturnObject(Skill obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(instance.transform);
        instance.poolingObjectQueue.Enqueue(obj);
    }
}
