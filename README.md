# FileTool
FileTool mass renames files using a command line

Parameters:

1) -p Directory Path, this path should contain a list of files that you wish to rename
2) -pr File prefix, set every file name equal to the prefix + the iteration number
3) -ex File extension, by default is "png"


Example Usage:

1) filetool help
2) filetool run -p C:\Directory -r FILEPREFIX
3) filetool run -p C:\Directory -pr FILEPREFIX -ex txt
