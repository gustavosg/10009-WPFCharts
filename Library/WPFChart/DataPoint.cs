﻿// ---------------------------------------------------------------------------------------------------
//
//
//
//
// ---------------------------------------------------------------------------------------------------
//
//
//
//
//
// ---------------------------------------------------------------------------------------------------
// Autor: Gustavo Souza Gonçalves
// Data: 14/03/2013
//
//
// ---------------------------------------------------------------------------------------------------
// Versão:
// ---------------------------------------------------------------------------------------------------
// Revisão de versão:
//
//
//
// ---------------------------------------------------------------------------------------------------

#region References

using System;
using System.Windows.Media;
using ChartLibrary.Utils;

#endregion

namespace ChartLibrary
{
    public class DataPoint : Singleton<DataPoint>
    {
        public String IndependentValue { get; set; }
        public Double DependentValue { get; set; }
        public String ToolTip { get { return IndependentValue + " ( " + DependentValue + " ) "; } }
        public SolidColorBrush Color { get; set; }
    }
}
