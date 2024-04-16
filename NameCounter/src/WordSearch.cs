public static class WordSearch
{
    // 
    /// <summary>
    ///     Name search in file of input path. 
    ///     Counts all occurances of the file name in the file. 
    /// </summary>
    /// <exception cref="ArgumentException">
    ///     If argument path does not represent a file according to specification.
    /// </exception>
    public static int FileWordSearch(string path)
    {
        // input preparation
        if (!File.Exists(path)) // the file might still be removed before finishing program, this give better error messages
        {
            throw new ArgumentException($"Path is invalid, file does not exist or user does not have access to file.\npath: \"{path}\"");
        }
        var fileName = Path.GetFileNameWithoutExtension(path);
        if (fileName.Length == 0)
        {
            throw new ArgumentException("File needs name, not just extension");
        }

        // file reading and search
        var count = 0;
        try {
            using (StreamReader reader = File.OpenText(path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    count += TextWordSearch(fileName, line);
                }
            }
        } catch (FileNotFoundException e)
        {
            throw new ArgumentException("Input file has been removed.", e);
        }
        return count;
    }

    /// <summary>
    /// Searches for number of occurances of a pattern in a text.
    /// </summary>
    private static int TextWordSearch(string pattern, string text)
    {
        var count = -1;
        var indOfFst = -1;

        do {
            count++;
            indOfFst = text.IndexOf(pattern, indOfFst+1, StringComparison.Ordinal);
        } while (indOfFst != -1 && indOfFst+1 < text.Length);

        return count;
    }
}