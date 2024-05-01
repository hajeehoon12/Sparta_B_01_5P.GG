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
                monster.TakeDamage(player, skilldamage);
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










    }
}
