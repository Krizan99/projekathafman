using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI312_Project
{
    class encoding
    {
        private Char m_character;
        private String m_encoding;

        public encoding(String character, String encoding)
        {
            m_character = character[0];
            m_encoding = encoding;
        }

        public encoding(Char character, String encoding)
        {
            m_character = character;
            m_encoding = encoding;
        }

        public Char character
        {
            get
            {
                return m_character;
            }
            set
            {
                m_character = value;
            }
        }
        public String encode
        {
            get
            {
                return m_encoding;
            }
            set
            {
                m_encoding = value;
            }
        }

        public override string ToString()
        {
            String s = String.Format("{0}, {1}", m_character, m_encoding);
            return s;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj == this)
                return true;
            if (!(obj.GetType() == GetType()))
                return false;

            bool equals = false;
            encoding encode = new encoding('\0', "0");

            encode = (encoding)obj;

            if (this.character == encode.character)
                equals = true;

            return equals;
        }

    }
}
