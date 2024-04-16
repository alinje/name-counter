namespace NameCounterTest;

[TestClass]
[DeploymentItem("testFiles")]
public class NameFileCounterTest
{

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void EmptyPath() =>
        WordSearch.FileWordSearch("");


    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void InvalidPath() =>
        WordSearch.FileWordSearch("yodelli++78 hej");
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void DirectoryPath() =>
        WordSearch.FileWordSearch("../In");
    

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void PathNotRepresentingFile() =>
        WordSearch.FileWordSearch("nonExistantFile.txt");


    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void PathWithoutFileName() =>
        WordSearch.FileWordSearch(".ext");
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void LongPathName() =>
        WordSearch.FileWordSearch("path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path\\path");

    [TestMethod]
    [DeploymentItem("testFiles\\subFolder\\fileInSubFolder.txt", "subFolder")]
    public void FileInSubFolder()
    {
        var res = WordSearch.FileWordSearch("subFolder\\fileInSubFolder.txt");
        Assert.AreEqual(2, res);
    }

    [TestMethod]
    public void EmptyFile() {
        var res = WordSearch.FileWordSearch("emptyFile.cs");
        Assert.AreEqual(0, res);
    }

    [TestMethod]
    public void MultInLine() {
        var res = WordSearch.FileWordSearch("multInLine.txt");
        Assert.AreEqual(7, res);
    }

    [TestMethod]
    public void ContainedWord() {
        var res = WordSearch.FileWordSearch("containedWord.txt");
        Assert.AreEqual(5, res);
    }


    [TestMethod]
    public void MultiRowSearch() {
        var res = WordSearch.FileWordSearch("multiRow.txt");
        Assert.AreEqual(3, res);
    }
    
    [TestMethod]
    public void WrongCaseSearch() {
        var res = WordSearch.FileWordSearch("wrongCase.txt");
        Assert.AreEqual(0, res);
    }

        
    [TestMethod]
    public void RepeatingWordSearch() {
        var res = WordSearch.FileWordSearch("aaa.txt");
        Assert.AreEqual(11, res);
    }
}