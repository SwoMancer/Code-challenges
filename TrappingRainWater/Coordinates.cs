namespace TrappingRainWater
{
    #region Coordinates
    /// <summary>
    /// Defines the <see cref="Coordinates" />.<br/>
    /// Holds two coordinates of the X and Y axel.
    /// </summary>
    public class Coordinates
    {
        #region Fields
        public ushort y;
        public ushort x;
        #endregion
        #region Constructor
        public Coordinates(ushort y, ushort x)
        {
            this.y = y;
            this.x = x;
        }
        #endregion
    }
    #endregion
}
