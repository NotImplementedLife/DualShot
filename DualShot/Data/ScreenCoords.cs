using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DualShot.Data
{
    public static class ScreenCoords
    {
        public static Dictionary<string, Dictionary<string, Int32Rect[]>> Data
            = new Dictionary<string, Dictionary<string, Int32Rect[]>>
            {
                { "DSLite", new Dictionary<string, Int32Rect[]>
                    {
                        { "EnamelNavy", new Int32Rect[]
                            {
                                new Int32Rect(128,  37, 219, 163),
                                new Int32Rect(128, 288, 219, 163),
                            }
                        },
                        { "IceBlue", new Int32Rect[]
                            {
                                new Int32Rect(295,  86, 509, 379),
                                new Int32Rect(294, 665, 510, 380),
                            }
                        },
                        { "JetBlack", new Int32Rect[]
                            {
                                new Int32Rect(331,  96, 571, 425),
                                new Int32Rect(329, 746, 572, 426),
                            }
                        },
                        { "LimeGreen", new Int32Rect[]
                            {
                                new Int32Rect(294,  85, 511, 380),
                                new Int32Rect(293, 665, 511, 380),
                            }
                        },
                        { "Pink", new Int32Rect[]
                            {
                                new Int32Rect(330,  96, 571, 425),
                                new Int32Rect(329, 745, 572, 426),
                            }
                        },
                        { "PolarWhite", new Int32Rect[]
                            {
                                new Int32Rect(310,  90, 536, 399),
                                new Int32Rect(309, 700, 537, 400),
                            }
                        },
                        { "Red", new Int32Rect[]
                            {
                                new Int32Rect(295,  85, 509, 379),
                                new Int32Rect(294, 665, 510, 380),
                            }
                        },
                        { "RoseMetal", new Int32Rect[]
                            {
                                new Int32Rect(156,  45, 269, 201),
                                new Int32Rect(155, 351, 269, 201),
                            }
                        },
                    }
                },
                { "DSi", new Dictionary<string, Int32Rect[]>
                    {
                        { "Black", new Int32Rect[]
                            {
                                new Int32Rect(330,  81, 601, 451),
                                new Int32Rect(330, 747, 601, 451),
                            }
                        },
                        { "Blue", new Int32Rect[]
                            {
                                new Int32Rect(330,  80, 601, 451),
                                new Int32Rect(330, 747, 601, 451),
                            }
                        },
                        { "MetallicBlue", new Int32Rect[]
                            {
                                new Int32Rect(330,  81, 601, 451),
                                new Int32Rect(330, 748, 601, 451),
                            }
                        },
                        { "Pink", new Int32Rect[]
                            {
                                new Int32Rect(330,  80, 601, 451),
                                new Int32Rect(330, 748, 601, 451),
                            }
                        },
                        { "Red", new Int32Rect[]
                            {
                                new Int32Rect(330,  81, 601, 451),
                                new Int32Rect(330, 748, 601, 451),
                            }
                        },
                        { "White", new Int32Rect[]
                            {
                                new Int32Rect(330,  80, 601, 451),
                                new Int32Rect(330, 748, 601, 451),
                            }
                        },
                    }
                },
                { "DSiXL", new Dictionary<string, Int32Rect[]>
                    {
                        { "DarkBrown", new Int32Rect[]
                            {
                                new Int32Rect(281,  73, 635, 477),
                                new Int32Rect(281, 733, 635, 477),
                            }
                        },
                        { "Green", new Int32Rect[]
                            {
                                new Int32Rect(281,  73, 635, 477),
                                new Int32Rect(281, 733, 635, 477),
                            }
                        },
                        { "MidnightBlue", new Int32Rect[]
                            {
                                new Int32Rect(281,  73, 635, 477),
                                new Int32Rect(281, 733, 635, 477),
                            }
                        },
                        { "WineRed", new Int32Rect[]
                            {
                                new Int32Rect(281,  73, 635, 477),
                                new Int32Rect(281, 733, 635, 477),
                            }
                        },
                        { "Yellow", new Int32Rect[]
                            {
                                new Int32Rect(281,  73, 635, 477),
                                new Int32Rect(281, 733, 635, 477),
                            }
                        },
                    }
                },                
            };
    }
}
