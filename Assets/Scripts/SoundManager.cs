using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	[Header("�ɯ�")]
	public AudioClip soundLvUp;
	[Header("�ɯŧޯ�")]
	public AudioClip soundSkillLvUp;
	[Header("���a����")]
	public AudioClip soundPlayerHurt;
	[Header("���a���`")]
	public AudioClip soundPlayDead;
	[Header("�Ǫ�����")]
	public AudioClip soundEnemyHurt;
	[Header("�Ǫ����`")]
	public AudioClip soundEnemyDead;
	[Header("�o�g�Z��")]
	public AudioClip soundFireWeapon;
}
    private AudioSource aud;
    private void Awake()
{
	aud = GetComponent<AudioSource>()

	}