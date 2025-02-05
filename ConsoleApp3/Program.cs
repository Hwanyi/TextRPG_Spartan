using static Program;

class Program
{
    public class GameManager
    {
        private PlayerCharacter player = null;
        private int flag; // current state;
        private bool somethingError = false;
        public int InputNum;
        public List<Items> storeItem;

        public GameManager()
        {
            flag = -1;
            storeItem = new List<Items>();
            storeItem.Add(new Items("수련자 갑옷", 1000, "수련에 도움이 되는 갑옷입니다.", 2, 5));
            storeItem.Add(new Items("무쇠갑옷", 2000, "무쇠로 만들어져 튼튼한 갑옷입니다.", 2, 9));
            storeItem.Add(new Items("스파르타의 갑옷", 3500, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 2, 15));
            storeItem.Add(new Items("낡은 검", 600, "쉽게 볼 수 있는 낡은 검 입니다.", 1, 2));
            storeItem.Add(new Items("청동 도끼", 1500, "어디선가 사용됐던 거 같은 도끼입니다.", 1, 5));
            storeItem.Add(new Items("스파르타의 창", 3000, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 1, 7));
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
                case 2:
                    Console.WriteLine("인벤토리");
                    Console.WriteLine("보유 중인 아이템을 관리 할 수 있습니다.\n");
                    Console.WriteLine("[아이템 목록]");
                    player.ShowItems(flag);
                    Console.WriteLine();
                    Console.WriteLine("1. 장착 관리");
                    Console.WriteLine("2. 나가기\n");
                    break;
                case 3:
                    Console.WriteLine("상점");
                    Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
                    Console.WriteLine("[보유 골드]");
                    Console.WriteLine("{0} G\n", player.gold);
                    Console.WriteLine("[아이템 목록]");
                    
                    
                    foreach(Items item in storeItem)
                    {
                        Console.Write(" -");
                        item.ShowInfo();
                    }

                    Console.WriteLine();
                    Console.WriteLine("1. 아이템 구매");
                    Console.WriteLine("0. 나가기\n");
                    break;
                case 21: //from case 2
                    Console.WriteLine("인벤토리 - 장착 관리");
                    Console.WriteLine("보유 중인 아이템을 관리 할 수 있습니다.\n");
                    Console.WriteLine("[아이템 목록]");
                    player.ShowItems(flag);
                    Console.WriteLine();
                    
                    Console.WriteLine("0. 나가기\n");
                    break;
                case 31: //from case 3
                case 32:
                case 33:
                case 34:
                    Console.WriteLine("상점 - 아이템 구매");
                    Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
                    Console.WriteLine("[보유 골드]");
                    Console.WriteLine("{0} G\n", player.gold);
                    Console.WriteLine("[아이템 목록]");

                    int count = 1;
                    foreach (Items item in storeItem)
                    {
                        Console.Write(" - ({0})",item.alreadyGet?"[구입완료]":count);
                        count++;
                        item.ShowInfo();
                    }

                    Console.WriteLine();
                    Console.WriteLine("0. 나가기\n");
                    break;
                default:
                    Console.WriteLine("미구현입니다. 아무거나 입력하면 돌아갑니다.\n");
                    break;
            }

            if(somethingError)
            {
                Console.WriteLine("잘못된 입력입니다.\n");
                somethingError = false;
            }

            if(flag == 32)
            {
                Console.WriteLine("이미 구매한 아이템입니다.\n");
                flag = 31;
            }

            if(flag == 33)
            {
                Console.WriteLine("구매를 완료했습니다.\n");
                flag = 31;
            }

