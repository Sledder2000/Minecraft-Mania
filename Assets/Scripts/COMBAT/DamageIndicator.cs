using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplayDamage(int damage, bool healing)
    {
        IEnumerator coroutine = DisplayDamageRoutine(damage, healing);
        StartCoroutine(coroutine);
    }
    private IEnumerator DisplayDamageRoutine(int damage, bool healing)
    {
        TMPro.TMP_Text damageText = gameObject.GetComponent<TMPro.TMP_Text>();
        if (healing) {
            damageText.color = new Color(0, 255, 0);
            damageText.text = "+" + damage;
        }
        else { damageText.text = "-" + damage; }

        Color c = damageText.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.05f)
        {
            c.a = alpha;
            damageText.color = c;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2, 0);
            yield return new WaitForSeconds(0.05f);
        }
        Destroy(gameObject);
    }
}
