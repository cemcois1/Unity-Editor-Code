using UnityEngine;

public class craftcode : MonoBehaviour
{
    [SerializeField] GameObject Myscene;
    [SerializeField] GameObject[] prefabs;
    public void CraftGameobject(string name)
    {
        foreach (GameObject gameObject in prefabs)
        {
            if (gameObject.name == name) Instantiate(gameObject, Myscene.transform);
        }
        
        
    }



}
