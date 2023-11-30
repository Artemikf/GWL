using Gwl.Rename;
using Gwl.Search;
using System.ComponentModel;
using System.Diagnostics;

const string path = @"C:\Users\silver\Desktop\store";

string[] fileMasks =
{
    "*.jpg",
    "*.png",
    "*.bmp",
    "???a?.txt"
};

string[] dirMasks =
{
    ".DS_Store",
    ".vs",
    "bin",
    "debug",
    "obj"
};



#region Finder test
//Finder finder = new Finder(Finder.AnalyzerStrategy.RegexStrategy);

////finder.FindFilesByCondition(path, f => f.Extension == ".exe");
//// finder.FindFilesByCondition(path, f => f.LastWriteTime.Year == 2023);

//// finder.FindDirectoriesByCondition(path, d => d.Name.StartsWith("a"));
////finder.FindDirectoriesByCondition(path, d => d.Name.Length > 3);

////foreach(FileInfo f in finder.Container.Files)
////    Console.WriteLine(f.FullName);

////foreach (DirectoryInfo d in finder.Container.Directories)
////    Console.WriteLine(d.FullName);


//finder.FindFilesByMask(path, fileMasks);
//finder.FindDirectoriesByMask(path, dirMasks);

////foreach(FileInfo f in finder.Container.Files)
////    Console.WriteLine(f.FullName);

//foreach (DirectoryInfo d in finder.Container.Directories)
//    Console.WriteLine(d.FullName);

//Console.WriteLine($"TOTAL SIZE: {CalcDirSize(new DirectoryInfo(path)) / 1024 / 1024} Mb");

//long deletedSize = 0;
//foreach (DirectoryInfo d in finder.Container.Directories)
//    deletedSize += CalcDirSize(d);
//Console.WriteLine($"DELETED SIZE: {deletedSize / 1024 / 1024} Mb");







//long CalcDirSize(DirectoryInfo d)
//{
//    long size = 0;

//    FileInfo[] fis = d.GetFiles();
//    foreach (FileInfo fi in fis)
//    {
//        size += fi.Length;
//    }

//    DirectoryInfo[] dis = d.GetDirectories();
//    foreach (DirectoryInfo di in dis)
//    {
//        size += CalcDirSize(di);
//    }

//    return size;
//} 
#endregion

#region Renamer test
Finder finder = new Finder(Finder.AnalyzerStrategy.RegexStrategy);
finder.FindFilesByMask(path, fileMasks);

Renamer renamer = new Renamer(finder.Container);
renamer.RenameFiles(@"img_<uuid>");







#endregion

