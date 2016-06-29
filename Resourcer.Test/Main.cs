using System.Reflection;
using System.Windows.Forms;

namespace Resourcer.Test
{
    public partial class Main : Form
    {
        const string CodeSample1 = @"{\rtf1\deff0{\fonttbl{\f0 Calibri;}{\f1 Microsoft Sans Serif;}}{\colortbl ;\red0\green0\blue255 ;\red0\green112\blue192 ;\red0\green176\blue80 ;\red240\green0\blue0 ;}{\*\defchp \fs22}{\stylesheet {\ql\fs22 Normal;}{\*\cs1\fs22 Default Paragraph Font;}{\*\cs2\sbasedon1\fs22 Line Number;}{\*\cs3\ul\fs22\cf1 Hyperlink;}{\*\ts4\tsrowd\fs22\ql\tscellpaddfl3\tscellpaddl108\tscellpaddfb3\tscellpaddfr3\tscellpaddr108\tscellpaddft3\tsvertalt\cltxlrtb Normal Table;}{\*\ts5\tsrowd\sbasedon4\fs22\ql\trbrdrt\brdrs\brdrw10\trbrdrl\brdrs\brdrw10\trbrdrb\brdrs\brdrw10\trbrdrr\brdrs\brdrw10\trbrdrh\brdrs\brdrw10\trbrdrv\brdrs\brdrw10\tscellpaddfl3\tscellpaddl108\tscellpaddfr3\tscellpaddr108\tsvertalt\cltxlrtb Table Simple 1;}}{\*\listoverridetable}\nouicompat\splytwnine\htmautsp\sectd\pard\plain\ql{\f1\fs17\cf2 var}{\f1\fs17\cf0  result = }{\f1\fs17\cf3 Assembly}{\f1\fs17\cf0 .GetExecutingAssembly().ExtractResource(""{\f1\fs17\cf4 Resourcer.Test.fractal1121017_640.jpg}{\f1\fs17\cf0 "");}\f1\fs17\par\pard\plain\ql{\f1\fs17\cf0 pictureBox1.ImageLocation = result.Location;}\fs22\par}";
        const string CodeSample2 = @"{\rtf1\deff0{\fonttbl{\f0 Calibri;}{\f1 Microsoft Sans Serif;}}{\colortbl ;\red0\green0\blue255 ;\red0\green112\blue192 ;\red0\green176\blue80 ;\red240\green0\blue0 ;}{\*\defchp \fs22}{\stylesheet {\ql\fs22 Normal;}{\*\cs1\fs22 Default Paragraph Font;}{\*\cs2\sbasedon1\fs22 Line Number;}{\*\cs3\ul\fs22\cf1 Hyperlink;}{\*\ts4\tsrowd\fs22\ql\tscellpaddfl3\tscellpaddl108\tscellpaddfb3\tscellpaddfr3\tscellpaddr108\tscellpaddft3\tsvertalt\cltxlrtb Normal Table;}{\*\ts5\tsrowd\sbasedon4\fs22\ql\trbrdrt\brdrs\brdrw10\trbrdrl\brdrs\brdrw10\trbrdrb\brdrs\brdrw10\trbrdrr\brdrs\brdrw10\trbrdrh\brdrs\brdrw10\trbrdrv\brdrs\brdrw10\tscellpaddfl3\tscellpaddl108\tscellpaddfr3\tscellpaddr108\tsvertalt\cltxlrtb Table Simple 1;}}{\*\listoverridetable}\nouicompat\splytwnine\htmautsp\sectd\pard\plain\ql{\f1\fs17\cf2 var}{\f1\fs17\cf0  result = }{\f1\fs17\cf3 Assembly}{\f1\fs17\cf0 .GetExecutingAssembly().ExtractResource(}{\lang1033\langfe1033\f1\fs17\cf0 ""}{\lang1033\langfe1033\f1\fs17\cf4 Resourcer.Test.Some.Random.Folder.fractal-1119594_640.jpg}{\lang1033\langfe1033\f1\fs17\cf0 ""}{\f1\fs17\cf0 );}\f1\fs17\par\pard\plain\ql{\f1\fs17\cf0 pictureBox2.ImageLocation = result.Location;}\fs22\par}";

        public Main()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                richTextBox1.Rtf = CodeSample1;
                var result = Assembly.GetExecutingAssembly().ExtractResource("Resourcer.Test.fractal-1121017_640.jpg");
                pictureBox1.ImageLocation = result.Location;

                richTextBox2.Rtf = CodeSample2;
                result = Assembly.GetExecutingAssembly().ExtractResource("Resourcer.Test.Some.Random.Folder.fractal-1119594_640.jpg");
                pictureBox2.ImageLocation = result.Location;
            };
        }
    }
}
