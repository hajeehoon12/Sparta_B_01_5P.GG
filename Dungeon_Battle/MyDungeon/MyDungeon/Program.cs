using System.Numerics;
using System.Threading;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;


namespace MyDungeon
{

    public class Program
    {

        public void SavePlayerInfo(Player player) // 현재 플레이어 데이터 저장
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\r\n ######     ###    ##     ## ######## \r\n##    ##   ## ##   ##     ## ##       \r\n##        ##   ##  ##     ## ##       \r\n ######  ##     ## ##     ## ######   \r\n      ## #########  ##   ##  ##       \r\n##    ## ##     ##   ## ##   ##       \r\n ######  ##     ##    ###    ######## \r\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string _fileName = player.Name+".json"; // 저장할 파일명 지정
            //string _itemFileName = "itemData.json"; // 이후 추가 직렬화 할 데이터가 있으면 쓸 양식

            string _userGameFolder = System.IO.Directory.GetParent(System.Environment.CurrentDirectory).Parent.FullName;
            Console.WriteLine($"저장될 폴더 명 : {System.IO.Directory.GetParent(System.Environment.CurrentDirectory).Parent.FullName}");
            string _filePath = Path.Combine(_userGameFolder, _fileName);
            //string _itemFilePath = Path.Combine(_userGameFolder, _itemFileName);

            string _playerJson = JsonConvert.SerializeObject(player, Formatting.Indented);
            
            File.WriteAllText(_filePath, _playerJson);
            
            Console.WriteLine("저장이 완료되었습니다.");
            Console.WriteLine($"플레이어의 정보가 해당 경로로 지정되었습니다. :{_filePath}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★");

        }

        private void LoadGameData(Player player)
        {
            Console.WriteLine("\r\n##        #######     ###    ########  \r\n##       ##     ##   ## ##   ##     ## \r\n##       ##     ##  ##   ##  ##     ## \r\n##       ##     ## ##     ## ##     ## \r\n##       ##     ## ######### ##     ## \r\n##       ##     ## ##     ## ##     ## \r\n########  #######  ##     ## ########  \r\n");
            Console.WriteLine("불러올 플레이어명을 입력하세요.\n>>");
            string temp_name = Console.ReadLine();


            string _fileName = temp_name + ".json";

            string _userGameFolder = System.IO.Directory.GetParent(System.Environment.CurrentDirectory).Parent.FullName;

            

            string _filePath = Path.Combine(_userGameFolder, _fileName); // 저장된 파일의 예상 경로
            Console.WriteLine($"데이터를 찾는 폴더 명 : {_filePath}");
            if (File.Exists(_filePath)) // 해당 경로에 저장된 것이 있었으면
            {
                string _playerJson = File.ReadAllText(_filePath);
                player = JsonConvert.DeserializeObject<Player>(_playerJson);
                Console.WriteLine($"{temp_name} 의 게임 데이터를 불러옵니다."); // 저장된 플레이어 데이터의 플레이어명

                Thread.Sleep(1000);
                Console.WriteLine($"플레이어명 : {temp_name} 의 게임 데이터를 불러오는데 성공했습니다!!");
                Console.WriteLine("\r\n ######     ###    ##     ## ######## \r\n##    ##   ## ##   ##     ## ##       \r\n##        ##   ##  ##     ## ##       \r\n ######  ##     ## ##     ## ######   \r\n      ## #########  ##   ##  ##       \r\n##    ## ##     ##   ## ##   ##       \r\n ######  ##     ##    ###    ######## \r\n");
                SelectAct(player);

            }
            else
            {
                Console.WriteLine("\n☆해당 플레이어명으로 저장된 게임이 없습니다! 메인 메뉴로 돌아갑니다!☆");
                Console.WriteLine("★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★");

                Thread.Sleep(1000);

                SelectAct(player);
            }

            
        }


