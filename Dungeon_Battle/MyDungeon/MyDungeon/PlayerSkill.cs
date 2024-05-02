using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDungeon
{
    static class PlayerSkill 
    {
        
        public static void OverHit(Player player, List<Monster> Monsters) // 스킬 오버 히트
        {
            int skilldamage = 0; // 스킬데미지 통일
            

            skilldamage = (int)(player.Critical() * 1.5f);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();

            for (int i = 40; i > 0; i--)
            {
                OverHitAction(i);
                Thread.Sleep(25);
            }
            Console.Clear();


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{player.Name} 의 심판!! [데미지 : {skilldamage}]");
            player.skillUsing = true;
            foreach (Monster monster in Monsters)
            {
                if (monster.Health > 0) // 몬스터가 죽지않았을 경우
                {
                    monster.TakeDamage(player, skilldamage);
                }
            }
            player.skillUsing = false;
        }

        public static void OverHitAction(int i) // 아스키아트 실행부분
        {                      
                Console.Clear();
            Console.SetCursorPosition(i, 0);

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("                                                   ...                "); Console.SetCursorPosition(i, 1);
            Console.WriteLine("                                   ,.      .~-    ~~!*-               "); Console.SetCursorPosition(i, 2);
            Console.WriteLine("                                   ,.     ~!:,  .;,*@:    ..~=;--.    " ); Console.SetCursorPosition(i, 3);
            Console.WriteLine("                                   ,..   !;#!. .~;*@=~.  ::;!$=~.     " ); Console.SetCursorPosition(i, 3);
            Console.WriteLine("                                   ,;-. :-*@!..::;@*;: ,;;!$@$~       " ); Console.SetCursorPosition(i, 4);
            Console.WriteLine("                                   -:!,.;:$=*,:;!$=:; :;:*=$!:.       " ); Console.SetCursorPosition(i, 5);
            Console.WriteLine("                                   -$!. ~~$*;,:!*=;~,~:~*@*;;.        " ); Console.SetCursorPosition(i, 6);
            Console.WriteLine("                               -  !-#=-$:*=::*:!$*;::!~=$!~-,         " ); Console.SetCursorPosition(i, 7);
            Console.WriteLine("                              .-, :~#**!;$=;!;!*=;~::;!$!~-.          " ); Console.SetCursorPosition(i, 8);
            Console.WriteLine("                              **;;;-#!;:!=;:-;=#!:~!:*$*:-.           " ); Console.SetCursorPosition(i, 9);
            Console.WriteLine("                             .-$=*;-#!~~!#!:-!$*:-!;*=#;~:            " ); Console.SetCursorPosition(i, 10);
            Console.WriteLine("                          .  ,-=@!;-#=;**@*:~!$*:-:!==!~;             " ); Console.SetCursorPosition(i, 11);
            Console.WriteLine("                          :~ ,:=@!:-=*:~!@*~-=#;~:;$!*;,              " ); Console.SetCursorPosition(i, 12);
            Console.WriteLine("                          :;;.~;=$~-*;;~*@!~~#=:,:*$#*:~              " ); Console.SetCursorPosition(i, 13);
            Console.WriteLine("                          =$$:$:*$*-!!!:=*!,*=#~,;$$*$:,              " ); Console.SetCursorPosition(i, 14);
            Console.WriteLine("                          =*@=;!;=!-;;~::@*-!@$:!$#*@=-.              " ); Console.SetCursorPosition(i, 15);
            Console.WriteLine("                        :-,!$#;:*!=-$~~==@*:$$=:$*=@$;-               " ); Console.SetCursorPosition(i, 16);
            Console.WriteLine("                        ==:;!*@;-!$-#=-$=#=;$@*:;=@;;:.               " ); Console.SetCursorPosition(i, 17);
            Console.WriteLine("                        ~=@*;*#@:,=-$$::*$;:$@!**$*;~.                " ); Console.SetCursorPosition(i, 18);
            Console.WriteLine("                        ,;##~~$@@!~-$*!;$$!:#@=!$;~;                  " ); Console.SetCursorPosition(i, 19);
            Console.WriteLine("                      .~.;*$@!!#@#;-*#::=@;;@@;$$!~,                  " ); Console.SetCursorPosition(i, 20);
            Console.WriteLine("                       ~=;:!#~:$=@*-*=*;!@*:=@*$=;;.                  " ); Console.SetCursorPosition(i, 21);
            Console.WriteLine("                       ,*#*!#=;:;#=-!=$*:#*;!$!;$;:                   " ); Console.SetCursorPosition(i, 22);
            Console.WriteLine("                        -*#$@$@*;!#-~!@!!~=;:$:;*-.                   " ); Console.SetCursorPosition(i, 23);
            Console.WriteLine("                       -:;**@!##~:*-!~;**~!~:=*:;~                    " ); Console.SetCursorPosition(i, 24);
            Console.WriteLine("                       .!;!;*#!##!~-=$;:!=*;*:;,,-                    " ); Console.SetCursorPosition(i, 25);
            Console.WriteLine("                        ,$@*=,-;$#=-~***:!~;,-,;.                     " ); Console.SetCursorPosition(i, 26);
            Console.WriteLine("                         -$$@$==:!=-*:-;!=,~~-:;:                     " ); Console.SetCursorPosition(i, 27);
            Console.WriteLine("                         --;$$$@=:~-**:$,,;.  :*$                     " ); Console.SetCursorPosition(i, 28);
            Console.WriteLine("                         -=*$!;**=;-:-;*!~    :!*,                    " ); Console.SetCursorPosition(i, 29);
            Console.WriteLine("                          .*#@$;,*;--;:--     :!!-                    " ); Console.SetCursorPosition(i, 30);
            Console.WriteLine("                           --*$$=$=-!-~-.     :;*#~                   " ); Console.SetCursorPosition(i, 31); Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("      ..,,--~~~::;;;!!!!****=#$#@@@-=##@####$$~;*@!~            .~:!  " ); Console.SetCursorPosition(i, 32);
            Console.WriteLine("   -:--,~~~~~::;!;;!**!!*!;;!!;;;;:-;;;;;!;;*!~;*@!$#=;--,,-,,--,:;:: " ); Console.SetCursorPosition(i, 33);
            Console.WriteLine("---~~-~-~~~~--~~~--~~~~~~~--~~-~~-,,~~~~::~:::~~::~;;::~:~~:~~::~~~~~-" ); Console.SetCursorPosition(i, 34);
            Console.WriteLine(",,,-,--,,-,,,,,,,,----~--~~~------,.-~~~~~~~~~--~~--,,-------------,-," ); Console.SetCursorPosition(i, 35);
            Console.WriteLine("   ,::~,.,--~,..,.~~~-~-------~---,.~:::~-~---~:*#~!:;:-,,,,,..,,;~,~ " ); Console.SetCursorPosition(i, 36);
            Console.WriteLine("    ..,,,,---------,,,,,,,...-,--~~,-~~:~:::::~~;$,:            .-,~  " ); Console.SetCursorPosition(i, 37); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                           .~!*$$$#-!:-~      ~~~;-                   " ); Console.SetCursorPosition(i, 38);
            Console.WriteLine("                          .*$#@;,$!-:!!-:     ~-;,                    " ); Console.SetCursorPosition(i, 39);
            Console.WriteLine("                         ,*=@*;*!*=-~~:;;:    :,!.                    " ); Console.SetCursorPosition(i, 40);
            Console.WriteLine("                         --~*#$#=~:-!#!#-.;   : ;                     " ); Console.SetCursorPosition(i, 41);
            Console.WriteLine("                         -#*#$$$;;*~*!,::=-;,---~                     " ); Console.SetCursorPosition(i, 42);
            Console.WriteLine("                        .#@=$~:~!$=-~:*$;$-!,--~                      " ); Console.SetCursorPosition(i, 43);
            Console.WriteLine("                        ==*!;=:##*~-$#!~~:*!=~:,,-                    " ); Console.SetCursorPosition(i, 44);
            Console.WriteLine("                       -:;!*#*=#~~*-=;:*:;;-:=!:;~                    " ); Console.SetCursorPosition(i, 45);
            Console.WriteLine("                        -;$#$=@=;;$-:;$$!~!::$;:*,                    " ); Console.SetCursorPosition(i, 46);
            Console.WriteLine("                       .!#$!#$*:;$#-:$==:==!;=!:#;;                   " ); Console.SetCursorPosition(i, 47);
            Console.WriteLine("                       ~*$;:$~~=$#*-!==!*@!:*@*$*!;                   " ); Console.SetCursorPosition(i, 48);
            Console.WriteLine("                      .-,;!*#!*$@#!-!#!:=@!;##:$=;~,                  " ); Console.SetCursorPosition(i, 49);
            Console.WriteLine("                        .~$@;~=#@!~-$=!:$$;~#@**#;:-                  " ); Console.SetCursorPosition(i, 50);
            Console.WriteLine("                        -$@=!*#@;,*-$$;:==::$@!!=$;;,                 " ); Console.SetCursorPosition(i, 51);
            Console.WriteLine("                        =$!!!$@:.~=-#=~!=#!;$@*;:$$;:,                " ); Console.SetCursorPosition(i, 52);
            Console.WriteLine("                        ;--*$$!;;=$-$:-**@!:$$=:#*=#=:.               " ); Console.SetCursorPosition(i, 53);
            Console.WriteLine("                        . ;=@=;*;=$-*-::!@=-!@=;!#==@*-.              " ); Console.SetCursorPosition(i, 54);
            Console.WriteLine("                          =$$:#:*$=-*:*:*=*,*$#~,!$$*$:.              " ); Console.SetCursorPosition(i, 55);
            Console.WriteLine("                          :;-.;;*$;-**;~*@!,~#!~.~*$$*:.              " ); Console.SetCursorPosition(i, 56);
            Console.WriteLine("                          :~ .~*@!:-*;:~!@*~~=#~~:;$!*:-              " ); Console.SetCursorPosition(i, 57);
            Console.WriteLine("                          .  ,-=@!:-$=:=!@*:~!$*:,~*==;~;             " ); Console.SetCursorPosition(i, 58);
            Console.WriteLine("                             .,$#*;-#;~~:#!:~;$=~~=;**=:,.            " ); Console.SetCursorPosition(i, 59);
            Console.WriteLine("                              !=!:;-#;:~!$;~-;=#!~~;;!=*;-            " ); Console.SetCursorPosition(i, 60);
            Console.WriteLine("                              ~~;.;-#*=!:$=!!;*=*;-*:!=$!~;.          " ); Console.SetCursorPosition(i, 61);
            Console.WriteLine("                               .  ;-#=~#:*=:~!:!#*:::;~$$:~:,         " ); Console.SetCursorPosition(i, 62);
            Console.WriteLine("                                   -=!.,~;$*:~~!!=:- -::=#;::         " ); Console.SetCursorPosition(i, 63);
            Console.WriteLine("                                   -;!. ;;$**,;;!$!:; -:;===:-.       " ); Console.SetCursorPosition(i, 64);
            Console.WriteLine("                                   ,::. ;-=@!..~:!@!:: ~~;!#@=~       " ); Console.SetCursorPosition(i, 65);
            Console.WriteLine("                                   , ,   :;#!. -~;=#*~  .:!:*#=-      " ); Console.SetCursorPosition(i, 66);
            Console.WriteLine("                                   ,      ~!;.  .~~$@~    ..*::~-     " ); Console.SetCursorPosition(i, 67);
            Console.WriteLine("                                   ,       :--    ;~*!:       .,,     " ); Console.SetCursorPosition(i, 68);
            Console.WriteLine("                                   ,         .     .,;~.              "); Console.SetCursorPosition(i, 69);
        }


        //도적 스킬
        public static void CriticalThrow(Player player, Monster monster) // 스킬 크리티컬 스로우
        {
            int skillDamage = (int)(player.Critical() * 1.8f);

            //연출...

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n{player.Name}의 크리티컬 스로우!! [데미지 : {skillDamage}]");
            player.skillUsing = true;
            if (monster.Health > 0)
                monster.TakeDamage(player, skillDamage);
            player.skillUsing = false;
        }

        public static void Avenger(Player player, List<Monster> Monsters)   // 스킬 어벤져
        {
            int skillDamage = (int)(player.Attack * 1.6f + 0.5f);

            //연출...

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n{player.Name}의 어벤져!! [데미지 : {skillDamage}]");
            player.skillUsing = true;
            foreach (Monster monster in Monsters)
            {
                if (monster.Health > 0)  //몬스터가 죽지 않으면
                    monster.TakeDamage(player, skillDamage);
            }
            player.skillUsing = false;
        }


        //궁수 스킬
        public static void SoulArrow(Player player, List<Monster> Monsters) // 스킬 소울 애로우 (여러 대상)
        {
            int index = 0;  // foreach인덱스

            bool isRightIndex;
            int selectMonster;  // 몬스터 선택지

            int firstMonsterIndex; //대상 몬스터의 첫주변
            int lastMonsterIndex;   //대상 몬스터의 막주변
            do
            {
                Console.WriteLine("\n[ 스킬 : 소울 애로우 ]");
                //대상을 선택
                Console.WriteLine("[ 대상을 선택하세요 ]");
                index = 0;
                foreach (Monster m in Monsters)
                {
                    Console.Write($"{index++}. ");
                    m.PrintMonster();
                }
                Console.Write(">> ");

                isRightIndex = int.TryParse(Console.ReadLine(), out selectMonster);
                if (selectMonster >= Monsters.Count || selectMonster < 0)//입력 숫자 범위를 벗어나면
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("숫자를 제대로 입력해주세요");
                    isRightIndex = false;
                }
                else if (Monsters[selectMonster].IsDead) //몬스터가 이미 죽으면
                {
                    Console.Clear();
                    Console.WriteLine("해당 몬스터는 이미 사망했습니다.");
                    isRightIndex = false;
                }
            }
            while (!isRightIndex);

            //딜 시작
            int skillDamage = (int)(player.Critical() * 1.4f + 1.7f);

            //연출..

            Console.Clear();    //여기서 콘솔창 갱신
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n{player.Name}의 소울 애로우!! [데미지 : {skillDamage}]");
            player.skillUsing = true;
            firstMonsterIndex = selectMonster == 0 ? 0 : selectMonster - 1; //selectMonster가 첫 인덱스이면 0
            lastMonsterIndex = selectMonster == Monsters.Count - 1 ? Monsters.Count - 1 : selectMonster + 1; //selectMonster가 마지막 인덱스이면 마지막

            //선택한 몬스터와 옆에 주변 몬스터들도 같이 공격
            //예) 2번을 선택하면 1, 2, 3번의 인덱스의 몬스터를 공격
            player.skillUsing = true;
            for(int i= firstMonsterIndex;i<= lastMonsterIndex; i++)
            {
                if (Monsters[i].IsDead)
                {
                    Console.WriteLine("\n해당 몬스터는 이미 사망했습니다.");
                    continue;
                }
                if (Monsters[i].Health > 0)
                    Monsters[i].TakeDamage(player, skillDamage);
            }
            player.skillUsing = false;
        }


        //마법사 스킬
        public static void Heal(Player player)  // 스킬 힐 (패시브)
        {
            //플레이어의 체력을 회복
            int healPower = player.stat.MaxHp / 10;
            player.Health += healPower;

            player.skillUsing = true;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{player.Name}의 갓 블레스 힐!! [체력 : +{healPower}]");
            player.skillUsing = false;
        }
        public static void ShiningRay(Player player, List<Monster> Monsters)    //샤이닝 레이
        {
            int selectMonster;  // 몬스터 선택 대상
            bool isRightMonster;    //숫자가 제대로 입력 되었는지
            int index = 0;  //foreach선택
            do
            {
                Console.WriteLine("\n[ 스킬 : 샤이닝 레이 ]");
                Console.WriteLine("[ 대상을 선택하세요 ]");
                index = 0;  //인덱스 초기
                foreach (Monster m in Monsters)
                {
                    Console.Write($"{index++}. ");
                    m.PrintMonster();
                }
                isRightMonster = int.TryParse(Console.ReadLine(), out selectMonster);
                if (selectMonster < 0 || selectMonster >= Monsters.Count) //해당 범위를 벗어나면
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("숫자를 제대로 입력해주세요");
                    isRightMonster = false;
                }
                else if (Monsters[selectMonster].IsDead)
                {
                    Console.Clear();
                    Console.WriteLine("해당 몬스터는 이미 사망했습니다.");
                    isRightMonster = false;
                }
            }
            while (!isRightMonster);

            //딜 시작
            int skillDamage = (int)(player.Attack * 1.5f + 1.2f);

            //연출

            Console.Clear();    //여기서 콘솔창 갱신
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{player.Name}의 샤이닝 레이!! [데미지 : {skillDamage}]");
            player.skillUsing = true;
            index = 0;
            foreach (Monster m in Monsters)
            {
                if (m.IsDead)
                {
                    Console.WriteLine("\n해당 몬스터는 이미 사망했습니다.");
                    continue;   //이미 죽으면 넘어가는걸로
                }
                if (index == selectMonster) //선택 대상은 크리티컬 추가 어택
                    m.TakeDamage(player, skillDamage + player.Critical());
                else
                    m.TakeDamage(player, skillDamage);
                index++;
            }
            player.skillUsing = false;
        }
    }
}
