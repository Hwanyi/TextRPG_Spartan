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
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    break;
            }

            if(somethingError)
            {
                Console.WriteLine("잘못된 입력입니다.\n");
                somethingError = false;
            }

            Console.Write(">>");
        }

        public void DoAction(string line)
        {
            switch (flag)
            {
                case -1:
                    player = new PlayerCharacter(line);
                    flag = 0;
                    break;
                case 0:
                    if (!int.TryParse(line, out InputNum) || (InputNum > 3 || InputNum < 0))
                    {
                        somethingError = true;
                        break;
                    }

                    if(!somethingError)
                        flag = InputNum;
                    
                    break;
            }
        }
    }

    public class PlayerCharacter
    {
        int level = 1;
        string name = "";
        float attack = 10f;
        float defense = 5f;
        float health = 100;
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
            gameManager.DoAction(line);
            
        }
    }
}