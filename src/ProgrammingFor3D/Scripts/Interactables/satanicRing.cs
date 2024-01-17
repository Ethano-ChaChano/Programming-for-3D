using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class satanicRing : MonoBehaviour
{
    public List<string> collectedTags = new List<string>();
    public Transform[] itemPoints;
    public GameObject puzzleBox;

    public string tag1;
    public string tag2;
    public string tag3;
    public string tag4;
    public string tag5;

    bool collectedAll;

    private void Update()
    {
        if (collectedAll) { activeSummon(); }
    }

    private void OnTriggerEnter(Collider other)
    {        
        if ((other.CompareTag(tag1) || other.CompareTag(tag2) || other.CompareTag(tag3) || other.CompareTag(tag4) || other.CompareTag(tag5)) 
            && other.gameObject.layer == 10)
        {
            if (!collectedTags.Contains(other.tag)) 
            { 
                collectedTags.Add(other.tag);

                foreach (Transform point in itemPoints)
                {
                    if (point.childCount <= 0)
                    {
                        other.transform.GetComponent<Rigidbody>().isKinematic = true;
                        other.transform.SetParent(point);
                        other.transform.position = point.position;
                        other.transform.rotation = point.rotation;
                        other.gameObject.layer = 0;
                        break;
                    }
                }
            }

            if (collectedTags.Count >= 5)
            {
                collectedAll = true;
            }
        }
    }

    void activeSummon() {
        transform.Rotate(Vector3.up, 0.2f);
        foreach (Transform point in itemPoints) { point.Rotate(new Vector3(45, 45, 45), 5); }
                
        puzzleBox.SetActive(true);
    }
}
