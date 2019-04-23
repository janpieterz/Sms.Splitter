using System.Collections.Generic;

namespace Sms.Splitter.Tests
{
    public static class MessageSplittingTestsData
    {
        #region GSM
        private static readonly List<object[]> GsmData  = new List<object[]>()
        {
            new object[] {
                //Split 160 character message
                "0--------<1--------<2--------<3--------<4--------<5--------<6--------<7--------<8--------<9--------<10-------<11-------<12-------<13-------<14-------<15-------<",
                160,
                160 ,
                new List<SplitPart>() { new SplitPart()
                {
                    Bytes = 160,
                    Characters = 160,
                    Content = "0--------<1--------<2--------<3--------<4--------<5--------<6--------<7--------<8--------<9--------<10-------<11-------<12-------<13-------<14-------<15-------<"
                } }
            },
            new object[]
            {
                //Split 161 character message
                "0--------<1--------<2--------<3--------<4--------<5--------<6--------<7--------<8--------<9--------<10-------<11-------<12-------<13-------<14-------<15-------<1",
                161,
                161,
                new List<SplitPart>()
                {
                    new SplitPart()
                    {
                        Bytes = 153,
                        Characters = 153,
                        Content = "0--------<1--------<2--------<3--------<4--------<5--------<6--------<7--------<8--------<9--------<10-------<11-------<12-------<13-------<14-------<15-"
                    },
                    new SplitPart()
                    {
                        Bytes = 8,
                        Characters = 8,
                        Content = "------<1"
                    }
                }
            },
            new object[]
            {
                //Split 306 character message
                "0--------<1--------<2--------<3--------<4--------<5--------<6--------<7--------<8--------<9--------<10-------<11-------<12-------<13-------<14-------<15-0--------<1--------<2--------<3--------<4--------<5--------<6--------<7--------<8--------<9--------<10-------<11-------<12-------<13-------<14-------<15-",
                306,
                306,
                new List<SplitPart>()
                {
                    new SplitPart()
                    {
                        Content = "0--------<1--------<2--------<3--------<4--------<5--------<6--------<7--------<8--------<9--------<10-------<11-------<12-------<13-------<14-------<15-",
                        Bytes = 153,
                        Characters = 153
                    },
                    new SplitPart()
                    {
                        Content = "0--------<1--------<2--------<3--------<4--------<5--------<6--------<7--------<8--------<9--------<10-------<11-------<12-------<13-------<14-------<15-",
                        Bytes = 153,
                        Characters = 153
                    }
                }
            },
            new object[]
            {
                //Split 307 character message
                "0--------<1--------<2--------<3--------<4--------<5--------<6--------<7--------<8--------<9--------<10-------<11-------<12-------<13-------<14-------<15-0--------<1--------<2--------<3--------<4--------<5--------<6--------<7--------<8--------<9--------<10-------<11-------<12-------<13-------<14-------<15--",
                307,
                307,
                new List<SplitPart>
                {
                    new SplitPart()
                    {
                        Content = "0--------<1--------<2--------<3--------<4--------<5--------<6--------<7--------<8--------<9--------<10-------<11-------<12-------<13-------<14-------<15-",
                        Bytes = 153,
                        Characters = 153
                    },
                    new SplitPart()
                    {
                        Content = "0--------<1--------<2--------<3--------<4--------<5--------<6--------<7--------<8--------<9--------<10-------<11-------<12-------<13-------<14-------<15-",
                        Bytes = 153,
                        Characters = 153
                    },
                    new SplitPart()
                    {
                        Content = "-",
                        Bytes = 1,
                        Characters = 1
                    }
                }
            },
            new object[]
            {
                //Split 160 character message ending with extended character
                "0--------<1--------<2--------<3--------<4--------<5--------<6--------<7--------<8--------<9--------<10-------<11-------<12-------<13-------<14-------<15-------€",
                161,
                161,
                new List<SplitPart> {
                    new SplitPart
                    {
                        Content = "0--------<1--------<2--------<3--------<4--------<5--------<6--------<7--------<8--------<9--------<10-------<11-------<12-------<13-------<14-------<15-",
                        Characters = 153,
                        Bytes = 153
                    },
                    new SplitPart()
                    {
                        Content = "------€",
                        Characters = 8,
                        Bytes = 8
                    }
                }
            },
            new object[]
            {
                //Split 160 character message with an extended character at the 153rd index
                "0--------<1--------<2--------<3--------<4--------<5--------<6--------<7--------<8--------<9--------<10-------<11-------<12-------<13-------<14-------<15€------<",
                161,
                161,
                new List<SplitPart>
                {
                    new SplitPart
                    {
                        Content = "0--------<1--------<2--------<3--------<4--------<5--------<6--------<7--------<8--------<9--------<10-------<11-------<12-------<13-------<14-------<15",
                        Characters = 152,
                        Bytes = 152
                    },
                    new SplitPart
                    {
                        Content = "€------<",
                        Characters = 9,
                        Bytes = 9
                    }
                }
            },
            new object[]
            {
                //Split 80 character message with all extended characters
                "\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\",
                160,
                160,
                new List<SplitPart>
                {
                    new SplitPart
                    {
                        Content = "\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\",
                        Characters = 160,
                        Bytes = 160
                    }
                }
            },
            new object[]
            {
                //Split 304 character message with all extended characters
                "\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}",
                608,
                608,
                new List<SplitPart>
                {
                    new SplitPart
                    {
                        Content = "\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}",
                        Characters = 152,
                        Bytes = 152
                    },
                    new SplitPart
                    {
                        Content = "\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}",
                        Characters = 152,
                        Bytes = 152
                    },
                    new SplitPart
                    {
                        Content = "\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}",
                        Characters = 152,
                        Bytes = 152
                    },
                    new SplitPart
                    {
                        Content = "\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}[~]\\\f|^€{}",
                        Characters = 152,
                        Bytes = 152
                    }
                }
            },
            new object[]
            {
                //Split 160 two-byte character message
                "\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603",
                160,
                160,
                new List<SplitPart>
                {
                    new SplitPart
                    {
                        Content = "                                                                                                                                                                ",
                        Characters = 160,
                        Bytes = 160
                    }
                }
            },
            new object[]
            {
                "\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33",
                160,
                160,
                new List<SplitPart>
                {
                    new SplitPart()
                    {
                        Content = "                                                                                                                                                                ",
                        Characters = 160,
                        Bytes = 160
                    }
                }
            },
            new object[]
            {
                string.Empty,
                0,
                0,
                new List<SplitPart>()
                {
                    new SplitPart
                    {
                        Characters = 0,
                        Content = string.Empty,
                        Bytes = 0
                    }
                }
            }
        };
        #endregion

