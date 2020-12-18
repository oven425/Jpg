# Purpose
Get width,hieght and rotate of exif

```csharp
CJpgReader jr = new CJpgReader();
jr.Parse(sri.Stream);
```

parse jpg get 
Position      | Name  | Size | Data | Requirement
--------------|-------|------| -----|------------------------
6             | FF-E0 | 16   |    0 | Dark Age building x 2
24            | FF-E0 | 67   |  200 | Feudal Age building x 2
93            | FF-DB | 67   |  800 | Castle Age building x 2 
93            | FF-DB | 1000 |  800 | Castle Age building x 2
93            | FF-DB | 1000 |  800 | Castle Age building x 2
93            | FF-DB | 1000 |  800 | Castle Age building x 2
93            | FF-DB | 1000 |  800 | Castle Age building x 2
93            | FF-DB | 1000 |  800 | Castle Age building x 2
93            | FF-DB | 1000 |  800 | Castle Age building x 2
93            | FF-DB | 1000 |  800 | Castle Age building x 2
93            | FF-DB | 1000 |  800 | Castle Age building x 2


FF-E0 - 16 - 6 - 198248
FF-DB - 67 - 24 - 198248
FF-DB - 67 - 93 - 198248
FF-C0 - 17 - 162 - 198248
FF-C4 - 29 - 181 - 198248
FF-C4 - 83 - 212 - 198248
FF-C4 - 27 - 297 - 198248
FF-C4 - 51 - 326 - 198248
FF-DA - 12 - 379 - 198248
