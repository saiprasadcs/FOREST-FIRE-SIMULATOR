namespace FOREST_FIRE_SIMULATOR
{
    /// <summary>
    /// Maintains FireImpact due to Fuel
    /// </summary>
    public class Fuel
    {
        private FireImpact FireImpact;
        private double probPercent = 0.35; // 35% probability

        /// <summary>
        /// Returns Fire Impact
        /// </summary>
        /// <returns></returns>
        public FireImpact GetFireImpact()
        {
            return this.FireImpact;
        }

        /// <summary>
        /// Sets FireImpact
        /// </summary>
        public void setFireImpact(int FireImpactValue)
        {
            this.FireImpact = (FireImpact)FireImpactValue;
        }

        /// <summary>
        /// Returns probability due to Fuel
        /// </summary>
        public double getProbability()
        {
            return this.probPercent / ((int)this.FireImpact + 1);
        }
    }
}