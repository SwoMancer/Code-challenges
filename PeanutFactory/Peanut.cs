namespace PeanutFactory
{   
    #region Peanut
    /// <summary>
    /// Defines the <see cref="Peanut" />.<br/>
    /// The peanut contains information about its position and size.
    /// </summary>
    public class Peanut
    {
        #region Fields
        public float x1, y1;
        public string size;
        #endregion
        #region Constructor
        public Peanut(float x1, float y1, string size)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.size = size;
        }
        #endregion
    }
    #endregion
}
