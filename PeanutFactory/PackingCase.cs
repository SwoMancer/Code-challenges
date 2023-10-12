namespace PeanutFactory
{
    #region PackingCase
    /// <summary>
    /// Defines the <see cref="PackingCase" />.<br/>
    /// The packing case contains the boxes and peanuts that would be inspected together.
    /// </summary>
    public class PackingCase
    {
        #region Fields
        public List<Box> boxes = new List<Box>();
        public List<Peanut> peanuts = new List<Peanut>();
        #endregion
        #region Methods
        /// <summary>
        /// See if peanuts are inside a box and if the size of the box and peanut are the same.
        /// </summary>
        /// <returns></returns>
        public List<string> InspectPeanuts()
        {
            List<string> outputs = new List<string>();

            foreach (Peanut peanut in peanuts)
            {
                string status = "floor";

                foreach (Box box in boxes)
                {
                    //If the peanut is not inside the box...
                    if ((box.x1 <= peanut.x1 && peanut.x1 <= box.x2) && (box.y1 <= peanut.y1 && peanut.y1 <= box.y2))
                    {
                        if (box.size == peanut.size)
                            status = "correct";
                        else
                            status = box.size;
                        break;
                    }
                }
                //Console.WriteLine(peanut.size + " " + status);
                outputs.Add(peanut.size + " " + status);
            }
            //Console.WriteLine();
            outputs.Add("");
            return outputs;
        }
        #endregion
    }
    #endregion
}
