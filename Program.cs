namespace FOREST_FIRE_SIMULATOR
{
    /// <summary>
    /// Class with main method.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Fire Impact on a factor can be HIGH(1), MEDIUM(2), LOW(3)\n");
            Console.WriteLine("Enter Fire Impact due to Weather");
            int fireImpact = Convert.ToInt32(Console.ReadLine()) - 1;
            isFireImpactValueValid(fireImpact);
            Weather weather = new Weather();
            weather.setFireImpact(fireImpact);
            Console.WriteLine("Enter Fire Impact due to Fuel");
            Fuel fuel = new Fuel();
            fireImpact = Convert.ToInt32(Console.ReadLine()) - 1;
            isFireImpactValueValid(fireImpact);
            fuel.setFireImpact(fireImpact);
            Console.WriteLine("Enter Fire Impact due to Topography");
            Topography topography = new Topography();
            fireImpact = Convert.ToInt32(Console.ReadLine()) - 1;
            isFireImpactValueValid(fireImpact);
            topography.setFireImpact(fireImpact);
            Forest fireForest = new Forest(weather, fuel, topography);
            fireForest.showForest();
            fireForest.simulateForestFire();
        }

        /// <summary>
        /// Checks if user input for FireImpact is valid
        /// </summary>
        /// <param name="fireImpact">Fire Impact value</param>
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