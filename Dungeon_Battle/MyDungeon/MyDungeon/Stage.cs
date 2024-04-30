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
        int[] monstersCount = { 0, 0, 0 };  //스테이지에 있는 몬스터 종류의 수 (미니온, 공허춘, 대포 순으로)

        private int select; //선택지

        public bool stageSelect;
        

        public void Start(Player player)
        {
            player1 = player;   // 실제 스테이터스에도 반영되는 것을 확인

            monsterInStage = new List<Monster>(4);

            //스테이지 선택
            Console.WriteLine("\n스테이지를 선택하세요.\n\n");
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
        // 1스테이지는 (공허충 최대 2마리 나머지 미니온)
        // 2스테이지는 (대포 1마리 나머지는 미니온이나 공허충)
        // 3스테이지는 (대포 최대 2마리 나머지는 미니온이나 공허충)
        public void StageStart(int stage)
        {
            monsterInStage.Clear(); //스테이지 선택하기전 리스트 비워놓기
            for (int i = 0; i < monstersCount.Length; i++)
                monstersCount[i] = 0;   //몬스터 종류 수 초기
            
            int randomLength;
            if (stage == 3) //스테이지가 3이면
                randomLength = new Random().Next(2, 5); //2~4마리의 랜덤한 몬스터 생성
            else
                randomLength = new Random().Next(1, 5); //1~4마리의 랜덤한 몬스터 생성

            for (int i = 0; i < randomLength; i++)
            {
                switch (stage)  //몬스터 리스트에 몬스터 추가
                {
                    case 1: //스테이지 1
                        if (monstersCount[(int)MonsterSpices.Worm] >= 2)    //공허충이 2마리가 넘어가면
                            CreateMonster(MonsterSpices.Minion);    //나머지를 미니온으로
                        else
                            CreateMonster((MonsterSpices)new Random().Next(0, 2));
                        break;
                    case 2: //스테이지 2
                        if (i == (randomLength - 1) && monstersCount[(int)MonsterSpices.CanonMinion] == 0)   //마지막 인덱스에서 대포가 없으면
                            CreateMonster(MonsterSpices.CanonMinion);
                        else if (monstersCount[(int)MonsterSpices.CanonMinion] >= 1) //대포가 1마리 있으면
                            CreateMonster((MonsterSpices)new Random().Next(0, 2));
                        else
                            CreateMonster((MonsterSpices)new Random().Next(0, 3));
                        break;
                    case 3: //스테이지 3
                        if (i > 1 && monstersCount[(int)MonsterSpices.CanonMinion] < 2)    //대포가 2마리 미만이면
                            CreateMonster(MonsterSpices.CanonMinion);
                        else if (monstersCount[(int)MonsterSpices.CanonMinion] >= 2) //대포가 2마리 넘어가면
                            CreateMonster((MonsterSpices)new Random().Next(0, 2));
                        else
                            CreateMonster((MonsterSpices)new Random().Next(0, 3));
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }



            Console.Clear();
            Console.WriteLine("\r\n########     ###    ######## ######## ##       ######## #### #### \r\n##     ##   ## ##      ##       ##    ##       ##       #### #### \r\n##     ##  ##   ##     ##       ##    ##       ##       #### #### \r\n########  ##     ##    ##       ##    ##       ######    ##   ##  \r\n##     ## #########    ##       ##    ##       ##                 \r\n##     ## ##     ##    ##       ##    ##       ##       #### #### \r\n########  ##     ##    ##       ##    ######## ######## #### #### \r\n");

            Console.WriteLine();
            foreach (Monster monster in monsterInStage)
            {
                monster.PrintMonster();
            }
            Console.WriteLine("\n[내 정보]");
            Console.WriteLine($"Lv.{player1.stat.Level}     {player1.Name}   ({player1.stat.job}) ");
            Console.WriteLine($"HP {player1.stat.Hp} / {player1.stat.MaxHp}");


            Console.WriteLine("1.공격");

            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            Console.ReadLine();
        }

        private void CreateMonster(MonsterSpices monsterIdx)  //랜덤으로 몬스터 생성
        {
            switch (monsterIdx)
            {
                //monsterInStage에 인덱스에 맞는 종류를 추가하고 카운트 증가
                case MonsterSpices.Minion:
                    monsterInStage.Add(new Minion("미니온"));
                    monstersCount[(int)MonsterSpices.Minion]++;
                    break;
                case MonsterSpices.Worm:
                    monsterInStage.Add(new Worm("공허충"));
                    monstersCount[(int)MonsterSpices.Worm]++;
                    break;
                case MonsterSpices.CanonMinion:
                    monsterInStage.Add(new CannonMinion("대포 미니온"));
                    monstersCount[(int)MonsterSpices.CanonMinion]++;
                    break;
            }
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