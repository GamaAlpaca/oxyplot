﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArrayHelper.cs" company="OxyPlot">
//   The MIT License (MIT)
//   
//   Copyright (c) 2012 Oystein Bjorke
//   
//   Permission is hereby granted, free of charge, to any person obtaining a
//   copy of this software and associated documentation files (the
//   "Software"), to deal in the Software without restriction, including
//   without limitation the rights to use, copy, modify, merge, publish,
//   distribute, sublicense, and/or sell copies of the Software, and to
//   permit persons to whom the Software is furnished to do so, subject to
//   the following conditions:
//   
//   The above copyright notice and this permission notice shall be included
//   in all copies or substantial portions of the Software.
//   
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
//   OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
//   MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
//   IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
//   CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
//   TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
//   SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary>
//   Array helper methods.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace OxyPlot
{
    using System;

    /// <summary>
    /// Array helper methods.
    /// </summary>
    public static class ArrayHelper
    {
        #region Public Methods

        /// <summary>
        /// Creates a vector.
        /// </summary>
        /// <param name="x0">
        /// The first value.
        /// </param>
        /// <param name="x1">
        /// The last value.
        /// </param>
        /// <param name="n">
        /// The number of steps.
        /// </param>
        /// <returns>
        /// A vector.
        /// </returns>
        public static double[] CreateVector(double x0, double x1, int n)
        {
            var result = new double[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = (x0 + ((x1 - x0) * i / (n - 1))).RemoveNoise();
            }

            return result;
        }

        /// <summary>
        /// Creates a vector.
        /// </summary>
        /// <param name="x0">
        /// The first value.
        /// </param>
        /// <param name="x1">
        /// The last value.
        /// </param>
        /// <param name="dx">
        /// The step size.
        /// </param>
        /// <returns>
        /// A vector.
        /// </returns>
        public static double[] CreateVector(double x0, double x1, double dx)
        {
            var n = (int)Math.Round((x1 - x0) / dx);
            var result = new double[n + 1];
            for (int i = 0; i <= n; i++)
            {
                result[i] = (x0 + (i * dx)).RemoveNoise();
            }

            return result;
        }

        /// <summary>
        /// Evaluates the specified function.
        /// </summary>
        /// <param name="f">
        /// The function.
        /// </param>
        /// <param name="x">
        /// The x values.
        /// </param>
        /// <param name="y">
        /// The y values.
        /// </param>
        /// <returns>
        /// Array of evaluations.
        /// </returns>
        public static double[,] Evaluate(Func<double, double, double> f, double[] x, double[] y)
        {
            int m = y.Length;
            int n = x.Length;
            var result = new double[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result[i, j] = f(x[j], y[i]);
                }
            }

            return result;
        }

        #endregion
    }
}