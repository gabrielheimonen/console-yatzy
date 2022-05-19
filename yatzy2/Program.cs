/*
    Lektion ett: Jag började med start menyn och funderade över hur jag ska få spelet att fungera, tänkte över processen, vad jag ska göra när osv.
    Jag hade svårigheter i början att komma igång med arbetet men fick lite hjälp i starten av alfons vilket gjorde att jag kom igång. Han hjälpte
    mig med hur jag skulle tänka samt hur jag skulle lägga allting i rätt klass för att få det så lätt användligt som möjligt. Sedan har jag 
    gjort en stor del av projektet hård kodat. Jag raderade allting och började om då tänkte jag lite mer och använde mig av klasser ännu mer 
    för att förenkla spel processen och få det att se bättre ut. Då kom problem nummer två jag hade 
    

*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace yatzy2
{
    class Program
    {
        static void Main(string[] args)
        {
           
            game game = new game();

            Console.WriteLine("Välkommen till Gabriels yatzi");
            
            while (true)
            {
                Console.WriteLine("Hur många personer är ni som spelar? (skriv med siffror)");
                string spelare = Console.ReadLine();
                if(int.TryParse(spelare, out int players))
                {
                    switch (Convert.ToInt32(spelare)) // switch:en är där man väljer hur många spelare det är som spelar
                    {
                        case 1:
                            Console.WriteLine("Du kan tyvärr inte spela ensam.");
                            break;
                        case 2:
                            game.gameStart(players);
                            break;
                        case 3:
                            game.gameStart(players);
                            break;     
                        case 4:        
                            game.gameStart(players);
                            break;
                    }
                }
            }
        }
    }
   
    public class game
    {
        board board = new board();
        dice dice = new dice();
        public void gameStart(int spelare)
        {
            while (true)
            {
                for (int playerNumber = 1; playerNumber < spelare; playerNumber++)
                {
                    int talInt = 0;
                    int radInt = 0;
                    Console.WriteLine("Okej då startar vi spelet");
                    board.showTable();
                    dice.diceThrow();
                    Console.WriteLine();
                    while (true)
                    {
                        Console.WriteLine("Hur många poäng har du?");
                        string tal = Console.ReadLine();
                        Console.WriteLine("Vad väljer du för rad?");
                        string rad = Console.ReadLine();
                        Console.WriteLine("Var vill du lägga poängen och hur mycket fick du?");
                        if (int.TryParse(tal, out talInt) && int.TryParse(rad, out radInt)) break;
                    }
                    board.addPoint(playerNumber, talInt, radInt - 1); // Jag lägger till poäng i brädan anledningen till att jag har -1 är för att den ska ta värdet man skriver in -1 för att den inte ska ta index värdet och det ska bli lättare att lägga rätt poäng på rätt ställe.
                }
            }
        }
    }

    public class dice 
    {
        public void diceThrow() { 
            int[] dices = { 0, 0, 0, 0, 0 };
            for (int i = 0; i < dices.Length; i++)
            {
                Random randomDice = new Random();
                 dices[i] = randomDice.Next(1, 7);
            }
            for(int i = 0; i < dices.Length; i++)
            {
                Console.WriteLine(dices[i]);
            }
            
            bool[] diceroll = { false, false, false, false, false };

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int input) && input < 6 && input > 0)
                {
                    diceroll[input - 1] = !diceroll[input - 1];
                    Console.Write(diceroll[input-1]);
                }
                else break;

            }
            Console.WriteLine();
            for (int i = 0; i < diceroll.Length; i++)
            {
                if (diceroll[i])
                {
                    Random rnd = new Random();
                    dices[i] = rnd.Next(1, 7);
                    diceroll[i] = false;
                }
                Console.Write(dices[i]);
            }
            Console.WriteLine();
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int input) && input < 6 && input > 0)
                {
                    diceroll[input - 1] = !diceroll[input - 1];
                    Console.Write(diceroll[input - 1]);
                }
                else break;

            }
            Console.WriteLine();
            for (int i = 0; i < diceroll.Length; i++)
            {
                if (diceroll[i])
                {
                    Random rnd = new Random();
                    dices[i] = rnd.Next(1, 7);
                }
                Console.Write(dices[i]);
            }
        }
    }
    public class board
    {
        //allting som är döpt med ett "p" före står för player

        int[] player1 = new int[14];
        int[] player2 = new int[14];
        int[] player3 = new int[14];
        int[] player4 = new int[14];
        string[] pboard =
            {
                "Ettor:       ",
                "Tvåor:       ",
                "Treor:       ",
                "Fyror:       ",
                "Femmor:      ",
                "Sexor:       ",
                "Ett Par:     ",
                "Två Par:     ",
                "Tretal:      ",
                "Fyrtal:      ",
                "Liten stege: ",
                "Stor stege:  ",
                "Kåk:         ",
                "Yatzy:       ",
            };
        public void showTable()
        {
            for (int p = 0; p < pboard.Length; p++)
            {
                Console.WriteLine(pboard[p] + player1[p] + " " + player2[p] + " " + player3[p] + " " + player4[p]);
            }
        }
        public void addPoint(int player, int points, int row)
        {
            switch (player)
            {
                case 1:
                    player1[row] = points;
                    break;
                case 2:
                    player2[row] = points;
                    break;
                case 3:
                    player3[row] = points;
                    break;
                case 4:
                    player4[row] = points;
                    break;
            }
        }
        public void printBoardPoints(int i)
        {
            int one = 0;
            int two = 0;
            int three = 0;
            int four = 0;
            int five = 0;
            int six = 0;

            int one2 = 0;
            int two2 = 0;
            int three2 = 0;
            int four2 = 0;
            int five2 = 0;
            int six2 = 0;

            string[] pboard =
            {
                "Spelare__",
                "Ettor__",
                "Tvåor__",
                "Treor__",
                "Fyror__",
                "Femmor__",
                "Sexor__"
            };
            int[] player =
            {
                one,
                two,
                three,
                four,
                five,
                six
            };
            int[] player2 =
            {
                one2,
                two2,
                three2,
                four2,
                five2,
                six2
            };
        }
    }
}
