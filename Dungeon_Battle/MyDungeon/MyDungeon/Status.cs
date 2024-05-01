using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDungeon
{
    public class Status
    {
        public Player player;


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


        

        public Status(string name)
        {
            Name = name;
            Level = 1;
            Attack = 10;
            Defense = 8;
            Hp = 100;
            Gold = 1000;
            Exp = 0;
            MaxHp = 100;
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
                    Show_stat();
                    Stat_menu();
                    break;
            }
        }

        public void isLevelUp() // 레벨업 검사
        {
            if (Exp == 2 * Level) // 경험치가 최대치에 도달하면 레벨업 진행
            {
                Attack += 0.5f;
                Defense += 1;
                Level += 1;
                Exp = 0;
                MaxHp += 20;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("레벨업!!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    }
}
