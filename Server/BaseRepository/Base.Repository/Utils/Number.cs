using System;

namespace Base.Repository.Utils {
    public static class Number {
        public static bool isNumber (string valor) {
            var isDigit = false;

            try {
                foreach (var s in valor) {
                    if (char.IsDigit (s))
                        isDigit = true;
                }

            } catch (System.Exception) {

                return isDigit = false;
            }

            return isDigit;
        }

        public static string ApenasNumerosStr(string numero)
        {
            return String.Join("", System.Text.RegularExpressions.Regex.Split(numero, @"[^\d]"));
        }
    }
}