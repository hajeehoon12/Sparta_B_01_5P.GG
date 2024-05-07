using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyDungeon
{
    public class Stage
    {
        public enum MonsterSpices { Minion, Worm, CanonMinion, baron};   //몬스터 종류

        Player player1;
        List<Monster> monsterInStage;   //스테이지에 몬스터 4마리 출현할 리스트
        int[] monstersCount = { 0, 0, 0 , 0};  //스테이지에 있는 몬스터 종류의 수 (미니온, 공허춘, 대포 순으로)

        public int stageExp = 0;
        public int stageGold = 0;
        public Dictionary<string, int> Drop_Items = new Dictionary<string, int>();
        

        private int select; //선택지

        public bool stageSelect;
        public bool inFight = false; // 싸우는 도중인가?
        

        public void Start(Player player)
        {
            player1 = player;   // 실제 스테이터스에도 반영되는 것을 확인
            monsterInStage = new List<Monster>(4);
            Console.ForegroundColor = ConsoleColor.Yellow;
            player1.stat.Mp = player1.stat.MaxMp;
            Console.WriteLine("\r\n ######  ########    ###     ######   ######## \r\n##    ##    ##      ## ##   ##    ##  ##       \r\n##          ##     ##   ##  ##        ##       \r\n ######     ##    ##     ## ##   #### ######   \r\n      ##    ##    ######### ##    ##  ##       \r\n##    ##    ##    ##     ## ##    ##  ##       \r\n ######     ##    ##     ##  ######   ######## \r\n");

            //스테이지 선택

            Console.ForegroundColor = ConsoleColor.Cyan;
            int atkinc, definc;
            (atkinc, definc) = player1.inven.Item_Ability_Total();
            player1.stat.Show_stat(atkinc,definc);  // 플레이어 상태 표시
            

            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("\n스테이지를 선택하세요.\n\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("0. 마을로 돌아가기\n");
            for (int i = 0; i < 4; i++)
            {

                if (player1.CurStage > i)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"Stage {i + 1}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write($"Stage {i + 1}");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($" (잠김) "); // 미해금 스테이지
                }
                Console.WriteLine("\n"); // 줄바꿈용

            }
            Console.ForegroundColor = ConsoleColor.Green;
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
            if (select > player1.CurStage) // 해금된 스테이지보다 높은수 입력
            {
                
                Console.Clear();
                Console.WriteLine(player1.CurStage);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("미해금된 스테이지입니다.");
                Start(player1);
            }
            else if (select < 0) // 0이하의 수를 입력
            {
                Console.Clear();
                Console.WriteLine("존재하지 않는 스테이지입니다.");
                Start(player1);
            }
            else if (select ==0) //0입력 마을귀환
            {
                Console.Clear();
                Console.WriteLine("마을로 귀환합니다.");
                player1.program.SelectAct(player1);

            }
            Console.ForegroundColor = ConsoleColor.White;
            StageStart(select);
        }

        public void StageStart(int stage)
        {
            inFight = false; // 초기화
            monsterInStage.Clear(); //스테이지 선택하기전 리스트 비워놓기
            for (int i = 0; i < monstersCount.Length; i++)
                monstersCount[i] = 0;   //몬스터 종류 수 초기
            
            int randomLength;
            if (stage == 1) //스테이지가 2,3이면
            {
                randomLength = new Random().Next(2, 4); //2~3 마리의 랜덤한 몬스터 생성
            }
            else if (stage == 2)
            {
                randomLength = new Random().Next(3, 5); // 3~4마리의 랜덤 몬스터
            }
            else if (stage == 3)
            {
                randomLength = new Random().Next(4, 5); //4마리의 랜덤한 몬스터 생성
            }
            else
            {
                randomLength = new Random().Next(1, 2); // 보스전 보스 몬스터 한마리만 생성
            }
         

            for (int i = 0; i < randomLength; i++)
            {
                switch (stage)  //몬스터 리스트에 순차적으로 몬스터를 추가
                {
                    case 1: //스테이지 1 , 미니언과 공허충만
                        
                        if (monstersCount[(int)MonsterSpices.Worm] >= 2)    //공허충이 2마리가 넘어가면
                            //CreateMonster(MonsterSpices.baron);
                            CreateMonster(MonsterSpices.Minion);    //나머지를 미니언으로
                        else
                            //CreateMonster(MonsterSpices.baron);
                            CreateMonster((MonsterSpices)new Random().Next(0, 2));

                        break;
                    case 2: //스테이지 2 , 대포 한마리와 나머지는 미니언과 공허충만
                        if (i == (randomLength - 1) && monstersCount[(int)MonsterSpices.CanonMinion] == 0)   //마지막 인덱스에서 대포가 없으면 , 대포 추가
                            CreateMonster(MonsterSpices.CanonMinion);
                        else if (monstersCount[(int)MonsterSpices.CanonMinion] >= 1) //대포가 1마리 있으면 공허충과 미니언만 생산
                            CreateMonster((MonsterSpices)new Random().Next(0, 2));
                        else
                            CreateMonster((MonsterSpices)new Random().Next(0, 3));
                        break;
                    case 3: //스테이지 3 , 대포미니언 3마리와 랜덤한마리
                        if (i > 1 && monstersCount[(int)MonsterSpices.CanonMinion] < 3)    //대포가 3마리 미만이면
                            CreateMonster(MonsterSpices.CanonMinion);
                        else if (monstersCount[(int)MonsterSpices.CanonMinion] >= 2) //대포가 3마리 넘어가면 미니언과 공허충만 생산
                            CreateMonster((MonsterSpices)new Random().Next(0, 2));
                        else
                            CreateMonster((MonsterSpices)new Random().Next(0, 3));
                        break;
                    case 4:
                        CreateMonster(MonsterSpices.baron);
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }

            Console.Clear();
            BattleStart();
            

        }

        public void BattleStart()
        {
            int actNum; // 입력용
            bool IsactNum;

            Console.ForegroundColor = ConsoleColor.Yellow;
            if (!inFight) // Battle!!
                Console.WriteLine("\r\n########     ###    ######## ######## ##       ######## #### #### \r\n##     ##   ## ##      ##       ##    ##       ##       #### #### \r\n##     ##  ##   ##     ##       ##    ##       ##       #### #### \r\n########  ##     ##    ##       ##    ##       ######    ##   ##  \r\n##     ## #########    ##       ##    ##       ##                 \r\n##     ## ##     ##    ##       ##    ##       ##       #### #### \r\n########  ##     ##    ##       ##    ######## ######## #### #### \r\n");
            else // Your Turn!!
            {
                Console.WriteLine("\r\n##    ##  #######  ##     ## ########     ######## ##     ## ########  ##    ## #### #### \r\n ##  ##  ##     ## ##     ## ##     ##       ##    ##     ## ##     ## ###   ## #### #### \r\n  ####   ##     ## ##     ## ##     ##       ##    ##     ## ##     ## ####  ## #### #### \r\n   ##    ##     ## ##     ## ########        ##    ##     ## ########  ## ## ##  ##   ##  \r\n   ##    ##     ## ##     ## ##   ##         ##    ##     ## ##   ##   ##  ####           \r\n   ##    ##     ## ##     ## ##    ##        ##    ##     ## ##    ##  ##   ### #### #### \r\n   ##     #######   #######  ##     ##       ##     #######  ##     ## ##    ## #### #### \r\n");
            }
            Console.ForegroundColor = ConsoleColor.White;

            if (player1.stat.Mp + 10 <= player1.stat.MaxMp) // 매턴마나 마나 10회복
            {
                player1.stat.Mp += 10;
            }
            else
            {
                player1.stat.Mp = player1.stat.MaxMp;
            }

            if (player1.stat.Hp <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\r\n##    ##  #######  ##     ##    ##        #######   ######  ######## \r\n ##  ##  ##     ## ##     ##    ##       ##     ## ##    ## ##       \r\n  ####   ##     ## ##     ##    ##       ##     ## ##       ##       \r\n   ##    ##     ## ##     ##    ##       ##     ##  ######  ######   \r\n   ##    ##     ## ##     ##    ##       ##     ##       ## ##       \r\n   ##    ##     ## ##     ##    ##       ##     ## ##    ## ##       \r\n   ##     #######   #######     ########  #######   ######  ######## \r\n");
                Console.WriteLine("\n3초 뒤에 자동으로 메인 화면으로 돌아갑니다."); Thread.Sleep(1000);
                Console.WriteLine($"{player1.Name} 의 체력 0 -> 1");
                Thread.Sleep(3000);
                player1.program.SelectAct(player1);
            }


            Console.WriteLine();
            foreach (Monster monster in monsterInStage)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if(monster.Health <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; // 몬스터가 죽은 상태면 검은 빨강으로 색상변경
                }
       
                monster.PrintMonster();
                
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n[내 정보]");
            Console.WriteLine($"Lv.{player1.stat.Level} {player1.Name} ({player1.stat.job}) ");
            Console.WriteLine($"HP {player1.stat.Hp} / {player1.stat.MaxHp}");
            Console.WriteLine($"Mp {player1.stat.Mp} / {player1.stat.MaxMp}");
            
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1. 공격");

            Console.WriteLine($"2. 스킬 (마나 20 사용) "); // - {player1.stat.job}

            Console.WriteLine("3. 물약 사용 ");

            Console.WriteLine();


            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                IsactNum = int.TryParse(Console.ReadLine(), out actNum);

                if (!IsactNum) // 숫자가 입력되지 않으면
                {
                    Console.WriteLine("숫자를 입력해주세요.");
                }
            }
            while (!IsactNum);
            Console.ForegroundColor = ConsoleColor.White;
            //Console.Clear();
            
            BattleTurn(actNum);
        }
        public void BattleTurn(int actNum) // 입력받은 값을 통해 플레이어와 몬스터의 턴이 진행됨 // 플레이어의 행동값 1.공격 2.스킬 3. 소모품 사용 등
        {
            inFight = true; // 전투중 (첫턴이아님)

            if (!player1.skipTurn) // 턴 스킵 false일 경우 //몬스터 디버프용 스킬
            {
                PlayerTurn(actNum); // 플레이어 턴 진행
            }
            else // 턴 스킵할 경우
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{player1.Name} 이(가) [행동불가] 디버프 상태입니다. 턴이 자동으로 스킵됩니다.."); Thread.Sleep(2000);

                Console.Clear();
                
                Console.WriteLine($"{player1.Name} 이(가) [행동불가] 디버프 상태입니다. 턴이 자동으로 스킵됩니다..");
            }
                                
            Thread.Sleep(800);
            MonsterTurn();  // 몬스터 턴 진행
            BattleStart();
        }

        public void MonsterTurn() // 몬스터가 턴이 돌아오는 부분
        {
            foreach (Monster monster in monsterInStage)
            {
                
                if (monster.Health <= 0) // 몬스터가 죽은상태면 공격을 안함
                {
                }
                else
                {
                    switch (monster.Name) // monster.name 에 따른 행동패턴 적용
                    {
                        case "바론":
                            Skills.BaronPattern(player1, monster);
                            break;
                        case "미니언":
                            Skills.MinionPattern(player1, monster);
                            break;
                        case "공허충":
                            Skills.WormPattern(player1, monster);
                            break;
                        case "머포미니언":
                            Skills.CannonPattern(player1, monster);
                            break;
                        default: // 그 무엇도 해당안될 경우
                            monster.HitDamage(player1, monster); // 몬스터가 플레이어에게 일반 공격 함수
                            IsEnd(); // 끝났는지 검사
                            Thread.Sleep(800);
                            break;
                    }
                    
                }
            }
        }
        
        public void PlayerTurn(int actNum)
        {
            bool IsRightEnemy; // 적을 알맞게 지정하였는가?
            int EnemyNum;  // 지정한 적 번호
            int IntroNum = 0; // 적앞에 표시될 번호

            bool isSkillRight; //스킬을 제대로 입력됐는지
            int skillNum = 0;   //스킬선택지

            Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine("\r\n########     ###    ######## ######## ##       ######## #### #### \r\n##     ##   ## ##      ##       ##    ##       ##       #### #### \r\n##     ##  ##   ##     ##       ##    ##       ##       #### #### \r\n########  ##     ##    ##       ##    ##       ######    ##   ##  \r\n##     ## #########    ##       ##    ##       ##                 \r\n##     ## ##     ##    ##       ##    ##       ##       #### #### \r\n########  ##     ##    ##       ##    ######## ######## #### #### \r\n");
            Console.ForegroundColor = ConsoleColor.White;

            switch (actNum) // 플레이어가 공격 혹은 스킬 혹은 소모품을 사용
            {
                case 1: // 플레이어의 일반 공격
                    Console.WriteLine();
                    foreach (Monster monster in monsterInStage)
                    {
                        //Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(IntroNum);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("  ");
                        monster.PrintMonster();
                        IntroNum++;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n[내 정보]");
                    Console.WriteLine($"Lv.{player1.stat.Level}  {player1.Name} ({player1.stat.job}) ");
                    Console.WriteLine($"HP {player1.stat.Hp} / {player1.stat.MaxHp}");
                    Console.ForegroundColor = ConsoleColor.Green;

                    do
                    {
                        Console.WriteLine("\n대상을 지정하세요");
                        Console.Write(">> ");

                        IsRightEnemy = int.TryParse(Console.ReadLine(), out EnemyNum);
                        Console.ForegroundColor = ConsoleColor.White;
                        if (!IsRightEnemy || !(EnemyNum <= monsterInStage.Count-1)) // 숫자가 입력되지 않으면
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
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

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write($"Lv.{player1.stat.Level} {player1.Name} 이(가)  {monsterInStage[EnemyNum].Name} 을(를) 공격했습니다."); //                     
                        
                    }
                    while (!IsRightEnemy);


                    monsterInStage[EnemyNum].TakeDamage(player1, player1.Critical()); // Player 가 몬스터에게 입힌 데미지 계산

                    break;
                case 2: // 플레이어 스킬 사용 // 임시 광역기
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();

                    if (player1.stat.Mp >= 20)
                    {
                        player1.stat.Mp -= 20;
                        Console.WriteLine("마나 20 소모");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("마나 부족!! 으로 인한 스킬 사용 취소");
                        BattleStart();
                        
                    }


                    switch(player1.stat.job)    //직업별로 사용하는 스킬
                    {   //원하는 스킬을 선택하도록
                        case "전사":
                            do
                            {
                                Console.WriteLine("[ 스킬을 선택하세요 ]\n");
                                Console.WriteLine("0. 취소");
                                Console.WriteLine("1. 심판 (적 전체에게 2배의 광역 데미지로 공격)");
                                
                                Console.Write("\n>> ");
                                isSkillRight = int.TryParse(Console.ReadLine(), out skillNum);
                                if (isSkillRight)
                                {
                                    if (skillNum == 1 || skillNum == 0)
                                        break;
                                    else
                                    {
                                        Console.WriteLine("입력이 잘못되었습니다.");
                                        isSkillRight = false;
                                    }
                                }
                            } while (!isSkillRight);
                            Console.Clear();    //여기서 콘솔창 갱신
                            if (skillNum == 1)
                                PlayerSkill.OverHit(player1, monsterInStage);
                            else if (skillNum == 0)
                            {
                                Console.Clear();
                                player1.stat.Mp += 20;
                                BattleStart();
                            }// 스킬 선택창으로 돌아감

                            break;
                        case "마법사":
                            do
                            {
                                Console.WriteLine("[ 스킬을 선택하세요 ]\n");
                                Console.WriteLine("0. 취소");
                                Console.WriteLine("1. 갓블레스 힐 (공격력 합산의 2배만큼 체력회복, 크리티컬 미적용)");
                                Console.WriteLine("2. 샤이닝 레이 (지정한 적에겐 크리티컬, 양옆의 적에게 1.2배의 데미지로 공격)");
                                Console.Write("\n>> ");
                                isSkillRight = int.TryParse(Console.ReadLine(), out skillNum);
                                if (isSkillRight)
                                {
                                    if (skillNum == 1 || skillNum == 2 || skillNum == 0)
                                        break;
                                    else
                                    {
                                        Console.WriteLine("입력이 잘못되었습니다.");
                                        isSkillRight = false;
                                    }
                                }
                            } while (!isSkillRight);
                            Console.Clear();    //여기서 콘솔창 갱신
                            if (skillNum == 1)
                                PlayerSkill.Heal(player1);
                            else if (skillNum == 2)
                                PlayerSkill.ShiningRay(player1, monsterInStage);
                            else if (skillNum == 0)
                            {
                                Console.Clear();
                                player1.stat.Mp += 20;
                                BattleStart();
                            }// 스킬 선택창으로 돌아감
                            break;
                        case "궁수":
                            
                            do
                            {
                                Console.WriteLine("[ 스킬을 선택하세요 ]\n");
                                Console.WriteLine("0. 취소");
                                Console.WriteLine("1. 소울 에로우 (적 전체에게 1.4배의 데미지로 광역공격, 27% 확률로 15의 추가데미지)");
                                
                                Console.Write("\n>> ");
                                isSkillRight = int.TryParse(Console.ReadLine(), out skillNum);
                                if (isSkillRight)
                                {
                                    if (skillNum == 1 || skillNum == 0)
                                        break;
                                    else
                                    {
                                        Console.WriteLine("입력이 잘못되었습니다.");
                                        isSkillRight = false;
                                    }
                                }
                            } while (!isSkillRight);
                            Console.Clear();    //여기서 콘솔창 갱신
                            if (skillNum == 1) PlayerSkill.SoulArrow(player1, monsterInStage);
                            else if (skillNum == 0)
                            {
                                Console.Clear();
                                player1.stat.Mp += 20;
                                BattleStart();
                            }// 스킬 선택창으로 돌아감
                            break;

                        case "도적":
                            do
                            {
                                Console.WriteLine("[ 스킬을 선택하세요 ]\n");
                                Console.WriteLine("0. 취소");
                                Console.WriteLine("1. 크리티컬 스로우 (단일 적에게 1.5배의 데미지로 두번 공격) (플레이어 레벨 5이상시 2.5배)");
                                Console.WriteLine("2. 어벤져 (적 전체에게 1.6배의 데미지로 공격 - 크리티컬 적용불가) ");
                                Console.Write("\n>> ");
                                isSkillRight = int.TryParse(Console.ReadLine(), out skillNum);
                                if (skillNum == 1 || skillNum == 2 || skillNum == 0)
                                    break;
                                else
                                {
                                    Console.WriteLine("입력이 잘못되었습니다.");
                                    isSkillRight = false;
                                }
                            } while (!isSkillRight);

                            if (skillNum == 1)  //크리티컬 스로우
                            {
                                do
                                {
                                    Console.WriteLine("\n[ 스킬 : 크리티컬 스로우 ]\n");
                                    int enemyIdx = 0;
                                    Console.WriteLine("★스킬 - 크리티컬 스로우 대상 지정 단계★\n");
                                    foreach (Monster m in monsterInStage)
                                    {
                                        Console.Write($"{enemyIdx++}. ");
                                        m.PrintMonster();
                                    }
                                    Console.WriteLine();
                                    IsRightEnemy = int.TryParse(Console.ReadLine(), out EnemyNum);  //공격할 대상 선택
                                    Console.Clear();    //대상 선택후 콘솔창 갱신
                                    if (IsRightEnemy && (EnemyNum >= 0 && EnemyNum < monsterInStage.Count))
                                    {
                                        Console.Clear();
                                        PlayerSkill.CriticalThrow(player1, monsterInStage[EnemyNum]);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\n다시 선택하세요");
                                        IsRightEnemy = false;   // 같은 정수를 이외의 값을 입력하면 true로 저장되어 빠져나온다. 그래서 false로 설정
                                    }
                                } while (!IsRightEnemy);

                            }
                            else if (skillNum == 2) //어벤져
                            {
                                Console.Clear();
                                PlayerSkill.Avenger(player1, monsterInStage);
                            }
                            else if (skillNum == 0)
                            {
                                Console.Clear();
                                player1.stat.Mp += 20;
                                BattleStart();
                            }// 스킬 선택창으로 돌아감
                            break;
                    }
                    break;
                case 3: // 플레이어 소모품 사용 , 물약선택창

                    int potionType;
                    bool isPotion = false;
                    bool usePotion = false; // 포션 사용검사

                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n[ 물약을 선택하세요 ]\n");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("0. 취소");
                        Console.WriteLine("1. 회복 물약 (체력 50 회복)");
                        Console.WriteLine("2. 마나 물약 (마나 50 회복 )");
                        Console.WriteLine("3. 공격력 상승의 물약 (이번 전투에 한해 공격력 10 증가)");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\n>> ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        isPotion = int.TryParse(Console.ReadLine(), out potionType);
                        if (isPotion)
                        {
                            if (potionType == 1 || potionType == 2 || potionType == 3 || potionType == 0)
                                break;
                            else
                            {
                                Console.WriteLine("입력이 잘못되었습니다.");
                                isPotion = false;
                            }
                        }
                    } while (!isPotion);
                    Console.Clear();    //여기서 콘솔창 갱신

                    if (potionType == 1) // 회복 물약 사용
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        for (int i = 0; i < player1.inven.ItemInfo.Count; i++)
                        {
                            if (player1.inven.ItemInfo[i].ItemType == 4)
                            {
                                if (player1.inven.ItemInfo[i].Amount >= 1 && player1.inven.ItemInfo[i].ItemName == "회복물약")
                                {
                                    Console.WriteLine("");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"{player1.Name} 이(가) 현재 회복물약 을(를) {player1.inven.ItemInfo[i].Amount} 개 소지하고 있습니다. 1개를 소비합니다.");
                                    player1.inven.ItemInfo[i].Amount -= 1;
                                    usePotion = true; // 포션사용
                                    if (player1.stat.Hp + 50 < player1.stat.MaxHp)
                                    {
                                        Console.WriteLine($"회복물약 을(를) 사용하여 체력을 50 만큼 회복했습니다. (남은 포션 : {player1.inven.ItemInfo[i].Amount})");
                                        player1.stat.Hp += 50;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"회복물약 을(를) 사용하여 체력을 {player1.stat.MaxHp - player1.stat.Hp} 만큼 회복했습니다. (남은 포션 : {player1.inven.ItemInfo[i].Amount})");
                                        player1.stat.Hp = player1.stat.MaxHp;
                                    }

                                    Console.WriteLine(""); Thread.Sleep(800);
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write($"플레이어 HP : {player1.stat.Hp} / {player1.stat.MaxHp}\n");
                                    Console.WriteLine();
                                    break;
                                }
                                else // 물약개수 동남
                                {

                                    break;
                                }
                            }

                        }
                        if (!usePotion) // 물약사용 실패
                        {
                            Console.WriteLine($"현재 인벤토리에 회복물약 이(가) 없습니다. 회복물약 사용이 취소됩니다.");
                            BattleStart();
                        }
                        // 회복 물약 사용
                    }
                    else if (potionType == 2) // 마나 물약 사용
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        for (int i = 0; i < player1.inven.ItemInfo.Count; i++)
                        {
                            //Console.WriteLine($"{player1.inven.ItemInfo[i].ItemName}"); // 디버깅용
                            if (player1.inven.ItemInfo[i].ItemType == 4)
                            {
                                if (player1.inven.ItemInfo[i].Amount >= 1 && player1.inven.ItemInfo[i].ItemName == "마나물약")
                                {
                                    Console.WriteLine("");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"{player1.Name} 이(가) 현재 마나물약 을(를) {player1.inven.ItemInfo[i].Amount} 개 소지하고 있습니다. 1개를 소비합니다.");
                                    player1.inven.ItemInfo[i].Amount -= 1;
                                    usePotion = true; // 포션사용
                                    if (player1.stat.Mp + 30 < player1.stat.MaxMp)
                                    {
                                        Console.WriteLine($"마나물약 을(를) 사용하여 체력을 30 만큼 회복했습니다. (남은 포션 : {player1.inven.ItemInfo[i].Amount})");
                                        player1.stat.Mp += 30;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"마나물약 을(를) 사용하여 체력을 {player1.stat.MaxMp - player1.stat.Mp} 만큼 회복했습니다. (남은 포션 : {player1.inven.ItemInfo[i].Amount})");
                                        player1.stat.Mp = player1.stat.MaxMp;
                                    }

                                    Console.WriteLine(""); Thread.Sleep(800);
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write($"플레이어 MP : {player1.stat.Mp} / {player1.stat.MaxMp}\n");
                                    Console.WriteLine();
                                    break;
                                }
                                else // 물약개수 동남
                                {

                                    break;
                                }
                            }

                        }
                        if (!usePotion) // 물약사용 실패
                        {
                            Console.WriteLine($"현재 인벤토리에 마나물약 이(가) 없습니다. 마나물약 사용이 취소됩니다.");
                            BattleStart();
                        }
                        // 마나 물약 사용
                    }
                    else if (potionType == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        for (int i = 0; i < player1.inven.ItemInfo.Count; i++)
                        {
                            if (player1.inven.ItemInfo[i].ItemType == 4)
                            {
                                if (player1.inven.ItemInfo[i].Amount >= 1 && player1.inven.ItemInfo[i].ItemName == "공격력 상승의 물약")
                                {
                                    Console.WriteLine("");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"{player1.Name} 이(가) 현재 공격력 상승의 물약 을(를) {player1.inven.ItemInfo[i].Amount} 개 소지하고 있습니다. 1개를 소비합니다.");
                                    player1.inven.ItemInfo[i].Amount -= 1;
                                    usePotion = true; // 포션사용

                                    player1.stat.AttackInc += 10;


                                    Console.WriteLine(""); Thread.Sleep(800);
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write($"플레이어 공격력 : {player1.stat.Attack + player1.stat.AttackInc} ->  {player1.stat.Attack + player1.stat.AttackInc + 10}\n");
                                    Console.WriteLine();
                                    break;
                                }
                                else // 물약개수 동남
                                {

                                    break;
                                }
                            }

                        }
                        if (!usePotion) // 물약사용 실패
                        {
                            Console.WriteLine($"현재 인벤토리에 공격력 상승의 물약 이(가) 없습니다. 공격력 상승의 물약 사용이 취소됩니다.");
                            BattleStart();
                        }
                        // 공격력 물약 사용
                    }
                    else
                    {
                        BattleStart();
                        // 포션선택취소
                    }
                    break;
                default: // 잘못된 값 입력
                    Console.Clear();
                    Console.WriteLine("제대로된 행동을 입력하세요.");
                    BattleStart(); // 플레이어 입력턴으로 원상복귀
                    break;

            }
            IsEnd(); // 끝났는지 검사
            // 플레이어 공격 적용
            
        }


        public void IsEnd() // 끝났는지 검사 단계
        {
            switch (IsBattleEnd())
            {
                case 1: // 플레이어 패배
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\r\n##    ##  #######  ##     ##    ##        #######   ######  ######## \r\n ##  ##  ##     ## ##     ##    ##       ##     ## ##    ## ##       \r\n  ####   ##     ## ##     ##    ##       ##     ## ##       ##       \r\n   ##    ##     ## ##     ##    ##       ##     ##  ######  ######   \r\n   ##    ##     ## ##     ##    ##       ##     ##       ## ##       \r\n   ##    ##     ## ##     ##    ##       ##     ## ##    ## ##       \r\n   ##     #######   #######     ########  #######   ######  ######## \r\n");
                    Console.WriteLine("\n3초 뒤에 자동으로 메인 화면으로 돌아갑니다."); Thread.Sleep(1000);
                    Console.WriteLine($"{player1.Name} 의 체력 0 -> 1"); 
                    Thread.Sleep(3000);
                    player1.program.SelectAct(player1);
                    break;
                case 2: // 플레이어 스테이지 클리어
                    Console.WriteLine("\r\n##     ## ####  ######  ########  #######  ########  ##    ## #### #### \r\n##     ##  ##  ##    ##    ##    ##     ## ##     ##  ##  ##  #### #### \r\n##     ##  ##  ##          ##    ##     ## ##     ##   ####   #### #### \r\n##     ##  ##  ##          ##    ##     ## ########     ##     ##   ##  \r\n ##   ##   ##  ##          ##    ##     ## ##   ##      ##              \r\n  ## ##    ##  ##    ##    ##    ##     ## ##    ##     ##    #### #### \r\n   ###    ####  ######     ##     #######  ##     ##    ##    #### #### \r\n");
                    //Console.WriteLine("플레이어 승리");
                    BattleResult(); // 결과판 출력
                    Console.WriteLine("5초 뒤에 자동으로 던전 선택창으로 나가집니다.");
                    Thread.Sleep(5000);
                    Start(player1);
                    break;
                default: // 0
                    break;


            }
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


        public void CreateMonster(MonsterSpices monsterIdx)  //랜덤으로 몬스터 생성
        {
            switch (monsterIdx)
            {
                //monsterInStage에 인덱스에 맞는 종류를 추가하고 카운트 증가
                case MonsterSpices.Minion:
                    monsterInStage.Add(new Minion("미니언"));
                    monstersCount[(int)MonsterSpices.Minion]++;
                    break;
                case MonsterSpices.Worm:
                    monsterInStage.Add(new Worm("공허충"));
                    monstersCount[(int)MonsterSpices.Worm]++;
                    break;
                case MonsterSpices.CanonMinion:
                    monsterInStage.Add(new CannonMinion("머포미니언"));
                    monstersCount[(int)MonsterSpices.CanonMinion]++;
                    break;
                case MonsterSpices.baron:
                    monsterInStage.Add(new baron("바론"));
                    monstersCount[(int)MonsterSpices.baron]++;
                    break;
            }
        }

        void BattleResult() //전투 결과
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\r\n########  ########  ######  ##     ## ##       ######## \r\n##     ## ##       ##    ## ##     ## ##          ##    \r\n##     ## ##       ##       ##     ## ##          ##    \r\n########  ######    ######  ##     ## ##          ##    \r\n##   ##   ##             ## ##     ## ##          ##    \r\n##    ##  ##       ##    ## ##     ## ##          ##    \r\n##     ## ########  ######   #######  ########    ##    \r\n");
            Console.ForegroundColor = ConsoleColor.White;

            if (player1.stat.Hp <= 0) //플레이어가 죽으면
            {
                //Lose
                Console.WriteLine();
                Console.WriteLine("You Lose");
            }
            else
            {
                player1.CurStage += 1; // 현재 스테이지 클리어 다음에 실행하면 다음 스테이지로 업데이트

                if (player1.quest.accept2 && !player1.quest.clearComplete2) // 2번 퀘스트 수행중이라면 완료료 바꿈
                {
                    player1.quest.clearComplete2 = true;
                }
                //Victory
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=============================================================");
                Console.WriteLine();
                Console.WriteLine("                       [던전 탐험 결과]");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n              던전에서 몬스터 {monsterInStage.Count}마리를 잡았습니다.\n");
                
            }

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("                         [캐릭터 정보]");
            Console.WriteLine($"                     Lv.{player1.stat.Level}  {player1.Name} ({player1.stat.job}) ");
            Console.WriteLine($"                        HP {player1.stat.Hp} / {player1.stat.MaxHp}");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("                   [던전에서 획득한 총 보상]\n");

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"                         + {stageGold} Gold"); // 이번 스테이지 획득한 총골드의 양

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine($"                         + {stageExp}  Exp"); // 이번 스테이지 획득한 총경험치 양

            Console.ForegroundColor = ConsoleColor.Cyan;

            foreach (KeyValuePair<string, int> earn_item in Drop_Items)
            {
                Console.WriteLine($"                        {earn_item.Key} X {earn_item.Value}"); // 이번 스테이지에서 획득한 아이템 나열
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=============================================================");

            Console.WriteLine("0. 마을로 돌아가기");
            Console.WriteLine(">>");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();
            player1.program.SelectAct(player1); // 메인메뉴로 되돌아가기

        }
    }
}