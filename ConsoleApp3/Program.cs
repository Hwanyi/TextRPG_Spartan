class Program
{
    public class GameManager
    {
        private PlayerCharacter player = null;
        private int flag; // current state;
        private bool somethingError = false;
        public int InputNum;

        public GameManager()
        {
            flag = -1;
        }

        public void ShowDialog()
        {
            Console.Clear();
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");

            switch (flag)
            {
                case -1: 
                    Console.WriteLine("원하시는 이름을 설정해주세요.");
                    break;
                case 0:
                    Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                    Console.WriteLine("1. 상태 보기");
                    Console.WriteLine("2. 인벤토리");
                    Console.WriteLine("3. 상점\n");
                    Console.WriteLine("원하시는 행동을 입력해주세요.\n");
                    break;
                case 1:
                    Console.WriteLine("상태 보기");
                    Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
                    player.ShowInfo();
                    Console.WriteLine();
                    Console.WriteLine("0. 나가기\n");
                    Console.WriteLine("원하시는 행동을 입력해주세요.\n");
                    break;

            }

            if(somethingError)
            {
                Console.WriteLine("잘못된 입력입니다.\n");
                somethingError = false;
            }

            Console.Write(">> ");
        }

        private void MakeCharacter(string line)
        {
            string temp;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"입력하신 이름은 {line} 입니다.\n");

                Console.WriteLine("1. 저장");
                Console.WriteLine("2. 취소\n");

                if (somethingError)
                {
                    Console.WriteLine("잘못된 입력입니다.\n");
                    somethingError = false;
                }

                Console.Write(">> ");
                temp = Console.ReadLine();

                if (!int.TryParse(temp, out InputNum))
                {
                    somethingError = true;
                    continue;
                }

                if(InputNum == 1)
                    break;
                else if (InputNum == 2)
                    return;
                else 
                    somethingError = true;
                
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("직업을 선택해주세요\n");
                Console.WriteLine("1. 전사");
                Console.WriteLine("2. 도적\n");

                if (somethingError)
                {
                    Console.WriteLine("잘못된 입력입니다.\n");
                    somethingError = false;
                }

                Console.Write(">> ");

                temp = Console.ReadLine();

                if (!int.TryParse(temp, out InputNum))
                {
                    somethingError = true;
                    continue;
                }

                if(InputNum == 1 || InputNum == 2)
                {
                    flag = 0;
                    break;
                }
                else
                {
                    somethingError = true;
                    continue;
                }
            }

            player = new PlayerCharacter(line); //나중에 1, 2에 따라 직업 변경

        }

        public void DoAction(string line)
        {
            switch (flag)
            {
                case -1:
                    MakeCharacter(line);
                    break;
                case 0:
                    if (!int.TryParse(line, out InputNum) || (InputNum > 3 || InputNum < 1))
                    {
                        somethingError = true;
                        return;
                    }

                    if(!somethingError)
                        flag = InputNum;
                    
                    break;
                case 1:
                    if (!int.TryParse(line, out InputNum) || InputNum != 0)
                    {
                        somethingError = true;
                        return;
                    }

                    if (!somethingError)
                        flag = InputNum;
                    break;
            }
        }
    }

    public class PlayerCharacter
    {
        int level = 1;
        string name = "";
        int attack = 10;
        int defense = 5;
        int health = 100;
        int gold = 1500;

        public PlayerCharacter(string name) 
        {
            if (name == null)
            {
                this.name = "";
                return;
            }
            this.name = name;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Lv : {0}", level);
            Console.WriteLine("{0}", name);
            Console.WriteLine("공격력 : {0}", attack);
            Console.WriteLine("방어력 : {0}", defense);
            Console.WriteLine("체 력 : {0}", health);
            Console.WriteLine("GOLD : {0}", gold);
        }
    }

    static void Main(string[] args)
    {
        GameManager gameManager = new GameManager();
        string line;

        while(true)
        {
            gameManager.ShowDialog();
            
            line = Console.ReadLine();
            Console.WriteLine();

            gameManager.DoAction(line);
            
        }
    }
}