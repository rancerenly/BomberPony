namespace Game
{
    /// <summary>
    /// Interface for any explodable object.
    /// </summary>
    public interface IExplodable
    {
        /// <summary>
        /// Method that invokes upon explosion.
        /// </summary>
        void Explode();
    }
}