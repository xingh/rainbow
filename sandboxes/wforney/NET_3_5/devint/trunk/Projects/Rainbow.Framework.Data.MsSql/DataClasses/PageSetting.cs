﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using Rainbow.Framework.Data.Types;
using Rainbow.Framework.Configuration;

namespace Rainbow.Framework.Data.MsSql
{
    partial class PageSetting : IComparable<PageSetting>, Rainbow.Framework.Data.Entities.IPageSetting
    {
        /// <summary>
        /// Gets or sets the base setting.
        /// </summary>
        /// <value>The base setting.</value>
        public BaseSetting BaseSetting
        {
            get
            {
                try
                {
                    using (DataClassesDataContext db = new DataClassesDataContext(Config.ConnectionString))
                    {
                        db.Log = new DebuggerWriter();
                        return db.BaseSettings.Single(s => s.SettingName == this.SettingName || s.EnglishName == this.EnglishName);
                    }
                }
                catch { return null; }
            }
            set
            {
                using (DataClassesDataContext db = new DataClassesDataContext(Config.ConnectionString))
                {
                    db.Log = new DebuggerWriter();
                    db.BaseSettings.SingleOrDefault(s => s.SettingName == this.SettingName || s.EnglishName == this.EnglishName) = value;
                }
            }
        }

        #region IComparable<PageSetting> Members

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>.
        /// </returns>
        public int CompareTo(PageSetting other)
        {
            if (other == null) return 1;
            int compareOrder = other.SettingOrder.Value;
            if (SettingOrder == compareOrder) return 0;
            if (SettingOrder < compareOrder) return -1;
            if (SettingOrder > compareOrder) return 1;
            return 0;
        }

        #endregion

        #region IComparable Members

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IComparable<IPage> Members

        public int CompareTo(Rainbow.Framework.Data.Entities.IPage other)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IConvertible Members

        public TypeCode GetTypeCode()
        {
            throw new NotImplementedException();
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public double ToDouble(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public int ToInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public long ToInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public float ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}