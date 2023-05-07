using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace RPG
{
	public class FloatingNumbers : MonoBehaviour
	{
		[SerializeField] Text text = null;

		[SerializeField] float speed = 3f;
		[SerializeField] float duration = 0.75f;

		void Start ()
		{
			var rb = gameObject.AddComponent<Rigidbody2D>();
			rb.gravityScale = 0;
			rb.velocity = new Vector2 (Random.Range(-0.25f, 0.25f), 1) * speed;
			Destroy(gameObject, duration);
		}

		public void SetText (string str, Color clr)
		{
			text.text = str;
			text.color = clr;
		}
	}
}
