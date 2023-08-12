using System;
class Program
{
    static void Main(string[] args)
    {
        // Объявление переменных
        int playerHealth = 100;
        int playerEnergy = 100;
        int catHealth = 100;
        int catEnergy = 100;
        int day = 1;
        int playerAction = 0;
        int catAction = 0;
        bool playerInvulnerability = false;
        Random rnd = new Random();
        int botAction;

        while (true)
        {

            // Отображение статов
            Console.Clear();
            Console.WriteLine("max HP = 100 ; max EP = 150");
            Console.WriteLine($"                               День {day}");
            Console.WriteLine();
            Console.WriteLine($"   Терпение игрока: {playerHealth} HP              Энтузиазм котика: {catHealth} HP");
            Console.WriteLine($"   Энергия игрока: {playerEnergy} EP               Энергия котика: {catEnergy} EP");
            Console.WriteLine();
            Console.WriteLine();

            // Определение победы или поражения
            if (playerHealth <= 0 && catHealth > 0)
            {
                Console.WriteLine("Кот победил!");
                break;
            }

            if (catHealth <= 0 && playerHealth > 0)
            {
                Console.WriteLine("Человек победил!");
                break;
            }

            if (catHealth <= 0 && catHealth <= 0)
            {
                Console.WriteLine("Ничья!");
                break;
            }

            

            // Ход кота
            Console.Clear();
            Console.WriteLine("max HP = 100 ; max EP = 150");
            Console.WriteLine($"                               День {day}");
            Console.WriteLine();
            Console.WriteLine($"   Терпение игрока: {playerHealth} HP              Энтузиазм котика: {catHealth} HP");
            Console.WriteLine($"   Энергия игрока: {playerEnergy} EP               Энергия котика: {catEnergy} EP");
            Console.WriteLine();
            Console.WriteLine();

            if (day > 1)
            {
                if (playerAction == 1) Console.WriteLine("Вчера двуногий украл мои какашки! (Энтузиазм -5)");
                if (playerAction == 2) Console.WriteLine("Вчера двуногий обрызгал меня! (Энтузиазм -15)");
                if (playerAction == 3) Console.WriteLine("Вчера двуногий пытался утопить меня! (Энтузиазм -40)");
                if (playerAction == 4) Console.WriteLine("Вчера двуногий весь день спал");
                if (playerAction == 5) Console.WriteLine("Вчера двуногий уходил из дома. Любопытно..");
                if (playerAction == 6) Console.WriteLine("Вчера двуногий занимался странными вещами.. Кажется, его совсем не расстроили мои действия");
                if (playerAction < 1 || playerAction > 6) Console.WriteLine("Вчера двуногий ничего не делал");
            }
            Console.WriteLine();
            Console.WriteLine("Твои действия сегодня:");
            Console.WriteLine(" 1. Нагадить на диван (Энергия -10, Терпение человека -5)");
            Console.WriteLine(" 2. Поцарапать мебель (Энергия -40, Терпение человека -15)");
            Console.WriteLine(" 3. Уронить телевизор (Энергия -100, Терпение человека -45)");
            Console.WriteLine(" 4. Весь день спать (Энергия +35)");
            Console.WriteLine(" 5. Поиграть с игрушкой (Энтузиазм +15, Энергия -30)");
            Console.WriteLine(" 6. Проследить за двуногим (+1 ход, Энергия -20)");
            
            // Ход бота
            if (playerEnergy < 30) playerAction = 4; // восстановление энергии при необходимости
            else
            {
                if (playerHealth <= 45 && catEnergy >= 100) playerAction = 5; // хил при низком хп
                else
                {
                    if (playerHealth <= 15 && catEnergy >= 40) playerAction = 5; // хил при низком хп
                    else
                    {
                        if (playerHealth <= 5 && catEnergy >= 10) playerAction = 5; // хил при низком хп
                        else
                        {
                            botAction = rnd.Next(1, 5); 
                            if (botAction == 4) playerAction = 6; // 1/4 на скилл защиты
                            else // 3/4 на скилл атаки
                            {
                                playerAction = rnd.Next(1, 4); // случайная атака
                            }
                        }
                    }
                }
            }

            catAction = int.Parse(Console.ReadLine());
            // Обработка скиллов бота
            if (playerAction == 1)
            {
                if (playerEnergy >= 10)
                {
                    playerEnergy -= 10;
                    catHealth -= 5;
                }
                else
                {
                    playerEnergy += 20;

                }
            }

            if (playerAction == 2)
            {
                if (playerEnergy >= 40)
                {
                    playerEnergy -= 40;
                    catHealth -= 15;
                }
                else
                {
                    playerEnergy += 20;
                }
            }

            if (playerAction == 3)
            {
                if (playerEnergy >= 100)
                {
                    playerEnergy -= 100;
                    catHealth -= 40;
                }
                else
                {
                    playerEnergy += 20;
                }
            }

            if (playerAction == 4)
            {
                if (playerEnergy > 120)
                {
                    playerEnergy = 150;
                }
                else
                {
                    playerEnergy += 30;
                }
            }

            if (playerAction == 5)
            {
                if (playerEnergy >= 30)
                {
                    if (playerHealth >= 75)
                    {
                        playerEnergy -= 30;
                        playerHealth = 100;
                    }
                    else
                    {
                        playerEnergy -= 30;
                        playerHealth += 25;
                    }
                }
                else
                {
                    playerEnergy += 20;
                }
            }

            if (playerAction == 6)
            {
                if (playerEnergy >= 10)
                {
                    playerEnergy -= 10;
                    playerInvulnerability = true;
                }
                else
                {
                    playerEnergy += 20;
                }
            }

            //Обработка скиллов кота
            if (catAction == 1)
            {
                if (catEnergy >= 10)
                {
                    catEnergy -= 10;
                    if (playerInvulnerability == false)
                    {
                        playerHealth -= 5;
                    }
                    Console.WriteLine("Ты наложил большую кучу на диван! Так держать! (Энергия -10, Терпение человека -5)");
                    Console.WriteLine("Нажми Enter для передачи хода..");
                    Console.ReadLine();
                }
                else
                {
                    catEnergy += 20;
                    Console.WriteLine("У тебя нет сил. Ты не доделал действие и засыпаешь без задних лап. (Энергия +20)");
                    Console.WriteLine("Нажми Enter для передачи хода..");
                    Console.ReadLine();
                }
            }

            if (catAction == 2)
            {
                if (catEnergy >= 40)
                {
                    catEnergy -= 40;
                    if (playerInvulnerability == false)
                    {
                        playerHealth -= 15;
                    }
                    Console.WriteLine("Ты испортил мебель двуногого! Молодец! (Энергия -40, Терпение человека -15)");
                    Console.WriteLine("Нажми Enter для передачи хода..");
                    Console.ReadLine();
                }
                else
                {
                    catEnergy += 20;
                    Console.WriteLine("У тебя нет сил. Ты не доделал действие и засыпаешь без задних лап. (Энергия +20)");
                    Console.WriteLine("Нажми Enter для передачи хода..");
                    Console.ReadLine();
                }
            }

            if (catAction == 3)
            {
                if (catEnergy >= 100)
                {
                    catEnergy -= 100;
                    if (playerInvulnerability == false)
                    {
                        playerHealth -= 45;
                    }
                    Console.WriteLine("Ты старался изо всех сил и сломал любимый говорящий ящик двуногого! (Энергия -100, Терпение человека -45)");
                    Console.WriteLine("Нажми Enter для передачи хода..");
                    Console.ReadLine();
                }
                else
                {
                    catEnergy += 20;
                    Console.WriteLine("У тебя нет сил. Ты не доделал действие и засыпаешь без задних лап. (Энергия +20)");
                    Console.WriteLine("Нажми Enter для передачи хода..");
                    Console.ReadLine();
                }
            }
            if (catAction == 4)
            {
                if (catEnergy > 115)
                {
                    catEnergy = 150;
                    Console.WriteLine("Ты весь день спал! Твоя энергия бьёт ключом. Лимит энергии: 150.");
                    Console.WriteLine("Нажми Enter для передачи хода..");
                    Console.ReadLine();
                }
                else
                {
                    catEnergy += 35;
                    Console.WriteLine("Ты спал весь день и готов к новым приключениям! (Энергия +40)");
                    Console.WriteLine("Нажми Enter для передачи хода..");
                    Console.ReadLine();
                }
            }

            if (catAction == 5)
            {
                if (catEnergy >= 30)
                {
                    if (catHealth > 85)
                    {
                        catHealth = 100;
                        Console.WriteLine("Благодаря активным играм твой энтузиазм на максимуме! Лимит энтузиазма: 100. (Энергия -30)");
                        Console.WriteLine("Нажми Enter для передачи хода..");
                        Console.ReadLine();
                    }
                    else
                    {
                        catHealth += 15;
                        Console.WriteLine("Ты поиграл с игрушкой, твой энтузиазм увеличен! (Энтузиазм +15, Энергия -30)");
                        Console.WriteLine("Нажми Enter для передачи хода..");
                        Console.ReadLine();
                    }
                }
                else
                {
                    catEnergy += 20;
                    Console.WriteLine("У тебя нет сил. Ты не доделал действие и засыпаешь без задних лап. (Энергия +20)");
                    Console.WriteLine("Нажми Enter для передачи хода..");
                    Console.ReadLine();
                }
            }

            if (catAction == 6)
            {
                if (catEnergy >= 20)
                {
                    catEnergy -= 20;
                    Console.WriteLine("Ты активно следишь за двуногим. (Энергия -20)");
                    if (playerAction == 1) Console.WriteLine("Двуногий крадёт мои какашки!");
                    if (playerAction == 2) Console.WriteLine("Двуногий достал пульверизатор. Чую что-то плохое.");
                    if (playerAction == 3) Console.WriteLine("Двуногий набирает ванну. Интересно, зачем?");
                    if (playerAction == 4) Console.WriteLine("Двуногий ещё спит. Он планирует спать весь день?");
                    if (playerAction == 5) Console.WriteLine("Двуногий куда-то собирается.");
                    if (playerAction == 6) Console.WriteLine("Двуногий медитирует. Зачем ему это?");
                    if (playerAction < 1 || playerAction > 6) Console.WriteLine("Кажется, двуногий ничего не замышляет.");
                    Console.WriteLine("Что планируешь делать дальше?");
                    catAction = int.Parse(Console.ReadLine());

                    if (catAction == 1)
                    {
                        if (catEnergy >= 10)
                        {
                            catEnergy -= 10;
                            if (playerInvulnerability == false)
                            {
                                playerHealth -= 5;
                            }
                            Console.WriteLine("Ты наложил большую кучу на диван! Так держать! (Энергия -10, Терпение человека -5)");
                            Console.WriteLine("Нажми Enter для передачи хода..");
                            Console.ReadLine();
                        }
                        else
                        {
                            catEnergy += 15;
                            Console.WriteLine("У тебя нет сил. Ты не доделал действие и засыпаешь без задних лап. (Энергия +20)");
                            Console.WriteLine("Нажми Enter для передачи хода..");
                            Console.ReadLine();
                        }
                    }

                    if (catAction == 2)
                    {
                        if (catEnergy >= 40)
                        {
                            catEnergy -= 40;
                            if (playerInvulnerability == false)
                            {
                                playerHealth -= 15;
                            }
                            Console.WriteLine("Ты испортил мебель двуногого! Молодец! (Энергия -40, Терпение человека -15)");
                            Console.WriteLine("Нажми Enter для передачи хода..");
                            Console.ReadLine();
                        }
                        else
                        {
                            catEnergy += 20;
                            Console.WriteLine("У тебя нет сил. Ты не доделал действие и засыпаешь без задних лап. (Энергия +20)");
                            Console.WriteLine("Нажми Enter для передачи хода..");
                            Console.ReadLine();
                        }
                    }

                    if (catAction == 3)
                    {
                        if (catEnergy >= 100)
                        {
                            catEnergy -= 100;
                            if (playerInvulnerability == false)
                            {
                                playerHealth -= 45;
                            }
                            Console.WriteLine("Ты старался изо всех сил и сломал любимый говорящий ящик двуногого! Так держать! (Энергия -100, Терпение человека -45)");
                            Console.WriteLine("Нажми Enter для передачи хода..");
                            Console.ReadLine();
                        }
                        else
                        {
                            catEnergy += 20;
                            Console.WriteLine("У тебя нет сил. Ты не доделал действие и засыпаешь без задних лап. (Энергия +20)");
                            Console.WriteLine("Нажми Enter для передачи хода..");
                            Console.ReadLine();
                        }
                    }
                    if (catAction == 4)
                    {
                        if (catEnergy > 115)
                        {
                            catEnergy = 150;
                            Console.WriteLine("Ты весь день спал! Твоя энергия бьёт ключом. Лимит энергии: 150.");
                            Console.WriteLine("Нажми Enter для передачи хода..");
                            Console.ReadLine();
                        }
                        else
                        {
                            catEnergy += 35;
                            Console.WriteLine("Ты спал весь день и готов к новым приключениям! (Энергия +40)");
                            Console.WriteLine("Нажми Enter для передачи хода..");
                            Console.ReadLine();
                        }
                    }

                    if (catAction == 5)
                    {
                        if (catEnergy >= 30)
                        {
                            if (catHealth > 85)
                            {
                                catHealth = 100;
                                Console.WriteLine("Благодаря активным играм твой энтузиазм на максимуме! Лимит энтузиазма: 100. (Энергия -30)");
                                Console.WriteLine("Нажми Enter для передачи хода..");
                                Console.ReadLine();
                            }
                            else
                            {
                                catHealth += 15;
                                Console.WriteLine("Ты поиграл с игрушкой, твой энтузиазм увеличен! (Энтузиазм +30, Энергия -30)");
                                Console.WriteLine("Нажми Enter для передачи хода..");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            catEnergy += 20;
                            Console.WriteLine("У тебя нет сил. Ты не доделал действие и засыпаешь без задних лап. (Энергия +20)");
                            Console.WriteLine("Нажми Enter для передачи хода..");
                            Console.ReadLine();
                        }
                    }
                    Console.WriteLine(" 6. Проследить за двуногим (+1 ход, Энергия -20)");
                    if (catAction == 6)
                    {
                        Console.WriteLine("Ты не получил никакой новой информации и пропускаешь день.");
                        Console.WriteLine("Нажми Enter для передачи хода..");
                        Console.ReadLine();
                    }

                    if (catAction < 1 || catAction > 6)
                    {
                        Console.WriteLine("Ты не предпринял никаких действий, ты пропускаешь день.");
                        Console.WriteLine("Нажми Enter для передачи хода..");
                        Console.ReadLine();
                    }
                }
                else
                {
                    catEnergy += 20;
                    Console.WriteLine("У тебя нет сил. Ты не доделал действие и засыпаешь без задних лап. (Энергия +20)");
                    Console.WriteLine("Нажми Enter для передачи хода..");
                    Console.ReadLine();
                }
            }

            if (catAction < 1 || catAction > 6)
            {
                Console.WriteLine("Ты не предпринял никаких действий, ты пропускаешь день.");
                Console.WriteLine("Нажми Enter для передачи хода..");
                Console.ReadLine();
            }

            day += 1;
            playerInvulnerability = false;

        }

        while (true)
        {
            Console.ReadLine();
        }
    }
}