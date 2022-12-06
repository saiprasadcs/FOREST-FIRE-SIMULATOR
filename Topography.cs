namespace FOREST_FIRE_SIMULATOR
{
    public class Topography
    {
        private FireImpact FireImpact;
        private double probPercent = 0.15; // 15% probability

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