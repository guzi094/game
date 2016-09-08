using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour {

    public float speed = 0.1f;
	
	// Update is called once per frame
	void Update () {
        float y = Mathf.Repeat(Time.time * speed, 1);

        Vector2 offset = new Vector2(0, y);

        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
	}
}
