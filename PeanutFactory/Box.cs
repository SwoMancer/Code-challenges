namespace PeanutFactory
{
    #region Box
    /// <summary>
    /// Defines the <see cref="Box" />.<br/>
    /// The box contains information about its dimension.
    /// </summary>
    public class Box
    {
        #region Fields
        public float x1, y1, x2, y2;
        public string size;
        #endregion
        #region Constructor
        public Box(float x1, float y1, float x2, float y2, string size)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.size = size;
        }
        #endregion
    }
    #endregion
}