        #region Unicode

        private static readonly List<object[]> UnicodeData = new List<object[]>()
        {
            //Split 1 character message of 4-byte characters
            new object[]
            {

                "\uD83D\uDC33",
                4,
                2,
                new List<SplitPart>
                {
                    new SplitPart()
                    {
                        Content = "\uD83D\uDC33",
                        Characters = 2,
                        Bytes = 4
                    }
                }
            },
            //Split 3 character message of 4-byte and 2-byte characters
            new object[]
            {
                "\uD83D\uDC33\u2603\uD83D\uDC33",
                10,
                5,
                new List<SplitPart>
                {
                    new SplitPart()
                    {
                        Content = "\uD83D\uDC33\u2603\uD83D\uDC33",
                        Characters = 5,
                        Bytes = 10
                    }
                }
            },
            //Split full single message of 2-byte Basic Multilingual Plane characters
            new object[]
            {
                "\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603",
                140,
                70,
                new List<SplitPart>
                {
                    new SplitPart()
                    {
                        Content = "\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603",
                        Characters = 70,
                        Bytes = 140
                    }
                }
            },
            //Split full single message of 4-byte Supplementary Multilingual Plane characters
            new object[]
            {
                "\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33",
                140,
                70,
                new List<SplitPart>
                {
                    new SplitPart()
                    {
                        Content =  "\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33",
                        Characters = 70,
                        Bytes = 140
                    }
                }
            },
            //Split full single message of mixed Supplementary Multilingual Plane and Basic Multilingual Plane characters
            new object[]
            {
                "\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603",
                140,
                70,
                new List<SplitPart>
                {
                    new SplitPart()
                    {
                        Content = "\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603\uD83D\uDC33\u2603",
                        Characters = 70,
                        Bytes = 140
                    }
                }
            },
            //Split 71 char multipart message of 2-byte Basic Multilingual Plane characters
            new object[]
            {
                "\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603",
                142,
                71,
                new List<SplitPart>
                {
                    new SplitPart
                    {
                        Content = "\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603",
                        Characters = 67,
                        Bytes = 134
                    },
                    new SplitPart
                    {
                        Content = "\u2603\u2603\u2603\u2603",
                        Characters = 4,
                        Bytes = 8
                    }
                }
            },
            //Split 70 char multipart message of 2-byte Basic Multilingual Plane characters with one 4-part Supplementary Multilingual Plane character at the 67th index
            new object[] {
                "\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\uD83D\uDC33\u2603\u2603\u2603",
                142,
                71,
                new List<SplitPart>
                {
                    new SplitPart
                    {
                        Content = "\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603\u2603",
                        Characters = 66,
                        Bytes = 132
                    },
                    new SplitPart
                    {
                        Content = "\uD83D\uDC33\u2603\u2603\u2603",
                        Characters = 5,
                        Bytes = 10
                    }
                }
            },
            //Split 35 char multipart message of 4-byte Supplementary Multilingual Plane characters with one 2-part Basic Multilingual Plane character at the 34th index
            new object[]
            {
                "\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\u2603\uD83D\uDC33",
                138,
                69,
                new List<SplitPart>
                {
                    new SplitPart
                    {
                        Content = "\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\u2603\uD83D\uDC33",
                        Characters = 69,
                        Bytes = 138
                    }
                }
            },
            //Split 36 char multipart message of 4-byte Supplementary Multilingual Plane characters with one 2-part Basic Multilingual Plane character at the 34th index
            new object[]
            {
                "\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\u2603\uD83D\uDC33\uD83D\uDC33",
                142,
                71,
                new List<SplitPart>
                {
                    new SplitPart()
                    {
                        Content = "\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\uD83D\uDC33\u2603",
                        Characters = 67,
                        Bytes = 134
                    },
                    new SplitPart
                    {
                        Content = "\uD83D\uDC33\uD83D\uDC33",
                        Characters = 4,
                        Bytes = 8
                    }
                }
            },
            //Split empty message
            new object[]
            {
                string.Empty,
                0,
                0,
                new List<SplitPart>
                {
                    new SplitPart()
                    {
                        Content = string.Empty
                    }
                }

            }
        };
        #endregion
        public static IEnumerable<object[]> GsmTestData => GsmData;
        public static IEnumerable<object[]> UnicodeTestData => UnicodeData;
    }
}