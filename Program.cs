
Buffet menuNinja = new Buffet();
Ninja ninjaComiendo = new Ninja();

Food menuSeleccionado1 = menuNinja.Serve();
Food menuSeleccionado2 = menuNinja.Serve();
Food menuSeleccionado3 = menuNinja.Serve();

ninjaComiendo.Eat(menuSeleccionado1);
ninjaComiendo.Eat(menuSeleccionado2);
ninjaComiendo.Eat(menuSeleccionado3);

class Food
{
    public string Name { get; set; }
    public int Calories { get; set; }
    public bool IsSpicy { get; set; }
    public bool IsSweet { get; set; }

    public Food(string n, int c, bool p, bool d)
    {
        Name = n;
        Calories = c;
        IsSpicy = p;
        IsSweet = d;
    }
}

class Buffet
{
    public List<Food> Menu;

    //constructor
    public Buffet()
    {
        Menu = new List<Food>()
        {
            new Food("Example", 1000, false, false),
            new Food("MenuUno", 1030, true, false),
            new Food("MenuDos", 1400, false, false),
            new Food("MenuTres", 1100, true, false),
            new Food("MenuCuatro", 2000, false, true),
            new Food("MenuCinco", 400, false, true),
            new Food("MenuSeis", 890, false, false),
            new Food("MenuSiete", 1020, true, false)
        };
    }

    public Food Serve()
    {
        Random menuAleatorio = new Random();
        int numeroMenu = menuAleatorio.Next(0, 8);

        return Menu[numeroMenu];
    }
}

class Ninja
{
    private int calorieIntake = 0;
    public List<Food> FoodHistory;
    public bool IsFull { get; set; }

    public Ninja(int iC = 0)
    {
        calorieIntake = iC;

        FoodHistory = new List<Food>();
    }

    // build out the Eat method
    public void Eat(Food item)
    {
        if (IsFull)
        {
            Console.WriteLine("");
            Console.WriteLine("El Ninja ya no está hambriento");
            Console.WriteLine("-----------------------------------------------");
        }
        
        if (calorieIntake < 1200)
        {
            IsFull = false;
            calorieIntake += item.Calories;
            FoodHistory.Add(item);

            if (FoodHistory.Count > 1)
            {
                Console.WriteLine("");
                Console.WriteLine("El ninja sigue hambriento");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("El ninja está hambriento");
            }

            if (item.IsSpicy)
            {
                Console.WriteLine($"El ninja elige el menú {FoodHistory[FoodHistory.Count - 1].Name} y la comida está picante");
            }
            else
            {
                Console.WriteLine($"El ninja elige el menú {FoodHistory[FoodHistory.Count - 1].Name} y la comida está dulce");
            }

            if (calorieIntake >= 1200)
            {
                IsFull = true;
            }
        }
    }
}


