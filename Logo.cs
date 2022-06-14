using System;
using System.Drawing;

namespace crackturkey
{
    class Logo
    {
        //Birinci bölüm renkleri
        static Color _color1 = Color.FromArgb(82, 188, 231);

        //ikinci bölüm renkleri
        static Color _color2 = Color.FromArgb(82, 188, 231);

        //üçüncü bölüm renkleri
        static Color _color3 = Color.FromArgb(82, 188, 231);


        public static void _Show()
        {
            Console.Clear();
            string line = "\t";
            Console.Write("\n\n");
            Colorful.Console.Write(@"        ", _color3); Colorful.Console.Write(@"██╗███╗   ██╗███████╗████████╗ █████╗  ██████╗ ██████╗  █████╗ ███╗   ███╗" + "\n", _color3);
            Colorful.Console.Write(@"        ", _color3); Colorful.Console.Write(@"██║████╗  ██║██╔════╝╚══██╔══╝██╔══██╗██╔════╝ ██╔══██╗██╔══██╗████╗ ████║" + "\n", _color3);
            Colorful.Console.Write(@"        ", _color3); Colorful.Console.Write(@"██║██╔██╗ ██║███████╗   ██║   ███████║██║  ███╗██████╔╝███████║██╔████╔██║" + "\n", _color3);
            Colorful.Console.Write(@"        ", _color3); Colorful.Console.Write(@"██║██║╚██╗██║╚════██║   ██║   ██╔══██║██║   ██║██╔══██╗██╔══██║██║╚██╔╝██║" + "\n", _color3);
            Colorful.Console.Write(@"        ", _color3); Colorful.Console.Write(@"██║██║ ╚████║███████║   ██║   ██║  ██║╚██████╔╝██║  ██║██║  ██║██║ ╚═╝ ██║" + "\n", _color3);
            Colorful.Console.Write(@"        ", _color3); Colorful.Console.Write(@"╚═╝╚═╝  ╚═══╝╚══════╝   ╚═╝   ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝     ╚═╝" + "\n", _color3);

        }
    }
}
