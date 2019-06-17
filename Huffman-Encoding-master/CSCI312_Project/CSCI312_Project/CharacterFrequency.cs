using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI312_Project
{
    class CharacterFrequency: IComparable
    {
        private Char m_char;
        private int m_count;

        public CharacterFrequency()
        {
            m_char = '\0';
            m_count = 0;
        }

        public CharacterFrequency(Char c)
        {
            m_char = c;
            m_count = 0;
        }

        public CharacterFrequency(Char c, int frequency)
        {
            m_char = c;
            if (frequency >= 0)
                m_count = frequency;
            else
                frequency = 0;
        }
        public CharacterFrequency(int code, int frequency)
        {
            
            m_char = (char)code;
            if (frequency >= 0)
                m_count = frequency;
            else
                frequency = 0;
        }
        public Char character
        {
            get
            {
                return m_char;
            }

            set
            {
                m_char = value;
            }
        }



        public int count
        {
            get
            {
                return m_count;
            }

            set
            {
                if (value < 0)
                    value = 0;

                m_count = value;
            }
        }

        public void increment()
        {
            m_count++;
        }

        public override string ToString()
        {
            String s = String.Format("{0},{1}\n",m_char,m_count);
            return s;
        }

        public string Print()
        {
            String s = String.Format("{0},{1}\n",(int)m_char,m_count);
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

            bool equal = false;
            CharacterFrequency cf = new CharacterFrequency('\0', 0);

            cf = (CharacterFrequency)obj;

            if (this.character == cf.character)
                equal = true;

            return equal;
        }

        public override int GetHashCode()
        {
            return (int)m_char;
        }
        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            CharacterFrequency cf = obj as CharacterFrequency;
            if (obj != null)
            {
                int result = 0;
                if (this.m_count > cf.m_count)
                    result = -1;
                else if (this.m_count == cf.m_count)
                    result = 0;
                else result = 1;

                return result;
            }
            else
                throw new ArgumentException("object is not a Character Frequency");
        }
    }
}
