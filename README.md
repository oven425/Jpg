# Purpose
Get width,hieght and rotate of exif
# Sample code
```csharp
using (FileStream fs = new FileStream("../../photo - 2.jpg", FileMode.Open))
{
    CJpgReader jpgr = new CJpgReader();
    jpgr.Parse(fs);
    //jpgr.Rotate
    //-1:none exif 
    //1:normal 2:mirror
    //3:180    4:180 mirror
    //5:270    6:270 mirror
    //7:90     8:90 mirror
    //jpgr.Headers
    //jpg format list
}
```
# jpg format list
## no exif data
 Position | Name  | Size | Data                  
----------|-------|------|-----------------------
 6        | FF-E0 | 16   |  
 24       | FF-DB | 67   |  
 93       | FF-DB | 67   |  
 162      | FF-C0 | 17   | width:1024 height:718 
 181      | FF-C4 | 29   |  
 212      | FF-C4 | 83   |  
 297      | FF-C4 | 27   |  
 326      | FF-C4 | 51   |  
 379      | FF-DA | 12   |  
 198248   | FF-D9 | 0    |  

## has exif
 Position | Name  | Size | Data                  
----------|-------|------|-----------------------
 6        | FF-E0 | 16   |  
 24       | FF-E1 | 4198 | Rotate:2              
 4224     | FF-E1 | 2269 |  
 6495     | FF-DB | 67   |  
 6564     | FF-DB | 67   |  
 6633     | FF-C0 | 17   | width:1024 height:718 
 6652     | FF-C4 | 29   |  
 6683     | FF-C4 | 83   |  
 6768     | FF-C4 | 27   |  
 6797     | FF-C4 | 51   |  
 6850     | FF-DA | 12   |  
 204719   | FF-D9 | 0    |  
