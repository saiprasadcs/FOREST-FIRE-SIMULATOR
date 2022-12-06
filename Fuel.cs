namespace FOREST_FIRE_SIMULATOR
{
    public class Fuel
    {
        private FireImpact FireImpact;
        private double probPercent = 0.35; // 35% probability

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