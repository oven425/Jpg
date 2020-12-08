using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_jpg
{
    public class CJpgHear
    {
        public string Name { set; get; }
        public ushort Size { set; get; }
        public long Pos { set; get; }

    }
    
    public class CJpgReader
    {
        public List<CJpgHear> Headers { set; get; } = new List<CJpgHear>();
        public void Parse(Stream stream)
        {
            //BinaryReader br = new BinaryReader(File.Open("D:\\mobile01-51f74a1e86330f30c9e565237f11e099.jpg", FileMode.Open));
            BinaryReader br = new BinaryReader(File.Open("D:\\photo.jpg", FileMode.Open));
            byte[] header = br.ReadBytes(2);
            while (true)
            {
                header = br.ReadBytes(2);
                CJpgHear jh = new CJpgHear();
                this.Headers.Add(jh);
                jh.Name = BitConverter.ToString(header);
                if(jh.Name == "FF-D9")
                {
                    return;
                }
                jh.Size = br.ReadUInt16LN();
                System.Diagnostics.Trace.WriteLine($"{jh.Name} - {jh.Size} - {br.BaseStream.Position} - {br.BaseStream.Length}");
                
                jh.Pos = br.BaseStream.Position;
                switch (jh.Name)
                {
                    //case "FF-E0":
                    //    {
                    //        string Identifier = Encoding.UTF8.GetString(br.ReadBytes(5));
                    //        byte[] version = br.ReadBytes(2);
                    //        byte Density_units = br.ReadByte();
                    //        short Xdensity = br.ReadInt16LN();
                    //        short Ydensity = br.ReadInt16LN();
                    //        byte XThumbnail = br.ReadByte();
                    //        byte YThumbnail = br.ReadByte();
                    //    }
                    //    break;
                    //case "FF-C0":
                    //    {
                    //        br.ReadByte();
                    //        byte[] widths = br.ReadBytes(2);
                    //        byte[] heights = br.ReadBytes(2);
                    //        int width = widths[0] * 256 + widths[1];
                    //        int height = heights[0] * 256 + heights[1];
                    //        br.ReadByte();
                    //        br.ReadBytes(3);
                    //        br.ReadBytes(3);
                    //        br.ReadBytes(3);
                    //    }
                    //    break;
                    //case "FF-E1":
                    //    {

                    //        string exif = Encoding.UTF8.GetString(br.ReadBytes(4));
                    //        byte[] bb = br.ReadBytes(2);
                    //        while (true)
                    //        {
                    //            long exifbegin = br.BaseStream.Position;
                    //            string mmll = Encoding.UTF8.GetString(br.ReadBytes(2));
                    //            string version = BitConverter.ToString(br.ReadBytesLN(2));
                    //            int offset = br.ReadInt32LN();
                    //            short ifd_count = br.ReadInt16LN();
                    //            for (int i = 0; i < ifd_count; i++)
                    //            {
                    //                ushort tag = br.ReadUInt16LN();
                    //                short type = br.ReadInt16LN();
                    //                int count = br.ReadInt32LN();
                    //                //byte[] bufs = br.ReadBytes(4);
                    //                switch (type)
                    //                {

                    //                    case 3:
                    //                        {
                    //                            short ss = br.ReadInt16LN();
                    //                            br.ReadBytes(2);
                    //                        }
                    //                        break;
                    //                    case 4:
                    //                        {
                    //                            int ii = br.ReadInt32LN();
                    //                        }
                    //                        break;
                    //                    case 7:
                    //                        {

                    //                            int offset1 = br.ReadInt32LN();
                    //                            long oldpos = br.BaseStream.Position;
                    //                            br.BaseStream.Position = exifbegin + offset1;
                    //                            byte[] bbs = br.ReadBytes(count);
                    //                            br.BaseStream.Position = oldpos;
                    //                        }
                    //                        break;
                    //                    default:
                    //                        {

                    //                        }
                    //                        break;
                    //                }


                    //            }
                    //            int nextifd = br.ReadInt32LN();
                    //        }

                    //    }
                    //    break;
                    case "FF-DA":
                        {
                            long sos_size = br.BaseStream.Length - br.BaseStream.Position;
                            byte[] sos_buf = br.ReadBytes((int)sos_size);
                            for(int i= sos_buf.Length-1; i>=0; i--)
                            {
                                if(sos_buf[i]==0xFF && sos_buf[i+1]==0xD9)
                                {
                                    br.BaseStream.Position = jh.Pos + i;
                                    break;
                                }
                            }
                            
                        }
                        break;
                    case "FF-DB"://Define Quantization Table
                    case "FF-C4"://Define Huffman Table
                    default:
                        {
                            header = br.ReadBytes(jh.Size - 2);
                        }
                        break;
                }
            }
        }
    }
}
