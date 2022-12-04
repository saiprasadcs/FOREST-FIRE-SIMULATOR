namespace FOREST_FIRE_SIMULATOR
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Fire Impact on a factor can be HIGH(1), MEDIUM(2), LOW(3)\n\n");
            Console.WriteLine("Enter Fire Impact due to Weather");
            int fireImpact = Convert.ToInt32(Console.ReadLine()) - 1;
            isFireImpactValueValid(fireImpact);
            Weather weather = new Weather();
            weather.setFireImpact(fireImpact);
            Forest forestFire = new Forest(weather);
            forestFire.showForest();
            forestFire.simulateForestFire();
        }

        static void isFireImpactValueValid(int fireImpact)
        {
            if (fireImpact < 0 || fireImpact > 2)
            {
                Console.WriteLine("Invalid Input!!! Press any key to stop the program..");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
    }
}