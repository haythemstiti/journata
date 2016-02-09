using UnityEngine;
using System.Collections;

public class AnimateMouth : MonoBehaviour {

    public Sprite[] sprites;
	public Sprite[] spritesBusted;
    private SpriteRenderer renderer;
	bool inOuch = false;
    int index = 0;
	int indexHit = 0;
	// Use this for initialization
	void Start () {
        renderer = GetComponent<SpriteRenderer>();
        float wait = Random.Range(0f, 2f);
        InvokeRepeating("Animate",wait, 0.15f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Animate()
    {
		if (inOuch == false) {
			renderer.sprite = sprites[index % 3];
			index++;
		}
        
    }
	public void invokeAnimateHit()
	{
		
			Invoke("AnimateHit1",0f);	


	}
	public void AnimateHit1()
	{
		
		renderer.sprite = sprites[0];
		indexHit++;
		Invoke("AnimateHit2",0.2f);	

	}

	public void AnimateHit2()
	{

		renderer.sprite = sprites[1];
		indexHit++;
		Invoke("AnimateHit3",0.2f);	
	}

	public void AnimateHit3()
	{

		renderer.sprite = sprites[2];
		indexHit++;

	}
}
