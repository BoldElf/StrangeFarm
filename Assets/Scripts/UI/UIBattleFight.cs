using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIBattleFight : MonoBehaviour
{
    //public event UnityAction Stone;
    //public event UnityAction Knight;
    //public event UnityAction Dodge;
    [SerializeField] private GameObject SelectionPanelBattle;
    [SerializeField] private GameObject StartBattlePanel; //
    [SerializeField] private GameObject PlayerDamage; //
    [SerializeField] private GameObject PlayerHit;//
    [SerializeField] private GameObject endPanel;//

    [SerializeField] private Enemy enemy;

    [SerializeField] private float timeToDisappearance;

    private void Start()
    {
        enemy.ActivePanel += SetActiveBattlePanel;
        enemy.BattlePanel += SetActiveBattlePanel_01;
        enemy.EnemyLose += SetActiveEnemyLose;
        enemy.EndPanel += SetActiveEndPanel;
        enemy.PlayerHit += SetPlayerHit;
    }

    private void OnDestroy()
    {
        enemy.ActivePanel -= SetActiveBattlePanel;
        enemy.BattlePanel -= SetActiveBattlePanel_01;
        enemy.EnemyLose -=SetActiveEnemyLose;
        enemy.EndPanel -= SetActiveEndPanel;
        enemy.PlayerHit -= SetPlayerHit;
    }


    private float timer = 0;

    private void Update()
    {
        if (enemy.gameObject.activeSelf == false && endPanel.activeSelf == true)
        {
            timer += Time.deltaTime;

            if (timer >= timeToDisappearance)
            {
                endPanel.SetActive(false);
            }
        }
    }


    private void SetPlayerHit(bool value)
    {
        PlayerHit.SetActive(value);
    }

    private void SetActiveEndPanel(bool value)
    {
        endPanel.SetActive(value);
    }

    private void SetActiveEnemyLose(bool value)
    {
        PlayerDamage.SetActive(value);
    }

    private void SetActiveBattlePanel_01(bool value)
    {
        StartBattlePanel.SetActive(value);
    }

    private void SetActiveBattlePanel(bool value)
    {
        SelectionPanelBattle.SetActive(value);
    }

    public void ButtonStone()
    {
        enemy.StoneInvoke();
    }
    public void ButtonKnight()
    {
        enemy.KnightInvoke();
    }
    public void ButtonDodge()
    {
        enemy.DodgeInvoke();
    }
}
