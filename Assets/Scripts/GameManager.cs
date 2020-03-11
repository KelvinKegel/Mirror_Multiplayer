using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject m_Player;

    public List<Collectable> sceneCollectables = new List<Collectable>();
    public Transform collectablesParent;

    private Collectable[] collectables;
    private int collectedAmount = 0;

    private void Awake()
    {
        if(Instance == null && Instance != this)
        {
            Instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        collectables = new Collectable[collectablesParent.childCount];

        for (int i = 0; i < collectables.Length; i++)
        {
            collectables[i] = collectablesParent.GetChild(i).GetComponent<Collectable>();

            sceneCollectables.Add(collectables[i]);
        }
    }

    public void ObjectCollected()
    {
        collectedAmount++;

        Debug.Log("Objetos coletados: " + collectedAmount + "/" + collectables.Length);

        if(collectedAmount >= collectables.Length)
        {
            Debug.Log("Fim de jogo");
        }
    }
}
