using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13253020HW1
{
    class Html
    {
        public string CutAttribute(string tag) //taglarin Attribute'lerini kesmek için
        {
            string temp;
            int startIndex;
            int length;
            if (tag.Contains(" ")) // tag'da boşluk varsa
            {
                startIndex = tag.IndexOf(" "); // tag ile attribute arasındaki boşluk karakterinin indexi
                length = tag.IndexOf(">") - startIndex; // attribute uzunluğunu hesaplanması
                temp = tag.Substring(startIndex, length); // attrubute kısmının tempe atılması
                tag = tag.Replace(temp, ""); // attribute'in yer
            }
            return tag;
        }

        public void IsTrue(string fileSource)
        {
            StreamReader read;
            read = File.OpenText(fileSource);
            Stack<string> htmlTags = new Stack<string>(100);
            Html htmlOp = new Html();
            string line;
            while ((line = read.ReadLine()) != null)
            {

                string temp = "";
                for (int i = 0; i < line.Length; i++)
                {

                    temp = "";

                    while (line[i] == '<') // tag açıldığı sürece devam et
                    {
                        while (line[i] != '>') // tag kapanıncaya kadar gerçekleştir
                        {
                            temp += line[i]; // karakteri geçici değerle birleştir
                            i++;
                            if (line.Length != i) // satırın sonuna ulaşmadıysak
                            {
                                if (line[i] == '>')  // i. index 'te tag kapanıyorsa büyüktür işaretini temp'e ekle
                                {
                                    temp += ">";
                                }
                            }
                            else if (line[line.Length - 1] != '>') // satırın sonunda tag kapanmadıysa 
                            {
                                line = read.ReadLine();           //alt satırdan devam et
                                i = 0; // line'nın indexini başa getirmek için
                                temp += " "; //  tag ile attribute arasını açmak için

                            }
                        }

                        ///kontrol kısmı
                        if (!temp.Contains("!DOCTYPE html") && !temp.Contains("br") && !temp.Contains("meta") && !temp.Contains("img")) // tag bu etiketlerden farklı ise kontrol et
                        {

                            htmlTags.Push(htmlOp.CutAttribute(temp));  // taglarin attribute'lerini kes ve stack'e at
                            Console.WriteLine(temp);
                            if (htmlTags.Count() == 1)
                            {
                                if (temp != "<html>")  // html tagından önce ve ya sonra tag olup olmadığının kontrolü
                                {
                                    Console.WriteLine("Geçersiz");
                                    return;
                                }
                            }

                            else if (htmlTags.Count() > 1)
                            {
                                string temp2 = htmlTags.Pop();  // stack'ten iki tane tag çıkar
                                string temp1 = htmlTags.Pop();

                                if (temp2.Contains("/")) // kapalı tag geldiyse (ilk giren son çıktığı için ilk önce pop edilen kapalı etiket olması gerekir)
                                {
                                    if (temp2.Replace("/", "") != temp1) // kapalı tag'daki '/' karakterini kaldırınca eşi olmazsa
                                    {
                                        // taglar doğru kapanmadıysa pop yapılan iki tag'i geri at
                                        htmlTags.Push(temp1);
                                        htmlTags.Push(temp2);
                                    }
                                }
                                else
                                {   // kapalı tag gelmediyse pop yapılan iki tag'i geri at
                                    htmlTags.Push(temp1);
                                    htmlTags.Push(temp2);
                                }

                            }

                        }
                        ///kontrol kısmı
                        i--;
                    }

                }
            }

            read.Close();

            if (htmlTags.IsEmpty())
            {
                Console.WriteLine("Geçerli");
            }
            else
            {
                Console.WriteLine("Geçersiz");
            }
            Console.ReadLine();

        }
        
    }
}