# Name counter
Simple command line program that counts the occurances of a file name (without file extension) inside the file.

## Run instructions
Run executable (can be downloaded as release) with argument string of file name,
ex: `NameCounter.exe "inputFile.txt"`.
One can build the project themselves from top directory with `dotnet build`.
Tests can be run with `dotnet test` in top directory.

## Input assumptions
* Same characters can be used in multiple occurances of the word. Ex. search for "aa" in "aaa" - 2 occurances.
* The search is case sensitive.
* Words can not continue over several lines - newline character breaks a word.
* File name can not be empty. Ex. input ".csproj" is rejected.
* File is UTF-8 encoded.

## Limitations
* While the program should not break for large inputs, it is optimized for smaller inputs.
* Readability has been prioritised over extendability, since it is a very small program.

