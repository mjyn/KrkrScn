using System;
using System.IO;
using System.Collections.Generic;

namespace KrkrScn
{
    class Serifu
    {
        public string Voice { get; set; }
        public string Text { get; set; }
        public string Caption { get; set; }
        public string CaptionOverride { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var Input = new List<string>();
            var SerifuDb = new List<Serifu>();
            foreach (string jsonfile in Directory.GetFiles(@"D:\work\sabbat\json", "*.json"))
            {
                Input.Clear();
                string line;
                var inputjson = new StreamReader(jsonfile);
                while ((line = inputjson.ReadLine()) != null)
                {
                    //Console.WriteLine(line);
                    Input.Add(line);
                }


                var filename = Path.GetFileName(jsonfile);
                var filenum = filename.Substring(0, 3);//005
                var findstring = "meg" + filenum + "_";//meg005_

                for (int i = 0; i < Input.Count; i++)
                {
                    if (Input[i].Contains(findstring))
                    {
                        var serifu = new Serifu();
                        serifu.Voice = Input[i].Trim().Substring(11, 10);
                        var text = Input[i - 6].Trim();
                        text = text.Substring(1, text.Length - 3);
                        text = text.Replace("\\\\n", "\n");
                        var caption = Input[i - 8].Trim();
                        var captionoverride = Input[i - 7].Trim();
                        serifu.Text = text;
                        serifu.Caption = caption.Substring(1, caption.Length - 3);
                        serifu.CaptionOverride = captionoverride.Substring(1, captionoverride.Length - 3);
                        SerifuDb.Add(serifu);
                    }
                }

            }

                //var scnjson = new StreamReader("");
        }
    }
}