        public void SelectAct(Player player) // 메뉴 선택
        {

            int act; //메뉴
            bool actIsNum;


            
            do
            {
                switch (player.stat.Level) // 플레이어의 레벨에 따라 색상 변경
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case 7:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 8:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;
                    case 9:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;


                        break;
                
                }
                Console.WriteLine("\r\n\r\n    ;:     . .   .@@-            .    . \r\n  .#$@-    *@   ~$*=#:          :#@-    \r\n ;@= !#* ,#$~#, *;-;,#=,....  .;@~:#:   \r\n-=    -=.$*  #= @;.,. ,     .~$@~~-~@@, \r\n$::;;;;:.~ ....,..~--~-. . .~~.      .@ \r\n$-,,:..!=~,---~-.~-~,...--,- .:~-;~-:,# \r\n*~,,~,~#~~-~-~~-,,:::,,,...,,:$~--~~-,#~\r\n!,   .~*..  ..$;~~;~~-;:.... ,$:-,,,..@~\r\n!    ,*$,,~~,,$~-;!$;::$~!~~:~*!--, ~.#,\r\n*-,..-*~  ,:..$-~~.:*-~:*.--, .#~-, .,=,\r\n!-----#~ ~---~$-,-$$~,-:=,,.-,.$:--,--=-\r\n!,,,, $   ,. .=-~$@@@~~:*  ,- ,$~-,,..=-\r\n!,,:,.$   .- = *;@@@@:=:*  ,   $;~-,,-*,\r\n=;;~~:$   .~ -!~!@@@@;~;*  -   #!;!;;;=-\r\n=--,,,~    ,  ~..!::#~,:-  .   ~-----~-.\r\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\r\n##     ## #### ##       ##          ###     ######   ######## \r\n##     ##  ##  ##       ##         ## ##   ##    ##  ##       \r\n##     ##  ##  ##       ##        ##   ##  ##        ##       \r\n##     ##  ##  ##       ##       ##     ## ##   #### ######   \r\n ##   ##   ##  ##       ##       ######### ##    ##  ##       \r\n  ## ##    ##  ##       ##       ##     ## ##    ##  ##       \r\n   ###    #### ######## ######## ##     ##  ######   ######## \r\n");

                Console.WriteLine($"탐험가 ★{player.Name}★님 5P.GG 마을에 오신 여러분 환영합니다!!" +
                "\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n0. 모험가 길드\n1. 상태 보기 \n2. 인벤토리 \n3. 상점 \n4. 탐험 던전  \n5. 몬스터 던전");
                if (!player.quest.accept2 || player.quest.complete2) // 2번퀘스트를 받지않거나 클리어를 했다면
                {
                    Console.WriteLine("6. 휴식하기");
                }
                else // 진행중이라면
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("6. 휴식하기 (상남자의 길!! 퀘스트 패널티로 인해 사용불가)");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                Console.WriteLine("7. 저장하기 \n8. 불러오기 \n9. 게임종료 \n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n★원하시는 행동을 숫자로 입력해주세요★ : ");
                actIsNum = int.TryParse(Console.ReadLine(), out act);
                Console.Clear();
            } while (!actIsNum);
            Console.ForegroundColor = ConsoleColor.Green;
            switch (act)
            {
                case 1: // 상태보기
                    Console.WriteLine("\n☆상태보기가 선택되었습니다.☆");
                    player.CharInfo();
                    SelectAct(player);
                    break;
                case 2:
                    Console.WriteLine("\n☆인벤토리가 선택되었습니다.☆");
                    player.InvenInfo(player);
                    SelectAct(player);
                    break;
                case 3:
                    Console.WriteLine("\n☆상점이 선택되었습니다.☆");
                    player.MarketVisit(player);
                    SelectAct(player);
                    break;
                case 4:
                    Console.WriteLine("\n☆탐험 던전이 선택되었습니다.☆");
                    player.GoDungeon(player);
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n☆몬스터 던전이 선택되었습니다.☆");
                    player.BattleDungeon(player);
                    break;
                case 6: // 2번퀘스트 진행중이면 비활성화
                    if (player.quest.accept2 && !player.quest.complete2)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[상남자의 길!!] 퀘스트를 진행중이기에 휴식 기능을 사용하지 못합니다.");
                        player.program.SelectAct(player);
                    }
                    Console.WriteLine("\n☆휴식이 선택되었습니다.☆");
                    player.DoCamping(player);
                    break;
                case 7:
                    Console.WriteLine("\n☆저장이 선택되었습니다.☆");
                    // 저장하기 코드 입력할것
                    SavePlayerInfo(player);
                    SelectAct(player); // 저장하고 메인메뉴로 다시
                    break;
                case 8:
                    LoadGameData(player);
                    break;
                case 9:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\r\n ######      ###    ##     ## ########    ######## ##    ## ########  \r\n##    ##    ## ##   ###   ### ##          ##       ###   ## ##     ## \r\n##         ##   ##  #### #### ##          ##       ####  ## ##     ## \r\n##   #### ##     ## ## ### ## ######      ######   ## ## ## ##     ## \r\n##    ##  ######### ##     ## ##          ##       ##  #### ##     ## \r\n##    ##  ##     ## ##     ## ##          ##       ##   ### ##     ## \r\n ######   ##     ## ##     ## ########    ######## ##    ## ########  \r\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n☆게임 종료를 선택하셨습니다! 2초후에 종료됩니다!!☆");

                    
                    if (false) // 게임 종료 취소 조건 넣을 예정
                    {
                        Console.WriteLine("\n☆게임 종료를 취소했습니다!☆"); // 취소 후 메인화면으로 복귀
                        SelectAct(player);
                        
                    }
                    else
                    {
                        Environment.Exit(0); // 게임 종료
                    }
                    
