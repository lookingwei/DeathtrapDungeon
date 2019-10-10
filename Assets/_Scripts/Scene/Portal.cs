﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//场景切换脚本:
//
//产生问题：切换场景后bgm感觉音量变小，声调有所变化
//尝试解决1:把AudioListener挪到Player上
//结果1：还行，bgm播放较正常
public class Portal : Colliderable
{
    public string sceneName;   //所加载的场景
    private SceneTranslate SceneTranslate;  //场景切换脚本

    protected override void Start()
    {
        base.Start();
        SceneTranslate = GetComponentInChildren<SceneTranslate>();
        GetComponent<BoxCollider2D>().enabled = true;
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            //储存各类信息
            GameManager.instance.SaveState();

            //切换场景：旧方法直接切换
            //SceneManager.LoadScene(sceneName);

            //新场景切换：异步加载
            SceneTranslate.ChangeScene(sceneName);
            GetComponent<BoxCollider2D>().enabled = false;           
        }
    }
}

