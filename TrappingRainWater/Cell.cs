using static TrappingRainWater.Garden;

namespace TrappingRainWater
{
    #region Cell
    /// <summary>
    /// Defines the <see cref="Cell" />.<br/>
    /// A cell contains information about its neighbour's wall types, If it can collect water and how high it is. 
    /// </summary>
    public class Cell
    {
        #region Fields
        public WallType top = WallType.Higher, bottom = WallType.Higher, left = WallType.Higher, right = WallType.Higher;
        public ushort height;
        public bool isAPool = true, isAlreadyScanned = false;
        public bool isAlreadyScannedTop = false, isAlreadyScannedRight = false, isAlreadyScannedBottom = false, isAlreadyScannedLeft = false;
        #endregion
        #region Constructor
        public Cell(ushort height)
        {
            this.height = height;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Compare cell sizes against each other.
        /// </summary>
        /// <param name="firstCell"></param>
        /// <param name="compareCell"></param>
        /// <returns></returns>
        public static WallType CompareCellSize(Cell firstCell, Cell compareCell)
        {
            if (firstCell.height > compareCell.height)
                return WallType.Lower;
            else if (firstCell.height == compareCell.height)
                return WallType.Level;
            else
                return WallType.Higher;
        }

        #endregion
    }
    #endregion
}
