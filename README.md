# Purpose
Get width,hieght and rotate of exif

```csharp
CJpgReader jpgr = new CJpgReader();
using (FileStream fs = new FileStream("../../photo - 2.jpg", FileMode.Open))
{
    jpgr.Parse(fs);
    string str = ToMarkdownTable(jpgr.Headers);
    //jpgr.Rotate
    //-1:none exif 1:normal 2:mirror 3:
    //jpgr.Headers
    //jpg format list
}
```

parse jpg get 
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
