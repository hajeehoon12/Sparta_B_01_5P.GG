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
        // 1스테이지는 (미니온 3마리, 공허충 1마리)
        // 2스테이지는 (미니온 2마리, 공허충 1마리, 대포 1마리)
        // 3스테이지는 (미니온 1마리, 공허충 1마리, 대포 2마리)
        public void StageStart(int stage)
        {
            switch (stage)  //몬스터 리스트에 몬스터 추가
            {
                case 1: //스테이지 1
                    //몬스터 생성

                    monsterInStage.Add(new Minion("미니언"));     
                    monsterInStage.Add(new Minion("미니언"));
                    monsterInStage.Add(new Minion("미니언"));
                    monsterInStage.Add(new Worm("공허충"));

                    break;
                case 2:
                    monsterInStage.Add(new Minion("미니언"));
                    monsterInStage.Add(new Minion("미니언"));
                    monsterInStage.Add(new Worm("공허충"));
                    monsterInStage.Add(new CannonMinion("대포 미니언"));
                    break;
                case 3:
                    monsterInStage.Add(new Minion("미니언"));
                    monsterInStage.Add(new Worm("공허충"));
                    monsterInStage.Add(new CannonMinion("대포 미니언"));
                    monsterInStage.Add(new CannonMinion("대포 미니언"));
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }

            Console.Clear();
            BattleStart();
            

        }

        public void BattleStart()
        {
            int actNum; // 입력용
            bool IsactNum;

            
            Console.WriteLine("\r\n########     ###    ######## ######## ##       ######## #### #### \r\n##     ##   ## ##      ##       ##    ##       ##       #### #### \r\n##     ##  ##   ##     ##       ##    ##       ##       #### #### \r\n########  ##     ##    ##       ##    ##       ######    ##   ##  \r\n##     ## #########    ##       ##    ##       ##                 \r\n##     ## ##     ##    ##       ##    ##       ##       #### #### \r\n########  ##     ##    ##       ##    ######## ######## #### #### \r\n");

            Console.WriteLine();
            foreach (Monster monster in monsterInStage)
            {
                monster.PrintMonster();
            }
            Console.WriteLine("\n[내 정보]");
            Console.WriteLine($"Lv.{player1.stat.Level}     {player1.Name}   ({player1.stat.job}) ");
            Console.WriteLine($"HP {player1.stat.Hp} / {player1.stat.MaxHp}");


            Console.WriteLine("1. 공격");

            Console.WriteLine();


            do
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                IsactNum = int.TryParse(Console.ReadLine(), out actNum);

                if (!IsactNum) // 숫자가 입력되지 않으면
                {
                    Console.WriteLine("숫자를 입력해주세요.");
                }
            }
            while (!IsactNum);

            Console.Clear();
            
            BattleTurn(actNum);
        }
        public void BattleTurn(int actNum) // 입력받은 값을 통해 플레이어와 몬스터의 턴이 진행됨 // 플레이어의 행동값 1.공격 2.스킬 3. 소모품 사용 등
        {
            bool IsRightEnemy; // 적을 알맞게 지정하였는가?
            int EnemyNum;  // 지정한 적 번호
            int IntroNum = 0; // 적앞에 표시될 번호


            Console.WriteLine("\r\n########     ###    ######## ######## ##       ######## #### #### \r\n##     ##   ## ##      ##       ##    ##       ##       #### #### \r\n##     ##  ##   ##     ##       ##    ##       ##       #### #### \r\n########  ##     ##    ##       ##    ##       ######    ##   ##  \r\n##     ## #########    ##       ##    ##       ##                 \r\n##     ## ##     ##    ##       ##    ##       ##       #### #### \r\n########  ##     ##    ##       ##    ######## ######## #### #### \r\n");


            switch (actNum) // 플레이어가 공격 혹은 스킬 혹은 소모품을 사용
            {
                case 1: // 플레이어 공격
                    foreach (Monster monster in monsterInStage)
                    {
                        
                        Console.Write(IntroNum + "  "); 
                        monster.PrintMonster();
                        IntroNum++;
                    }
                    Console.WriteLine("\n[내 정보]");
                    Console.WriteLine($"Lv.{player1.stat.Level}     {player1.Name}   ({player1.stat.job}) ");
                    Console.WriteLine($"HP {player1.stat.Hp} / {player1.stat.MaxHp}");

                    do
                    {
                        Console.WriteLine("대상을 지정하세요");
                        Console.Write(">> ");

                        IsRightEnemy = int.TryParse(Console.ReadLine(), out EnemyNum);

                        if (!IsRightEnemy) // 숫자가 입력되지 않으면
                        {
                            Console.Clear();
                            Console.WriteLine("숫자를 제대로 입력해주세요.");
                            BattleTurn(actNum);
                        }
                        if (monsterInStage[EnemyNum].IsDead) // 지정한 몬스터가 죽었을 경우
                        {
                            Console.Clear();
                            Console.WriteLine("해당 몬스터는 이미 사망했습니다.");
                            BattleTurn(actNum); // 다시 원상복귀
                        }
                        Console.Clear(); // 지저분한 앞내용 지움
                        Console.Write($"Lv.{player1.stat.Level} {player1.Name}이(가)  {monsterInStage[EnemyNum].Name} 을(를) 공격했습니다."); //
                    }
                    while (!IsRightEnemy);

                    
                    monsterInStage[EnemyNum].TakeDamage(player1, player1.Critical()); // 몬스터[번호] 가 데미지를 입음(player에게, player 데미지)




                    break;
                case 2: // 플레이어 스킬

                    break;
                case 3: // 플레이어 소모품 사용


                    break;
                default: // 잘못된 값 입력
                    BattleStart(); // 플레이어 입력턴으로 원상복귀
                    break;
            
            }

            // 플레이어 공격 적용
            switch (IsBattleEnd())
            {
                case 1:
                    Console.WriteLine("플레이어 패배");
                    break;
                case 2:
                    Console.WriteLine("\r\n##     ## ####  ######  ########  #######  ########  ##    ## #### #### \r\n##     ##  ##  ##    ##    ##    ##     ## ##     ##  ##  ##  #### #### \r\n##     ##  ##  ##          ##    ##     ## ##     ##   ####   #### #### \r\n##     ##  ##  ##          ##    ##     ## ########     ##     ##   ##  \r\n ##   ##   ##  ##          ##    ##     ## ##   ##      ##              \r\n  ## ##    ##  ##    ##    ##    ##     ## ##    ##     ##    #### #### \r\n   ###    ####  ######     ##     #######  ##     ##    ##    #### #### \r\n");
                    Console.WriteLine("플레이어 승리");
                    BattleResult();
                    Console.ReadLine(); // 입력대기용
                    Start(player1);
                    break;
                default: // 0
                    break;
            
            
            }
            

            
            BattleStart();
        }

        public int IsBattleEnd() // 배틀이 끝났는지 여부 알아보기 및 승자가 누구인지 //1.플레이어 패배 2. 플레이어 승리 0. 전투가안끝남
        {
            if (player1.stat.Hp <= 0) // 플레이어가 죽었으면 
            {
                return 1; // 1 return

            }
            foreach (Monster monster in monsterInStage)
            {
                if (!monster.IsDead) // 몬스터 중 한마리라도 살아있으면
                {
                    return 0;
                }
                
            }
            return 2; // 다죽었으면 2 return
            
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