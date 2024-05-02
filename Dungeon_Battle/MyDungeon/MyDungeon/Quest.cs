using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MyDungeon
{
    public class Quest
    {


        public bool isSucess; // 성공 여부
        public bool accept; // 수락 여부
        public string questItem; // 퀘스트 관련 아이템
        List<ItemData> quest_Item = new List<ItemData>(); // 저장할 퀘스트 아이템 정보
        public bool accept3; // 3번 퀘스트 수락 여부
        public bool accept2; // 2번 퀘스트 수락 여부
        public bool complete3 = false; // 3번 퀘스트 완료 여부
        public bool complete2 = false; // 2번 퀘스트 완료 여부

        bool selectRight = false;
        int selectAct;

        public int minionCount = 0;

        Player player;


        public Quest()
        {
            
        
        }


        public void ThirdQuestCheck() // 퀘스트 조건 검사
        {
            Quest check = new Quest();
            check.questItem = "낡은 수련용 방패";
            // if(check.questItem == true)  수련용 방패 장착 체크
            {
                check.isSucess = true;
            }
        }

       

        public void QuestScreen() // 퀘스트 목록 출력
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\r\n #######  ##     ## ########  ######  ######## #### #### \r\n##     ## ##     ## ##       ##    ##    ##    #### #### \r\n##     ## ##     ## ##       ##          ##    #### #### \r\n##     ## ##     ## ######    ######     ##     ##   ##  \r\n##  ## ## ##     ## ##             ##    ##              \r\n##    ##  ##     ## ##       ##    ##    ##    #### #### \r\n ##### ##  #######  ########  ######     ##    #### #### \r\n");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1. 마을을 위협하는 미니언 처치\n");

            

            if (complete2)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("2. 상남자의 길!!");
                Console.Write(" [완료됨]");
            }
            else if (accept2)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("2. 상남자의 길!!");
                Console.Write(" [진행중]");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("2. 상남자의 길!!");
            }
            Console.WriteLine("\n");


            if (complete3)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("3. 장비를 장착해보자!!");
                Console.Write(" [완료됨]");
            }
            else if (accept3)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("3. 장비를 장착해보자!!");
                Console.Write(" [진행중]");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("3. 장비를 장착해보자!!");
            }
            Console.WriteLine("\n");




            Console.WriteLine("4. 포션을 사용해보자\n");
            Console.WriteLine("0. 돌아가기");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("원하시는 행동을 선택해주세요");
            Console.WriteLine(">>");
        }
        public void FirstQuest() // 첫번째 퀘스트
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Quest!!");
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("마을을 위협하는 미니언 처치");
            Console.WriteLine();
            Console.WriteLine("이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나?");
            Console.WriteLine("마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!");
            Console.WriteLine("모험가인 자네가 좀 처치해주게");
            Console.WriteLine();
            Console.WriteLine("- 미니언 5마리 처치 (0/5)"); // 0/5 카운트 넣기
            Console.WriteLine();
            Console.WriteLine("- 보상 -"); // 보상 구현하기
            Console.WriteLine("아이템");
            Console.WriteLine("골드");
            Console.WriteLine();
            if (isSucess == false || accept == false) //0/5 조건이 달성 되었을 때 보상받기로 변경 > 보상 받고 나서 사후처리 bool false면 수락 true 보상받기
            {
                Console.WriteLine("1. 수락");

            }
            else if (isSucess == true || accept == true)
            {
                Console.WriteLine("2. 보상받기");
            }
            Console.WriteLine("2. 거절");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine(">>");

            string select = Console.ReadLine();
            if (select == "1")
            {

            }
            else if (select == "2")
            {
                QuestScroll(player);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("\n ===== 잘못된 입력입니다.다시 입력해주세요 ===== ");
            }
        }
        public void SecondQuest(bool complete ,Player character) // 두번쨰 퀘스트
        {
            if (!accept3) // 퀘스트 수락 안함
            {
                Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("퀘스트 : 상남자의 길!!"); Thread.Sleep(500);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\r\n\r\n                ..;==!:,,,,             \r\n               .!=====$$$$$;            \r\n               .======$$$$$$            \r\n               .*=..::::..*$            \r\n                :=        !,            \r\n                 =        :             \r\n                 -                      \r\n                  ~                     \r\n                  *=:~~;$*              \r\n                  ~===$$$*              \r\n                  .;!*=!!,              \r\n              ~;;,.. ., ,.~;;-          \r\n          *=======..,  ,.-=$$$$$$;      \r\n        .!========!.  .  *$$$$$$$$*     \r\n      ...!=========*~*==*$$$$$$$$$-.    \r\n     .....============$$$$$$$$$$$=,.    \r\n    ......============$$$$$$$$$$$;..    \r\n   .......-===========$$$$$$$$$$$;..    \r\n  ......  .*==========$$$$$$$$$$$....   \r\n .....     :==========$$$$$$$$$$$.....  \r\n .....     :==========$$$$$$$$$$. ....  \r\n  .....    :==========$$$$$$$$$$  ....  \r\n   .....   :==========$$$$$$$$$$  ....  \r\n     ..... :==========$$$$$$$$$$   ...  \r\n       ....:==========$$$$$$$$$$   .... \r\n      .-,.. .!========$$$$$$$$$$   .... \r\n        .~   .!=======$$$$$$$$$$    ... \r\n              ,~*=====$$$$$$$$$$    ... \r\n             :;!*=====$$$$$$$$$$    ... \r\n           :==========$$$$$$$$$$    ... \r\n           :==========$$$$$$$$$$    ... \r\n.;;;;;;;;;;*==========$$$$$$$$$$!!!!!!!~\r\n.=====================$$$$$$$$$$$$$$$$$:\r\n.=====================$$$$$$$$$$$$$$$$$:\r\n.=====================$$$$$$$$$$$$$$$$$:\r\n.=====================$$$$$$$$$$$$$$$$$:\r\n.=====================$$$$$$$$$$$*;;;;;-\r\n");
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(18, 3);
                Console.WriteLine("[혁매님]");


                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(37, 20);
                Console.WriteLine($"\"{character.Name}\" 다시 보니 반갑네!"); Thread.Sleep(1500);
                Console.SetCursorPosition(37, 22);
                Console.WriteLine("보아하니 어느 정도 걸음마를 뗀 모양이군."); Thread.Sleep(1500);
                Console.SetCursorPosition(37, 24);
                Console.WriteLine("남자라면 모름지기 휴식없이 혼자서 던전을 클리어할줄도 알아야 하는 법!"); Thread.Sleep(1500);
                Console.SetCursorPosition(37, 26);
                Console.WriteLine("내가 한창 잘 나갈때는 말이야! 돈이 없어서 포션도 없이 싸우고... 어?"); Thread.Sleep(1500);
                
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(37, 28);
                Console.WriteLine($"{player.Name} : 이거 진짜에요?"); Thread.Sleep(2000);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(37, 30);
                Console.WriteLine("그래 지금은 늙어서 전사나 하고 있지만, 한창 게임할땐 마법사나 도적으로 주로 했어!"); Thread.Sleep(1500);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(37, 32);
                Console.WriteLine("내가 옛날에.."); Thread.Sleep(1500);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(37, 34);
                Console.Write($"{player.Name} : 인생사 풀기전에"); Thread.Sleep(1000);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(47, 32);
                Console.WriteLine("는 말이야 !@#$!##$~~"); Thread.Sleep(1000);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(62, 34);
                Console.Write($"..돔황챠!!!"); Thread.Sleep(500);
                Console.Write("."); Thread.Sleep(500);
                Console.Write("."); Thread.Sleep(500);
                Console.Write("."); Thread.Sleep(500);


                Console.SetCursorPosition(0, 44);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=================================================================================================");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("강제 퀘스트 : 앞으로 몬스터 던전 1회 클리어할 동안 휴식 사용불가!! \n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=================================================================================================");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("0. 헛소리 더 듣다 수락하기");
                Console.WriteLine("1. 수락");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                do
                {
                    selectRight = int.TryParse(Console.ReadLine(), out selectAct);

                } while (!selectRight);

                switch (selectAct)
                {
                    case 0: // 나가기 버튼 (원래는 나가기만 맞지만 두번째 퀘스트는 예외)
                        accept2 = true; // 퀘스트 수락
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\n{player.Name} : 헛소리를 더 듣고싶다니.. 미쳐버린거냐?\n"); Thread.Sleep(2000);
                        Console.Write($"{player.Name} : 빨리 퀘스트를 해치워야 올때마다 헛소리를 안듣지"); Thread.Sleep(1000);
                        Console.Write("."); Thread.Sleep(500);
                        Console.Write("."); Thread.Sleep(500);
                        Console.Write("."); Thread.Sleep(500);
                        Console.Write("."); Thread.Sleep(500);
                        Console.Write("."); Thread.Sleep(500);
                        Console.Write("."); Thread.Sleep(500);

                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[강제 퀘스트 시작] : 상남자의 길!!");
                        QuestScroll(player);
                        break;
                    case 1: // 퀘스트 수락, 방패 지급
                        accept2 = true;  //퀘스트 수락
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\n{player.Name} : 휴식 없이 몬스터 던전이라? 최대한 빠르게 해결하는게 좋겠군..\n"); Thread.Sleep(2000);
                        Console.WriteLine($"{player.Name} : 빨리 퀘스트를 해치워야 올때마다 헛소릴 안듣지..."); Thread.Sleep(1000);
                        Console.Write("."); Thread.Sleep(500);
                        Console.Write("."); Thread.Sleep(500);
                        Console.Write("."); Thread.Sleep(500);
                        Console.Write("."); Thread.Sleep(500);
                        Console.Write("."); Thread.Sleep(500);
                        Console.Write("."); Thread.Sleep(500);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n[강제 퀘스트 시작] : 상남자의 길!! (패널티로 몬스터 던전을 1회 클리어하기 전까지 휴식이 불가능합니다.)");
                        accept3 = true; // 퀘스트 수락 확인용 변수

                        QuestScroll(player);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\n{player.Name} : 데자뷴가?"); Thread.Sleep(2000);

                        SecondQuest(false, character);
                        break;
                }



                QuestScroll(player);

            }
            Console.WriteLine("- 보상 -"); // 보상 구현하기
            Console.WriteLine("아이템");
            Console.WriteLine("골드");
            Console.WriteLine();
            Console.WriteLine("1. 수락"); // 0/5 조건이 달성 되었을 때 보상받기로 변경 > 보상 받고 나서 사후처리
            Console.WriteLine("2. 거절");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            string select = Console.ReadLine();
            if (select == "1")
            {

            }
            else if (select == "2")
            {
                QuestScroll(player);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("\n ===== 잘못된 입력입니다.다시 입력해주세요 ===== ");
            }
        }
        public void ThirdQuest(bool complete , Player character) //세번째 퀘스트
        {
            if (accept3 && complete3)
            {
                Console.Clear();
                Console.WriteLine("이미 완료된 퀘스트입니다!");
            }

            if (accept3 && !complete) // 퀘스트 수락 + 조건 달성 못함
            {
                Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("퀘스트 : 장비를 장착해보자!!"); Thread.Sleep(500);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\r\n\r\n                ..;==!:,,,,             \r\n               .!=====$$$$$;            \r\n               .======$$$$$$            \r\n               .*=..::::..*$            \r\n                :=        !,            \r\n                 =        :             \r\n                 -                      \r\n                  ~                     \r\n                  *=:~~;$*              \r\n                  ~===$$$*              \r\n                  .;!*=!!,              \r\n              ~;;,.. ., ,.~;;-          \r\n          *=======..,  ,.-=$$$$$$;      \r\n        .!========!.  .  *$$$$$$$$*     \r\n      ...!=========*~*==*$$$$$$$$$-.    \r\n     .....============$$$$$$$$$$$=,.    \r\n    ......============$$$$$$$$$$$;..    \r\n   .......-===========$$$$$$$$$$$;..    \r\n  ......  .*==========$$$$$$$$$$$....   \r\n .....     :==========$$$$$$$$$$$.....  \r\n .....     :==========$$$$$$$$$$. ....  \r\n  .....    :==========$$$$$$$$$$  ....  \r\n   .....   :==========$$$$$$$$$$  ....  \r\n     ..... :==========$$$$$$$$$$   ...  \r\n       ....:==========$$$$$$$$$$   .... \r\n      .-,.. .!========$$$$$$$$$$   .... \r\n        .~   .!=======$$$$$$$$$$    ... \r\n              ,~*=====$$$$$$$$$$    ... \r\n             :;!*=====$$$$$$$$$$    ... \r\n           :==========$$$$$$$$$$    ... \r\n           :==========$$$$$$$$$$    ... \r\n.;;;;;;;;;;*==========$$$$$$$$$$!!!!!!!~\r\n.=====================$$$$$$$$$$$$$$$$$:\r\n.=====================$$$$$$$$$$$$$$$$$:\r\n.=====================$$$$$$$$$$$$$$$$$:\r\n.=====================$$$$$$$$$$$$$$$$$:\r\n.=====================$$$$$$$$$$$*;;;;;-\r\n");
                Console.ForegroundColor = ConsoleColor.Cyan;




                Console.SetCursorPosition(37, 20);
                Console.WriteLine($"\"{character.Name}\" 왔는가?"); Thread.Sleep(1500);
                Console.SetCursorPosition(37, 22);
                Console.WriteLine("보아하니 아직 장비를 장착하지 못한 모양이군"); Thread.Sleep(1500);
                Console.SetCursorPosition(37, 24);
                Console.WriteLine("메뉴 - 인벤토리 - 장착관리 에서 내가 건네준 방패를 장착해오게나."); Thread.Sleep(1500);
                Console.SetCursorPosition(37, 26);
                Console.WriteLine("그럼 기다리고 있겟네 하하"); Thread.Sleep(1500);
                Console.Clear();
                QuestScroll(player);
                
            }



            if (!complete) // 퀘스트 완료전
            {
                Console.ForegroundColor = ConsoleColor.Yellow;Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("퀘스트 : 장비를 장착해보자!!"); Thread.Sleep(500);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\r\n\r\n                ..;==!:,,,,             \r\n               .!=====$$$$$;            \r\n               .======$$$$$$            \r\n               .*=..::::..*$            \r\n                :=        !,            \r\n                 =        :             \r\n                 -                      \r\n                  ~                     \r\n                  *=:~~;$*              \r\n                  ~===$$$*              \r\n                  .;!*=!!,              \r\n              ~;;,.. ., ,.~;;-          \r\n          *=======..,  ,.-=$$$$$$;      \r\n        .!========!.  .  *$$$$$$$$*     \r\n      ...!=========*~*==*$$$$$$$$$-.    \r\n     .....============$$$$$$$$$$$=,.    \r\n    ......============$$$$$$$$$$$;..    \r\n   .......-===========$$$$$$$$$$$;..    \r\n  ......  .*==========$$$$$$$$$$$....   \r\n .....     :==========$$$$$$$$$$$.....  \r\n .....     :==========$$$$$$$$$$. ....  \r\n  .....    :==========$$$$$$$$$$  ....  \r\n   .....   :==========$$$$$$$$$$  ....  \r\n     ..... :==========$$$$$$$$$$   ...  \r\n       ....:==========$$$$$$$$$$   .... \r\n      .-,.. .!========$$$$$$$$$$   .... \r\n        .~   .!=======$$$$$$$$$$    ... \r\n              ,~*=====$$$$$$$$$$    ... \r\n             :;!*=====$$$$$$$$$$    ... \r\n           :==========$$$$$$$$$$    ... \r\n           :==========$$$$$$$$$$    ... \r\n.;;;;;;;;;;*==========$$$$$$$$$$!!!!!!!~\r\n.=====================$$$$$$$$$$$$$$$$$:\r\n.=====================$$$$$$$$$$$$$$$$$:\r\n.=====================$$$$$$$$$$$$$$$$$:\r\n.=====================$$$$$$$$$$$$$$$$$:\r\n.=====================$$$$$$$$$$$*;;;;;-\r\n");
                Console.ForegroundColor = ConsoleColor.Cyan;

                


                Console.SetCursorPosition(37, 20);
                Console.WriteLine($"어이! 이번에 들어온 \"{character.Name}\" 신참, 자네 장비는 장착할 줄 아는가?"); Thread.Sleep(1500);
                Console.SetCursorPosition(37, 22);
                Console.WriteLine("장비는 전투에 한해서는 없어서는 안될 중요한 아이템이라네."); Thread.Sleep(1500);
                Console.SetCursorPosition(37, 24);
                Console.WriteLine("제대로 장비를 착용하지 않고 전투에 나선다면 다쳐서 돌아오기 십상이지."); Thread.Sleep(1500);
                Console.SetCursorPosition(37, 26);
                Console.WriteLine("내 소싯적에 애용하던 방패를 자네에게 건네줄테니 인벤토리에서 낡은 방패를 장착해오게"); Thread.Sleep(1500);
               
                Console.WriteLine();
                
                
                Console.SetCursorPosition(0, 44);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=================================================================================================");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("퀘스트 목표 : 베테랑 모험가 [혁매님] 한테 받은 낡은 수련용 방패를 인벤토리에서 장착하라! (0/1)\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=================================================================================================");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("0. 나가기");
                Console.WriteLine("1. 수락");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                do
                {
                    selectRight = int.TryParse(Console.ReadLine(), out selectAct);
                    
                } while (!selectRight);

                switch (selectAct)
                {
                    case 0: // 나가기 버튼
                        Console.Clear();
                        QuestScroll(player);
                        break;
                    case 1: // 퀘스트 수락, 방패 지급
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n어디 보자... 여기 있네. 내가 가장 소중히 여기는 방패니까 조심히 다루게나!!"); Thread.Sleep(1500);
                        player.ItemAmount_Change(new ItemData(3, "낡은 수련용 방패", 0, 2, 50, 1, "돈을 주고서나 팔아야 겨우 팔릴것 같은 싸구려 방패"), 1);
                        Console.WriteLine("\n☆★낡은 수련용 방패 지급 완료!★☆\n"); 

                        Console.WriteLine("[아이템 설명] : 돈을 주고서나 팔아야 겨우 팔릴것 같은 싸구려 방패"); Thread.Sleep(1500);

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\n{player.Name} : 아니 이런 쓰레기를 줘놓고 그렇게 생색낸거야?\n"); Thread.Sleep(2000);
                        Console.WriteLine($"{player.Name} : 빨리 퀘스트를 해치우고 이딴 방패 바로 팔아버려야지..."); Thread.Sleep(6000);
                        Console.Clear();
                        Console.WriteLine("[퀘스트 수락 완료] : 장비를 장착해보자!!");
                        accept3 = true; // 퀘스트 수락 확인용 변수

                        QuestScroll(player);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("잘못된 입력입니다.");
                        ThirdQuest(false, character);
                        break;
                }
            }
            else // 퀘스트 완료
            {
                
                
                Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("퀘스트 : 장비를 장착해보자!! [조건 달성 완료]"); Thread.Sleep(500);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\r\n\r\n                ..;==!:,,,,             \r\n               .!=====$$$$$;            \r\n               .======$$$$$$            \r\n               .*=..::::..*$            \r\n                :=        !,            \r\n                 =        :             \r\n                 -                      \r\n                  ~                     \r\n                  *=:~~;$*              \r\n                  ~===$$$*              \r\n                  .;!*=!!,              \r\n              ~;;,.. ., ,.~;;-          \r\n          *=======..,  ,.-=$$$$$$;      \r\n        .!========!.  .  *$$$$$$$$*     \r\n      ...!=========*~*==*$$$$$$$$$-.    \r\n     .....============$$$$$$$$$$$=,.    \r\n    ......============$$$$$$$$$$$;..    \r\n   .......-===========$$$$$$$$$$$;..    \r\n  ......  .*==========$$$$$$$$$$$....   \r\n .....     :==========$$$$$$$$$$$.....  \r\n .....     :==========$$$$$$$$$$. ....  \r\n  .....    :==========$$$$$$$$$$  ....  \r\n   .....   :==========$$$$$$$$$$  ....  \r\n     ..... :==========$$$$$$$$$$   ...  \r\n       ....:==========$$$$$$$$$$   .... \r\n      .-,.. .!========$$$$$$$$$$   .... \r\n        .~   .!=======$$$$$$$$$$    ... \r\n              ,~*=====$$$$$$$$$$    ... \r\n             :;!*=====$$$$$$$$$$    ... \r\n           :==========$$$$$$$$$$    ... \r\n           :==========$$$$$$$$$$    ... \r\n.;;;;;;;;;;*==========$$$$$$$$$$!!!!!!!~\r\n.=====================$$$$$$$$$$$$$$$$$:\r\n.=====================$$$$$$$$$$$$$$$$$:\r\n.=====================$$$$$$$$$$$$$$$$$:\r\n.=====================$$$$$$$$$$$$$$$$$:\r\n.=====================$$$$$$$$$$$*;;;;;-\r\n");
                Console.ForegroundColor = ConsoleColor.Cyan;




                Console.SetCursorPosition(37, 20);
                Console.WriteLine($"\"{character.Name}\"!! 다시 보니 반갑네~"); Thread.Sleep(1500);
                Console.SetCursorPosition(37, 22);
                Console.WriteLine("그래 내 방패는 잘 맞는가?"); Thread.Sleep(1500);
                Console.SetCursorPosition(37, 24);
                Console.WriteLine("뭐라고?! 이딴 싸구려 방패를 왜 줬냐고?"); Thread.Sleep(1500);
                Console.SetCursorPosition(37, 26);
                Console.WriteLine("내가 다른 물건을 건네준 것 같구만.. 미안하네 제대로 챙겨주겠네"); Thread.Sleep(1500);

                Console.WriteLine();


                Console.SetCursorPosition(0, 44);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("======================================================================================================");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("퀘스트 목표 : 베테랑 모험가 [혁매님] 에게서 받은 낡은 수련용 방패를 인벤토리에서 장착하라! (1/1) 달성!\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("======================================================================================================");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("0. 나가기");
                Console.WriteLine("1. 퀘스트 완료");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.WriteLine(">>");

                do
                {
                    selectRight = int.TryParse(Console.ReadLine(), out selectAct);

                } while (!selectRight);

                switch (selectAct)
                {
                    case 0: // 나가기 버튼
                        Console.Clear();
                        QuestScroll(player);
                        break;
                    case 1: // 퀘스트 완료, 새방패 지급
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n어디 보자... 여기 있네. 내가 가장 소중히 여기는 방패니까 조심히 다루게나!!"); Thread.Sleep(2000);
                        player.ItemAmount_Change(new ItemData(3, "[혁매님]의 순찰방패", 0, 20, 5000, 1, "상대가 캠을 키지 않으면 이상한 노래가 나올것만 같은 무서운 방패"), 1);
                        Console.WriteLine("\n☆★ 보상 : [혁매님]의 순찰방패 , Exp + 5 ★☆\n");
                        player.stat.Exp += 5;
                        player.stat.isLevelUp();
                        complete3 = true; // 퀘스트완료
                        Console.WriteLine("[아이템 설명] : 상대가 캠을 키지 않으면 이상한 노래가 나올것만 같은 무서운 방패"); Thread.Sleep(3000);

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\n{player.Name} : [혁매님]의 순찰방패?....."); Thread.Sleep(1000);
                        Console.WriteLine($"{player.Name} : 뭐야 이게? 방패에 자신의 얼굴이 그려져있고, 설명도 이상하지만 나름 쓸만한 것 같군"); Thread.Sleep(6000);
                        Console.Clear();
                        Console.WriteLine("[퀘스트 완료] : 장비를 장착해보자!!");

                        QuestScroll(player);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("잘못된 입력입니다.");
                        ThirdQuest(false, character);
                        break;
                }
            }
        }

        public void ForthQuest()
        {
            Console.WriteLine("Quest!!");
            Console.WriteLine();
            Console.WriteLine("포션을 사용해보자");
            Console.WriteLine();
            Console.WriteLine("이봐, 자네 포션이라는 것은 아는가?");
            Console.WriteLine("전투에서 자네에게 큰 도움을 주는 소모품이라네");
            Console.WriteLine("전투에서 한번 포션을 사용해보게나");
            Console.WriteLine();
            Console.WriteLine("- 회복 포션 사용해보기");
            Console.WriteLine();
            Console.WriteLine("1. 수락");  //조건이 달성 되었을 때 보상받기로 변경 > 보상 받고 나서 사후처리
            Console.WriteLine("2. 거절");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine(">>");

            string select = Console.ReadLine();
            if (select == "1")
            {

            }
            else if (select == "2")
            {
                QuestScroll(player);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("\n ===== 잘못된 입력입니다.다시 입력해주세요 ===== ");
            }
        }
        public void QuestScroll(Player character)
        {
            player = character;
            Console.ForegroundColor = ConsoleColor.Cyan;
            QuestScreen();
            while (true)
            {
                string select = Console.ReadLine();
                if (select == "1") // 1번을 입력할 시 1번 퀘스트 진행
                {
                    
                    FirstQuest();
                }
                else if (select == "2") // 2번을 입력할 시 2번 퀘스트 진행
                {
                    if (complete2)
                    {
                        Console.WriteLine("이미 완료한 퀘스트입니다.");
                        QuestScroll(character);
                    }
                    
                    // 미니언카운트
                    Console.Clear();
                    SecondQuest(false, character);
                }
                else if (select == "3") // 3번을 입력할 시 3번 퀘스트 진행
                {
                    if (complete3)
                    {
                        Console.WriteLine("이미 완료한 퀘스트입니다.");
                        QuestScroll(character);
                    }
                    bool isEquip = false;
                    // 퀘스트를 수행했는지 체크

                    for (int i = 0; i < character.inven.ItemInfo.Count; i++)
                    {
                        
                        if (character.inven.ItemInfo[i].ItemName == "낡은 수련용 방패")
                        {
                            if (character.inven.ItemInfo[i].IsEquip)
                            {
                                isEquip = true;
                            }
                        }
                    }
                    Console.Clear();
                    ThirdQuest(isEquip, character);
                }
                else if (select == "4") // 4번을 입력할 시 4번 퀘스트 진행
                {
                    break;
                    //ForthQuest();
                }
                else if (select == "0") // -1번 입력할 시 메뉴화면
                {
                    Console.Clear();
                    player.program.SelectAct(player);
                }
                else // 이외 번호를 입력했다면 오류 문구 출력
                {
                    Console.WriteLine();
                    Console.WriteLine("\n ===== 잘못된 입력입니다.다시 입력해주세요 ===== ");
                }
            }
        }











    }
}