            if(flag == 34)
            {
                Console.WriteLine("Gold가 부족합니다.\n");
                flag = 31;
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

            player = new PlayerCharacter(line, InputNum); //나중에 1, 2에 따라 직업 변경

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
                case 2:
                    if (!int.TryParse(line, out InputNum) || !(InputNum == 1 || InputNum == 2))
                    {
                        somethingError = true;
                        return;
                    }

                    if (InputNum == 1)
                        flag = 21;
                    else
                        flag = 0;
                    break;
                case 3:
                    if (!int.TryParse(line, out InputNum) || !(InputNum == 1 || InputNum == 0))
                    {
                        somethingError = true;
                        return;
                    }

                    if (InputNum == 1)
                        flag = 31;
                    else
                        flag = 0;
                    break;
                case 21:
                    if (!int.TryParse(line, out InputNum))
                    {
                        somethingError = true;
                        return;
                    }
                    if (InputNum == 0)
                    {
                        flag = 0;
                        break;
                    }
                    if(InputNum > player.items.Count || InputNum < 0)
                    {
                        somethingError = true;
                        return;
                    } else
                    {
                        player.EquipItem(InputNum - 1);
                        return;
                    }
                    break;
                case 31: //default store
                case 32: //already get
                case 33: //success buy
                case 34: //no money
                    if (!int.TryParse(line, out InputNum))
                    {
                        somethingError = true;
                        return;
                    }

                    if (InputNum < 0 || InputNum > storeItem.Count)
                    {
                        somethingError = true;
                        return;
                    }

                    if (InputNum == 0)
                    {
                        flag = 0;
                        break;
                    }

                    player.BuyItems(storeItem[InputNum - 1], ref flag);
                    

                    break;
                default:

                    flag = 0;
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
        public int gold = 1500;
        int job;

        public List<Items> items;
        int addictionAttack = 0;
        int addictionDefense = 0;

        public PlayerCharacter(string name, int job) 
        {
            if (name == null)
            {
                this.name = "";
                return;
            }
            this.name = name;
            this.job = job;
            items = new List<Items>();
        }

        public void ShowInfo()
        {
            Console.WriteLine("Lv : {0}", level);
            Console.WriteLine("{0} ( {1} )", name, (job == 1)?"전사":"도적");
            Console.WriteLine("공격력 : {0} {1}", attack, (addictionAttack > 0)?$"(+{addictionAttack})":"");
            Console.WriteLine("방어력 : {0} {1}", defense, (addictionDefense > 0) ? $"(+{addictionDefense})" : "");
            Console.WriteLine("체 력 : {0}", health);
            Console.WriteLine("GOLD : {0}", gold);
        }

        public void ShowItems(int flag)
        {
            int count = 1;
            foreach (Items item in items)
            {
                Console.Write(" -");
                if(flag == 21 || flag == 31)
                {
                    Console.Write(" ({0})", count++);
                }
                Console.Write(" {0}{1}\t| {2} +{3} | '{4}'\t ",item.isEquip?"[E]":"", item.name, (item.type == 1) ? "공격력" : "방어력", item.increaseValue, item.script);
                if(flag == 3 || flag == 31)
                {
                    Console.Write("| {0} ", item.price);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void EquipItem(int num)
        {
            items[num].isEquip = !items[num].isEquip;
            if (items[num].isEquip)
            {
                if (items[num].type == 1)
                    addictionAttack += items[num].increaseValue;
                else
                    addictionDefense += items[num].increaseValue;
            } 
            else
            {
                if (items[num].type == 1)
                    addictionAttack -= items[num].increaseValue;
                else
                    addictionDefense -= items[num].increaseValue;
            }
        }

        public bool BuyItems(Items item, ref int flag)
        {
            if(item.alreadyGet)
            {
                flag = 32;
                return false;
            }
            if(item.price > gold)
            {
                flag = 34;
                return false;
            }

            items.Add(item);
            gold -= item.price;
            item.alreadyGet = true;
            flag = 33;
            return true;
        }
    }

    public class Items
    {
        public bool isEquip;
        public string name;
        public int price;
        public string script;
        public int type; //1. attack 2. defense
        public int increaseValue;
        public bool alreadyGet;

        public Items(string name, int price, string script, int type, int increaseValue)
        {
            isEquip = false;
            this.name = name;
            this.price = price;
            this.script = script;
            this.type = type;
            this.increaseValue = increaseValue;
            alreadyGet = false;
        }
        public void ShowInfo()
        {
            
            Console.WriteLine(" {0}{1}\t| {2} +{3}\t| {4}\t| {5}G", isEquip ? "[E]" : "", name, (type == 1) ? "공격력" : "방어력", increaseValue, script, price);
           
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