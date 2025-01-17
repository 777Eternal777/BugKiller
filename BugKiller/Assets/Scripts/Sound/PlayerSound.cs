using UnityEngine;
using System.Collections;

public class PlayerSound : MonoBehaviour
{
		public AudioSource audiosource;
		public AudioClip sound;
		private float walkAudioTimer = 0.0f;
		private	Player target;
		Animator anim;
		SoundManager sm;
		float hp;
		CharacterMovingScript cms;
		bool jumped;

		void Start ()
		{
				jumped = false;
				cms = GameObject.Find ("Character").GetComponent<CharacterMovingScript> ();
				target = Player.Instance;
				sm = GameObject.Find ("SoundManager").GetComponent<SoundManager> ();
				anim = gameObject.GetComponent<Animator> ();
				hp = target.Health;
		}
	
		void Update ()
		{
				try {
						if (anim.GetBool ("Run")) {
								jumped = false;
								if (walkAudioTimer > 0.3) {

										sound = SoundManager.GetPlayerFootstepSound ();
										audiosource.pitch = (1);
										audiosource.PlayOneShot (sound, 1);
										walkAudioTimer = 0;
								}
			
						}
						walkAudioTimer += Time.deltaTime;
		
						if (hp > target.Health) {
								sound = SoundManager.GetPlayerHitted ();
								audiosource.PlayOneShot (sound, 1);
								hp = target.Health;
						} else if (hp < target.Health) {
								hp = target.Health;
						}
				} catch {
				}
		}

		public void PlayPlayerJumpSound ()
		{
				if (!Gender.GetGender ())
						sound = SoundManager.GetPlayerJump ();
				else
						sound = SoundManager.GetGirlJump ();
				audiosource.PlayOneShot (sound, 2);
		}
}