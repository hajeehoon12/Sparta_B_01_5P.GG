using System;
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
        enum MonsterSpices { Minion, Worm, CanonMinion };   //몬스터 종류

        Player player1;
        List<Monster> monsterInStage;   //스테이지에 몬스터 4마리 출현할 리스트

        private int select; //선택지

        public bool stageSelect;
        

        public void Start(Player player)
        {
            player1 = player;   // 실제 스테이터스에도 반영되는 것을 확인

            monsterInStage = new List<Monster>(4);

            //스테이지 선택
            Console.WriteLine("스테이지를 선택하세요.");
            for (int i = 0; i < 3; i++)
                Console.WriteLine($"{i + 1} 스테이지");

            do
            {
                Console.Write(">> ");

                stageSelect = int.TryParse(Console.ReadLine(), out select);

                if (!stageSelect)
                {
                    Console.WriteLine("숫자를 입력해주세요.");
                }
            }
            while (!stageSelect);

            StageStart(select);
        }

        //stage를 만들어서
        // 1스테이지는 (미니온 3마리, 공허충 1마리)
        // 2스테이지는 (미니온 2마리, 공허충 1마리, 대포 1마리)
        // 3스테이지는 (미니온 1마리, 공허충 1마리, 대포 2마리)
        public void StageStart(int stage)
        {
            switch (stage)  //몬스터 리스트에 몬스터 추가
            {
                case 1: //스테이지 1
                    //몬스터 생성
                    monsterInStage.Add(new Minion("미니온"));
                    monsterInStage.Add(new Minion("미니온"));
                    monsterInStage.Add(new Minion("미니온"));
                    monsterInStage.Add(new Worm("공허충"));
                    break;
                case 2:
                    monsterInStage.Add(new Minion("미니온"));
                    monsterInStage.Add(new Minion("미니온"));
                    monsterInStage.Add(new Worm("공허충"));
                    monsterInStage.Add(new CannonMinion("대포 미니온"));
                    break;
                case 3:
                    monsterInStage.Add(new Minion("미니온"));
                    monsterInStage.Add(new Worm("공허충"));
                    monsterInStage.Add(new CannonMinion("대포 미니온"));
                    monsterInStage.Add(new CannonMinion("대포 미니온"));
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }

            Console.WriteLine("Battle!!");

            Console.WriteLine();
            foreach (Monster monster in monsterInStage)
            {
                monster.PrintMonster();
            }

            Console.WriteLine();
            Console.WriteLine("[내정보]");
            Console.WriteLine($"Lv.{player1.stat.Level} {player1.Name} ");
            Console.WriteLine($"HP {player1.stat.Hp}/100");

            Console.WriteLine("1.공격");

            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            Console.ReadLine();
        }

        void BattleResult() //전투 결과
        {
            Console.WriteLine("Battle - Result");

            if (player1.IsDead) //플레이어가 죽으면
            {
                //Lose
                Console.WriteLine();
                Console.WriteLine("You Lose");
            }
            else
            {
                //Victory
                Console.WriteLine();
                Console.WriteLine("Victory");

                Console.WriteLine();
                Console.WriteLine($"던전에서 몬스터 {monsterInStage.Count}마리를 잡았습니다.");
            }


            Console.WriteLine();
            Console.WriteLine("0. 다음");
            Console.WriteLine(">>");
        }
    }
}