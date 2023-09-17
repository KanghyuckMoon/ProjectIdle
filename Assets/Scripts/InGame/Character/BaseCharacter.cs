using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
				spriteRenderer.color = Color.gray;
				return true;
			}
			spriteRenderer.color = Color.white;
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
	[SerializeField] private RewardSO rewardSO;
	[SerializeField] private Animator animator;
	[SerializeField] private SpriteRenderer spriteRenderer;

	private CharacterData characterData;

	private CharacterStat characterStat;

	private BaseCharacter target;

	private float attackTimer = 0f;

	private bool isJoyStickMove;

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
		characterStat.Hp = characterStat.MaxHp;
		spriteRenderer.color = Color.white;
		gameObject.SetActive(true);
		UiUpdateAction?.Invoke();
	}

	public void Move()
	{
		if(isJoyStickMove)
		{
			return;
		}

		if(target == null || target.IsDead)
		{
			ReTarget();
			return;
		}

		Vector2 currentPosition = transform.position;
		Vector2 targetPosition = target.transform.position;

		float distance = Vector2.Distance(currentPosition, targetPosition);
		bool isAttack = distance <= characterStat.AtkRange;
		if (isAttack)
		{
			Debug.Log("공격");
			Attack();
		}
		else
		{
			//float step = characterStat.Dex * Time.deltaTime;
			//transform.position = Vector2.MoveTowards(currentPosition, targetPosition, step);
			Vector2 dir = (targetPosition - currentPosition).normalized;
			MoveDirection(dir);
		}

		animator.SetBool("isMove", !isAttack);
	}

	private void MoveDirection(Vector2 direction)
	{
		if(direction.x > 0)
		{
			spriteRenderer.flipX = false;
		}
		else
		{
			spriteRenderer.flipX = true;
		}

		float step = characterStat.Dex * Time.deltaTime;
		Vector2 movement = direction * step;
		transform.position += (Vector3)movement;
		//transform.Translate(direction * step);// = new Vector2(direction.x + transform.position.x, direction.y + transform.position.y) * step;// Vector2.MoveTowards(currentPosition, targetPosition, step);
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
			if(!isPlayer)
			{
				GameManager.Instance.PlayerMoney.EarnMoney(rewardSO.moneyType, Money.ReturnMoney(rewardSO.moneyIndex, rewardSO.money));
				GameManager.Instance.PlayerProfile.AddExp(rewardSO.exp);
				CharacterManager.Instance.CheckStageClear();
			}
			else
			{
				CharacterManager.Instance.CheckStageFailed();
			}
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
			if(enemy.IsDead)
			{
				continue;
			}
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

	public void JoyStickMove(Vector2 dir)
	{
		isJoyStickMove = true;
		MoveDirection(dir);
	}

	public void JoyStickMoveEnd()
	{
		isJoyStickMove = false;
	}
}
