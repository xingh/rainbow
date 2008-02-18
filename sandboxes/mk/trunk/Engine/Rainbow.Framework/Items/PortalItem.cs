namespace Rainbow.Framework
{
    /// <summary>
    /// This class encapsulates the basic attributes of a Portal, and is used
    /// by the administration pages when manipulating Portals.  PortalItem implements 
    /// the IComparable interface so that an ArrayList of PortalItems may be sorted
    /// by PortalOrder, using the ArrayList's Sort() method.
    /// </summary>
    public class PortalItem //: IComparable
    {
        string name;
        string path;
        int id;

        /// <summary>
        /// Name
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Path
        /// </summary>
        /// <value>The path.</value>
        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        /// <summary>
        /// ID
        /// </summary>
        /// <value>The ID.</value>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

//        /// <summary>
//        /// Public comparer
//        /// </summary>
//        /// <param name="value">The value.</param>
//        /// <returns></returns>
//        public int CompareTo(object value)
//        {
//            return CompareTo(Name);
//        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}