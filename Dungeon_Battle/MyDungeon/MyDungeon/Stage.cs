﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyDungeon
{
    public class Stage
    {

        Player player1;
        Minion monster1;

        //stage를 만들어서  1스테이지는 
        // 

        public void Start(Player player)
        {
            player1 = player;
            player1.stat.Attack += 5; // 실제 스테이터스에도 반영되는 것을 확인
   
        }

        public void StageStart()
        {
            
            
        
        }




    }
}
