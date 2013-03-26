using System;
using System.Collections.Generic;
using System.Text;
namespace HPA.Common
{
    public class StandardName
    {
        /// <summary>
        /// Show upper the fist character of string
        /// Vu Dinh Cuong
        /// 2006
        /// </summary>
        /// <param name="inputStirng"> String input</param>
        /// <returns>a standard string</returns>
        public static string UpperTheFirstCase(string inputStirng)
        {
            char[] arrayChar = inputStirng.ToLower().ToCharArray();
            string strRet=null;
            Byte i = 0;
            bool first = true;
            bool meetSpace = false;
            for (i = 0; i < arrayChar.Length; i++)
            {
                if (first == true)
                {
                    if (arrayChar[i] == ' ')
                    { //do nothing
                    }
                    else
                    {
                        first = false;
                        //The first Char need to change to the Uppercase
                        strRet = arrayChar[i].ToString().ToUpper();
                    }
                }
                else
                {
                    // if have many space char in the continue then we need to remove and only keep one
                    if (arrayChar[i] == ' ')
                    {
                        meetSpace = true;
                    }
                    else
                    {
                        if (meetSpace == true)
                        {
                            strRet += " "+ arrayChar[i].ToString();
                            meetSpace = false;
                        }
                        else
                        {
                            strRet += arrayChar[i].ToString();
                        }
                    }
                }
                
            }
            return strRet;
        }
        /// <summary>
        /// convert String style from "input  string test" to "Input String Test"
        /// Cuongvd
        /// 2006
        /// </summary>
        /// <param name="chuoiVao"></param>
        /// <returns></returns>
        public static string TitleCase(string inputString)
        {
            char[] arrayChar = inputString.ToLower().ToCharArray();
            string strRet = null;
            Byte i = 0;
            bool first = true;
            bool meetSpace = false;
            for (i = 0; i < arrayChar.Length; i++)
            {
                if (first == true)
                {
                    if (arrayChar[i] == ' ')
                    { //do nothing
                    }
                    else
                    {
                        first = false;
                        //The first Char need to change to the Uppercase
                        strRet = arrayChar[i].ToString().ToUpper();
                    }
                }
                else
                {
                    // if have more than space character in the continue then we need to remove and keep only one
                    if (arrayChar[i] == ' ')
                    {
                        meetSpace = true;
                    }
                    else
                    {
                        if (meetSpace == true)
                        {// the first char of word need to change to Upper
                            strRet += " " + arrayChar[i].ToString().ToUpper();
                            meetSpace = false;
                        }
                        else
                        {
                            strRet += arrayChar[i].ToString();
                        }
                    }
                }

            }
            return strRet;
        }
        /// <summary>
        /// Convert string from 
        /// "input test STRing  "\n To:
        /// "input test string"\n
        /// Vu Dinh Cuong
        ///  - 2006
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string LowerCase(string inputString)
        {
            char[] arrayChar = inputString.ToLower().ToCharArray();
            string strRet = null;
            Byte i = 0;
            bool firstChar = true;
            bool meetSpace = false;
            for (i = 0; i < arrayChar.Length; i++)
            {
                if (firstChar == true)
                {
                    if (arrayChar[i] == ' ')
                    { //do nothing
                    }
                    else
                    {
                        firstChar = false;
                        //The first Char need to change to the Uppercase
                        strRet = arrayChar[i].ToString();
                    }
                }
                else
                {
                    // if have many space char in the continue then we need to remove and only keep one
                    if (arrayChar[i] == ' ')
                    {
                        meetSpace = true;
                    }
                    else
                    {
                        if (meetSpace == true)
                        {// the first char of word need to change to Upper
                            strRet += " " + arrayChar[i].ToString();
                            meetSpace = false;
                        }
                        else
                        {
                            strRet += arrayChar[i].ToString();
                        }
                    }
                }

            }
            return strRet;            
        }
        /// <summary>
        /// Convert String from "Test STRing " to:
        ///  "TEST STRING"
        /// Cuongvd
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string UpperCase(string inputString)
        {
            char[] arrayChar = inputString.ToUpper().ToCharArray();
            string strRet = null;
            Byte i = 0;
            bool firstChar = true;
            bool meetSpace = false;
            for (i = 0; i < arrayChar.Length; i++)
            {
                if (firstChar == true)
                {
                    if (arrayChar[i] == ' ')
                    { //do nothing
                    }
                    else
                    {
                        firstChar = false;
                        //The first Char need to change to the Uppercase
                        strRet = arrayChar[i].ToString();
                    }
                }
                else
                {
                    // if have many space char in the continue then we need to remove and only keep one
                    if (arrayChar[i] == ' ')
                    {
                        meetSpace = true;
                    }
                    else
                    {
                        if (meetSpace == true)
                        {// the first char of word need to change to Upper
                            strRet += " " + arrayChar[i].ToString();
                            meetSpace = false;
                        }
                        else
                        {
                            strRet += arrayChar[i].ToString();
                        }
                    }
                }

            }
            return strRet;
        }

    }
}
