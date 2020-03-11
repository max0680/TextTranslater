using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexLinguistics.NET;

namespace TextTranslater
{
    class MyTranslator
    {
      
          

        const string yandex_Key = "trnsl.1.1.20200308T105611Z.9a97950766652eb8.da297e84ecc720f17b17d204e6fba9a7908b0a50";
        public Translator diction;



        public MyTranslator()
         {
                diction = new Translator(yandex_Key);
         }

        public String Translateword (string word)
        {
            string value = word;
            Translation translation = diction.Translate(word, new LangPair(Lang.En, Lang.Ru), null, false);
            value = translation.Text;

                   //    Translate("Семь раз отмерь, один раз отрежь",
                   //new LangPair(Lang.None, Lang.En), null, true);

            return value;

        }

       

    }
}
