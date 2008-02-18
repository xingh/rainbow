using System;

namespace Rainbow.Framework.Items
{
    /// <summary>
    /// PageItem Class
    /// This class encapsulates the basic attributes of a Page, and is used
    /// by the administration pages when manipulating tabs.<br/>
    /// PageItem implements 
    /// the IComparable interface so that an ArrayList of PageItems may be sorted
    /// by PageOrder, using the ArrayList's Sort() method.
    /// </summary>
    public class PageItem : IComparable
    {
        int order;
        string name;
        int id;
        int nestLevel;

        /// <summary>
        /// Order
        /// </summary>
        /// <value>The order.</value>
        public int Order
        {
            get { return order; }
            set { order = value; }
        }

        /// <summary>
        /// Name
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get { return name;}
            set { name = value;}
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

        /// <summary>
        /// NestLevel
        /// </summary>
        /// <value>The nest level.</value>
        public int NestLevel
        {
            get { return nestLevel; }
            set { nestLevel = value; }
        }

        /// <summary>
        /// Public comparer
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int CompareTo(object value)
        {
            if (value == null)
            {
                return 1;
            }
            int compareOrder = ((PageItem) value).Order;
            if (Order == compareOrder)
            {
                return 0;
            }
            if (Order < compareOrder)
            {
                return -1;
            }
            if (Order > compareOrder)
            {
                return 1;
            }
            return 0;
        }
    }
}