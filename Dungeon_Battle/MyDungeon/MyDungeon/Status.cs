using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDungeon
{
    public class Status
    {
        Player player;


        public int Level { get; set; }
        string Name { get; set; }
        public float Attack { get; set; }
        public int Defense { get; set; }
        public int Hp { get; set; }
        public float Gold { get; set; }

        public int MaxHp { get; set; }

        public int Exp { get; set; }

        public int AttackInc { get; set; }
        public int DefInc { get; set; }
        public string job { get; set; }


        

        public Status(string name, Player player1)
        {
            Name = name;
            Level = 1;
            Attack = 10;
            Defense = 8;
            Hp = 100;
            Gold = 1000;
            Exp = 0;
            MaxHp = 100;
            player = player1;
            AttackInc = 0;
            DefInc = 0;

        }

        public void Show_dungeon_stat()
        {


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================================================================");
            Console.WriteLine("             [현재 플레이어 상태]     \n");
            Console.WriteLine($"Lv. {Level}");
            Console.WriteLine($"{Name} ({job})");
            Console.WriteLine($"공격력 : {Attack}");
            Console.WriteLine($"방어력 : {Defense}");
            Console.WriteLine($"체 력 : {Hp} / {MaxHp}");
            Console.WriteLine($"치명타 확률 : {player.critical} + ({player.increaseCritical}) %");
            Console.WriteLine($"치명타 데미지 : {player.criticalDmg * 100} + ({player.increaseCritical}) %");
            Console.WriteLine($"회피율 : {player.avoid} + ({player.increaseAvoid}) %");
            Console.WriteLine($"Gold : {Gold}");
            Console.WriteLine("==================================================================\n\n");


        }
        public void Show_stat()
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\r\n ######  ########    ###    ######## ##     ##  ######  \r\n##    ##    ##      ## ##      ##    ##     ## ##    ## \r\n##          ##     ##   ##     ##    ##     ## ##       \r\n ######     ##    ##     ##    ##    ##     ##  ######  \r\n      ##    ##    #########    ##    ##     ##       ## \r\n##    ##    ##    ##     ##    ##    ##     ## ##    ## \r\n ######     ##    ##     ##    ##     #######   ######  \r\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n캐릭터의 정보가 표시됩니다.\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=================================");
            Console.WriteLine("             [상태창]           \n");
            Console.WriteLine($"Lv. {Level}");
            Console.WriteLine($"{Name} ({job})");
            Console.WriteLine($"공격력 : {Attack}");
            Console.WriteLine($"방어력 : {Defense}");
            Console.WriteLine($"체 력 : {Hp} / {MaxHp}");
            Console.WriteLine($"치명타 확률 : {player.critical} + ({player.increaseCritical}) %");
            Console.WriteLine($"치명타 데미지 : {player.criticalDmg * 100} + ({player.increaseCritical}) %");
            Console.WriteLine($"회피율 : {player.avoid} + ({player.increaseAvoid}) %");
            Console.WriteLine($"Gold : {Gold}");
            Console.WriteLine("=================================\n\n");

            
        }

        public void Show_stat(int atkinc, int definc)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n☆캐릭터의 정보가 표시됩니다.☆\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================================================================");
            Console.WriteLine("             [현재 플레이어 상태]           \n");
            Console.WriteLine($"Lv. {Level}");
            Console.WriteLine($"{Name} ({job})");

            DefInc = definc;
            AttackInc = atkinc;

            if (atkinc != 0)
            {
                Console.WriteLine($"공격력 : {Attack} + ({atkinc})");
            }
            else
            {
                Console.WriteLine($"공격력 : {Attack}");
            }
            if (definc != 0)
            {
                Console.WriteLine($"방어력 : {Defense} + ({definc})");
            }
            else
            {
                Console.WriteLine($"방어력 : {Defense}");
            }
            Console.WriteLine($"체 력 : {Hp} / {MaxHp}");

            if (player.increaseCritical == 0)
            {
                Console.WriteLine($"치명타 확률 : {player.critical} %");
            }
            else
            {
                Console.WriteLine($"치명타 확률 : {player.critical} + ({player.increaseCritical}) %");
            }

            if (player.increaseCriticalDmg == 0)
            {
                Console.WriteLine($"치명타 데미지 : {player.criticalDmg * 100} %");
            }
            else
            {
                Console.WriteLine($"치명타 데미지 : {player.criticalDmg * 100} + ({player.increaseCriticalDmg}) %");
            }

            if (player.increaseAvoid == 0)
            {
                Console.WriteLine($"회피율 : {player.avoid} %");
            }
            else
            {
                Console.WriteLine($"회피율 : {player.avoid} + ({player.increaseAvoid}) %");
            }

            Console.WriteLine($"Gold : {Gold} G");
            Console.WriteLine("==================================================================\n\n");


        }
        public void Show_stat(int atkinc, int definc, Player player)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n☆캐릭터의 정보가 표시됩니다.☆\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================================================================");
            Console.WriteLine("             [현재 플레이어 상태]           \n");
            Console.WriteLine($"Lv. {Level}");
            Console.WriteLine($"{Name} ({job})");

            DefInc = definc;
            AttackInc = atkinc;

            if (atkinc != 0)
            {
                Console.WriteLine($"공격력 : {Attack} + ({atkinc})");
            }
            else
            {
                Console.WriteLine($"공격력 : {Attack}");
            }
            if (definc != 0)
            {
                Console.WriteLine($"방어력 : {Defense} + ({definc})");
            }
            else
            {
                Console.WriteLine($"방어력 : {Defense}");
            }
            Console.WriteLine($"체 력 : {Hp} / {MaxHp}");

            if (player.increaseCritical == 0)
            {
                Console.WriteLine($"치명타 확률 : {player.critical} %");
            }
            else
            {
                Console.WriteLine($"치명타 확률 : {player.critical} + ({player.increaseCritical}) %");
            }

            if (player.increaseCriticalDmg == 0)
            {
                Console.WriteLine($"치명타 데미지 : {player.criticalDmg * 100} %");
            }
            else
            {
                Console.WriteLine($"치명타 데미지 : {player.criticalDmg * 100} + ({player.increaseCriticalDmg}) %");
            }

            if (player.increaseAvoid == 0)
            {
                Console.WriteLine($"회피율 : {player.avoid} %");
            }
            else
            {
                Console.WriteLine($"회피율 : {player.avoid} + ({player.increaseAvoid}) %");
            }

            Console.WriteLine($"Gold : {Gold} G");
            Console.WriteLine("==================================================================\n\n");


        }
        public void Stat_menu()
        {
            int act;
            bool actIsNum;
            Console.ForegroundColor = ConsoleColor.Green;
            do
            {
                Console.WriteLine("-1. 나가기");

                Console.Write("\n원하시는 행동을 숫자로 입력해주세요.\n");
                Console.Write(">>");
                actIsNum = int.TryParse(Console.ReadLine(), out act);
            } while (!actIsNum);

            switch (act)
            {
                case -1: // 바깥 메뉴로 가기
                    Console.WriteLine("\n\n");
                    Console.Clear();
                    break;


                default:
                    Console.WriteLine("\n=====잘못된 입력입니다. 다시 입력해주세요=====");
                    Console.Clear();
                    Show_stat();
                    Stat_menu();
                    break;
            }
        }

        public void isLevelUp() // 레벨업 검사
        {
            if (Exp >= 2 * Level) // 경험치가 최대치에 도달하면 레벨업 진행
            {
                Attack += 1f;
                Defense += 2;
                Exp -= 2* Level;
                Level += 1;
                
                MaxHp += 20;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{Name} 의 레벨이 상승했습니다!!\n");
                Console.WriteLine($"Lv. {Level - 1} -> {Level}");  
                Console.WriteLine($"공격력 {Attack - 1} -> {Attack}");
                Console.WriteLine($"방어력 {Defense-2} -> {Defense}\n");
                
            }
        }

    }
}
