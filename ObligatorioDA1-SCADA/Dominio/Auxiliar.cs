﻿using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace Dominio
{
    public abstract class Auxiliar
    {
        public static bool ContieneCaracteresAlfabeticos(string value)
        {
            Regex caracteresAlfabeticos = new Regex(@"[A-Z]", RegexOptions.IgnoreCase);
            return caracteresAlfabeticos.IsMatch(value);
        }

        public static bool EsTextoValido(string value)
        {
            return !string.IsNullOrEmpty(value) && ContieneCaracteresAlfabeticos(value);
        }

        public static bool NoEsNulo(object unObjeto)
        {
            return unObjeto != null;
        }

        public static bool EsListaVacia(IList variables)
        {
            return variables.Count == 0;
        }

        public static bool ValoresMonotonosCrecientes(decimal valor1, decimal valor2, decimal valor3, decimal valor4)
        {
            return valor1 <= valor2 && valor2 <= valor3 && valor3 <= valor4;
        }

        public static bool EstaFueraDelRango(decimal valor, Tuple<decimal, decimal> rango)
        {
            decimal valorMinimoValido = rango.Item1;
            decimal valorMaximoValido = rango.Item2;
            return valor < valorMinimoValido || valor > valorMaximoValido;
        }
    }
}
