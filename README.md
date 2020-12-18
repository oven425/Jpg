# Purpose
Get width,hieght and rotate of exif

```csharp
CJpgReader jr = new CJpgReader();
jr.Parse(sri.Stream);
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


