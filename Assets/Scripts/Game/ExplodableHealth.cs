namespace Game
{
    /// <summary>
    /// Health that receives explosion damage.
    /// </summary>
    public class ExplodableHealth : Health, IExplodable
    {
        /// <inheritdoc/>
        public void Explode()
        {
            Damage(1);
        }
    }
}