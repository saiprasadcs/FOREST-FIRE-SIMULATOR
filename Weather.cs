namespace FOREST_FIRE_SIMULATOR
{
    /// <summary>
    /// Maintains FireImpact due to Weather
    /// </summary>
    public class Weather
    {
        private FireImpact FireImpact;
        private double probPercent = 0.35;

        /// <summary>
        /// Returns Fire Impact
        /// </summary>
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
        /// Returns probability due to Weather
        /// </summary>
        public double getProbability()
        {
            return this.probPercent / ((int)this.FireImpact + 1);
        }
    }
}