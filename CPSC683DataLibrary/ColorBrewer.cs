using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CPSC683DataLibrary
{
    /// <summary>
    /// Describes the different types of color schemes
    /// </summary>
    public enum ColorSchemeType
    {
        /// <summary>
        /// Used for distinct coloring
        /// Accent, Dark2, Paired, Pastel1, Pastel2, Set1, Set2, Set3
        /// </summary>
        Categorical,
        /// <summary>
        /// Diverges from specific color to white to another color
        /// BrBG, PRGn, PiYG, PuOr, RdBu, RdGy, RdYlBu, RdYlGn, Spectral
        /// </summary>
        Diverging,
        /// <summary>
        /// Single color spectrums
        /// Blues, Greens, Greys, Oranges, Purples, Reds
        /// </summary>
        Sequential_Single,
        /// <summary>
        /// Multi color spectrums
        /// BuGn, BuPn, GnBu, OrRd, PuBuGn, PuBu, PuRd, RdPu, YlGnBu, YlGn, YlOrBr, YlOrRd
        /// </summary>
        Sequential_Multi
    }

    /// <summary>
    /// Color scheme class
    /// </summary>
    public static class ColorBrewer
    {
        #region Color Dictionary
        /// <summary>
        /// List of all colors within ColorBrewer
        /// </summary>
        public static Dictionary<string, uint[][]>[] colorList = new Dictionary<string, uint[][]>[]
        {
            new Dictionary<string, uint[][]>
            {
                { "Accent", new uint[][] { new uint[] {0X7fc97f,0Xbeaed4,0Xfdc086}, new uint[] {0X7fc97f,0Xbeaed4,0Xfdc086,0Xffff99}, new uint[] {0X7fc97f,0Xbeaed4,0Xfdc086,0Xffff99,0X386cb0}, new uint[] {0X7fc97f,0Xbeaed4,0Xfdc086,0Xffff99,0X386cb0,0Xf0027f}, new uint[] {0X7fc97f,0Xbeaed4,0Xfdc086,0Xffff99,0X386cb0,0Xf0027f,0Xbf5b17}, new uint[] {0X7fc97f,0Xbeaed4,0Xfdc086,0Xffff99,0X386cb0,0Xf0027f,0Xbf5b17,0X666666}, } },
                { "Dark2", new uint[][] { new uint[] {0X1b9e77,0Xd95f02,0X7570b3}, new uint[] {0X1b9e77,0Xd95f02,0X7570b3,0Xe7298a}, new uint[] {0X1b9e77,0Xd95f02,0X7570b3,0Xe7298a,0X66a61e}, new uint[] {0X1b9e77,0Xd95f02,0X7570b3,0Xe7298a,0X66a61e,0Xe6ab02}, new uint[] {0X1b9e77,0Xd95f02,0X7570b3,0Xe7298a,0X66a61e,0Xe6ab02,0Xa6761d}, new uint[] {0X1b9e77,0Xd95f02,0X7570b3,0Xe7298a,0X66a61e,0Xe6ab02,0Xa6761d,0X666666}, } },
                { "Paired", new uint[][] { new uint[] {0Xa6cee3,0X1f78b4,0Xb2df8a}, new uint[] {0Xa6cee3,0X1f78b4,0Xb2df8a,0X33a02c}, new uint[] {0Xa6cee3,0X1f78b4,0Xb2df8a,0X33a02c,0Xfb9a99}, new uint[] {0Xa6cee3,0X1f78b4,0Xb2df8a,0X33a02c,0Xfb9a99,0Xe31a1c}, new uint[] {0Xa6cee3,0X1f78b4,0Xb2df8a,0X33a02c,0Xfb9a99,0Xe31a1c,0Xfdbf6f}, new uint[] {0Xa6cee3,0X1f78b4,0Xb2df8a,0X33a02c,0Xfb9a99,0Xe31a1c,0Xfdbf6f,0Xff7f00}, new uint[] {0Xa6cee3,0X1f78b4,0Xb2df8a,0X33a02c,0Xfb9a99,0Xe31a1c,0Xfdbf6f,0Xff7f00,0Xcab2d6}, new uint[] {0Xa6cee3,0X1f78b4,0Xb2df8a,0X33a02c,0Xfb9a99,0Xe31a1c,0Xfdbf6f,0Xff7f00,0Xcab2d6,0X6a3d9a}, new uint[] {0Xa6cee3,0X1f78b4,0Xb2df8a,0X33a02c,0Xfb9a99,0Xe31a1c,0Xfdbf6f,0Xff7f00,0Xcab2d6,0X6a3d9a,0Xffff99}, new uint[] {0Xa6cee3,0X1f78b4,0Xb2df8a,0X33a02c,0Xfb9a99,0Xe31a1c,0Xfdbf6f,0Xff7f00,0Xcab2d6,0X6a3d9a,0Xffff99,0Xb15928}, } },
                { "Pastel1", new uint[][] { new uint[] {0Xfbb4ae,0Xb3cde3,0Xccebc5}, new uint[] {0Xfbb4ae,0Xb3cde3,0Xccebc5,0Xdecbe4}, new uint[] {0Xfbb4ae,0Xb3cde3,0Xccebc5,0Xdecbe4,0Xfed9a6}, new uint[] {0Xfbb4ae,0Xb3cde3,0Xccebc5,0Xdecbe4,0Xfed9a6,0Xffffcc}, new uint[] {0Xfbb4ae,0Xb3cde3,0Xccebc5,0Xdecbe4,0Xfed9a6,0Xffffcc,0Xe5d8bd}, new uint[] {0Xfbb4ae,0Xb3cde3,0Xccebc5,0Xdecbe4,0Xfed9a6,0Xffffcc,0Xe5d8bd,0Xfddaec}, new uint[] {0Xfbb4ae,0Xb3cde3,0Xccebc5,0Xdecbe4,0Xfed9a6,0Xffffcc,0Xe5d8bd,0Xfddaec,0Xf2f2f2}, } },
                { "Pastel2", new uint[][] { new uint[] {0Xb3e2cd,0Xfdcdac,0Xcbd5e8}, new uint[] {0Xb3e2cd,0Xfdcdac,0Xcbd5e8,0Xf4cae4}, new uint[] {0Xb3e2cd,0Xfdcdac,0Xcbd5e8,0Xf4cae4,0Xe6f5c9}, new uint[] {0Xb3e2cd,0Xfdcdac,0Xcbd5e8,0Xf4cae4,0Xe6f5c9,0Xfff2ae}, new uint[] {0Xb3e2cd,0Xfdcdac,0Xcbd5e8,0Xf4cae4,0Xe6f5c9,0Xfff2ae,0Xf1e2cc}, new uint[] {0Xb3e2cd,0Xfdcdac,0Xcbd5e8,0Xf4cae4,0Xe6f5c9,0Xfff2ae,0Xf1e2cc,0Xcccccc }, } },
                { "Set1", new uint[][] { new uint[] {0Xe41a1c,0X377eb8,0X4daf4a}, new uint[] {0Xe41a1c,0X377eb8,0X4daf4a,0X984ea3}, new uint[] {0Xe41a1c,0X377eb8,0X4daf4a,0X984ea3,0Xff7f00}, new uint[] {0Xe41a1c,0X377eb8,0X4daf4a,0X984ea3,0Xff7f00,0Xffff33}, new uint[] {0Xe41a1c,0X377eb8,0X4daf4a,0X984ea3,0Xff7f00,0Xffff33,0Xa65628}, new uint[] {0Xe41a1c,0X377eb8,0X4daf4a,0X984ea3,0Xff7f00,0Xffff33,0Xa65628,0Xf781bf}, new uint[] {0Xe41a1c,0X377eb8,0X4daf4a,0X984ea3,0Xff7f00,0Xffff33,0Xa65628,0Xf781bf,0X999999 }, } },
                { "Set2", new uint[][] { new uint[] {0X66c2a5,0Xfc8d62,0X8da0cb}, new uint[] {0X66c2a5,0Xfc8d62,0X8da0cb,0Xe78ac3}, new uint[] {0X66c2a5,0Xfc8d62,0X8da0cb,0Xe78ac3,0Xa6d854}, new uint[] {0X66c2a5,0Xfc8d62,0X8da0cb,0Xe78ac3,0Xa6d854,0Xffd92f}, new uint[] {0X66c2a5,0Xfc8d62,0X8da0cb,0Xe78ac3,0Xa6d854,0Xffd92f,0Xe5c494}, new uint[] {0X66c2a5,0Xfc8d62,0X8da0cb,0Xe78ac3,0Xa6d854,0Xffd92f,0Xe5c494,0Xb3b3b3}, } },
                { "Set3", new uint[][] {new uint[] {0X8dd3c7,0Xffffb3,0Xbebada}, new uint[] {0X8dd3c7,0Xffffb3,0Xbebada,0Xfb8072}, new uint[] {0X8dd3c7,0Xffffb3,0Xbebada,0Xfb8072,0X80b1d3}, new uint[] {0X8dd3c7,0Xffffb3,0Xbebada,0Xfb8072,0X80b1d3,0Xfdb462}, new uint[] {0X8dd3c7,0Xffffb3,0Xbebada,0Xfb8072,0X80b1d3,0Xfdb462,0Xb3de69}, new uint[] {0X8dd3c7,0Xffffb3,0Xbebada,0Xfb8072,0X80b1d3,0Xfdb462,0Xb3de69,0Xfccde5}, new uint[] {0X8dd3c7,0Xffffb3,0Xbebada,0Xfb8072,0X80b1d3,0Xfdb462,0Xb3de69,0Xfccde5,0Xd9d9d9}, new uint[] {0X8dd3c7,0Xffffb3,0Xbebada,0Xfb8072,0X80b1d3,0Xfdb462,0Xb3de69,0Xfccde5,0Xd9d9d9,0Xbc80bd}, new uint[] {0X8dd3c7,0Xffffb3,0Xbebada,0Xfb8072,0X80b1d3,0Xfdb462,0Xb3de69,0Xfccde5,0Xd9d9d9,0Xbc80bd,0Xccebc5}, new uint[] {0X8dd3c7,0Xffffb3,0Xbebada,0Xfb8072,0X80b1d3,0Xfdb462,0Xb3de69,0Xfccde5,0Xd9d9d9,0Xbc80bd,0Xccebc5,0Xffed6f }, } }
            },

            new Dictionary<string, uint[][]>
            {
                { "BrBG", new uint[][] { new uint[] {0Xd8b365,0Xf5f5f5,0X5ab4ac}, new uint[] {0Xa6611a,0Xdfc27d,0X80cdc1,0X018571}, new uint[] {0Xa6611a,0Xdfc27d,0Xf5f5f5,0X80cdc1,0X018571}, new uint[] {0X8c510a,0Xd8b365,0Xf6e8c3,0Xc7eae5,0X5ab4ac,0X01665e}, new uint[] {0X8c510a,0Xd8b365,0Xf6e8c3,0Xf5f5f5,0Xc7eae5,0X5ab4ac,0X01665e}, new uint[] {0X8c510a,0Xbf812d,0Xdfc27d,0Xf6e8c3,0Xc7eae5,0X80cdc1,0X35978f,0X01665e}, new uint[] {0X8c510a,0Xbf812d,0Xdfc27d,0Xf6e8c3,0Xf5f5f5,0Xc7eae5,0X80cdc1,0X35978f,0X01665e}, new uint[] {0X543005,0X8c510a,0Xbf812d,0Xdfc27d,0Xf6e8c3,0Xc7eae5,0X80cdc1,0X35978f,0X01665e,0X003c30}, new uint[] {0X543005,0X8c510a,0Xbf812d,0Xdfc27d,0Xf6e8c3,0Xf5f5f5,0Xc7eae5,0X80cdc1,0X35978f,0X01665e,0X003c30}, } },
                { "PRGn", new uint[][] { new uint[] {0Xaf8dc3,0Xf7f7f7,0X7fbf7b}, new uint[] {0X7b3294,0Xc2a5cf,0Xa6dba0,0X008837}, new uint[] {0X7b3294,0Xc2a5cf,0Xf7f7f7,0Xa6dba0,0X008837}, new uint[] {0X762a83,0Xaf8dc3,0Xe7d4e8,0Xd9f0d3,0X7fbf7b,0X1b7837}, new uint[] {0X762a83,0Xaf8dc3,0Xe7d4e8,0Xf7f7f7,0Xd9f0d3,0X7fbf7b,0X1b7837}, new uint[] {0X762a83,0X9970ab,0Xc2a5cf,0Xe7d4e8,0Xd9f0d3,0Xa6dba0,0X5aae61,0X1b7837}, new uint[] {0X762a83,0X9970ab,0Xc2a5cf,0Xe7d4e8,0Xf7f7f7,0Xd9f0d3,0Xa6dba0,0X5aae61,0X1b7837}, new uint[] {0X40004b,0X762a83,0X9970ab,0Xc2a5cf,0Xe7d4e8,0Xd9f0d3,0Xa6dba0,0X5aae61,0X1b7837,0X00441b}, new uint[] {0X40004b,0X762a83,0X9970ab,0Xc2a5cf,0Xe7d4e8,0Xf7f7f7,0Xd9f0d3,0Xa6dba0,0X5aae61,0X1b7837,0X00441b}, } },
                { "PiYG", new uint[][] { new uint[] {0Xe9a3c9,0Xf7f7f7,0Xa1d76a}, new uint[] {0Xd01c8b,0Xf1b6da,0Xb8e186,0X4dac26}, new uint[] {0Xd01c8b,0Xf1b6da,0Xf7f7f7,0Xb8e186,0X4dac26}, new uint[] {0Xc51b7d,0Xe9a3c9,0Xfde0ef,0Xe6f5d0,0Xa1d76a,0X4d9221}, new uint[] {0Xc51b7d,0Xe9a3c9,0Xfde0ef,0Xf7f7f7,0Xe6f5d0,0Xa1d76a,0X4d9221}, new uint[] {0Xc51b7d,0Xde77ae,0Xf1b6da,0Xfde0ef,0Xe6f5d0,0Xb8e186,0X7fbc41,0X4d9221}, new uint[] {0Xc51b7d,0Xde77ae,0Xf1b6da,0Xfde0ef,0Xf7f7f7,0Xe6f5d0,0Xb8e186,0X7fbc41,0X4d9221}, new uint[] {0X8e0152,0Xc51b7d,0Xde77ae,0Xf1b6da,0Xfde0ef,0Xe6f5d0,0Xb8e186,0X7fbc41,0X4d9221,0X276419}, new uint[] {0X8e0152,0Xc51b7d,0Xde77ae,0Xf1b6da,0Xfde0ef,0Xf7f7f7,0Xe6f5d0,0Xb8e186,0X7fbc41,0X4d9221,0X276419}, } },
                { "PuOr", new uint[][]{ new uint[] {0Xf1a340,0Xf7f7f7,0X998ec3}, new uint[] {0Xe66101,0Xfdb863,0Xb2abd2,0X5e3c99}, new uint[] {0Xe66101,0Xfdb863,0Xf7f7f7,0Xb2abd2,0X5e3c99}, new uint[] {0Xb35806,0Xf1a340,0Xfee0b6,0Xd8daeb,0X998ec3,0X542788}, new uint[] {0Xb35806,0Xf1a340,0Xfee0b6,0Xf7f7f7,0Xd8daeb,0X998ec3,0X542788}, new uint[] {0Xb35806,0Xe08214,0Xfdb863,0Xfee0b6,0Xd8daeb,0Xb2abd2,0X8073ac,0X542788}, new uint[] {0Xb35806,0Xe08214,0Xfdb863,0Xfee0b6,0Xf7f7f7,0Xd8daeb,0Xb2abd2,0X8073ac,0X542788}, new uint[] {0X7f3b08,0Xb35806,0Xe08214,0Xfdb863,0Xfee0b6,0Xd8daeb,0Xb2abd2,0X8073ac,0X542788,0X2d004b}, new uint[] {0X7f3b08,0Xb35806,0Xe08214,0Xfdb863,0Xfee0b6,0Xf7f7f7,0Xd8daeb,0Xb2abd2,0X8073ac,0X542788,0X2d004b } } },
                { "RdBu", new uint[][] { new uint[] {0Xef8a62,0Xf7f7f7,0X67a9cf}, new uint[] {0Xca0020,0Xf4a582,0X92c5de,0X0571b0}, new uint[] {0Xca0020,0Xf4a582,0Xf7f7f7,0X92c5de,0X0571b0}, new uint[] {0Xb2182b,0Xef8a62,0Xfddbc7,0Xd1e5f0,0X67a9cf,0X2166ac}, new uint[] {0Xb2182b,0Xef8a62,0Xfddbc7,0Xf7f7f7,0Xd1e5f0,0X67a9cf,0X2166ac}, new uint[] {0Xb2182b,0Xd6604d,0Xf4a582,0Xfddbc7,0Xd1e5f0,0X92c5de,0X4393c3,0X2166ac}, new uint[] {0Xb2182b,0Xd6604d,0Xf4a582,0Xfddbc7,0Xf7f7f7,0Xd1e5f0,0X92c5de,0X4393c3,0X2166ac}, new uint[] {0X67001f,0Xb2182b,0Xd6604d,0Xf4a582,0Xfddbc7,0Xd1e5f0,0X92c5de,0X4393c3,0X2166ac,0X053061}, new uint[] {0X67001f,0Xb2182b,0Xd6604d,0Xf4a582,0Xfddbc7,0Xf7f7f7,0Xd1e5f0,0X92c5de,0X4393c3,0X2166ac,0X053061}, } },
                { "RdGy", new uint[][] { new uint[] {0Xef8a62,0Xffffff,0X999999}, new uint[] {0Xca0020,0Xf4a582,0Xbababa,0X404040}, new uint[] {0Xca0020,0Xf4a582,0Xffffff,0Xbababa,0X404040}, new uint[] {0Xb2182b,0Xef8a62,0Xfddbc7,0Xe0e0e0,0X999999,0X4d4d4d}, new uint[] {0Xb2182b,0Xef8a62,0Xfddbc7,0Xffffff,0Xe0e0e0,0X999999,0X4d4d4d}, new uint[] {0Xb2182b,0Xd6604d,0Xf4a582,0Xfddbc7,0Xe0e0e0,0Xbababa,0X878787,0X4d4d4d}, new uint[] {0Xb2182b,0Xd6604d,0Xf4a582,0Xfddbc7,0Xffffff,0Xe0e0e0,0Xbababa,0X878787,0X4d4d4d}, new uint[] {0X67001f,0Xb2182b,0Xd6604d,0Xf4a582,0Xfddbc7,0Xe0e0e0,0Xbababa,0X878787,0X4d4d4d,0X1a1a1a}, new uint[] {0X67001f,0Xb2182b,0Xd6604d,0Xf4a582,0Xfddbc7,0Xffffff,0Xe0e0e0,0Xbababa,0X878787,0X4d4d4d,0X1a1a1a}, } },
                { "RdYlBu", new uint[][] { new uint[] {0Xfc8d59,0Xffffbf,0X91bfdb}, new uint[] {0Xd7191c,0Xfdae61,0Xabd9e9,0X2c7bb6}, new uint[] {0Xd7191c,0Xfdae61,0Xffffbf,0Xabd9e9,0X2c7bb6}, new uint[] {0Xd73027,0Xfc8d59,0Xfee090,0Xe0f3f8,0X91bfdb,0X4575b4}, new uint[] {0Xd73027,0Xfc8d59,0Xfee090,0Xffffbf,0Xe0f3f8,0X91bfdb,0X4575b4}, new uint[] {0Xd73027,0Xf46d43,0Xfdae61,0Xfee090,0Xe0f3f8,0Xabd9e9,0X74add1,0X4575b4}, new uint[] {0Xd73027,0Xf46d43,0Xfdae61,0Xfee090,0Xffffbf,0Xe0f3f8,0Xabd9e9,0X74add1,0X4575b4}, new uint[] {0Xa50026,0Xd73027,0Xf46d43,0Xfdae61,0Xfee090,0Xe0f3f8,0Xabd9e9,0X74add1,0X4575b4,0X313695}, new uint[] {0Xa50026,0Xd73027,0Xf46d43,0Xfdae61,0Xfee090,0Xffffbf,0Xe0f3f8,0Xabd9e9,0X74add1,0X4575b4,0X313695}, } },
                { "RdYlGn", new uint[][] { new uint[] {0Xfc8d59,0Xffffbf,0X91cf60}, new uint[] {0Xd7191c,0Xfdae61,0Xa6d96a,0X1a9641}, new uint[] {0Xd7191c,0Xfdae61,0Xffffbf,0Xa6d96a,0X1a9641}, new uint[] {0Xd73027,0Xfc8d59,0Xfee08b,0Xd9ef8b,0X91cf60,0X1a9850}, new uint[] {0Xd73027,0Xfc8d59,0Xfee08b,0Xffffbf,0Xd9ef8b,0X91cf60,0X1a9850}, new uint[] {0Xd73027,0Xf46d43,0Xfdae61,0Xfee08b,0Xd9ef8b,0Xa6d96a,0X66bd63,0X1a9850}, new uint[] {0Xd73027,0Xf46d43,0Xfdae61,0Xfee08b,0Xffffbf,0Xd9ef8b,0Xa6d96a,0X66bd63,0X1a9850}, new uint[] {0Xa50026,0Xd73027,0Xf46d43,0Xfdae61,0Xfee08b,0Xd9ef8b,0Xa6d96a,0X66bd63,0X1a9850,0X006837}, new uint[] {0Xa50026,0Xd73027,0Xf46d43,0Xfdae61,0Xfee08b,0Xffffbf,0Xd9ef8b,0Xa6d96a,0X66bd63,0X1a9850,0X006837} } },
                { "Spectral", new uint[][] { new uint[] {0Xfc8d59,0Xffffbf,0X99d594}, new uint[] {0Xd7191c,0Xfdae61,0Xabdda4,0X2b83ba}, new uint[] {0Xd7191c,0Xfdae61,0Xffffbf,0Xabdda4,0X2b83ba}, new uint[] {0Xd53e4f,0Xfc8d59,0Xfee08b,0Xe6f598,0X99d594,0X3288bd}, new uint[] {0Xd53e4f,0Xfc8d59,0Xfee08b,0Xffffbf,0Xe6f598,0X99d594,0X3288bd}, new uint[] {0Xd53e4f,0Xf46d43,0Xfdae61,0Xfee08b,0Xe6f598,0Xabdda4,0X66c2a5,0X3288bd}, new uint[] {0Xd53e4f,0Xf46d43,0Xfdae61,0Xfee08b,0Xffffbf,0Xe6f598,0Xabdda4,0X66c2a5,0X3288bd}, new uint[] {0X9e0142,0Xd53e4f,0Xf46d43,0Xfdae61,0Xfee08b,0Xe6f598,0Xabdda4,0X66c2a5,0X3288bd,0X5e4fa2}, new uint[] {0X9e0142,0Xd53e4f,0Xf46d43,0Xfdae61,0Xfee08b,0Xffffbf,0Xe6f598,0Xabdda4,0X66c2a5,0X3288bd,0X5e4fa2}, } }
            },

            new Dictionary<string, uint[][]>
            {
                { "Blues", new uint[][] { new uint[] {0Xdeebf7,0X9ecae1,0X3182bd}, new uint[] {0Xeff3ff,0Xbdd7e7,0X6baed6,0X2171b5},new uint[] {0Xeff3ff,0Xbdd7e7,0X6baed6,0X3182bd,0X08519c},new uint[] {0Xeff3ff,0Xc6dbef,0X9ecae1,0X6baed6,0X3182bd,0X08519c},new uint[] {0Xeff3ff,0Xc6dbef,0X9ecae1,0X6baed6,0X4292c6,0X2171b5,0X084594},new uint[] {0Xf7fbff,0Xdeebf7,0Xc6dbef,0X9ecae1,0X6baed6,0X4292c6,0X2171b5,0X084594},new uint[] {0Xf7fbff,0Xdeebf7,0Xc6dbef,0X9ecae1,0X6baed6,0X4292c6,0X2171b5,0X08519c,0X08306b}}},
                { "Greens", new uint[][] {new uint[] {0Xe5f5e0,0Xa1d99b,0X31a354},new uint[] {0Xedf8e9,0Xbae4b3,0X74c476,0X238b45},new uint[] {0Xedf8e9,0Xbae4b3,0X74c476,0X31a354,0X006d2c},new uint[] {0Xedf8e9,0Xc7e9c0,0Xa1d99b,0X74c476,0X31a354,0X006d2c},new uint[] {0Xedf8e9,0Xc7e9c0,0Xa1d99b,0X74c476,0X41ab5d,0X238b45,0X005a32},new uint[] {0Xf7fcf5,0Xe5f5e0,0Xc7e9c0,0Xa1d99b,0X74c476,0X41ab5d,0X238b45,0X005a32},new uint[] {0Xf7fcf5,0Xe5f5e0,0Xc7e9c0,0Xa1d99b,0X74c476,0X41ab5d,0X238b45,0X006d2c,0X00441b}}},
                { "Greys", new uint[][] { new uint[] {0Xf0f0f0,0Xbdbdbd,0X636363}, new uint[] {0Xf7f7f7,0Xcccccc,0X969696,0X525252}, new uint[] {0Xf7f7f7,0Xcccccc,0X969696,0X636363,0X252525}, new uint[] {0Xf7f7f7,0Xd9d9d9,0Xbdbdbd,0X969696,0X636363,0X252525}, new uint[] {0Xf7f7f7,0Xd9d9d9,0Xbdbdbd,0X969696,0X737373,0X525252,0X252525}, new uint[] {0Xffffff,0Xf0f0f0,0Xd9d9d9,0Xbdbdbd,0X969696,0X737373,0X525252,0X252525}, new uint[] {0Xffffff,0Xf0f0f0,0Xd9d9d9,0Xbdbdbd,0X969696,0X737373,0X525252,0X252525,0X000000 } }},
                { "Oranges", new uint[][] { new uint[] {0Xfee6ce,0Xfdae6b,0Xe6550d},new uint[] {0Xfeedde,0Xfdbe85,0Xfd8d3c,0Xd94701},new uint[] {0Xfeedde,0Xfdbe85,0Xfd8d3c,0Xe6550d,0Xa63603},new uint[] {0Xfeedde,0Xfdd0a2,0Xfdae6b,0Xfd8d3c,0Xe6550d,0Xa63603},new uint[] {0Xfeedde,0Xfdd0a2,0Xfdae6b,0Xfd8d3c,0Xf16913,0Xd94801,0X8c2d04},new uint[] {0Xfff5eb,0Xfee6ce,0Xfdd0a2,0Xfdae6b,0Xfd8d3c,0Xf16913,0Xd94801,0X8c2d04},new uint[] {0Xfff5eb,0Xfee6ce,0Xfdd0a2,0Xfdae6b,0Xfd8d3c,0Xf16913,0Xd94801,0Xa63603,0X7f2704},}},
                { "Purples", new uint[][] { new uint[] {0Xefedf5,0Xbcbddc,0X756bb1},new uint[] {0Xf2f0f7,0Xcbc9e2,0X9e9ac8,0X6a51a3},new uint[] {0Xf2f0f7,0Xcbc9e2,0X9e9ac8,0X756bb1,0X54278f},new uint[] {0Xf2f0f7,0Xdadaeb,0Xbcbddc,0X9e9ac8,0X756bb1,0X54278f},new uint[] {0Xf2f0f7,0Xdadaeb,0Xbcbddc,0X9e9ac8,0X807dba,0X6a51a3,0X4a1486},new uint[] {0Xfcfbfd,0Xefedf5,0Xdadaeb,0Xbcbddc,0X9e9ac8,0X807dba,0X6a51a3,0X4a1486},new uint[] {0Xfcfbfd,0Xefedf5,0Xdadaeb,0Xbcbddc,0X9e9ac8,0X807dba,0X6a51a3,0X54278f,0X3f007d}}},
                { "Reds", new uint[][]{new uint[] {0Xfee0d2,0Xfc9272,0Xde2d26},new uint[] {0Xfee5d9,0Xfcae91,0Xfb6a4a,0Xcb181d},new uint[] {0Xfee5d9,0Xfcae91,0Xfb6a4a,0Xde2d26,0Xa50f15},new uint[] {0Xfee5d9,0Xfcbba1,0Xfc9272,0Xfb6a4a,0Xde2d26,0Xa50f15},new uint[] {0Xfee5d9,0Xfcbba1,0Xfc9272,0Xfb6a4a,0Xef3b2c,0Xcb181d,0X99000d},new uint[] {0Xfff5f0,0Xfee0d2,0Xfcbba1,0Xfc9272,0Xfb6a4a,0Xef3b2c,0Xcb181d,0X99000d}, new uint[] {0Xfff5f0,0Xfee0d2,0Xfcbba1,0Xfc9272,0Xfb6a4a,0Xef3b2c,0Xcb181d,0Xa50f15,0X67000d},}},
            },

            new Dictionary<string, uint[][]>
            {
                { "BuGn", new uint[][] { new uint[] {0Xe5f5f9,0X99d8c9,0X2ca25f },new uint[] {0Xedf8fb,0Xb2e2e2,0X66c2a4,0X238b45 },new uint[] {0Xedf8fb, 0Xb2e2e2, 0X66c2a4, 0X2ca25f, 0X006d2c },new uint[] {0Xedf8fb,0Xccece6,0X99d8c9,0X66c2a4,0X2ca25f,0X006d2c },new uint[] {0Xedf8fb,0Xccece6,0X99d8c9,0X66c2a4,0X41ae76,0X238b45,0X005824 },new uint[] {0Xf7fcfd,0Xe5f5f9,0Xccece6,0X99d8c9,0X66c2a4,0X41ae76,0X238b45,0X005824 },new uint[] {0Xf7fcfd,0Xe5f5f9,0Xccece6,0X99d8c9,0X66c2a4,0X41ae76,0X238b45,0X006d2c,0X00441b }}},
                { "BuPu", new uint[][] { new uint[] {0Xe0ecf4,0X9ebcda,0X8856a7 },new uint[] {0Xedf8fb,0Xb3cde3,0X8c96c6,0X88419d},new uint[] {0Xedf8fb,0Xb3cde3,0X8c96c6,0X8856a7,0X810f7c},new uint[] {0Xedf8fb,0Xbfd3e6,0X9ebcda,0X8c96c6,0X8856a7,0X810f7c},new uint[] {0Xedf8fb,0Xbfd3e6,0X9ebcda,0X8c96c6,0X8c6bb1,0X88419d,0X6e016b},new uint[] {0Xf7fcfd,0Xe0ecf4,0Xbfd3e6,0X9ebcda,0X8c96c6,0X8c6bb1,0X88419d,0X6e016b},new uint[] {0Xf7fcfd,0Xe0ecf4,0Xbfd3e6,0X9ebcda,0X8c96c6,0X8c6bb1,0X88419d,0X810f7c,0X4d004b}}},
                { "GnBu", new uint[][] { new uint[] {0Xe0f3db,0Xa8ddb5,0X43a2ca},new uint[] {0Xf0f9e8,0Xbae4bc,0X7bccc4,0X2b8cbe },new uint[] {0Xf0f9e8,0Xbae4bc,0X7bccc4,0X43a2ca,0X0868ac },new uint[] {0Xf0f9e8, 0Xccebc5, 0Xa8ddb5, 0X7bccc4, 0X43a2ca, 0X0868ac },new uint[] {0Xf0f9e8,0Xccebc5,0Xa8ddb5,0X7bccc4,0X4eb3d3,0X2b8cbe,0X08589e },new uint[] {0Xf7fcf0,0Xe0f3db,0Xccebc5,0Xa8ddb5,0X7bccc4,0X4eb3d3,0X2b8cbe,0X08589e },new uint[] {0Xf7fcf0,0Xe0f3db,0Xccebc5,0Xa8ddb5,0X7bccc4,0X4eb3d3,0X2b8cbe,0X0868ac,0X084081 }}},
                { "OrRd", new uint[][] { new uint[] {0Xfee8c8,0Xfdbb84,0Xe34a33},new uint[] {0Xfef0d9,0Xfdcc8a,0Xfc8d59,0Xd7301f},new uint[] {0Xfef0d9, 0Xfdcc8a, 0Xfc8d59, 0Xe34a33, 0Xb30000},new uint[] {0Xfef0d9,0Xfdd49e,0Xfdbb84,0Xfc8d59,0Xe34a33,0Xb30000},new uint[] {0Xfef0d9,0Xfdd49e,0Xfdbb84,0Xfc8d59,0Xef6548,0Xd7301f,0X990000},new uint[] {0Xfff7ec,0Xfee8c8,0Xfdd49e,0Xfdbb84,0Xfc8d59,0Xef6548,0Xd7301f,0X990000},new uint[] {0Xfff7ec,0Xfee8c8,0Xfdd49e,0Xfdbb84,0Xfc8d59,0Xef6548,0Xd7301f,0Xb30000,0X7f0000 }}},
                { "PuBuGn", new uint[][] { new uint[] {0Xece2f0,0Xa6bddb,0X1c9099 },new uint[] {0Xf6eff7,0Xbdc9e1,0X67a9cf,0X02818a },new uint[] {0Xf6eff7,0Xbdc9e1,0X67a9cf,0X1c9099,0X016c59 },new uint[] {0Xf6eff7,0Xd0d1e6,0Xa6bddb,0X67a9cf,0X1c9099,0X016c59 },new uint[] {0Xf6eff7,0Xd0d1e6,0Xa6bddb,0X67a9cf,0X3690c0,0X02818a,0X016450 },new uint[] {0Xfff7fb,0Xece2f0,0Xd0d1e6,0Xa6bddb,0X67a9cf,0X3690c0,0X02818a,0X016450},new uint[] {0Xfff7fb,0Xece2f0,0Xd0d1e6,0Xa6bddb,0X67a9cf,0X3690c0,0X02818a,0X016c59,0X014636 }}},
                { "PuBu", new uint[][] { new uint[] {0Xece7f2,0Xa6bddb,0X2b8cbe},new uint[] {0Xf1eef6,0Xbdc9e1,0X74a9cf,0X0570b0},new uint[] {0Xf1eef6,0Xbdc9e1,0X74a9cf,0X2b8cbe,0X045a8d},new uint[] {0Xf1eef6,0Xd0d1e6,0Xa6bddb,0X74a9cf,0X2b8cbe,0X045a8d},new uint[] {0Xf1eef6,0Xd0d1e6,0Xa6bddb,0X74a9cf,0X3690c0,0X0570b0,0X034e7b},new uint[] {0Xfff7fb,0Xece7f2,0Xd0d1e6,0Xa6bddb,0X74a9cf,0X3690c0,0X0570b0,0X034e7b},new uint[] {0Xfff7fb,0Xece7f2,0Xd0d1e6,0Xa6bddb,0X74a9cf,0X3690c0,0X0570b0,0X045a8d,0X023858}}},
                { "PuRd", new uint[][] { new uint[] {0Xe7e1ef,0Xc994c7,0Xdd1c77},new uint[] {0Xf1eef6,0Xd7b5d8,0Xdf65b0,0Xce1256}, new uint[] {0Xf1eef6,0Xd7b5d8,0Xdf65b0,0Xdd1c77,0X980043},new uint[] {0Xf1eef6,0Xd4b9da,0Xc994c7,0Xdf65b0,0Xdd1c77,0X980043},new uint[] {0Xf1eef6,0Xd4b9da,0Xc994c7,0Xdf65b0,0Xe7298a,0Xce1256,0X91003f},new uint[] {0Xf7f4f9,0Xe7e1ef,0Xd4b9da,0Xc994c7,0Xdf65b0,0Xe7298a,0Xce1256,0X91003f},new uint[] {0Xf7f4f9,0Xe7e1ef,0Xd4b9da,0Xc994c7,0Xdf65b0,0Xe7298a,0Xce1256,0X980043,0X67001f}}},
                { "RdPu", new uint[][] { new uint[] {0Xfde0dd,0Xfa9fb5,0Xc51b8a},new uint[] {0Xfeebe2,0Xfbb4b9,0Xf768a1,0Xae017e},new uint[] {0Xfeebe2,0Xfbb4b9,0Xf768a1,0Xc51b8a,0X7a0177},new uint[] {0Xfeebe2,0Xfcc5c0,0Xfa9fb5,0Xf768a1,0Xc51b8a,0X7a0177},new uint[] {0Xfeebe2,0Xfcc5c0,0Xfa9fb5,0Xf768a1,0Xdd3497,0Xae017e,0X7a0177},new uint[] {0Xfff7f3,0Xfde0dd,0Xfcc5c0,0Xfa9fb5,0Xf768a1,0Xdd3497,0Xae017e,0X7a0177},new uint[] {0Xfff7f3,0Xfde0dd,0Xfcc5c0,0Xfa9fb5,0Xf768a1,0Xdd3497,0Xae017e,0X7a0177,0X49006a}}},
                { "YlGnBu", new uint[][] { new uint[] {0Xedf8b1,0X7fcdbb,0X2c7fb8 }, new uint[] {0Xffffcc,0Xa1dab4,0X41b6c4,0X225ea8 },new uint[] {0Xffffcc, 0Xa1dab4, 0X41b6c4, 0X2c7fb8, 0X253494 }, new uint[] {0Xffffcc,0Xc7e9b4,0X7fcdbb,0X41b6c4,0X2c7fb8,0X253494 },new uint[] {0Xffffcc,0Xc7e9b4,0X7fcdbb,0X41b6c4,0X1d91c0,0X225ea8,0X0c2c84 },new uint[] {0Xffffd9,0Xedf8b1,0Xc7e9b4,0X7fcdbb,0X41b6c4,0X1d91c0,0X225ea8,0X0c2c84 },new uint[] {0Xffffd9,0Xedf8b1,0Xc7e9b4,0X7fcdbb,0X41b6c4,0X1d91c0,0X225ea8,0X253494,0X081d58}}},
                { "YlGn", new uint[][] { new uint[] {0Xf7fcb9,0Xaddd8e,0X31a354},new uint[] {0Xffffcc,0Xc2e699,0X78c679,0X238443},new uint[] {0Xffffcc,0Xc2e699, 0X78c679, 0X31a354,0X006837},new uint[] {0Xffffcc,0Xd9f0a3,0Xaddd8e,0X78c679,0X31a354,0X006837},new uint[] {0Xffffcc,0Xd9f0a3,0Xaddd8e,0X78c679,0X41ab5d,0X238443,0X005a32},new uint[] {0Xffffe5,0Xf7fcb9,0Xd9f0a3,0Xaddd8e,0X78c679,0X41ab5d,0X238443,0X005a32},new uint[] {0Xffffe5,0Xf7fcb9,0Xd9f0a3,0Xaddd8e,0X78c679,0X41ab5d,0X238443,0X006837,0X004529}}},
                { "YlOrBr", new uint[][] { new uint[] {0Xfff7bc,0Xfec44f,0Xd95f0e},new uint[] {0Xffffd4,0Xfed98e,0Xfe9929,0Xcc4c02},new uint[] {0Xffffd4,0Xfed98e,0Xfe9929,0Xd95f0e,0X993404},new uint[] {0Xffffd4,0Xfee391,0Xfec44f,0Xfe9929,0Xd95f0e,0X993404},new uint[] {0Xffffd4,0Xfee391,0Xfec44f,0Xfe9929,0Xec7014,0Xcc4c02,0X8c2d04},new uint[] {0Xffffe5,0Xfff7bc,0Xfee391,0Xfec44f,0Xfe9929,0Xec7014,0Xcc4c02,0X8c2d04},new uint[] {0Xffffe5,0Xfff7bc,0Xfee391,0Xfec44f,0Xfe9929,0Xec7014,0Xcc4c02,0X993404,0X662506}}},
                { "YlOrRd", new uint[][] { new uint[] {0Xffeda0,0Xfeb24c,0Xf03b20},new uint[] {0Xffffb2,0Xfecc5c,0Xfd8d3c,0Xe31a1c},new uint[] {0Xffffb2,0Xfecc5c,0Xfd8d3c,0Xf03b20,0Xbd0026},new uint[] {0Xffffb2,0Xfed976,0Xfeb24c,0Xfd8d3c,0Xf03b20,0Xbd0026},new uint[] {0Xffffb2,0Xfed976,0Xfeb24c,0Xfd8d3c,0Xfc4e2a,0Xe31a1c,0Xb10026},new uint[] {0Xffffcc,0Xffeda0,0Xfed976,0Xfeb24c,0Xfd8d3c,0Xfc4e2a,0Xe31a1c,0Xb10026},new uint[] {0Xffffcc,0Xffeda0,0Xfed976,0Xfeb24c,0Xfd8d3c,0Xfc4e2a,0Xe31a1c,0Xbd0026,0X800026}}},
            }
    };

        #endregion

        /// <summary>
        /// Returns dictionary
        /// Key: Name of color scheme
        /// Index: Index in which matches number of elements for that color scheme
        /// </summary>
        /// <param name="c">Type of color scheme</param>
        /// <param name="numberOfElements">Number of elements within row</param>
        /// <returns>Dictionary</returns>
        public static Dictionary<string, int> ReturnColorSchemeNamesWithNumberOfElements(ColorSchemeType c, int numberOfElements)
        {
            Dictionary<string, int> allColors = new Dictionary<string, int>();

            foreach (string k in colorList[(int)c].Keys)
            {
                allColors[k] = ReturnIndexOfColorArray(c, k, numberOfElements);
            }

            return allColors;
        }

        /// <summary>
        /// Returns a color array for a specific color scheme
        /// </summary>
        /// <param name="c">Color scheme type</param>
        /// <param name="nameOfScheme">Name of color scheme</param>
        /// <param name="index">Index of color scheme. Specific for number of elements</param>
        /// <returns>Color array of specific color scheme</returns>
        public static Color[] ReturnColorArray(ColorSchemeType c, string nameOfScheme, int index)
        {
            List<Color> newList = new List<Color>();

            foreach (uint t in colorList[(int)c][nameOfScheme][index])
                newList.Add(ConvertHexadecimalToColor(t));

            return newList.ToArray();
        }

        /// <summary>
        /// Checks if color scheme has that number of elements.
        /// </summary>
        /// <param name="c">Color scheme category</param>
        /// <param name="key">Name of color scheme</param>
        /// <param name="numberOfElements">Number of elements that column contains</param>
        /// <returns>Returns the index for the appropriate number of colors to access within color scheme.</returns>
        public static int ReturnIndexOfColorArray(ColorSchemeType c, string key, int numberOfElements)
        {
            int min = 0, max = 0;

            for (int i = 0; i < colorList[(int)c][key].Length; i++)
            {
                if (colorList[(int)c][key][i].Length < colorList[(int)c][key][min].Length)
                    min = i;

                if (colorList[(int)c][key][i].Length > colorList[(int)c][key][max].Length)
                    max = i;

                if (numberOfElements == colorList[(int)c][key][i].Length)
                    return i;
            }

            if (numberOfElements < colorList[(int)c][key][min].Length)
                return min;
            else
                return max;
        }

        /// <summary>
        /// Convert hexadecimal value to color
        /// </summary>
        /// <param name="colorVal">uint value of color</param>
        /// <returns>Color of uint</returns>
        public static Color ConvertHexadecimalToColor(uint colorVal)
        {
            int r = (int)colorVal >> 16;
            int g = (int)(colorVal >> 8) & 0xFF;
            int b = (int)colorVal & 0xFF;

            return new Color(r / 255f, g / 255f, b / 255f);
        }
    }
}
