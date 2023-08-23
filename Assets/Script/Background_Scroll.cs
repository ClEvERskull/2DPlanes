using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Scroll : MonoBehaviour {
    public float speed;
	void Update () {
        MeshRenderer rndr = GetComponent<MeshRenderer>();
        Material mat = rndr.material;
        Vector2 offset = mat.mainTextureOffset;
        offset.x += Time.deltaTime / speed;
        mat.mainTextureOffset = offset;
    }
}
