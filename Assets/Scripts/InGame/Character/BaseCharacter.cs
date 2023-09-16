using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
	public bool IsDead
	{
		get
		{
			if(characterStat is null)
			{
				return true;
			}

			if(characterStat.Hp <= 0)
			{
				return true;
			}
			return false;
		}
	}
	public float HpAmount
	{
		get
		{
			return (float)characterStat.Hp / characterStat.MaxHp;
		}
	}

	public CharacterStat CharacterStat => characterStat;

	[Header("Player")]
	public bool isPlayer;
	[SerializeField] private int index;
	[Header("Enemy")]
	[SerializeField] private CharacterDataSO characterDataSO;
	[SerializeField] private Animator animator;
	[SerializeField] private SpriteRenderer spriteRenderer;

	private CharacterData characterData;

	private CharacterStat characterStat;

	private BaseCharacter target;

	private float attackTimer = 0f;

	public Action UiUpdateAction
	{
		get
		{
			return uiUpdateAction;
		}
		set
		{
			uiUpdateAction = value;
		}
	}
	private Action uiUpdateAction;

	public void Start()
	{
		if(isPlayer)
		{
			characterData = GameManager.Instance.PlayerCharacter.GetCharacterData(index);
		}
		else
		{
			characterData = CharacterDataSO.ChDataSOToChData(characterDataSO);
		}
		ResetStat();

		if(isPlayer)
		{
			CharacterManager.Instance.playerCharacters.Add(this);
		}
		else
		{
			CharacterManager.Instance.enemyCharacters.Add(this);
		}
		UiUpdateAction?.Invoke();
	}

	public void Update()
	{
		if(IsDead)
		{
			return;
		}
		Move();
	}

	public void ResetStat()
	{
		characterStat = CharacterStat.CharacterDataToChStat(characterData);
	}

	public void Move()
	{
		if(target == null || target.IsDead)
		{
			ReTarget();
		}

		Vector2 currentPosition = transform.position;
		Vector2 targetPosition = target.transform.position;

		if(targetPosition.x < currentPosition.x)
		{
			spriteRenderer.flipX = true;
		}
		else
		{
			spriteRenderer.flipX = false;
		}

		float distance = Vector2.Distance(currentPosition, targetPosition);
		bool isAttack = distance <= characterStat.AtkRange;
		if (isAttack)
		{
			Debug.Log("공격");
			Attack();
		}
		else
		{
			float step = characterStat.Dex * Time.deltaTime;
			transform.position = Vector2.MoveTowards(currentPosition, targetPosition, step);
		}

		animator.SetBool("isMove", !isAttack);
	}

	public void Attack()
	{
		attackTimer -= characterStat.Agi * Time.deltaTime;
		if (attackTimer <= 0f)
		{
			attackTimer = 1f;
			animator.SetTrigger("isAttack");
			target.Hit(characterStat.Atk);
		}
	}

	public void Hit(int damage)
	{
		characterStat.Hp -= damage;
		UiUpdateAction?.Invoke();

		if (IsDead)
		{
			gameObject.SetActive(false);
		}
	}

	public void ReTarget()
	{
		if(isPlayer)
		{
			target = FindClosest(CharacterManager.Instance.enemyCharacters);
		}
		else
		{
			target = FindClosest(CharacterManager.Instance.playerCharacters);
		}
	}

	private BaseCharacter FindClosest(List<BaseCharacter> list)
	{
		float closestDistance = Mathf.Infinity;
		Vector2 currentPosition = transform.position;
		BaseCharacter closestEnemy = null;

		foreach (BaseCharacter enemy in list)
		{
			float distance = Vector2.Distance(currentPosition, enemy.transform.position);
			if (distance < closestDistance)
			{
				closestDistance = distance;
				closestEnemy = enemy;
			}
		}

		if (closestEnemy != null)
		{
			Debug.Log("가장 가까운 적: " + closestEnemy.name);
		}
		return closestEnemy;
	}
}