                    break;
                case 0:
                    Console.WriteLine("☆모험가 길드를 선택하셨습니다.");
                    player.QuestAccept(player);

                    break;


                default:
                    Console.WriteLine("\n☆====잘못된 입력입니다. 다시 입력해주세요====☆");
                    SelectAct(player);
                    break;

            }
            SelectAct(player);
            
        }



        static void Main()
        {
            Console.SetWindowSize(120, 60);



            Console.Clear();
            

            string playerName;
            string playerjob;


             Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(0,15);
                       
            Console.WriteLine("                                    ..######..########.....##.....#######...########....##...." +
                         "\r\n                                   .##.....#.##.....##...##.##...##.....##....##......##.##.." +
                         "\r\n                                  .##.......##.....##..##...##..##.....##....##.....##...##." +
                         "\r\n                                 ..######..########..##.....##.########.....##....##.....##" +
                         "\r\n                                .......##.##........#########.##...##......##....#########" +
                         "\r\n                               .##....##.##........##.....##.##....##.....##....##.....##" +
                         "\r\n                              ..######..##........##.....##.##.....##....##....##.....##");
             
            Console.WriteLine("\r\n                            .########..##.....##.##....##..######...########..#######..##....##" +
                              "\r\n                           .##.....##.##.....##.###...##.##....##..##.......##.....##.###...##" +
                              "\r\n                          .##.....##.##.....##.####..##.##........##.......##.....##.####..##" +
                              "\r\n                         .##.....##.##.....##.##.##.##.##...####.######...##.....##.##.##.##" +
                              "\r\n                        .##.....##.##.....##.##..####.##....##..##.......##.....##.##..####" +
                              "\r\n                       .##.....##.##.....##.##...###.##....##..##.......##.....##.##...###" +
                              "\r\n                      .########...#######..##....##..######...########..#######..##....## \r\n\n");

            

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(29, 35);
            Console.Write("☆게임을 플레이할 플레이어의 이름을 적으세요☆ : ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            playerName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(30, 38);
            Console.WriteLine("1. 전사 (최대체력 + 20 , 방어력 + 3)\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(30, 40);
            
            Console.WriteLine("2. 마법사 (공격력 + 10 , 치명타 확률 + 10 , 최대체력 - 20)\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(30, 42);
            
            Console.WriteLine("3. 궁수 (공격력 + 5 , 치명타 확률 + 15, 치명타 데미지 + 15)\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(30, 44);
            
            Console.WriteLine("4. 도적 (치명타 확률 + 10, 치명타 데미지 + 10, 회피율 + 10)\n");
            Console.SetCursorPosition(29, 46);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("☆게임을 플레이할 플레이어의 직업을 선택해주세요☆ : ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            playerjob = Console.ReadLine();
            if (playerjob == "1")
            {
                playerjob = "전사";
            }
            else if (playerjob == "2")
            {
                playerjob = "마법사";
            }
            else if (playerjob == "3")
            {
                playerjob = "궁수";
            }
            else if (playerjob == "4")
            {
                playerjob = "도적";
            }
            else
            {
                Console.WriteLine("\n입력값이 올바르지 않습니다. 플레이어의 직업이 전사로 고정됩니다.");
                playerjob = "전사";
            }

            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();
            Console.WriteLine($"\n\n=======당신의 플레이어 닉네임 : {playerName}======= \n\n");

            Player player = new Player(playerName);
            player.stat.job = playerjob; // 캐릭터 직업설정
            player.PlayerSet(); // 직업별 능력치 부여

            Program program = new Program();
            program.SelectAct(player);
        }
    }
}
