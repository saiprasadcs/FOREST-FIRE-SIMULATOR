namespace FOREST_FIRE_SIMULATOR
{
    public class Weather
    {
        private FireImpact FireImpact;
        private double probPercent = 0.85;

        public FireImpact GetFireImpact()
        {
            return this.FireImpact;
        }

        public void setFireImpact(int FireImpactValue)
        {
            this.FireImpact = (FireImpact)FireImpactValue;
        }
        public double getProbability()
        {
            return this.probPercent / ((int)this.FireImpact + 1);
        }
    }
}