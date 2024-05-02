using System;
using System.Collections.Generic;
using System.Linq;
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

            
            Console.WriteLine("\r\n #######  ##     ## ########  ######  ######## #### #### \r\n##     ## ##     ## ##       ##    ##    ##    #### #### \r\n##     ## ##     ## ##       ##          ##    #### #### \r\n##     ## ##     ## ######    ######     ##     ##   ##  \r\n##  ## ## ##     ## ##             ##    ##              \r\n##    ##  ##     ## ##       ##    ##    ##    #### #### \r\n ##### ##  #######  ########  ######     ##    #### #### \r\n");
            Console.WriteLine();
            Console.WriteLine("1. 마을을 위협하는 미니언 처치");
            Console.WriteLine("2. 마을을 위협하는 공허충 처치");
            Console.WriteLine("3. 장비를 장착해보자");
            Console.WriteLine("4. 포션을 사용해보자");
            Console.WriteLine("-1 돌아가기");
            Console.WriteLine();
            Console.WriteLine();
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
        public void SecondQuest() // 두번쨰 퀘스트
        {
            Console.Clear();
            Console.WriteLine("Quest!!");
            Console.WriteLine();
            Console.WriteLine("마을을 위협하는 공허충 처치");
            Console.WriteLine();
            Console.WriteLine("이봐! 마을 근처에 공허충들이 너무 많아졌다고 생각하지 않나?");
            Console.WriteLine("마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!");
            Console.WriteLine("모험가인 자네가 좀 처치해주게");
            Console.WriteLine();
            Console.WriteLine("- 공허충 5마리 처치 (0/5)"); // 0/5 카운트 넣기
            Console.WriteLine();
            Console.WriteLine("- 보상 -"); // 보상 구현하기
            Console.WriteLine("아이템");
            Console.WriteLine("골드");
            Console.WriteLine();
            Console.WriteLine("1. 수락"); // 0/5 조건이 달성 되었을 때 보상받기로 변경 > 보상 받고 나서 사후처리
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
        public void ThirdQuest(bool complete) //세번째 퀘스트
        {

            if (!complete) // 퀘스트 완료전
            {
                Quest check = new Quest();
                ThirdQuestCheck(); // 퀘스트 성공 여부 확인
                //Console.Clear();
                Console.WriteLine("Quest!!");
                Console.WriteLine();
                Console.WriteLine("장비를 장착해보자");
                Console.WriteLine();
                Console.WriteLine("자네 장비는 장착할 줄 아는가?");
                Console.WriteLine("장비는 전투에서 없어서는 안될 중요한 아이템이라네");
                Console.WriteLine("자네에게 장비를 장착하는 방법을 알려 주겠네");
                Console.WriteLine("내가 낡은 수련용 방패를 자네에게 주었으니 인벤토리에서 낡은 방패를 장착해오게");
                Console.WriteLine();
                Console.WriteLine("- 낡은 수련용 방패 장착하기");
                Console.WriteLine();

                Console.WriteLine("0. 나가기");
                Console.WriteLine("1. 수락");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.WriteLine(">>");

                do
                {
                    selectRight = int.TryParse(Console.ReadLine(), out selectAct);
                    Console.Clear();
                } while (!selectRight);

                switch (selectAct)
                {
                    case 0:
                        QuestScroll(player);
                        break;
                    case 1:
                        player.ItemAmount_Change(new ItemData(3, "낡은 수련용 방패", 0, 2, 50, 1, "가벼운 공격은 막을 수 있지만 성능이 좋아 보이진 않는다."), 1);
                        
                        check.accept = true; // 낡은 수련용 방패 지급 구현해야함
                        Console.Clear();
                        Console.WriteLine("낡은 수련용 방패 지급 완료!");
                        QuestScroll(player);
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        ThirdQuest(false);
                        break;
                }
            }
            else // 퀘스트 완료
            {
                Console.Clear();
                Console.WriteLine("완료");
                Console.ReadLine();
                QuestScroll(player);
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
                    // 미니언카운트
                    SecondQuest();
                }
                else if (select == "3") // 3번을 입력할 시 3번 퀘스트 진행
                {
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
                    ThirdQuest(isEquip);
                }
                else if (select == "4") // 4번을 입력할 시 4번 퀘스트 진행
                {
                    break;
                    //ForthQuest();
                }
                else if (select == "-1") // -1번 입력할 시 메뉴화면
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
